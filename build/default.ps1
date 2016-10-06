properties {
	$pwd = Split-Path $psake.build_script_file	
	$build_directory  = "$pwd\output\condep-dsl-operations-azure"
	$configuration = "Release"
	$releaseNotes = ""
	$nunitPath = "$pwd\..\src\packages\NUnit.ConsoleRunner.3.4.1\tools"
	$nuget = "$pwd\..\tools\nuget.exe"
}
 
include .\..\tools\psake_ext.ps1

Framework '4.6x64'

function GetNugetAssemblyVersion($assemblyPath) {
	$versionInfo = Get-Item $assemblyPath | % versioninfo

	return "$($versionInfo.FileVersion)"
}

task default -depends Build-All, Test-All, Pack-All

task Build-All -depends Clean, RestoreNugetPackages, Build
task Test-All -depends Test
task Pack-All -depends Create-BuildSpec-ConDep-Dsl-Operations-Azure, Pack-ConDep-Dsl-Operations-Azure

task RestoreNugetPackages {
	Exec { & $nuget restore "$pwd\..\src\condep-dsl-operations-azure.sln" }
}

task Build {
	Exec { msbuild "$pwd\..\src\condep-dsl-operations-azure.sln" /t:Build /p:Configuration=$configuration /p:OutDir=$build_directory /p:GenerateProjectSpecificOutputFolder=true}
}

task Test {
	Exec { & $nunitPath\nunit3-console.exe $build_directory\ConDep.Dsl.Operations.Azure.Tests\ConDep.Dsl.Operations.Azure.Tests.dll --work=".\output" }
}

task Clean {
	Write-Host "Cleaning Build output.."  -ForegroundColor Green
	Remove-Item $build_directory -Force -Recurse -ErrorAction SilentlyContinue
}

task Create-BuildSpec-ConDep-Dsl-Operations-Azure {
    Write-Host "Creating nuget spec file.."  -ForegroundColor Green
	Generate-Nuspec-File `
		-file "$build_directory\condep.dsl.operations.azure.$(GetNugetAssemblyVersion $build_directory\ConDep.Dsl.Operations.Azure\ConDep.Dsl.Operations.Azure.dll).nuspec" `
		-version $(GetNugetAssemblyVersion $build_directory\ConDep.Dsl.Operations.Azure\ConDep.Dsl.Operations.Azure.dll) `
		-id "ConDep.Dsl.Operations.Azure" `
		-title "ConDep.Dsl.Operations.Azure" `
		-licenseUrl "http://www.con-dep.net/license/" `
		-projectUrl "http://www.con-dep.net/" `
		-description "Note: This package is for extending the ConDep DSL with operations for Azure." `
		-iconUrl "https://raw.github.com/condep/ConDep/master/images/ConDepNugetLogo.png" `
		-releaseNotes "$releaseNotes" `
		-tags "Continuous Deployment Delivery Infrastructure WebDeploy Deploy msdeploy IIS automation powershell remote aws azure" `
		-dependencies @(
			@{ Name="ConDep.Dsl"; Version="[5.0.0-beta95,6)"},
			@{ Name="Newtonsoft.Json"; Version="[6.0.6,7)"},
			@{ Name="SlowCheetah.Tasks.Unofficial"; Version="[1.0.0]"},
			@{ Name="Microsoft.AspNet.WebApi.Client"; Version="[4.0.30506]"}
		) `
		-files @(
			@{ Path="ConDep.Dsl.Operations.Azure\ConDep.Dsl.Operations.Azure.dll"; Target="lib/net40"}
		)
}

task Pack-ConDep-Dsl-Operations-Azure {
    Write-Host "Creating nuget package.."  -ForegroundColor Green
	Exec { & $nuget pack "$build_directory\condep.dsl.operations.azure.$(GetNugetAssemblyVersion $build_directory\ConDep.Dsl.Operations.Azure\ConDep.Dsl.Operations.Azure.dll).nuspec" -OutputDirectory "$build_directory" }
}