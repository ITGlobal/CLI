#!/usr/bin/env pwsh

$directory = (Resolve-Path "./docs").path
docker run -it --rm -v $($directory):/usr/src/app --name $name -p 4000:4000 starefossen/github-pages