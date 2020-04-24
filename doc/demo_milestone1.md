# Manual Demos - Milestone 1

Milestone 1 deliverables are tagged as [milestone1tag](https://github.com/usetech-llc/cosmos_api_dotnet/tree/milestone1tag)

## Deliverable 1

### The project can be built with provided instructions with dotnet command line tool.

Run commands below for setup testing environment(line 1) and API tests(line 2)
```
$ ./run-gaia-testenv.sh
$ ./run-tests.sh
```

Now you are connected to a running docker container with API built. You can execute following commands to examine deliverables.

### Connection to a public node (one of seed nodes per https://github.com/cosmos/launch) can be established through RESTful interface with API connect command.

In instructions above that point already reached, but you can repeat it by commands

```
$ docker-compose run cosmos-api-test dotnet test --filter ClientTests -l "console;verbosity=detailed"
```

#### Connection to a public node can be closed with API disconnect command

Disconnect method provided by native dotnet infrastructure through IDisposable interface

```csharp
	using var client = CreateClient();
```

#### Node’s TLS certificate is verified during connection process

Certificate validation happens in package Flurl.Http for .NET

#### Basic data can be read from the node, deserialized to appropriate C# Object and returned from API, which includes following GET endpoints:

### /node_info

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter GaiaRestTest -l "console;verbosity=detailed"
```

This command executes test `AsyncGetNodeInfoCompletes()` in `GaiaRestTest.cs` file. 
Here is the code fragment from the API implementation of `client.GaiaRest.GetNodeInfoAsync()` that demonstrates that API makes request to `/node_info` endpoint:
```csharp
var client = _clientGetter();
return client.Request("node_info")
    .GetJsonAsync<NodeStatus>(cancellationToken: cancellationToken);
```

### /version

This endpoint does not exist in Cosmos API so it was not implemented. Most likely, all version information is returned by [Node Info](../README.md#node-info) method.

### Endpoints /syncing, /blocks/latest, /blocks/{height}, /validatorsets/latest, /validatorsets/{height}

That group of endpoints is located in TendermintRpcTest test group

Command to run tests:
```
$ docker-compose run cosmos-api-test dotnet test --filter TendermintRpcTest -l "console;verbosity=detailed"
```

### /node_version

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter GaiaRestTest -l "console;verbosity=detailed"
```

### /txs/{hash}

### /txs

### /auth/accounts/{address}

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter AuthTests -l "console;verbosity=detailed"
```

### Command line is provided to execute all milestone deliverables

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test -l "console;verbosity=detailed"
```

### Building instructions, initialization, and library usage documented

Documentation provided in the project root



## Deliverable 2

### Balances can be read using /bank/balances/{address} endpoint

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter BankTests -l "console;verbosity=detailed"
```

### Transaction can be created and signed offline without connecting to a node with either signing algorithm: Secp256r1 (Reference: https://kjur.github.io/jsrsasign/sample/sample-ecdsa.html), Sr25519

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter ClientTests -l "console;verbosity=detailed"
```

This code fragment demonstrates transaction signing 
```csharp
           var account = await Auth.GetAuthAccountByAddressAsync(fromAddress, cancellationToken);

           var msg = new MsgSend()
            {
                FromAddress = fromAddress,
                ToAddress = toAddress,
                Amount = coins,
            };
            var signMsg = new StdSignDoc()
            {
                Fee = fee,
                Memo = memo,
                Messages = new List<TypeValue<IMsg>>
                {
                    new TypeValue<IMsg>(msg), 
                },
                Sequence = account.Result.Value.GetSequence(),
                AccountNumber = account.Result.Value.GetAccountNumber(),
                ChainId = chainId
            };
            var bytesToSign = GetSignBytes(signMsg);
            var key = KeysParser.Parse(privateKey, passphrase);
            var signedBytes = Sign(bytesToSign, key);
            var tx = new StdTx()
            {
                Msg = new List<TypeValue<IMsg>>() { new TypeValue<IMsg>(msg) },
                Memo = memo,
                Fee = fee,
                Signatures = new List<StdSignature>()
                {
                    new StdSignature()
                    {
                        Signature = signedBytes,
                        PubKey = account.Result.Value.GetPublicKey()
                    }
                },
            };
```

### Transaction is published on chain using POST /txs endpoint

Command to run test
```
$ docker-compose run cosmos-api-test dotnet test --filter ClientTests -l "console;verbosity=detailed"
```

In code 
```csharp
Transactions.PostBroadcastAsync(new BroadcastTxBody(tx, mode), cancellationToken);
```

### Command line is provided to execute all milestone deliverables

Command without filter
```
$ docker-compose run cosmos-api-test dotnet test -l "console;verbosity=detailed"
```

### Usage example is provided

All examples are provided in the [README](../README.md) also any unit test can provide an additional example.
