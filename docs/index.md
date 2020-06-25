# Cosmos .NET API

This API enables connection and interaction between a .NET application and a Cosmos blockchain node built with Cosmos SDK.

Built by [UseTech.com](https://usetech.com/blockchain)

- [Getting Started](#getting-started)
- [Gas Estimates](#gas-estimates)
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
    * [BaseReq Structure](#basereq-structure)
- [Custom Transactions](#custom-transactions)
    * [Formatting Transactions](#formatting-transactions)
    * [Sending Transactions](#sending-transactions)
- [Bank API](#bank-api)
    * [Reading Balance](#reading-balance)
    * [Sending Transfer](#sending-transfer)
- [Authentication API](#authentication-api)
    * [GetAuthAccountByAddress](#getauthaccountbyaddress)
- [Staking API](#staking-api)
    * [GetDelegations](#getdelegations)
    * [PostDelegations](#postdelegations)
    * [GetDelegationByValidator](#getdelegationbyvalidator)
    * [GetUnbondingDelegations](#getunbondingdelegations)
    * [PostUnbondingDelegation](#postunbondingdelegation)
    * [GetUnbondingDelegationsByValidator](#getunbondingdelegationsbyvalidator)
    * [GetRedelegations](#getredelegations)
    * [PostRedelegation](#postredelegation)
    * [GetValidators](#getvalidators)
    * [GetValidator](#getvalidator)
    * [GetTransactions](#gettransactions)
    * [GetDelegationsByValidator](#getdelegationsbyvalidator)
    * [GetStakingPool](#getstakingpool)
    * [GetStakingParams](#getstakingparams)
- [Government API](#government-api)
    * [GetProposals](#getproposals)
    * [PostProposal](#postproposal)
    * [GetProposal](#getproposal)
    * [GetProposerByProposalId](#getproposerbyproposalid)
    * [GetDeposits](#getdeposits)
    * [PostDeposit](#postdeposit)
    * [GetDeposit](#getdeposit)
    * [GetVotes](#getvotes)
    * [PostVote](#postvote)
    * [GetVote](#getvote)
    * [GetTally](#gettally)
    * [GetDepositParams](#getdepositparams)
    * [GetTallyParams](#gettallyparams)
    * [GetVotingParams](#getvotingparams)
- [Slashing API](#slashing-api)
    * [GetSigningInfo](#getsigninginfo)
    * [GetSigningInfos](#getsigninginfos)
    * [PostUnjail](#postunjail)
    * [Get Slashing Parameters](#get-slashing-parameters)
- [Distribution API](#distribution-api)
    * [GetDelegatorRewards](#getdelegatorrewards)
    * [PostWithdrawRewards](#postwithdrawrewards)
    * [GetWithdrawAddress](#getwithdrawaddress)
    * [PostWithdrawAddress](#postwithdrawaddress)
    * [GetValidatorDistributionInfo](#getvalidatordistributioninfo)
    * [GetValidatorOutstandingRewards](#getvalidatoroutstandingrewards)
    * [GetValidatorRewards](#getvalidatorrewards)
    * [PostValidatorWithdrawRewards](#postvalidatorwithdrawrewards)
    * [GetCommunityPool](#getcommunitypool)
    * [Get Distribution Parameters](#get-distribution-parameters)
- [Minting API](#minting-api)
    * [Get Minting Parameters](#get-minting-parameters)
    * [GetInflation](#getinflation)
    * [GetAnnualProvisions](#getannualprovisions)

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


## Gas Estimates

In order to format a transaction, Post... methods are used, which return formatted transaction in JSON format ready to be signed and sent to the node. 

Each Post... method has "...Simulation" version, which accepts the same parameters and returns gas estimate for the transaction.

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

#### Description
Retrieve a transaction using its hash.

#### Parameters
**hash** - byte[] - Array of bytes containing transaction hash 

#### Returns
[TxResponse](#txresponse)



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
[PaginatedTxs](#paginatedtxs) structure

#### PaginatedTxs
```
PaginatedTxs
  |- int TotalCount
  |- int Count
  |- int PageNumber
  |- int PageTotal
  |- int Limit
  |- IList<[TxResponse](#txresponse)> Txs
```

## BaseReq Structure
This structure is the base structure for every transaction request.

```csharp
public class BaseReq
{
    // Sender address
    public string From;
    // Memo
    public string? Memo;
    // Chain ID string
    public string ChainId;
    // Account number
    public ulong AccountNumber { get; set; }
    // Sequence number
    public ulong Sequence { get; set; }
    // fees
    public IList<Coin>? Fees { get; set; }
    // gas price in each coin gas charged in
    public IList<DecCoin>? GasPrices { get; set; }
    // gas
    public string? Gas { get; set; }
    // gas adjustment
    public string? GasAdjustment { get; set; }
}
```

# Custom Transactions

The API support sending custom transactions, but there are certain requirements to the module: It must support POST method that creates transaction object. 

There is a NameService demo that comes with this API. It is located in [NameserviceApi](https://github.com/usetech-llc/cosmos_api_dotnet/tree/master/src/NameserviceApi) directory. The method `PostBuyNameAsync` in file `Nameservice.cs` utilizes POST method in NameService SDK example to compose the transaction:

```csharp
public async Task<StdTx> PostBuyNameAsync(BuyNameReq request, CancellationToken cancellationToken = default)
{
    var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
    request = new BuyNameReq(baseReq, request.Name, request.Amount, request.Buyer);
    var content = _cosmosApiClient.Serializer.SerializeJsonHttpContent(request);
    var response = (await _cosmosApiClient.HttpClient.PostAsync("nameservice/names", content, cancellationToken))
        .EnsureSuccessStatusCode();
    return await _cosmosApiClient.Serializer.DeserializeJson<StdTx>(response.Content);
}
```

In ordert to get access to this method in the application that uses API, we need to implement an API extension. This is done in file `CosmosApiClientExtensions.cs`:

```csharp
public static class CosmosApiClientExtensions
{
    public static INameservice CreateNameservice(this ICosmosApiClient cosmosApiClient)
    {
        return new Nameservice(cosmosApiClient);
    }
}
```

...so the calling code will look like this:
```csharp
using var client = ConfigureBuilder(Configuration.LocalNameserviceBaseUrl)
    .RegisterAccountType<Account>("cosmos-sdk/Account")
    .RegisterMsgType<MsgBuyName>("nameservice/BuyName")
    .CreateClient();
var namespaceApi = client.CreateNameservice();
```

## Formatting Transactions

Now in order to format a transaction that registers a name we need this:
```csharp
var baseReq = await client.CreateBaseReq(Configuration.LocalNameserviceOwner1, "memo", null, null, null, null);
var name = Guid.NewGuid().ToString("N");
var req = new BuyNameReq(baseReq, name, "1nametoken", Configuration.LocalNameserviceOwner1);
var stdTx = await namespaceApi.PostBuyNameAsync(req);
```

## Sending Transactions

Signing and posting the transaction can be done using method `SignAndBroadcastStdTxAsync`:
```csharp
var signers = new []{ new SignerWithAddress(Configuration.LocalNameserviceOwner1, Configuration.LocalNameserviceOwner1PrivateKey, Configuration.LocalNameserviceOwner1Passphrase) };
var broadcastResponse = await client.SignAndBroadcastStdTxAsync(stdTx, signers, BroadcastTxMode.Block);
```

Alternatively, an already signed transaction can be sent with method `client.Transactions.PostBroadcastAsync`.

The complete example of signing and sending transaction is located in file `src/CosmosApi.Test/Nameservice/NameserviceTests.cs`.


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

# Staking API

## GetDelegations
```csharp
Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Delegation>> GetDelegations(string delegatorAddr);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();
var delegations = client
    .Staking
    .GetDelegations(Configuration.LocalDelegator1Address);
```

### Description
Get all delegations from a delegator.

### Parameters
**delegatorAddr** - Bech32 AccAddress of Delegator.

### Returns
List of [Delegation](#delegation) structs

#### Delegation
```csharp
public class Delegation
{
    string DelegatorAddress;
    string ValidatorAddress;
    BigDecimal Shares;
    BigInteger Balance;
}
```

## PostDelegations
```csharp
Task<StdTx> PostDelegationsAsync(DelegateRequest request, CancellationToken cancellationToken = default);
StdTx PostDelegations(DelegateRequest request);

Task<GasEstimateResponse> PostDelegationsSimulationAsync(DelegateRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostDelegationsSimulation(DelegateRequest request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));

var postResult = await client
    .Staking
    .PostDelegationsAsync(delegateRequest);
```

### Description
Format Delegation transaction. 
Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.
The simulation version returns gas estimate.

### Parameters
**request** - DelegateRequest
```csharp
public class DelegateRequest
{
    public BaseReq BaseReq;
    public string DelegatorAddress;
    public string ValidatorAddress;
    public Coin Amount;
}
```

### Returns
Transaction in JSON format.

The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

#### GasEstimateResponse
Represents the estimated transaction fees.
```csharp
public class GasEstimateResponse
{
    public ulong GasEstimate;
}
```

## GetDelegationByValidator
```csharp
Task<ResponseWithHeight<Delegation>> GetDelegationByValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<Delegation> GetDelegationByValidator(string delegatorAddr, string validatorAddr);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var delegation = await client
    .Staking
    .GetDelegationByValidatorAsync(Configuration.LocalDelegator1Address,
        Configuration.LocalValidatorAddress);
```

### Description
Query the current delegation between a delegator and a validator.

### Parameters
**delegatorAddr** - Bech32 AccAddress of Delegator
**validatorAddr** - Bech32 OperatorAddress of validator

### Returns
[Delegation](#delegation) struct

## GetUnbondingDelegations
```csharp
Task<ResponseWithHeight<IList<UnbondingDelegation>>> GetUnbondingDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<UnbondingDelegation>> GetUnbondingDelegations(string delegatorAddr);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var delegations = await client
    .Staking
    .GetUnbondingDelegationsAsync(Configuration.LocalDelegator1Address);
```

### Description
Get all unbonding delegations from a delegator.

### Parameters
**delegatorAddr** - Bech32 AccAddress of Delegator

### Returns
List of [UnbondingDelegation](#unbondingdelegation) struct

#### UnbondingDelegation
```csharp
public class UnbondingDelegation
{
    public string DelegatorAddress;
    public string ValidatorAddress;
    public IList<UnbondingDelegationEntry> Entries;
}

public class UnbondingDelegationEntry
{
    /// Height which the unbonding took place.
    public long CreationHeight { get; set; } 
    /// Time at which the unbonding delegation will complete.
    public DateTimeOffset CompletionTime { get; set; }
    /// Atoms initially scheduled to receive at completion.
    public BigInteger InitialBalance { get; set; }
    /// Atoms to receive at completion.
    public BigInteger Balance { get; set; }
}
```

## PostUnbondingDelegation
```csharp
Task<StdTx> PostUnbondingDelegationAsync(UndelegateRequest request, CancellationToken cancellationToken = default);
StdTx PostUnbondingDelegation(UndelegateRequest request);

Task<GasEstimateResponse> PostUnbondingDelegationSimulationAsync(UndelegateRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostUnbondingDelegationSimulation(UndelegateRequest request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
var undelegateRequest = new UndelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));
var tx = (await client
    .Staking
    .PostUnbondingDelegationAsync(undelegateRequest));
```

### Description
Format transaction for unbonding delegation. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**request** - [UndelegateRequest](#undelegaterequest)

#### UndelegateRequest
```csharp
public class UndelegateRequest
{
    public BaseReq BaseReq;
    public string DelegatorAddress;
    public string ValidatorAddress;
    public Coin Amount;
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetUnbondingDelegationsByValidator
```csharp
Task<ResponseWithHeight<UnbondingDelegation>> GetUnbondingDelegationsByValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<UnbondingDelegation> GetUnbondingDelegationsByValidator(string delegatorAddr, string validatorAddr);
Task<ResponseWithHeight<IList<UnbondingDelegation>>> GetUnbondingDelegationsByValidatorAsync(string validatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<UnbondingDelegation>> GetUnbondingDelegationsByValidator(string validatorAddr);
```

### Example 1
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();
var result = await client
        .Staking
        .GetUnbondingDelegationsByValidatorAsync(Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress);
```

### Example 2
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var unbondingDelegations = await client
    .Staking
    .GetUnbondingDelegationsByValidatorAsync(Configuration.GlobalValidator1Address);
```

### Description
1. Query all unbonding delegations between a delegator and a validator.
2. Get all unbonding delegations for a validator.

### Parameters
**delegatorAddr** - Bech32 AccAddress of Delegator
**validatorAddr** - Bech32 OperatorAddress of validator

### Returns
List of [UnbondingDelegation](#unbondingdelegation) struct

## GetRedelegations
```csharp
Task<ResponseWithHeight<IList<Redelegation>>> GetRedelegationsAsync(string? delegator = default, string? validatorFrom = default, string? validatorTo = default, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Redelegation>> GetRedelegations(string? delegator = default, string? validatorFrom = default, string? validatorTo = default);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var result = await client
    .Staking
    .GetRedelegationsAsync(Configuration.GlobalDelegator1Address, Configuration.GlobalValidator1Address, Configuration.GlobalValidator2Address);
```

### Description
Get all redelegations.

### Parameters
**delegator** - Bech32 AccAddress of Delegator.
**validatorFrom** - Bech32 ValAddress of SrcValidator.
**validatorTo** - Bech32 ValAddress of DstValidator.

### Returns
List of [Redelegation](#redelegation) struct

#### Redelegation
Redelegation contains the list of a particular delegator's redelegating bonds from a particular source validator to a particular destination validator

```csharp
public class Redelegation
{
    /// Delegator.
    public string DelegatorAddress;
    /// Validator redelegation source operator addr.
    public string ValidatorSrcAddress;
    /// Validator redelegation destination operator addr.
    public string ValidatorDstAddress;
    /// Redelegation entries.
    public IList<Redelegation> Entries;
}
```

## PostRedelegation
```csharp
Task<StdTx> PostRedelegationAsync(RedelegateRequest request, CancellationToken cancellationToken = default);
StdTx PostRedelegation(RedelegateRequest request);

Task<GasEstimateResponse> PostRedelegationSimulationAsync(RedelegateRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostRedelegationSimulation(RedelegateRequest request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseRequest = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, null, null, null, null, null);
var redelegationRequest = new RedelegateRequest(baseRequest, Configuration.GlobalDelegator1Address, Configuration.GlobalValidator1Address, Configuration.GlobalValidator2Address, new Coin("uatom", 10));

var tx = await client
    .Staking
    .PostRedelegationAsync(redelegationRequest);
```

### Description
Format a redelegation request transaction. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**request** - [RedelegateRequest](#redelegaterequest)

#### RedelegateRequest
```csharp
public class RedelegateRequest
{
    public BaseReq BaseReq;
    public string DelegatorAddress;
    public string ValidatorSrcAddress;
    public string ValidatorDstAddress;
    public Coin Amount;
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetValidators
```csharp
Task<ResponseWithHeight<IList<Validator>>> GetValidatorsAsync(BondStatus? status = default, int? page = default, int? limit = default, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Validator>> GetValidators(BondStatus? status = default, int? page = default, int? limit = default);
ResponseWithHeight<IList<Validator>> GetValidators(string delegatorAddr);
Task<ResponseWithHeight<Validator>> GetValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var validators = await client
    .Staking
    .GetValidatorsAsync();
```

### Description
Get all validator candidates. By default it returns only the bonded validators.

### Parameters
**status** - The validator bond status.
**page** - The page number.
**limit** - The maximum number of items per page.
**delegatorAddr** - Bech32 AccAddress of Delegator.

### Returns
List of [Validator](#validator) struct

#### Validator
Validator defines the total amount of bond shares and their exchange rate to coins. Slashing results in a decrease in the exchange rate, allowing correct calculation of future undelegations without iterating over delegators. When coins are delegated to this validator, the validator is credited with a delegation whose number of bond shares is based on the amount of coins delegated divided by the current exchange rate. Voting power can be calculated as total bonded shares multiplied by exchange rate.

```csharp
public class Validator
{
    /// Address of the validator's operator; bech encoded in JSON.
    public string OperatorAddress { get; set; } = null!;
    /// The consensus public key of the validator; bech encoded in JSON.
    public string ConsPubKey { get; set; } = null!;
    /// Has the validator been jailed from bonded status.
    public bool Jailed { get; set; }
    /// Validator status (bonded/unbonding/unbonded).
    public BondStatus Status { get; set; }
    /// delegated tokens (incl. self-delegation).
    public BigInteger Tokens { get; set; }
    /// Total shares issued to a validator's delegators. 
    public BigDecimal DelegatorShares { get; set; }
    /// Description terms for the validator.
    public ValidatorDescription Description { get; set; } = null!;
    /// If unbonding, height at which this validator has begun unbonding.
    public long UnbondingHeight { get; set; }
    /// If unbonding, min time for the validator to complete unbonding. 
    public DateTimeOffset UnbondingCompletionTime { get; set; }
    /// Commission parameters.
    public ValidatorCommission Commission { get; set; } = null!;
    /// Validator's self declared minimum self delegation.
    public BigInteger MinSelfDelegation { get; set; }
}

public enum BondStatus
{
    Unbonded = 0,
    Unbonding = 1,
    Bonded = 2,
}

public class ValidatorDescription
{
    /// Name.
    public string Moniker { get; set; } = null!;
    /// Optional identity signature (ex. UPort or Keybase).
    public string Identity { get; set; } = null!;
    /// Optional website link.
    public string Website { get; set; } = null!;
    /// Optional details.
    public string Details { get; set; } = null!;
}

public class ValidatorCommission
{
    public CommissionRates CommissionRates { get; set; } = null!;
    /// The last time the commission rate was changed.
    public DateTimeOffset UpdateTime { get; set; }
}
```

## GetValidator
```csharp
Task<ResponseWithHeight<Validator>> GetValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<Validator> GetValidator(string delegatorAddr, string validatorAddr);
cancellationToken = default);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var validators = await client
    .Staking
    .GetValidatorsAsync(BondStatus.Bonded, limit: 3);
```

### Description
Query a validator that a delegator is bonded to.

### Parameters
**delegatorAddr** - Bech32 AccAddress of Delegator.
**validatorAddr** - Bech32 ValAddress of Delegator.

### Returns
[Validator](#validator) struct

## GetTransactions
```csharp
Task<IList<PaginatedTxs>> GetTransactionsAsync(string delegatorAddr, IList<DelegatingTxType>? txTypes = default, CancellationToken 
IList<PaginatedTxs> GetTransactions(string delegatorAddr, IList<DelegatingTxType>? txTypes = default);
```
### Example
This example shows how to get Bond transactions.

```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var txTypes = new List<DelegatingTxType>()
{
    DelegatingTxType.Bond
};
var txs = await client
    .Staking
    .GetTransactionsAsync(Configuration.GlobalDelegator1Address, txTypes);
```

### Description
Get the list of delegation transactions by delegator address and transaction type

### Parameters
**delegatorAddr** - Delegator address
**txTypes** - Transaction types

### Returns
List of [PaginatedTxs](#paginatedtxs)

## GetDelegationsByValidator
```csharp
Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsByValidatorAsync(string validatorAddr, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Delegation>> GetDelegationsByValidator(string validatorAddr);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var validatorResponse = await client
    .Staking
    .GetValidatorAsync(Configuration.GlobalValidator1Address);
```

### Description
Get all delegations for a validator.

### Parameters
**validatorAddr** - Bech32 OperatorAddress of validator

### Returns
List of [Delegation](#delegation) struct

## GetStakingPool
```csharp
Task<ResponseWithHeight<StakingPool>> GetStakingPoolAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<StakingPool> GetStakingPool();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var pool = await client
    .Staking
    .GetStakingPoolAsync();
```

### Description
Get the current state of the staking pool.

### Parameters
None 

### Returns
[StakingPool](#stakingpool) struct

#### StakingPool
```csharp
public class StakingPool
{
    public BigInteger NotBondedTokens;
    public BigInteger BondedTokens;
}

```

## GetStakingParams
```csharp
Task<ResponseWithHeight<StakingParams>> GetStakingParamsAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<StakingParams> GetStakingParams();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var @params = await client
    .Staking
    .GetStakingParamsAsync();
```

### Description
Get the current staking parameter values

### Parameters
None

### Returns
[StakingParams](#stakingparams) struct

#### StakingParams
```csharp
public class StakingParams
{
    /// Nanoseconds count.
    public long UnbondingTime;
    public ushort MaxValidators;
    public ushort MaxEntries;
    public string BondDenom;
}
```

# Government API
## GetProposals
```csharp
Task<ResponseWithHeight<IList<Proposal>>> GetProposalsAsync(string? voter = default, string? depositor = default, ProposalStatus? status = default, ulong? limit = default, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Proposal>> GetProposals(string? voter = default, string? depositor = default, ProposalStatus? status = default, ulong? limit = default);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var proposals = await client
    .Governance
    .GetProposalsAsync(limit: 5);
```

### Description
Query proposals.

### Parameters
**voter** - Voter address.
**depositor** - Depositor address.
**status** - Proposal status.
**limit** - Maximum number of items.

### Returns
List of [Proposal](#proposal) struct

#### Proposal
```csharp
public class Proposal
{
    public IProposalContent Content;
    public ulong ProposalId;
    public ProposalStatus Status;
    public TallyResult FinalTallyResult;
    public DateTimeOffset SubmitTime;
    public DateTimeOffset DepositEndTime;
    public IList<Coin> TotalDeposit;
    public DateTimeOffset VotingStartTime;
    public DateTimeOffset VotingEndTime;
}
```

## PostProposal
```csharp
Task<GasEstimateResponse> PostProposalSimulationAsync(PostProposalReq request, CancellationToken cancellationToken = default);
Task<GasEstimateResponse> PostProposalSimulationAsync(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType, CancellationToken cancellationToken = default);
Task<GasEstimateResponse> PostProposalSimulationAsync<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, CancellationToken cancellationToken = default) where TContentType : IProposalContent;
GasEstimateResponse PostProposalSimulation(PostProposalReq request);
GasEstimateResponse PostProposalSimulation(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType);
GasEstimateResponse PostProposalSimulation<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit) where TContentType : IProposalContent;
Task<StdTx> PostProposalAsync(PostProposalReq request, CancellationToken cancellationToken = default);
Task<StdTx> PostProposalAsync(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType, CancellationToken cancellationToken = default);
Task<StdTx> PostProposalAsync<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, CancellationToken cancellationToken = default) where TContentType : IProposalContent;
StdTx PostProposal(PostProposalReq request);
StdTx PostProposal(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType);
StdTx PostProposal<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit) where TContentType : IProposalContent;
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "", null, null, null, null);
var initialDeposit = new List<Coin>()
{
    new Coin()
    {
        Amount = 10,
        Denom = "uatom"
    }
};
var stdTx = await client
    .Governance
    .PostProposalAsync<TextProposal>(baseReq, "title", "description", Configuration.GlobalDelegator1Address, initialDeposit);
```

### Description
Format a proposal transaction. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**request** - PostProposalReq struct
**baseReq** - base request
**title** - Proposal title
**description** - Proposal description
**proposer** - Proposer address
**initialDeposit** - Initial proposal deposit
**proposalContentType** - Proposal type

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetProposal
```csharp
Task<ResponseWithHeight<Proposal>> GetProposalAsync(ulong id, CancellationToken cancellationToken = default);
ResponseWithHeight<Proposal> GetProposal(ulong id);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var proposal = await client
    .Governance
    .GetProposalAsync(1);
```

### Description
Query a proposal.

### Parameters
**id** - Proposal ID

### Returns
[Proposal](#proposal) struct

## GetProposerByProposalId
```csharp
Task<ResponseWithHeight<Proposer>> GetProposerByProposalIdAsync(ulong proposalId, CancellationToken cancellationToken = default);
ResponseWithHeight<Proposer> GetProposerByProposalId(ulong proposalId);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var proposer = await client
    .Governance
    .GetProposerByProposalIdAsync(ProposalId);
```

### Description
Query proposer.

### Parameters
**proposalId** - Proposal ID to query proposer for

### Returns
[Proposer](#proposer) struct

#### Proposer
```csharp
public class Proposer
{
    public ulong ProposalId { get; set; }
    public string ProposerAddress { get; set; } = null!;
}
```

## GetDeposits
```csharp
Task<ResponseWithHeight<IList<Deposit>>> GetDepositsAsync(ulong proposalId, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Deposit>> GetDeposits(ulong proposalId);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var deposits = await client
    .Governance
    .GetDepositsAsync(ProposalId);
```

### Description
Query deposits.

### Parameters
**proposalId** - Proposal ID

### Returns
List of [Deposit](#deposit) struct

#### Deposit
```csharp
public class Deposit
{
    public IList<Coin> Amount;
    public ulong ProposalId;
    public string Depositor;
}
```

## PostDeposit
```csharp
Task<GasEstimateResponse> PostDepositSimulationAsync(ulong proposalId, DepositReq request, CancellationToken cancellationToken = default);
GasEstimateResponse PostDepositSimulation(ulong proposalId, DepositReq request);
Task<StdTx> PostDepositAsync(ulong proposalId, DepositReq request, CancellationToken cancellationToken = default);
StdTx PostDeposit(ulong proposalId, DepositReq request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "memo", null, null, null, null);
var amount = new List<Coin>()
{
    new Coin()
    {
        Amount = 10,
        Denom = "uatom"
    }
};
var depositReq = new DepositReq(baseReq, Configuration.GlobalDelegator1Address, amount);
var tx = await client
    .Governance
    .PostDepositAsync(ProposalId, depositReq);
```

### Description
Format a transaction to deposit tokens to a proposal. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**proposalId** - Proposal ID
**request** - Deposit request, [DepositReq](#depositreq) struct

#### DepositReq
```csharp
public class DepositReq
{
    public BaseReq BaseReq;
    
    /// Address of the depositor.
    public string Depositor;

    /// Coins to add to the proposal's deposit.
    public IList<Coin> Amount;
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetDeposit
```csharp
Task<ResponseWithHeight<Deposit>> GetDepositAsync(ulong proposalId, string depositor, CancellationToken cancellationToken = default);
ResponseWithHeight<Deposit> GetDeposit(ulong proposalId, string depositor);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var deposits = await client
    .Governance
    .GetDepositsAsync(ProposalId);
var expectedDeposit = deposits.Result.First();

var deposit = await client
    .Governance
    .GetDepositAsync(ProposalId, expectedDeposit.Depositor);
```

### Description
Query deposits by proposal ID and depositor.

### Parameters
**proposalId** - Proposal ID
**depositor** - Depositor account

### Returns
[Deposit](#deposit) struct

## GetVotes
```csharp
Task<ResponseWithHeight<IList<Vote>>> GetVotesAsync(ulong proposalId, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<Vote>> GetVotes(ulong proposalId);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var votes = await client
    .Governance
    .GetVotesAsync(ProposalId);
```

### Description
Query voters information by proposalId.

### Parameters
**proposalId** - Proposal ID

### Returns
List of [Vote](#vote) struct

#### Vote
```csharp
public class Vote
{
    public string Voter;
    public ulong ProposalId;
    public VoteOption Option;
}
```

## PostVote
```csharp
Task<GasEstimateResponse> PostVoteSimulationAsync(ulong proposalId, VoteReq request, CancellationToken cancellationToken = default);
GasEstimateResponse PostVoteSimulation(ulong proposalId, VoteReq request);

Task<StdTx> PostVoteAsync(ulong proposalId, VoteReq request, CancellationToken cancellationToken = default);
StdTx PostVote(ulong proposalId, VoteReq request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "memo", null, null, null, null);
var voteReq = new VoteReq(baseReq, Configuration.GlobalDelegator1Address, VoteOption.Yes);

var tx = await client
    .Governance
    .PostVoteAsync(ProposalId, voteReq);
```

### Description
Format a voting transaction. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**proposalId** - Proposal ID
**request** - Voting request, [VoteReq](#votereq) struct

#### VoteReq
```csharp
public class VoteReq
{
    public BaseReq BaseReq;
    /// Address of the voter.
    public string Voter; 
    public VoteOption Option;
}

public enum VoteOption : byte
{
    Empty = 0x00,
    Yes = 0x01,
    Abstain = 0x02,
    No = 0x03,
    NoWithVeto = 0x04,
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetVote
```csharp
Task<ResponseWithHeight<Vote>> GetVoteAsync(ulong proposalId, string voter, CancellationToken cancellationToken = default);
ResponseWithHeight<Vote> GetVote(ulong proposalId, string voter);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var votes = await client
    .Governance
    .GetVotesAsync(ProposalId);

var expectedVote = votes.Result.Last();

var vote = await client
    .Governance
    .GetVoteAsync(ProposalId, expectedVote.Voter);
```

### Description
Query vote information by proposal Id and voter address.

### Parameters
**proposalId** - Proposal ID
**voter** - Bech32 voter address

### Returns
[Vote](#vote) struct

## GetTally
```csharp
Task<ResponseWithHeight<TallyResult>> GetTallyAsync(ulong proposalId, CancellationToken cancellationToken = default);
ResponseWithHeight<TallyResult> GetTally(ulong proposalId);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var tally = await client
    .Governance
    .GetTallyAsync(ProposalId);
```

### Description
Gets a proposal’s tally result at the current time. If the proposal is pending deposits (i.e status ‘DepositPeriod’) it returns an empty tally result.

### Parameters
**proposalId** - Proposal ID

### Returns
[TallyResult](#tallyresult) struct

#### TallyResult
```csharp
public class TallyResult
{
    public BigDecimal Yes { get; set; }
    public BigDecimal Abstain { get; set; }
    public BigDecimal No { get; set; }
    public BigDecimal NoWithVeto { get; set; }
}
```

## GetDepositParams
```csharp
Task<ResponseWithHeight<DepositParams>> GetDepositParamsAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<DepositParams> GetDepositParams();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var depositParams = await client
    .Governance
    .GetDepositParamsAsync();
```

### Description
Query governance deposit parameters.

### Parameters
None

### Returns
[DepositParams](#depositparams) struct

#### DepositParams
```csharp
public class DepositParams
{
    /// Minimum deposit for a proposal to enter voting period.
    public IList<Coin>? MinDeposit;
    
    /// Maximum period in nanoseconds for Atom holders to deposit on a proposal.
    public long? MaxDepositPeriod;
}
```

## GetTallyParams
```csharp
Task<ResponseWithHeight<TallyParams>> GetTallyParamsAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<TallyParams> GetTallyParams();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var tallyParams = await client
    .Governance
    .GetTallyParamsAsync();
```

### Description
Query governance tally parameters.

### Parameters
None

### Returns
[TallyParams](#tallyparams) struct

#### TallyParams
```csharp
public class TallyParams
{
    /// Minimum percentage of total stake needed to vote for a result to be considered valid.
    public BigDecimal? Quorum;
    
    /// Minimum proportion of Yes votes for proposal to pass.
    public BigDecimal? Threshold;
    
    /// Minimum value of Veto votes to Total votes ratio for proposal to be vetoed.
    public BigDecimal? Veto;
}
```

## GetVotingParams
```csharp
Task<ResponseWithHeight<VotingParams>> GetVotingParamsAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<VotingParams> GetVotingParams();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var votingParams = await client
    .Governance
    .GetVotingParamsAsync();
```

### Description
Query governance voting parameters.

### Parameters
None 

### Returns
[VotingParams](#votingparams) struct

#### VotingParams
```csharp
public class VotingParams
{
    /// Length of the voting period in nanoseconds.
    public long? VotingPeriod;
}
```

# Slashing API
## GetSigningInfo
```csharp
Task<ResponseWithHeight<ValidatorSigningInfo>> GetSigningInfoAsync(string publicKey, CancellationToken cancellationToken = default);
ResponseWithHeight<ValidatorSigningInfo> GetSigningInfo(string publicKey);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var validators = await client.Staking.GetValidatorsAsync();
var validator = validators.Result.First();
```

### Description
Get sign info of a validator.

### Parameters
**publicKey** - Validator's public key.

### Returns
[ValidatorSigningInfo](#validatorsigninginfo) struct

#### ValidatorSigningInfo
```csharp
public class ValidatorSigningInfo
{
    /// Validator consensus address. 
    public string Address { get; set; } = null!;
    /// Height at which validator was first a candidate OR was unjailed.
    public long StartHeight { get; set; }
    /// Index offset into signed block bit array. 
    public long IndexOffset { get; set; }
    /// Timestamp validator cannot be unjailed until. 
    public DateTimeOffset JailedUntil { get; set; }
    /// Whether or not a validator has been tombstoned (killed out of validator set). 
    public bool Tombstoned { get; set; }
    /// Missed blocks counter (to avoid scanning the array every time). 
    public long MissedBlocksCounter { get; set; } 
}
```

## GetSigningInfos
```csharp
Task<ResponseWithHeight<IList<ValidatorSigningInfo>>> GetSigningInfosAsync(int? page = default, int? limit = default, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<ValidatorSigningInfo>> GetSigningInfos(int? page = default, int? limit = default);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var signingInfos = await client
    .Slashing
    .GetSigningInfosAsync();
```

### Description
Get signing info of multiple validators.

### Parameters
**page** - Page number.
**limit** - Maximum number of items per page.

### Returns
[ValidatorSigningInfo](#validatorsigninginfo) struct

## PostUnjail
```csharp
Task<GasEstimateResponse> PostUnjailSimulationAsync(string validatorAddress, UnjailRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostUnjailSimulation(string validatorAddress, UnjailRequest request);
Task<StdTx> PostUnjailAsync(string validatorAddress, UnjailRequest request, CancellationToken cancellationToken = default);
StdTx PostUnjail(string validatorAddress, UnjailRequest request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);

var stdTx = await client
    .Slashing
    .PostUnjailAsync(Configuration.LocalValidator1Address, new UnjailRequest(baseReq));
```

### Description
Format Unjail transaction. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**validatorAddress** - Validator address
**request** - [UnjailRequest](#unjailrequest) request

#### UnjailRequest
```csharp
public class UnjailRequest
{
    public BaseReq BaseReq { get; set; } = null!;
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## Get Slashing Parameters
```csharp
Task<ResponseWithHeight<SlashingParams>> GetParametersAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<SlashingParams> GetParameters();
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var slashingParams = await client
    .Slashing
    .GetParametersAsync();
```

### Description
Get the current slashing parameters.

### Parameters
None

### Returns
[SlashingParams](#slashingparams) struct

#### SlashingParams
```csharp
public class SlashingParams
{
    /// Duration in nanoseconds.
    public long MaxEvidenceAge { get; set; }
    public long SignedBlocksWindow { get; set; }
    public BigDecimal MinSignedPerWindow { get; set; }
    /// Duration in nanoseconds.
    public long DowntimeJailDuration { get; set; }
    public BigDecimal SlashFractionDoubleSign { get; set; }
    public BigDecimal SlashFractionDowntime { get; set; }
}
```

# Distribution API
## GetDelegatorRewards
```csharp
ResponseWithHeight<DelegatorTotalRewards> GetDelegatorRewards(string delegatorAddress);
Task<ResponseWithHeight<DelegatorTotalRewards>> GetDelegatorRewardsAsync(string delegatorAddress, CancellationToken cancellationToken = default);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var rewards = await client
    .Distribution
    .GetDelegatorRewardsAsync(Configuration.LocalDelegator1Address);
```

### Description
Get the total rewards balance from all delegations.

### Parameters
**delegatorAddress** - Delegator address to query

### Returns
[DelegatorTotalRewards](#delegatortotalrewards) struct

#### DelegatorTotalRewards
```csharp
public class DelegatorTotalRewards
{
    public IList<DelegationDelegatorReward> Rewards;
    public IList<DecCoin> Total;
}
```

## PostWithdrawRewards
```csharp
Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(string delegatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostWithdrawRewardsSimulation(string delegatorAddress, WithdrawRewardsRequest request);
Task<StdTx> PostWithdrawRewardsAsync(string delegatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);
StdTx PostWithdrawRewards(string delegatorAddress, WithdrawRewardsRequest request);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseRequest = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);
var stdTx = await client
    .Distribution
    .PostWithdrawRewardsAsync(Configuration.LocalDelegator1Address, new WithdrawRewardsRequest(baseRequest));
```

### Description
Format a withdraw all delegator rewards transaction. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.
### Parameters
**delegatorAddress** - Delegator address
**request** - [WithdrawRewardsRequest](#withdrawrewardsrequest) struct

#### WithdrawRewardsRequest
```csharp
public class WithdrawRewardsRequest
{
    public BaseReq BaseReq { get; set; } = null!;
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetWithdrawAddress
```csharp
Task<ResponseWithHeight<string>> GetWithdrawAddressAsync(string delegatorAddress, CancellationToken cancellationToken = default);
ResponseWithHeight<string> GetWithdrawAddress(string delegatorAddress);
```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var rewards = await client
    .Distribution
    .GetDelegatorRewardsAsync(Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address);
```

### Description
Get the delegations' rewards withdrawal address. This is the address in which the user will receive the reward funds.

### Parameters
**delegatorAddress** - Delegator address to query

### Returns
Withdraw address string

## PostWithdrawAddress
```csharp
Task<GasEstimateResponse> PostWithdrawAddressSimulationAsync(string delegatorAddress, SetWithdrawalAddrRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostWithdrawAddressSimulation(string delegatorAddress, SetWithdrawalAddrRequest request);
Task<StdTx> PostWithdrawAddressAsync(string delegatorAddress, SetWithdrawalAddrRequest request, CancellationToken cancellationToken = default);
StdTx PostWithdrawAddress(string delegatorAddress, SetWithdrawalAddrRequest request);

```
### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseRequest = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);
var stdTx = await client
    .Distribution
    .PostWithdrawRewardsAsync(Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, new WithdrawRewardsRequest(baseRequest));
```

### Description
Format a transaction to replace the delegations' rewards withdrawal address for a new one. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**delegatorAddress** - Delegator address
**request** - [SetWithdrawalAddrRequest](#setwithdrawaladdrrequest) struct

#### SetWithdrawalAddrRequest
```csharp
public class SetWithdrawalAddrRequest
{
    public BaseReq BaseReq { get; set; } = null!;
    public string WithdrawAddress { get; set; } = null!;
}
```

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetValidatorDistributionInfo
```csharp
Task<ResponseWithHeight<ValidatorDistInfo>> GetValidatorDistributionInfoAsync(string validatorAddress, CancellationToken cancellationToken = default);
ResponseWithHeight<ValidatorDistInfo> GetValidatorDistributionInfo(string validatorAddress);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var address = await client
    .Distribution
    .GetWithdrawAddressAsync(Configuration.LocalDelegator1Address);
```

### Description
Query the distribution information of a single validator.

### Parameters
**validatorAddress** - Validator address

### Returns
[ValidatorDistInfo](#validatordistinfo) struct

#### ValidatorDistInfo
```csharp
public class ValidatorDistInfo
{
    public string OperatorAddress;
    public IList<DecCoin> SelfBondRewards;
    public IList<DecCoin> ValCommission;
}
```

## GetValidatorOutstandingRewards
```csharp
Task<ResponseWithHeight<IList<DecCoin>>> GetValidatorOutstandingRewardsAsync(string validatorAddress, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<DecCoin>> GetValidatorOutstandingRewards(string validatorAddress);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var rewards = await client
    .Distribution
    .GetValidatorOutstandingRewardsAsync(Configuration.LocalValidator1Address);
```

### Description
Fee distribution outstanding rewards of a single validator.

### Parameters
**validatorAddress** - Validator address

### Returns
List of [DecCoin](#deccoin) struct

#### DecCoin
DecCoin defines a coin which can have additional decimal points.

```csharp
public class DecCoin
{
    public string Denom { get; set; } = null!;
    public BigDecimal Amount { get; set; }
}
```

## GetValidatorRewards
```csharp
Task<ResponseWithHeight<IList<DecCoin>>> GetValidatorRewardsAsync(string validatorAddress, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<DecCoin>> GetValidatorRewards(string validatorAddress);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var rewards = await client
    .Distribution
    .GetValidatorRewardsAsync(Configuration.LocalValidator1Address);
```

### Description
Query the commission and self-delegation rewards of validator.

### Parameters
**validatorAddress** - Validator address

### Returns
List of [DecCoin](#deccoin) struct

## PostValidatorWithdrawRewards
```csharp
Task<GasEstimateResponse> PostValidatorWithdrawRewardsSimulationAsync(string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);
GasEstimateResponse PostValidatorWithdrawRewardsSimulation(string validatorAddress, WithdrawRewardsRequest request);
Task<StdTx> PostValidatorWithdrawRewardsAsync(string validatorAddress, WithdrawRewardsRequest request
StdTx PostValidatorWithdrawRewards(string validatorAddress, WithdrawRewardsRequest request);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
var stdTx = await client
    .Distribution
    .PostValidatorWithdrawRewardsAsync(Configuration.LocalValidator1Address, new WithdrawRewardsRequest(baseRequest));
```

### Description
Format a transaction to withdraw the validator's self-delegation and commissions rewards. Sign and send it with [SignAndBroadcastStdTxAsync](#sending-transactions) method.

### Parameters
**validatorAddress** - Validator address
**request** - [WithdrawRewardsRequest](#withdrawrewardsrequest) struct

### Returns
Transaction in JSON format.
The simulation version returns [GasEstimateResponse](#gasestimateresponse) struct.

## GetCommunityPool
```csharp
Task<ResponseWithHeight<IList<DecCoin>>> GetCommunityPoolAsync(long? height = default, CancellationToken cancellationToken = default);
ResponseWithHeight<IList<DecCoin>> GetCommunityPool(long? height = default);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var communityPool = await client
    .Distribution
    .GetCommunityPoolAsync();
```

### Description
Fee distribution parameters.

### Parameters
**height** - Block to query

### Returns
List of [DecCoin](#deccoin) struct

## Get Distribution Parameters
```csharp
Task<ResponseWithHeight<DistributionParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default);
ResponseWithHeight<DistributionParams> GetParams(long? height = default);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var @params = await client
    .Distribution
    .GetParamsAsync();
```

### Description
Get fee distribution parameters.

### Parameters
**height** - Block to query

### Returns
[DistributionParams](#distributionparams)

#### DistributionParams
```csharp
public class DistributionParams
{
    public BigDecimal CommunityTax;
    public BigDecimal BaseProposerReward;
    public BigDecimal BonusProposerReward;
    public bool WithdrawAddrEnabled;
}
```

# Minting API
## Get Minting Parameters
```csharp
Task<ResponseWithHeight<MintParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default);
ResponseWithHeight<MintParams> GetParams(long? height = default);
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var @params = await client
    .Mint
    .GetParamsAsync();
```

### Description
Minting module parameters.

### Parameters
**height** - Block to query

### Returns
[MintParams](#mintparams) struct

#### MintParams
```csharp
public class MintParams
{
    /// Type of coin to mint.
    public string MintDenom;
    /// Maximum annual change in inflation rate.
    public BigDecimal InflationRateChange;
    /// Maximum inflation rate.
    public BigDecimal InflationMax;
    /// minimum inflation rate.
    public BigDecimal InflationMin;
    /// Goal of percent bonded atoms.
    public BigDecimal GoalBonded;
    /// Expected blocks per year.
    public ulong BlocksPerYear;
}
```

## GetInflation
```csharp
Task<ResponseWithHeight<BigDecimal>> GetInflationAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<BigDecimal> GetInflation();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var inflation = await client
    .Mint
    .GetInflationAsync();
```

### Description
Current minting inflation value.

### Parameters
None 

### Returns
BigDecimal inflation rate

## GetAnnualProvisions
```csharp
Task<ResponseWithHeight<BigDecimal>> GetAnnualProvisionsAsync(CancellationToken cancellationToken = default);
ResponseWithHeight<BigDecimal> GetAnnualProvisions();
```

### Example
```csharp
using var client = new CosmosApiBuilder()
    .UseBaseUrl("localhost:1317")
    .RegisterCosmosSdkTypeConverters()
    .CreateClient();

var annualProvisions = await client
    .Mint
    .GetAnnualProvisionsAsync();
```

### Description
Current minting annual provisions value.

### Parameters
None

### Returns
BigDecimal provisions value

