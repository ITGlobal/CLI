#!/usr/bin/env sh
set -e
IMAGE=$(docker build -q -f cli-features-example.Dockerfile .)
docker run -it --rm $IMAGE $*