# Getting a few environment variables we need
[String]$buildID="$env:BUILD_BUILDID"
[String]$project="$env:SYSTEM_TEAMPROJECT"

# Setting up basic authentication 

$username="infy.devops.poc2@outlook.com"
$password="vyg76y3zdxz4tx6pqe6qhreub4yc75ijzl77mvcduy3qw3fifbpa"
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

$urlTestRun="https://infosysdevops.visualstudio.com/defaultCollection/"+$project+"/_apis/test/runs?api-version=1.0&buildUri=vstfs:///Build/Build/"+$buildID

Write-Host $urlTestRun
$responseTestRun= (Invoke-RestMethod -Uri $urlTestRun -headers $headers -Method Get).value | select id
Write-Host $responseTestRun
 $testrunID="0";
foreach($id in $responseTestRun.id)
{
    $testrunID=$id
}

$urlTestResult="https://infosysdevops.visualstudio.com/defaultCollection/"+$project+"/_apis/test/runs/"+$testrunID+"/results?api-version=3.0-preview"
Write-Host $urlTestResult
$responseTestResult= (Invoke-RestMethod -Uri $urlTestResult -headers $headers -Method Get).value
foreach($testcase in $responseTestResult)
{
    if($testcase.outcome -eq "Failed")
    {
        $getDefectUrl = 'http://infosysjira/rest/api/2/search?jql=summary~%22'+$testcase.automatedTestName+'%22'
        $getDefectResponse = (Invoke-RestMethod -Uri $getDefectUrl -headers $jiraheaders -Method Get).issues
        Write-Host $getDefectResponse
        Write-Host $getDefectResponse.count
        if($getDefectResponse.count -gt 0)
        {
            foreach($def in $getDefectResponse)
            {
                $addCommentURL='http://infosysjira/rest/api/2/issue/'+$def.key+'/comment'
                $addCommentBody = '{"body":"UT Test case '+$testcase.automatedTestName+' has Failed in Build '+$testcase.build.name+'"}';
                $addCommenResponse = Invoke-RestMethod -Uri $addCommentURL -headers $jiraheaders -Method Post  -Body $addCommentBody -ContentType application/json
                Write-Host $addCommenResponse
            }
        }
        else
        {
            $defectJSON='{ "fields":{"summary":"UT Test case '+$testcase.automatedTestName+' has Failed in Build '+$testcase.build.name+'","description":"UT Test case '+$testcase.automatedTestName+' has Failed in Build '+$testcase.build.name+'","priority":{"name":"Medium"},"issuetype":{"name":"Bug"},"project":{"key":"ADMSTP"}}}'
            Write-Host $defectJSON
            $defectURL = 'http://infosysjira/rest/api/2/issue/'
            $defectResponse = Invoke-RestMethod -Uri $defectURL -headers $jiraheaders -Method Post  -Body $defectJSON -ContentType application/json
            Write-Host $defectResponse
        }
    }
}
