#!/bin/bash

git submodule update --init --recursive
docker-compose build gaia-test
docker-compose build nameservice
docker-compose up -d gaia-test
docker-compose up -d nameservice
