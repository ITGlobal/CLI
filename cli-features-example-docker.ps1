#!/usr/bin/env pwsh

$IMAGE = $(docker build -q -f ./build/cli-features-example.Dockerfile .)
if($LASTEXITCODE -ne 0)
{
    exit $LASTEXITCODE
}

docker run -it --rm $IMAGE $args