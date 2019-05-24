#!/usr/bin/env pwsh
param (
    [Parameter]
    [string] $Configuration = "Release",
    
    [Parameter]
    [string] $Version = ""
)

$SOLUTION_DIR = Resolve-Path "."
$ARTIFACTS = Join-Path $SOLUTION_DIR "artifacts"
$CONFIGURATION = $Configuration

# CLEAN
write-host "< clean >" -f cyan
if (-not (Test-Path $ARTIFACTS)) {
    New-Item $ARTIFACTS -ItemType Directory | Out-Null
}
Get-ChildItem $ARTIFACTS | Remove-Item -Recurse -Force
& dotnet clean -v q /nologo
if ($LASTEXITCODE -ne 0) {
    Write-Host "'dotnet clean' failed with $LASTEXITCODE" -f red
    exit $LASTEXITCODE
}
write-host "Dropped build output"

# VERSION
write-host "< version >" -f cyan
$VERSION = $Version

if ([string]::IsNullOrEmpty($Version)) {
    if ((git tag | measure).Count -eq 0) {
        $VERSION = "0.0.0-dev"
        write-host "there are no tags! Will use '$VERSION' as version number" -f red    
    }
    else {
        $VERSION = "$(git describe --abbrev=0 --tags)"
    }
}

if ($env:APPVEYOR) {
    $BUILD_NUMBER = [int]($env:APPVEYOR_BUILD_NUMBER)
    if ($env:APPVEYOR_REPO_TAG -ne "true") {
        $tag = $(git log -n 1 --pretty=format:%h)
        $VERSION = "$VERSION-$tag+$env:APPVEYOR_BUILD_NUMBER"
    }
}

write-host "version number : $VERSION"

if ($env:APPVEYOR) {
    appveyor SetVariable -Name VERSION -Value $VERSION
    appveyor UpdateBuild -Version "$VERSION"
}

# COMPILE
write-host "< compile >" -f cyan
& dotnet build -v q -c $CONFIGURATION /nologo /p:Version=$VERSION 
if ($LASTEXITCODE -ne 0) {
    Write-Host "'dotnet build' failed with $LASTEXITCODE" -f red
    exit $LASTEXITCODE
}

# TEST
write-host "< test >" -f cyan
& dotnet test -v q -c $CONFIGURATION --no-restore --no-build /nologo
if ($LASTEXITCODE -ne 0) {
    Write-Host "'dotnet test' failed with $LASTEXITCODE" -f red
    exit $LASTEXITCODE
}

# PACK
write-host "< pack >" -f cyan
& dotnet pack /nologo -v q -c $CONFIGURATION /p:Version=$VERSION --include-symbols --include-source `
    --no-restore --no-build --output $ARTIFACTS ./CLI.sln
if ($LASTEXITCODE -ne 0) {
    Write-Host "`"dotnet pack`" failed with $LASTEXITCODE"
    exit $LASTEXITCODE
}
Write-Host "Generated packages:"
gci $ARTIFACTS -file -filter *.nupkg | % { write-host "`t$($_.Name)" }

Write-Host "Completed" -f Green