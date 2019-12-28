#!/usr/bin/env pwsh

docker run -it --rm -v ${pwd}:/usr/src/app -p 4000:4000 starefossen/github-pages
