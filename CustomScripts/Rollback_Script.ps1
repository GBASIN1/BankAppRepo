param(       
       [String] $RelID="0",
       [String] $RelDefId="0",
	   [String] $TFSCollectionPath = "http://victadpst-03:8080/tfs/defaultcollection/"
)
Write-Host "Current release ID $RelID"
Write-Host "TfsDefaultcollection path $TFSCollectionPath"
Write-Host "Current Release Def ID $RelDefId"

[String]$project="$env:SYSTEM_TEAMPROJECT"
#[String] $project = "CICDTeamProject"

$basicAuth= ("{0}:{1}"-f $username,$password)
$basicAuth=[System.Text.Encoding]::UTF8.GetBytes($basicAuth)
$basicAuth=[System.Convert]::ToBase64String($basicAuth)
$headers= @{Authorization=("Basic {0}"-f$basicAuth)}

$jirausername="sarita02"
$jirapassword="sarita@13"
$jirabasicAuth= ("{0}:{1}"-f $jirausername,$jirapassword)
$jirabasicAuth=[System.Text.Encoding]::UTF8.GetBytes($jirabasicAuth)
$jirabasicAuth=[System.Convert]::ToBase64String($jirabasicAuth)
$jiraheaders= @{Authorization=("Basic {0}"-f$jirabasicAuth)}



$UrlGetCurrentRelease = $TFSCollectionPath + $project+"/_apis/release/releases/"+$RelID+"?api-version=2.2-preview.1"
$release = Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $UrlGetCurrentRelease 
Write-Host "URL for current release Is $UrlGetCurrentRelease"
$PrevEnvStatus = "Success"
foreach($env in $release.environments)
{
    Write-Host "Env name and status:" $env.name + ":" $env.status
    if($PrevEnvStatus -eq "Success" -And $env.status -ne "notStarted")
    {
        Write-Host "In ENV Loop - Env ID "$env.Id
        $urlGET= $TFSCollectionPath + $project+"/_apis/release/releases/"+$RelID+"/environments/"+$env.Id+"/tasks?api-version=2.2-preview.1"
        #$urlGET="http://victadpst-03:8080/tfs/defaultcollection/CICDTeamProject/_apis/release/releases/7/environments/7/tasks?api-version=2.2-preview.1"
        Write-Host "URL Is $urlGET"
        $tasks = (Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $urlGET).value | select name,status

            foreach($task in $tasks)
            {
                       Write-Host 'Task "'$task.name'" has completed with status "'$task.status'"'
                       if($task.status -eq "failure")
                       {
                           $PrevEnvStatus = "failure"
                           #Commented the Jira defect creation as there is a connectivity issue to infosysjira from hosted azure agent(Jira defect creation working fine with On-Premise agent)
                           #$defectJSON='{ "fields":{"summary":"Task '+$task.name+' has Failed in Release","description":" No Description Available","priority":{"name":"Medium"},"issuetype":{"name":"Bug"},"project":{"key":"ADMSTP"}}}'
                           #Write-Host $defectJSON
                           #$defectURL = 'http://infosysjira/rest/api/2/issue/'
                           #$defectResponse = Invoke-RestMethod -Uri $defectURL -headers $jiraheaders -Method Post  -Body $defectJSON -ContentType application/json
                           #Write-Host $defectResponse

                           $UrlGetReleases =  $TFSCollectionPath +$project+"/_apis/release/releases?api-version=2.2-preview.1&definitionId=$RelDefId"

                           #$UrlGetReleases = "http://victadpst-03:8080/tfs/defaultcollection/CICDTeamProject/_apis/release/releases?api-version=2.2-preview.1&definitionid=1"

                           $releases = (Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $UrlGetReleases).value | select id
                           foreach($rel in $releases)
                           {
                               Write-Host "In releases Loop "$rel.id
                               $UrlGetRelease =  $TFSCollectionPath +$project+"/_apis/release/releases/"+$rel.id+"?api-version=2.2-preview.1"
                               $release = Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $UrlGetRelease 
                               $flag =$false
                               foreach($env in $release.environments)
                               {
                                   Write-Host "In ENV Loop "$env.status
                                   if($env.status -eq "succeeded")
                                   {
                                       $flag=$true
                                   }
                                   else
                                   {
                                       $flag=$false
                                       break
                                   }               
                               }
                               if($flag)
                               {
                                   Write-Host "Last Successful Deployment happened in Release "$release.name
                           
                                   Write-Host "Release ID" $release.id
                           
                                   $rollbackJSON = '{ "definitionId": '+$RelDefId+', "description": "' + $release.description +'" ,"artifacts": ['
                                   foreach($art in $release.artifacts)
                                   {
                                       $rollbackJSON = $rollbackJSON + '{"alias": "'+$art.alias+'","instanceReference": {"id": "'+$art.definitionReference.version.id+'", "name": "'+ $art.definitionReference.version.name +'"}},'
                                   }
                                   $rollbackJSON = $rollbackJSON.TrimEnd(',') + ']}'
                                   Write-Host $rollbackJSON

                                   Write-Host "Invoke release now"

			                       $urlInvokeRelease= $TFSCollectionPath + $project +"/_apis/release/releases?api-version=2.2-preview.1"

                                   $responseInvokeRelease= Invoke-RestMethod -Uri $urlInvokeRelease -UseDefaultCredentials -Method Post  -Body $rollbackJSON -ContentType application/json

                                   Write-Host $responseInvokeRelease
                                   break
                               }
                           }
                           break
                       }
            }
    }
} 
