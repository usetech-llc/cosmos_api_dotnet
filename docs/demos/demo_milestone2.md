# Manual Demos - Milestone 2

Milestone 2 deliverables are tagged as [milestone2tag](https://github.com/usetech-llc/cosmos_api_dotnet/tree/milestone2tag)

## Deliverable 3

In order to get started, cleanup the previous Cosmos Dotnet API docker images if you have any. The univeral command set for this is:
```
docker stop $(docker ps -q)
docker rm $(docker ps -a -q)
docker system prune -a -f
```

...then run commands below to setup testing environment (line 1) and API tests (line 2):
```
$ ./run-services.sh
$ ./run-tests.sh
```

Now you are connected to a running docker container with API built. You can execute following commands to examine deliverables.


### Transaction is generated using application RESTful endpoint

Follow test can demonstrates RESTful generated transaction. Generated transaction will be printed in console.

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter NameserviceTests -l "console;verbosity=detailed"
```

### Transaction is signed offline
#### Transaction is published on chain

For custom transaction test previous test also be useful

```
$ docker-compose run cosmos-api-test dotnet test --filter NameserviceTests -l "console;verbosity=detailed"
```

#### Command line is provided to execute all milestone deliverables

You can execute following commands to examine all milestone deliverables.

```
$ docker-compose run cosmos-api-test dotnet test -l "console;verbosity=detailed"
```

#### Usage example is provided (using Nameserver application from Cosmos SDK tutorial) 

All examples are provided in the [Documentation](../index.md), which is also hosted on [ReadTheDocs](https://cosmos-api-dotnet.readthedocs.io/en/latest/), also any unit test can provide an additional example.

## Deliverable 4

#### Following endpoints are supported. Responses are deserialized to appropriate C# Object and returned from API, POST endpoints are used here as a reference and are not invoked, instead corresponding transactions are generated, signed, and published on-chain:

### /staking/delegators/{delegatorAddr}/delegations
### /staking/delegators/{delegatorAddr}/delegations/{validatorAddr}
### /staking/delegators/{delegatorAddr}/unbonding_delegations
### /staking/delegators/{delegatorAddr}/unbonding_delegations/{validatorAddr}
### /staking/redelegations
### /staking/delegators/{delegatorAddr}/redelegations
### /staking/delegators/{delegatorAddr}/validators
### /staking/delegators/{delegatorAddr}/validators/{validatorAddr}
### /staking/delegators/{delegatorAddr}/txs
### /staking/validators
### /staking/validators/{validatorAddr}
### /staking/validators/{validatorAddr}/delegations
### /staking/validators/{validatorAddr}/unbonding_delegations
### /staking/pool
### /staking/parameters

That group of endpoints is located in StakingTests test group

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter StakingTests -l "console;verbosity=detailed"
```

### Command line is provided to execute all milestone deliverables


Command without filter
```
$ docker-compose run cosmos-api-test dotnet test --filter StakingTests -l "console;verbosity=detailed"
```

### Usage example is provided

All examples are provided in the [Documentation](../index.md), which is also hosted on [ReadTheDocs](https://cosmos-api-dotnet.readthedocs.io/en/latest/), also any unit test can provide an additional example.


## Deliverable 5

### Following endpoints are supported. Responses are deserialized to appropriate C# Object and returned from API, POST endpoints are used here as a reference and are not invoked, instead corresponding transactions are generated, signed, and published on-chain:

### GET /gov/proposals
### POST /gov/proposals
### /gov/proposals/{proposalId}
### /gov/proposals/{proposalId}/proposer
### GET /gov/proposals/{proposalId}/deposits
### POST /gov/proposals/{proposalId}/deposits
### /gov/proposals/{proposalId}/deposits/{depositor}
### GET /gov/proposals/{proposalId}/votes
### POST /gov/proposals/{proposalId}/votes
### /gov/proposals/{proposalId}/votes/{voter}
### /gov/proposals/{proposalId}/tally
### /gov/parameters/deposit
### /gov/parameters/tallying
### /gov/parameters/voting

That group of endpoints is located in StakingTests test group

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter GovernanceTests -l "console;verbosity=detailed"
```

### Command line is provided to execute all milestone deliverables

Command without filter
```
$ docker-compose run cosmos-api-test dotnet test --filter GovernanceTests -l "console;verbosity=detailed"
```

### Usage examples are provided

All examples are provided in the [Documentation](../index.md), which is also hosted on [ReadTheDocs](https://cosmos-api-dotnet.readthedocs.io/en/latest/), also any unit test can provide an additional example.
