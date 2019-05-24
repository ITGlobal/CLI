#!/usr/bin/env pwsh

$name = "itglobal_cli_docs"

$ids = $(docker ps --filter name=$name -q)
if(-not [string]::IsNullOrEmpty($ids))
{
    docker rm -f $name
}

$directory = (Resolve-Path "./docs").path
$cmd = @("run", "-it", "--rm", "-v", "$($directory):/usr/src/app", "-p", "4000:4000", "--name", "$name", "starefossen/github-pages:latest")

docker $cmd