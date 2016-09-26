$CONFIGURATION = $env:CONFIGURATION
$VERSION = $env:APPVEYOR_BUILD_VERSION

if(!$CONFIGURATION) {
    $CONFIGURATION = "Release"
}

$PROJECT = "./src/ITGlobal.CLI"
$OUTDIR = "./artifacts"
$PROJECT_JSON = Join-Path $PROJECT "project.json"

if($VERSION) {
    Write-Host "Patching project.json with version=$VERSION" -ForegroundColor Cyan
    $projectJson = [string](Get-Content $PROJECT_JSON)
    $projectJson = [regex]::Replace($projectJson, "`"version`"\s*\:\s*`"[^`"]+`"", "`"version`" : `"$VERSION`"")
    Set-Content $PROJECT_JSON $projectJson
}

Write-Host "Restoring packages" -ForegroundColor Cyan
& dotnet restore $PROJECT

Write-Host "Building project" -ForegroundColor Cyan
& dotnet build $PROJECT -c config --no-dependencies

Write-Host "Packaging project" -ForegroundColor Cyan
& dotnet pack $PROJECT -c $CONFIGURATION --no-build -o $OUTDIR