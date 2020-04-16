#!/bin/bash

# Start gaiad
gaiad start --rpc.laddr "tcp://0.0.0.0:26657" >> /dev/null &


# Start rest server
gaiacli rest-server --laddr "tcp://0.0.0.0:1317" >> /dev/null &


# Naive check runs checks once a minute to see if either of the processes exited.
# This illustrates part of the heavy lifting you need to do if you want to run
# more than one service in a container. The container exits with an error
# if it detects that either of the processes has exited.
# Otherwise it loops forever, waking up every 60 seconds

while sleep 60; do
  ps aux |grep gaiad |grep -q -v grep
  GAIAD_STATUS=$?
  ps aux |grep gaiacli |grep -q -v grep
  REST_STATUS=$?
  # If the greps above find anything, they exit with 0 status
  # If they are not both 0, then something is wrong
  if [ $GAIAD_STATUS -ne 0 -o $REST_STATUS -ne 0 ]; then
    echo "One of the processes has already exited."
    exit 1
  fi
done
