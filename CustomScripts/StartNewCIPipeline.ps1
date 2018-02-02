param(

       # Getting the CI Pipeline Name as an argument

       [String] $DefinitionName="TestByArsh"

)

Write-Host "Next Pipeline is "-nonewline; Write-Host $DefinitionName


# Getting a few environment variables we need

[String]$project="$env:SYSTEM_TEAMPROJECT"


#[String]$project="BankingApplication"
 

# Setting up basic authentication 

$username="infy.devops.poc2@outlook.com"

$password="vyg76y3zdxz4tx6pqe6qhreub4yc75ijzl77mvcduy3qw3fifbpa"

 

$basicAuth= ("{0}:{1}"-f $username,$password)

$basicAuth=[System.Text.Encoding]::UTF8.GetBytes($basicAuth)

$basicAuth=[System.Convert]::ToBase64String($basicAuth)

$headers= @{Authorization=("Basic {0}"-f$basicAuth)}
$urlGET="https://infosysdevops.visualstudio.com/defaultCollection/"+$project+"/_apis/build/definitions?api-version=2.0&name="+$DefinitionName

$buildDefs = (Invoke-RestMethod -headers $headers -Method Get -Uri $urlGET).value | select id
$buildDefID = 8
foreach($id in $buildDefs.id)
{
$buildDefID=$id
}
$json = "definition: { id:$buildDefID }"
$json = "{ $json }"

$url= "https://infosysdevops.visualstudio.com/defaultCollection/"+$project+"/_apis/build/builds?api-version=2.0-preview"

Write-Host $url

Write-Host $headers

Write-Host $json

$responseBuild= Invoke-RestMethod -Uri $url -headers $headers -Method Post  -Body $json -ContentType application/json

Write-Host $responseBuild