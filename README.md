# Cosmos .NET API

This API enables connection and interaction between a .NET application and a Cosmos blockchain node built with Cosmos SDK.

- [Getting Started](#getting-started)
- [Connecting to a Node](#connecting-to-a-node)
  * [Simple Connect](#simple-connect)
  * [ICosmosApiBuilder Interface](#icosmosapibuilder-interface)
  * [ICosmosApiClient Interface](#icosmosapiclient-interface)
  * [CosmosApiClientSettings](#cosmosapiclientsettings)
- [Gaia API](#gaia-api)
  * [Node Info](#node-info)
  * [Synching Status](#synching-status)
- [Tendermint API](#tendermint-api)
  * [Block Info](#block-info)
    + [Latest Block](#latest-block)
    + [Block by Number](#block-by-number)
  * [Validators](#validators)
    + [Latest Set](#latest-set)
    + [Set by Block Number](#set-by-block-number)
- [Transactions API](#transactions-api)
  * [Reading Transaction Info](#reading-transaction-info)
    + [Get Transaction by Hash](#get-transaction-by-hash)
    + [Search Transactions](#search-transactions)
  * [Sending Transactions](#sending-transactions)
- [Bank API](#bank-api)
  * [Reading Balance](#reading-balance)
  * [Sending Transfer](#sending-transfer)
- [Authentication API](#authentication-api)
  * [GetAuthAccountByAddress](#getauthaccountbyaddress)


## Getting Started

The purpose of this section is to get you started working on .NET API for Cosmos SDK and we assume that you already have a Cosmos node up and running locally or at some URL. If you have not done this yet, please refer to [Cosmos SDK Tutorials](https://tutorials.cosmos.network/).

First, install .NET Code 3.1. Microsoft provides support for several operating systems, here is the [link to .NET Core page](https://docs.microsoft.com/en-us/dotnet/core/install/).

Now let's check out the API code if you have not done so yet:
```
git checkout https://github.com/usetech-llc/cosmos_api_dotnet cosmos_api_dotnet
```

The next step is to build the API and unit tests:
```
$ cd cosmos_api_dotnet/src
$ dotnet build
```

If the code builds with no errors, you have the development environment setup! Create a new .NET application, add a project reference to API project like this (or using UI in your IDE):
```
    <ItemGroup>
      <ProjectReference Include="..\CosmosApi\CosmosApi.csproj" />
    </ItemGroup>
```
...and proceed to the [Connecting to a Node](#connecting-to-a-node) section.

## Connecting to a Node

We will start simple then provide details for all possible configuration.

### Simple Connect

This is a simple example how one can connect to a local node and read an address balance:

```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .CreateClient();

var balance =
    await client.Bank.GetBankBalancesByAddressAsync("cosmos1h9ymfm2fxrqgd257dlw5nku3jgqjgpl59sm5ns");
```

To perform a bit more complex operations, such as transferring balance in Bank module, we need to register JSON converters that will help API endoce standard transactions and decode messages received from node. Standard converters can be registered with [RegisterCosmosSdkTypeConverters](#registercosmossdktypeconverters) method:

```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();
```

### ICosmosApiBuilder interface

The interface `ICosmosApiBuilder` is created to help create the api client. [Above](#simple-connect) is the example how it can be used to build an api object. Below you will find details for each method.

---
#### CreateClient

```csharp
ICosmosApiClient CreateClient();
```

##### Description

Creates a new instance of Cosmos Api Client

##### Parameters

None 

##### Returns

An API object that is ready to be used with a node. See [ICosmosApiClient](#icosmosapiclient-interface) for details.

---
#### Configure

```csharp
ICosmosApiBuilder Configure(Action<CosmosApiClientSettings> configurator);
```

##### Description

Sets settings of created clients using Action.

##### Parameters

**configurator** Action<CosmosApiClientSettings> . See [CosmosApiClientSettings](#cosmosapiclientsettings) for details.

##### Returns

ICosmosApiBuilder for method chaining.

---
#### UseAuthorization

```csharp
ICosmosApiBuilder UseAuthorization(string username, string password);
```

##### Description
Sets username and password authorization for created clients

##### Parameters

**username** string - User name
**password** string - Password

##### Returns
ICosmosApiBuilder for method chaining.

---
#### UseBaseUrl

```csharp
ICosmosApiBuilder UseBaseUrl(string url);
```

##### Description
Sets the base url used by created clients.

##### Parameters
**url** string - Node URL

##### Returns
ICosmosApiBuilder for method chaining.

---
#### RegisterCosmosSdkTypeConverters

```csharp
ICosmosApiBuilder RegisterCosmosSdkTypeConverters();
```

##### Description
Registers json converters for types declared in standard cosmos sdk with no cutom modules.

##### Parameters
None

##### Returns
ICosmosApiBuilder for method chaining.


---
#### RegisterTxType

```csharp
ICosmosApiBuilder RegisterTxType<T>(string jsonName) where T : ITx;
```

##### Description
Adds a possible subtype of the ITx Interface so it can be serialized and deserialized properly.

This method should be used to add custom module transactions if the module has its own implementations of Account, Tx or Msg interfaces that serialize to JSON in the same way as they do in Cosmos SDK modules, i.e. 

```
{ "type": "<type discriminator>", "value": { <json value of implementation> }
```

##### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterTxType<StdTx>("cosmos-sdk/StdTx")
    .CreateClient();
```

##### Parameters
**T** Type Parameter - Type which might be used where ITx Interface is used. In the example StdTx represents the standard transaction structure that is already implemented in the API in `CosmosApi.Models` namespace. Custom module transactions need to be implemented as similar structures that inherit from ITx Interface.  
**jsonName** string - Value of the type discriminator. I.e. JSON value field name, as it comes in the response from the node.

##### Returns
ICosmosApiBuilder for method chaining.

---
#### RegisterMsgType

```csharp
ICosmosApiBuilder RegisterMsgType<T>(string jsonName) where T : IMsg;
```

##### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterMsgType<MsgSend>("cosmos-sdk/MsgSend")
    .CreateClient();
```

##### Description
Adds a possible subtype of the IMsg Interface so it can be serialized and deserialized properly. 

This method should be used to add custom module transactions if the module has its own implementations of Account, Tx or Msg interfaces that serialize to JSON in the same way as they do in Cosmos SDK modules, i.e. 

```
{ "type": "<type discriminator>", "value": { <json value of implementation> }
```

##### Parameters
**T** Type Parameter - Type which might be used where IMsg Interface is used. In the example MsgSend represents the standard message structure that is already implemented in the API in `CosmosApi.Models` namespace. Custom module messages need to be implemented as similar structures that inherit from IMsg Interface.   
**jsonName** string - Value of the type discriminator. I.e. JSON value field name, as it comes in the response from the node.

##### Returns
ICosmosApiBuilder for method chaining.

---
#### RegisterAccountType
```csharp
ICosmosApiBuilder RegisterAccountType<T>(string jsonName) where T : IAccount
```

##### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterAccountType<BaseAccount>("cosmos-sdk/Account")
    .CreateClient();
```

##### Description
Adds a possible subtype of the IAccount Interface, so it can be serialized and deserialized properly

This method should be used to add custom module transactions if the module has its own implementations of Account, Tx or Msg interfaces that serialize to JSON in the same way as they do in Cosmos SDK modules, i.e. 

```
{ "type": "<type discriminator>", "value": { <json value of implementation> }
```

##### Parameters
**T** Type Parameter - Type which might be used where BaseAccount class is used. In the example BaseAccount represents the standard message structure that is already implemented in the API in `CosmosApi.Models` namespace. Custom module messages need to be implemented as similar structures that inherit from BaseAccount class.   
**jsonName** string - Value of the type discriminator. I.e. JSON value field name, as it comes in the response from the node.

##### Returns
ICosmosApiBuilder for method chaining.

---
#### AddJsonConverter

```csharp
ICosmosApiBuilder AddJsonConverter(IConverterFactory factory);
```

##### Description
Adds a converter factory to use for serialization and deserialization.

This method should be used when custom module transactions do not serialize to JSON in a standard Cosmos SDK way (i.e. key-value type of JSON object)

##### Parameters
**factory** IConverterFactory - Converter Factory

##### Returns
ICosmosApiBuilder for method chaining.

### ICosmosApiClient Interface

#### Nested Interfaces

The ICosmosApiClient contains nested interfaces that implement interaction with built-in modules of Cosmos SDK such as TendermintRPC, Transactions, Bank, etc. These interfaces are each documented in high level sections of this document.

```scharp
IGaiaREST GaiaRest { get; }
ITendermintRPC TendermintRpc { get; }
ITransactions Transactions { get; }
IAuth Auth { get; }
IBank Bank { get; }
...
```

---
#### SendAsync

```csharp
Task<BroadcastTxResult> SendAsync(string chainId, string fromAddress, string toAddress, IList<Coin> coins, BroadcastTxMode mode, StdFee fee, string privateKey, string passphrase, string memo = "", CancellationToken cancellationToken = default);
```

##### Description
Creates signed transaction and broadcasts it.

##### Parameters

**chainId** string - Chain ID
**fromAddress** string - Address that signs transaction
**toAddress** string - Address that receives transaction
**coins** IList<Coin> - List of token entries (Denomination and Amount) to send in this transaction
**mode** BroadcastTxMode - Defines when this call will complete (Block: Return after tx commit, Sync: Return afer CheckTx, Async: Return right away).
**fee** StdFee - includes the amount of coins paid in fees and the maximum gas to be used by the transaction. The ratio yields an effective "gasprice", which must be above some miminum to be accepted into the mempool.
**privateKey** string - Sender address private key
**passphrase** string - Sender passphrase to decode private key
**memo** string - Memo to include in transaction data
**cancellationToken** - CancellationToken 

##### Returns
BroadcastTxResult structure

### CosmosApiClientSettings

All fields in this structure are nullable.

**BaseUrl** - string - Base url of cosmos api rest server.
**Username** - string - Specifies the username to use for the authorization.
**Password** - string - Specifies the password to use for the authorization.
**ConnectionLeaseTimeout** - TimeSpan - Specifies the time to keep the underlying HTTP/TCP conneciton open. When expired, a Connection: close header is sent with the next request, which should force a new connection and DSN lookup to occur on the next call. Default is null, effectively disabling the behavior.
**HttpClientFactory** - Func<HttpMessageHandler, HttpClient> - Defines how HttpClient should be instantiated and configured by default. Default is null, creating default HttpClient.
**CreateMessageHandlerFactory** - Func<HttpMessageHandler> - Defines how HttpMessageHandler should be instantiated and configured by default. Default is null, creating default HttpMessageHandler. 
**Timeout** - TimeSpan - The HTTP request timeout.
**OnBeforeCall** - Action<BeforeCall> - Callback that is called immediately before every HTTP request is sent.
**OnBeforeCallAsync** - Func<BeforeCall, Task> - Callback that is asynchronously called immediately before every HTTP request is sent.
**OnAfterCall** - Action<AfterCall> - Callback that is called immediately after every HTTP response is received.
**OnAfterCallAsync** - Func<AfterCall, Task> - Callback that is asynchronously called immediately after every HTTP response is received.
**OnError** - Action<Error> - Callback that is called when an error occurs during any HTTP call, including when any non-success HTTP status code is returned in the response.
**OnErrorAsync** - Func<Error, Task> - Callback that is asynchronously called when an error occurs during any HTTP call, including when any non-success HTTP status code is returned in the response.

# Gaia API
Gaia API is implemented in `IGaiaREST` sub-interface of `ICosmosApiClient`.

---
## Node Info
```csharp
NodeStatus GetNodeInfo();
Task<NodeStatus> GetNodeInfoAsync(CancellationToken cancellationToken = default(CancellationToken));
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var nodeInfo = client.GaiaRest.GetNodeInfo();
```
### Description
Returns properties of the connected node

### Parameters
None

### Returns
NodeStatus structure:

**ApplicationVersion** - Application version
**NodeInfo** - Node Information (Id, Moniker, ProtocolVersion, Network, Channels, ListenAddr, Version, Other)

# Tendermint API
Tendermint API is implemented in `ITendermintRPC` sub-interface of `ICosmosApiClient`.

---
## Synching Status

```csharp
Task<NodeSyncingStatus> GetSyncingAsync(CancellationToken cancellationToken = default(CancellationToken));
NodeSyncingStatus GetSyncing();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var syncData = await client.TendermintRpc.GetSyncingAsync();
```

### Description
Get if the node is currently syning with other nodes

### Parameters
None 

### Returns
NodeSyncingStatus structure (one boolean field Syncing).

## Block Info
---
### Latest Block
```csharp
Task<BlockQuery> GetLatestBlockAsync(CancellationToken cancellationToken = default(CancellationToken));
BlockQuery GetLatestBlock();
```

#### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var block = await client.TendermintRpc.GetLatestBlockAsync();
```

#### Description
Get the latest block

#### Parameters
None

#### Returns

##### BlockQuery structure
```
BlockMeta
  |- BlockHeader
    |- string ChainId
    |- long? Height 
    |- DateTimeOffset Time 
    |- long? NumTxs 
    |- BlockID LastBlockId
      |- byte[] Hash
      |- BlockIDParts Parts
        |- int Total
        |- byte[] Hash
    |- long TotalTxs 
    |- byte[] LastCommitHash
    |- byte[] DataHash
    |- byte[] ValidatorsHash
    |- byte[] NextValidatorsHash
    |- byte[] ConsensusHash
    |- byte[] AppHash
    |- byte[] LastResultsHash
    |- byte[] EvidenceHash
    |- byte[] ProposerAddress
    |- BlockHeaderVersion Version
      |- ulong Block
      |- ulong App
  |-BlockId
    |- byte[] Hash
    |- BlockIDParts Parts
      |- int Total
      |- byte[] Hash
Block
  |- BlockHeader Header
  |- BlockData Data
    |- IList<string> Transactions
  |- EvidenceData Evidence
    |- object Evidence
  |- BlockLastCommit LastCommit
    |- BlockID BlockId
    |- IList<CommitSig> Precommits
      |- byte[] ValidatorAddress
      |- int ValidatorIndex 
      |- long Height 
      |- int Round 
      |- DateTimeOffset Timestamp 
      |- SignedMsgType? Type 
        |- enum: PrevoteType, PrecommitType, or ProposalType
      |- BlockID BlockId
      |- byte[] Signature
```

### Block by Number

```csharp
Task<BlockQuery> GetBlockByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken));
BlockQuery GetBlockByHeight(long height);
```

#### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var block = await client.TendermintRpc.GetBlockByHeightAsync(3);
```

#### Description
Get a block at a certain height

#### Parameters
**height** - long - Block height

#### Returns
[BlockQuery structure](#blockquery-structure)

## Validators
---
### Latest Set
```csharp
Task<ResponseWithHeight<ValidatorSet>> GetLatestValidatorSetAsync(CancellationToken cancellationToken = default(CancellationToken));
ResponseWithHeight<ValidatorSet> GetLatestValidatorSet();
```

#### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var validatorSet = await client.TendermintRpc.GetLatestValidatorSetAsync();
```

#### Description
Get the latest validator set

#### Parameters
None

#### Returns
[ResponseWithHeight](#responsewithheight)<[ValidatorSet](#validatorset)> structure

##### ResponseWithHeight
```
ResponseWithHeight
  |- long Height
  |- TResult Result
```

#### ValidatorSet
```
ValidatorSet
  |- long BlockHeight
  |- IList<TendermintValidator>
    |- byte[] Address
    |- string PubKey
    |- long VotingPower
    |- long ProposerPriority
```

---
### Set by Block Number
```csharp
Task<ResponseWithHeight<ValidatorSet>> GetValidatorSetByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken));
ResponseWithHeight<ValidatorSet> GetValidatorSetByHeight(long height);
```

#### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var validatorSet = await client.TendermintRpc.GetValidatorSetByHeightAsync(1);    
```

#### Description
Get a validator set a certain height

#### Parameters
**height** - long - Block height

#### Returns
[ResponseWithHeight](#responsewithheight)<[ValidatorSet](#validatorset)> structure

# Transactions API
## Reading Transaction Info
---
### Get Transaction by Hash
```csharp
Task<TxResponse> GetByHashAsync(byte[] hash, CancellationToken cancellationToken = default);
TxResponse GetByHash(byte[] hash);
```

#### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var tx = await client.Transactions.GetByHashAsync(
                ByteArrayExtensions.ParseHexString("7DCB49D5B4FAE87A5532741816E68EE4222C1DBD66326FBADA55268FA7E760E6"));
```

#### Description
Retrieve a transaction using its hash.

#### Parameters
**hash** - byte[] - Array of bytes containing transaction hash 

#### Returns
[TxResponse](#txresponse)

##### TxResponse

```
TxResponse
  |- long Height 
  |- string TxHash
  |- uint Code 
  |- string Data
  |- string RawLog
  |- IList<ABCIMessageLog> Logs
    |- ushort MsgIndex
    |- bool Success
    |- string Log
  |- string Info
  |- long GasWanted 
  |- long GasUsed 
  |- string Codespace
  |- IList<ITx> Tx
  |- DateTimeOffset Timestamp 
```

---
### Search Transactions
```csharp
Task<PaginatedTxs> GetSearchAsync(string? messageAction, string? messageSender, int? page = default, int? limit = default, int? minHeight = default, int? maxHeight = default, CancellationToken cancellationToken = default);
PaginatedTxs GetSearch(string? messageAction, string? messageSender, int? page = default, int? limit = default, int? minHeight = default, int? maxHeight = default);
```

#### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var searchResult = await client.Transactions.GetSearchAsync("send", null, limit: 2);
```

#### Description
Paginated method for searching transactions.

#### Parameters
**messageAction** - string - Transaction events such as ‘send’. Note that each module documents its own events. look for xx_events.md in the corresponding cosmos-sdk/docs/spec directory.
**messageSender** - string - Transaction tags with sender.
**page** - int - Page number.
**limit** - int - Maximum number of items per page
**minHeight** - int - Transactions on blocks with height greater or equal this value
**maxHeight** - int - transactions on blocks with height less than or equal this value

#### Returns
PaginatedTxs structure:

```
PaginatedTxs
  |- int TotalCount
  |- int Count
  |- int PageNumber
  |- int PageTotal
  |- int Limit
  |- IList<[TxResponse](#txresponse)> Txs
```

## Sending Transactions
TBD

# Bank API
---
## Reading Balance
```csharp
Task<ResponseWithHeight<IList<Coin>>> GetBankBalancesByAddressAsync(string address, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Coin>> GetBankBalancesByAddress(string address);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var balance =
    await client.Bank.GetBankBalancesByAddressAsync("cosmos1h9ymfm2fxrqgd257dlw5nku3jgqjgpl59sm5ns");
```

### Description
Get the account balances.

### Parameters
**address** - string - Account address

### Returns
[ResponseWithHeight](#responsewithheight)<IList<Coin>>> structure, where Coin is a list of token entries (Denomination and Amount).

---
## Sending Transfer

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var account1 = ((await client.Auth.GetAuthAccountByAddressAsync(Address1)).Result as BaseAccount)!;

var denom = account1.Coins[0].Denom;
var amount = 10;
var coinsToSend = new List<Coin>()
{
    new Coin(denom, amount)
};
var memo = Guid.NewGuid().ToString("D");
var fee = new StdFee()
{
    Amount = new List<Coin>(),
    Gas = 300000,
};
var result = await client.SendAsync(LocalChainId, Address1, Address2, coinsToSend, BroadcastTxMode.Block, fee, Address1PrivateKey, Address1Passphrase, memo);
```

# Authentication API

---
## GetAuthAccountByAddress
```csharp
Task<ResponseWithHeight<IAccount>> GetAuthAccountByAddressAsync(string address, CancellationToken cancellationToken = default);
ResponseWithHeight<IAccount> GetAuthAccountByAddress(string address);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var account =
    await client.Auth.GetAuthAccountByAddressAsync("cosmos16xyempempp92x9hyzz9wrgf94r6j9h5f06pxxv");
```

### Description
Get the account information on blockchain.

### Parameters
**address** - string - Address

### Returns
[ResponseWithHeight](#responsewithheight)<[IAccount Interface](#iaccount-interface)>

#### IAccount Interface

```csharp
public interface IAccount
{
    public PublicKey GetPublicKey();
    public ulong GetSequence();
    public ulong GetAccountNumber();
}
```
