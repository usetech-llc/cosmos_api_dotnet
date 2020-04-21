git submodule init && git submodule update --recursive --remote
docker-compose build gaia-test
docker-compose up -d gaia-test
