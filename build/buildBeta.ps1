Write-Host "Getting latest Azure beta package.."
$latestVersionId = ..\tools\nuget.exe list "ConDep.Dsl.Operations.Azure" -ConfigFile "..\src\.nuget\nuget.config" -Prerelease
$latestBetaNumber = $latestVersionId.Split('-') | Select-Object -Last 1 |  % {$_.replace("beta","")}

Write-Host "Latest beta package is beta$latestBetaNumber. Upping to new number.."
$nextBetaNumber = ([int]$latestBetaNumber + 1).ToString()
Write-Host "Next package will be beta$nextBetaNumber."

Invoke-psake .\default.ps1 -properties @{"preString"="-beta$nextBetaNumber"}