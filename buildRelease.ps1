Import-Module .\tools\psake.psm1

Invoke-psake .\build\default.ps1 -properties @{"preString"=""}

if (!($psake.build_success)) {    throw "Error when building"}