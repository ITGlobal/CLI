pushd ./src/CLI
dotnet restore -v q
dotnet version $args
$exitcode = $LASTEXITCODE
popd
exit $exitcode