$SOLUTION_DIR = Resolve-Path "."
$ARTIFACTS = Join-Path $SOLUTION_DIR "artifacts"
$CONFIGURATION = $env:CONFIGURATION
$VERSION = $env:APPVEYOR_BUILD_VERSION

if(!$CONFIGURATION) {
    $CONFIGURATION = "Release"
}

if(!$VERSION) {
    $VERSION = "0.0.0-dev"
}

# CLEAN
if(-not (Test-Path $ARTIFACTS)) {
    New-Item $ARTIFACTS -ItemType Directory | Out-Null
}
Get-ChildItem $ARTIFACTS | Remove-Item -Recurse -Force
& dotnet clean -v q /nologo
if($LASTEXITCODE -ne 0) {
    Write-Host "'dotnet clean' failed with $LASTEXITCODE" -f red
    exit $LASTEXITCODE
}

# RESTORE
& dotnet restore -v q /nologo
if($LASTEXITCODE -ne 0) {
    Write-Host "'dotnet restore' failed with $LASTEXITCODE" -f red
    exit $LASTEXITCODE
}

# PACK
& dotnet pack /nologo -v q -c $CONFIGURATION /p:Version=$VERSION --include-symbols --include-source `
    --no-restore --output $ARTIFACTS ./src/CLI/CLI.csproj
if ($LASTEXITCODE -ne 0) {
    Write-Host "`"dotnet pack`" failed with $LASTEXITCODE"
    exit $LASTEXITCODE
}

Write-Host "Completed" -f Green