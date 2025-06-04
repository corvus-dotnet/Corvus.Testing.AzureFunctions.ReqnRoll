<#
This example demonstrates a software build process using the 'ZeroFailed.Build.DotNet' extension
to provide the features needed when building a .NET solutions.
#>

$zerofailedExtensions = @(
    @{
        # References the extension from its GitHub repository. If not already installed, use latest version from 'main' will be downloaded.
        Name = "ZeroFailed.Build.DotNet"
        GitRepository = "https://github.com/zerofailed/ZeroFailed.Build.DotNet"
        GitRef = "main"
    }
)

# Load the tasks and process
. ZeroFailed.tasks -ZfPath $here/.zf


#
# Build process configuration
#
#
# Build process control options
#
$SkipInit = $false
$SkipVersion = $false
$SkipBuild = $false
$CleanBuild = $Clean
$SkipTest = $false
$SkipTestReport = $false
$SkipAnalysis = $false
$SkipPackage = $false


$SolutionToBuild = (Resolve-Path (Join-Path $here "Solutions/Corvus.Testing.AzureFunctions.ReqnRoll.sln")).Path
$ProjectsToPublish = @()
$NuSpecFilesToPackage = @()
$NugetPublishSource = property ZF_NUGET_PUBLISH_SOURCE "$here/_local-nuget-feed"
$IncludeAssembliesInCodeCoverage = "Corvus.Testing.AzureFunctions*"
$ExcludeAssembliesInCodeCoverage = "Corvus.Testing.AzureFunctions*Demo*"


# Customise the build process
task installAzureFunctionsSDK {
    
    $existingVersion = ""
    if ((Get-Command func -ErrorAction Ignore)) {
        $existingVersion = exec { & func --version }
    }

    if (!$existingVersion -or $existingVersion -notlike "4.*") {
        Write-Build White "Installing/updating Azure Functions Core Tools..."
        if ($IsWindows) {
            exec { & npm install -g azure-functions-core-tools@ --unsafe-perm true }
        }
        else {
            Write-Build Yellow "NOTE: May require 'sudo' on Linux/MacOS"
            exec { & sudo npm install -g azure-functions-core-tools@ --unsafe-perm true }
        }
    } 
}

task . FullBuild


#
# Build Process Extensibility Points - uncomment and implement as required
#

# task RunFirst {}
# task PreInit {}
# task PostInit {}
# task PreVersion {}
# task PostVersion {}
# task PreBuild {}
# task PostBuild {}
task PreTest Init,installAzureFunctionsSDK
# task PostTest {}
# task PreTestReport {}
# task PostTestReport {}
# task PreAnalysis {}
# task PostAnalysis {}
# task PrePackage {}
# task PostPackage {}
# task PrePublish {}
# task PostPublish {}
# task RunLast {}

# Override for debugging purposes
# task GitVersion -If {!$SkipGitVersion} {
    
#     if ($GitVersion.Keys.Count -gt 0) {
#         Write-Build Cyan "Version details overridden by environment variable:`n$($GitVersion | ConvertTo-Json)"
#     }
#     else {
#         exec { dotnet --list-sdks }
    
#         Install-DotNetTool -Name "GitVersion.Tool" -Version $GitVersionToolVersion
#         Write-Build Cyan "GitVersion Config: $GitVersionConfig"
#         exec { dotnet-gitversion /output json /nofetch /config $GitVersionConfig } | Tee-Object -Variable gitVersionOutputJson
        
#         Write-Build Cyan "GitVersion Output:`n$gitVersionOutputJson"
    
#         $env:GitVersionOutput = $gitVersionOutputJson
#         $script:GitVersion = $gitVersionOutputJson | ConvertFrom-Json -AsHashtable
    
#         # Set the native GitVersion output as environment variables and build server variables
#         foreach ($var in $script:GitVersion.Keys) {
#             Set-Item -Path "env:GITVERSION_$var" -Value $GitVersion[$var]
#             Set-BuildServerVariable -Name "GitVersion.$var" -Value $GitVersion[$var]
#         }
#     }
# }
