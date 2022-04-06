param(

       # Getting the CI Pipeline Name as an argument
       [String] $VSTSCollectionPath = "https://infosysdevops.vsrm.visualstudio.com/defaultCollection/",
       [String] $VSTSBuild_Rel_Dep_Path="E:\Charmi\VSTS_Build_Rel_Dependency.xml",
       [String] $VSTS_TeamProject = "BankingApplication"
)

$username=""
$password=""
$basicAuth= ("{0}:{1}"-f $username,$password)
$basicAuth=[System.Text.Encoding]::UTF8.GetBytes($basicAuth)
$basicAuth=[System.Convert]::ToBase64String($basicAuth)
$headers= @{Authorization=("Basic {0}"-f$basicAuth)}

[xml]$XmlDocument = Get-Content -Path $VSTSBuild_Rel_Dep_Path
$ndlist = $XmlDocument.SelectSingleNode("/VSTS/BuildDef")
foreach ($testCaseNode in $ndlist.ChildNodes) 
{
    $build_dDefNameNode = $testCaseNode.SelectSingleNode("Name");
    $ReleaseDef_node_lst = $testCaseNode.SelectSingleNode("ReleaseDef")
    $urlGetBuildDefId = $VSTSCollectionPath + $VSTS_TeamProject + "/_apis/build/definitions?api-version=2.0&name="+$build_dDefNameNode.InnerText
    $buildDefs = (Invoke-RestMethod -headers $headers -Method Get -Uri $urlGetBuildDefId).value | select id
    $buildDefID = $buildDefs.id
    $json = "definition: { id:"+ $buildDefID +" }"
    $json = "{ $json }"
    $url= $VSTSCollectionPath + $VSTS_TeamProject +"/_apis/build/builds?api-version=2.0"
    $responseBuild = Invoke-RestMethod -Uri $url -headers $headers -Method Post  -Body $json -ContentType application/json
    write-host "Triggered build json:" $responseBuild
    $timeout = new-timespan -Minutes 15
    $sw = [diagnostics.stopwatch]::StartNew()

    $isBuildFinished = "false"
    $buildStatus = "failed"
    $curr_build_id = $responseBuild.id
    while ($sw.elapsed -lt $timeout)
    {
        $build_Queued_url = $VSTSCollectionPath + $VSTS_TeamProject +"/_apis/build/builds/"+$responseBuild.id+"?api-version=2.0"
        $Queued_Build_Response = Invoke-RestMethod -Uri $build_Queued_url -headers $headers -Method Get 
        foreach ($testCaseNode in $ndlist) 
        {
            write-host "Build state for" $Queued_Build_Response.id "is"  $Queued_Build_Response.status
            if($Queued_Build_Response.status -eq "completed")
            { 
                $isBuildFinished = "true"
                if($Queued_Build_Response.result -eq "failed")
                {
                    write-host "Build " $responseBuild.buildNumber "completed with status failed for " $build_dDefNameNode.InnerText
                }
                else
                {
                    $buildStatus = "succeeded"
                    write-host "Build "$responseBuild.buildNumber "completed with status" $Queued_Build_Response.result "for "$build_dDefNameNode.InnerText
                }
         
            }
        }
        if($isBuildFinished -eq "true")
        {
                break;
        }
        else
        {
            start-sleep -seconds 30
        }
        
    }
    #end of while loop

    if($buildStatus -eq "succeeded")
    {
         foreach($rel_def_node in $ReleaseDef_node_lst.ChildNodes)
         {
            $rel_def_Name = $rel_def_node.InnerText
            write-host "Rel Def name:" $rel_def_Name
            #$url= $VSTSCollectionPath + $VSTS_TeamProject +"/_apis/release/definitions?api-version=3.0-preview.1"
            $url = $VSTSCollectionPath + $VSTS_TeamProject + "/_apis/release/definitions?api-version=3.0-preview.1"
            $ReleaseDefs = (Invoke-RestMethod -Uri $url -headers $headers -Method GET).value
            $rel_def_id = 5;
            foreach($def in $ReleaseDefs)
            {
                if($def.name -eq $rel_def_Name)
                {
                    $rel_def_id = $def.id;
                    write-host "Def name found and rel def id:" $rel_def_id
                    break;
                }
            }
            $url = $VSTSCollectionPath + $VSTS_TeamProject + "/_apis/release/releases?definitionId="+$rel_def_id+"&api-version=3.0-preview.1"
            $listOfReleases = (Invoke-RestMethod -Uri $url -headers $headers -Method GET).value
            $foundRel= "false";
            foreach($def in $listOfReleases)
            {
               $release_id = $def.id
               write-host "Rel ID:" $release_id
               #if($release_id -eq 272)
               #{
                   $url = $VSTSCollectionPath + $VSTS_TeamProject + "/_apis/release/releases/"+$release_id+"?api-version=3.0-preview.1"
                   $rel_details = Invoke-RestMethod -Uri $url -headers $headers -Method GET
                   foreach($artifact in $rel_details.artifacts)
                   {
                     if($artifact.definitionReference.version.id -eq $curr_build_id)
                     {
                        $foundRel = "true";
                        break;
                     }

                   }
                   if($foundRel)
                   {
                       write-host "Rel found linked with build.Release id:"$release_id 
                       foreach($env in $rel_details.environments)
                       {
                            Write-Host "Env name and status:" $env.name  ":" $env.status
                            $env_status = $env.status
                            $env_name = $env.name
                            if(($env_status -eq "inProgress") -or ($env_status -eq "notStarted"))
                            {
                                #start-sleep -seconds 30
                                $tm_out = new-timespan -Minutes 15
                                $swatch = [diagnostics.stopwatch]::StartNew()

                                $isBuildFinished = "false"
                                $buildStatus = "failed"
                                while ($swatch.elapsed -lt $tm_out)
                                {
                                    $envuri = $VSTSCollectionPath + $VSTS_TeamProject + "/_apis/release/releases/"+$release_id+"/Environments/"+$env.ID+"?api-version=3.0-preview.1"
                                    $env_details = Invoke-RestMethod -Uri $envuri -headers $headers -Method GET
                                    write-host "In while loop: Env: "$env_details.name "status: "  $env_details.status
                                    if(($env_details.status -eq "inProgress") -or ($env_details.status -eq "notStarted"))
                                    {
                                        start-sleep -seconds 30;
                                    }
                                    else
                                    {
                                        $env_status = $env_details.status
                                        $env_name = $env_details.name
                                        break;   
                                    }
                                }
                            }
                        
                            if($env_status -ne "succeeded")
                            {
                                write-host "Release status of release def " $rel_def_Name " is not completed sucessfully"
                                write-host "Env name:" $env_name "and Env Status:" $env_status
                                break;
                            }
                    
                       }
                       break; 
                   }
                   else
                   {
                     write-host "Release corresponding to Build def has not been triggered"
                   }

               
               #}
            }

         }
        
         
        #http://victadpst-03:8080/tfs/DefaultCollection/CICDTeamProject/_apis/release/definitions?api-version=3.0-preview.1
    }


}
