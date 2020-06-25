#!/bin/bash

docker-compose build cosmos-api-test
docker-compose up -d cosmos-api-test

docker-compose run cosmos-api-test dotnet test -l "console;verbosity=detailed"
