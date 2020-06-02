# Manual Demos - Milestone 3

Milestone 3 deliverables are tagged as [milestone3tag](https://github.com/usetech-llc/cosmos_api_dotnet/tree/milestone1tag)

Before start demo execute following commands
```
$ sudo apt-get install expect
$ chmod 777 run-services.sh
$ ./run-services.sh
```


## Deliverable 7

#### Following endpoints are supported. Responses are deserialized to appropriate C# Object and returned from API, POST endpoints are used here as a reference and are not invoked, instead corresponding transactions are generated, signed, and published on-chain:

### GET /distribution/delegators/{delegatorAddr}/rewards
### POST /distribution/delegators/{delegatorAddr}/rewards
### GET /distribution/delegators/{delegatorAddr}/rewards/{validatorAddr}
### POST /distribution/delegators/{delegatorAddr}/rewards/{validatorAddr}
### GET /distribution/delegators/{delegatorAddr}/withdraw_address
### POST /distribution/delegators/{delegatorAddr}/withdraw_address
### /distribution/validators/{validatorAddr}
### /distribution/validators/{validatorAddr}/outstanding_rewards
### GET /distribution/validators/{validatorAddr}/rewards
### POST /distribution/validators/{validatorAddr}/rewards
### /distribution/community_pool
### /distribution/parameters

That group of endpoints is located in DistributionTests test group

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter DistributionTests -l "console;verbosity=detailed"
```

### Command line is provided to execute all milestone deliverables

```
$ docker-compose run cosmos-api-test dotnet test --filter DistributionTests -l "console;verbosity=detailed"
```

### Usage example is provided

All examples are provided in the [README](../README.md) also any unit test can provide an additional example.



## Deliverable 8

### Following endpoints are supported. Responses are deserialized to appropriate C# Object and returned from API, POST endpoints are used here as a reference and are not invoked, instead corresponding transactions are generated, signed, and published on-chain:

### /minting/parameters
### /minting/inflation
### /minting/annual-provisions

That group of endpoints is located in MintTests test group

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter MintTests -l "console;verbosity=detailed"
```

### Command line is provided to execute all milestone deliverables

```
$ docker-compose run cosmos-api-test dotnet test --filter MintTests -l "console;verbosity=detailed"
```

### Usage examples are provided

All examples are provided in the [README](../README.md) also any unit test can provide an additional example.



## Deliverable 9

### API and example full documentation

All examples are provided in the [README](../README.md) also any unit test can provide an additional example.

### Command line is provided to execute all milestone deliverables

Cleanup project files, ensure all tests pass

### API library is packaged as a zip archive with DLL files that can be used without compilation on Windows.

DLL files can be found at repository release section (https://github.com/usetech-llc/cosmos_api_dotnet/releases)