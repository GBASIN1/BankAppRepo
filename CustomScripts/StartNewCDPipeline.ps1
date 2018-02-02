param(
       # Getting the CD pipeline name,artifact version as arguments
       [String] $CDPipeline="TFSBankApp_SIT_Rel",
       [String] $CIPipeline="BankAppBuildDefinition",
	   [String] $TFSCollectionPath = "http://victadpst-03:8080/tfs/defaultcollection/"
	)
Write-Host "Next CD Pipeline is "-nonewline; Write-Host $CDPipeline
Write-Host "Artifact Source is "-nonewline; Write-Host $CIPipeline
Write-Host "TFS DefaultCollection path is :" + $TFSCollectionPath
# Getting a few environment variables we need

#[String]$project="$env:SYSTEM_TEAMPROJECT"
[String] $project = "CICDTeamProject"

#[String]$project="BankingApplication"
 

# Setting up basic authentication 

#$username="infy.devops.poc2@outlook.com"

#$password="vyg76y3zdxz4tx6pqe6qhreub4yc75ijzl77mvcduy3qw3fifbpa"

 

$basicAuth= ("{0}:{1}"-f $username,$password)

$basicAuth=[System.Text.Encoding]::UTF8.GetBytes($basicAuth)

$basicAuth=[System.Convert]::ToBase64String($basicAuth)

$headers= @{Authorization=("Basic {0}"-f$basicAuth)}

# http://victadpst-03:8080/tfs/defaultcollection/CICDTeamProject/_apis/release/definitions?api-version=2.2-preview.1
$urlGET=$TFSCollectionPath + $project+"/_apis/release/definitions?api-version=2.2-preview.1"

$relDefs = Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $urlGET | select value
$relDefID = 0
foreach($rel in $relDefs.value)
{
if($rel.name -eq $CDPipeline)
    {
        $relDefID=$rel.id
    }
}
# test http://victadpst-03:8080/tfs/defaultcollection/CICDTeamProject/_apis/build/definitions?api-version=2.0&name=BankAppBuildDefinition

$urlGETBD= $TFSCollectionPath+$project+"/_apis/build/definitions?api-version=2.0&name="+$CIPipeline

$buildDefs = (Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $urlGETBD).value | select id
$buildDefID = 8
foreach($id in $buildDefs.id)
{
$buildDefID=$id
}
#http://victadpst-03:8080/tfs/defaultcollection/CICDTeamProject/_apis/build/builds?api-version=2.0&definitions=1
$urlGETBuilds=$TFSCollectionPath+$project+"/_apis/build/builds?api-version=2.0&definitions="+$buildDefID

$builds = Invoke-RestMethod -UseDefaultCredentials -Method Get -Uri $urlGETBuilds | select value
$artifactID=0
$buildname = ""
foreach($bu in $builds.value)
{
if($bu.result -eq "succeeded")
    {
        $artifactID=$bu.id
		$buildname = $bu.buildNumber
        break
    }
}
write-Host "Build Name :" + $buildname

$json = '{ "definitionId": '+$relDefID+',"artifacts": [{"alias": "'+$CIPipeline+'","instanceReference": {"id": "'+$artifactID+'", "name": "'+ $buildname +'"}}]}'

#http://victadpst-03:8080/tfs/defaultcollection/CICDTeamProject/_apis/release/releases?api-version=2.2-preview.1
$url= $TFSCollectionPath+$project+"/_apis/release/releases?api-version=2.2-preview.1"

Write-Host $url

Write-Host "jSON:"  $json

$responseBuild= Invoke-RestMethod -Uri $url -UseDefaultCredentials -Method Post  -Body $json -ContentType application/json

$json = ConvertTo-Json -InputObject $responseBuild
Write-Host "Response:" $json