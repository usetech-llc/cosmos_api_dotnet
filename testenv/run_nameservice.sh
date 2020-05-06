#!/bin/bash

# Start nsd
nsd start --p2p.laddr "tcp://0.0.0.0:26666" --proxy_app "tcp://0.0.0.0:26668" --rpc.laddr "tcp://0.0.0.0:26667" >> /dev/null &


# Start rest server
nscli rest-server --laddr "tcp://0.0.0.0:1327" --node "tcp://localhost:26667" >> /dev/null &


# Naive check runs checks once a minute to see if either of the processes exited.
# This illustrates part of the heavy lifting you need to do if you want to run
# more than one service in a container. The container exits with an error
# if it detects that either of the processes has exited.
# Otherwise it loops forever, waking up every 60 seconds

while sleep 60; do
  ps aux |grep nsd |grep -q -v grep
  NSD_STATUS=$?
  ps aux |grep nscli |grep -q -v grep
  REST_STATUS=$?
  # If the greps above find anything, they exit with 0 status
  # If they are not both 0, then something is wrong
  if [ $NSD_STATUS -ne 0 -o $REST_STATUS -ne 0 ]; then
    echo "One of the processes has already exited."
    exit 1
  fi
done
