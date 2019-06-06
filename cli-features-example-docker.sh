#!/usr/bin/env sh
set -e
IMAGE=$(docker build -q -f ./build/cli-features-example.Dockerfile .)
docker run -it --rm $IMAGE $*