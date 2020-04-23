# Cosmos .NET API

This API enables connection and interaction between a .NET application and a Cosmos blockchain node built with Cosmos SDK.

- [Getting Started](#getting-started)
- [Connecting to a Node](#connecting-to-a-node)
- [Tendermint API](#tendermint-api)
  * [Node Info](#node-info)
  * [Synching Status](#synching-status)
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

### ICosmosApiBuilder interface

The interface `ICosmosApiBuilder` is created to help create the api client. [Above](#simple-connect) is the example how it can be used to build an api object. Below you will find details for each method.

#### CreateClient

##### Description

Creates a new instance of Cosmos Api Client

##### Parameters

None 

##### Returns

An API object that is ready to be used with a node. See [ICosmosApiClient](#icosmosapiclient-interface) for details.

#### Configure

##### Description

Sets settings of created clients using Action.

##### Parameters

**configurator** Action<CosmosApiClientSettings> . See [CosmosApiClientSettings](#cosmosapiclientsettings) for details.

##### Returns

ICosmosApiBuilder for method chaining.

#### UseAuthorization

##### Description
Sets username and password authorization for created clients

##### Parameters

**username** string - User name
**password** string - Password

##### Returns
ICosmosApiBuilder for method chaining.

#### UseBaseUrl

##### Description
Sets the base url used by created clients.

##### Parameters
**url** string - Node URL

##### Returns
ICosmosApiBuilder for method chaining.

#### RegisterTxType

##### Description
Adds a possible subtype of the [ITx](#itx-interface) so it can be serialized and deserialized properly.
##### Parameters
**T** Type Parameter - Type which might be used where [ITx](#itx-interface) is used.
**jsonName** string - Value of the type discriminator.

##### Returns
ICosmosApiBuilder for method chaining.

#### RegisterMsgType

##### Description
Adds a possible subtype of the [IMsg](#imsg-interface) so it can be serialized and deserialized properly. 

##### Parameters
**T** Type Parameter - Type which might be used where [IMsg](#imsg-interface) is used.
**jsonName** string - Value of the type discriminator.

##### Returns
ICosmosApiBuilder for method chaining.

#### RegisterTypeValue

##### Description
Adds a possible Value type of [TypeValue](#typevalue)

##### Parameters
**T** Type Parameter - Type of TypeValue's Value.
**jsonName** string - Value of json discriminator.

##### Returns
ICosmosApiBuilder for method chaining.

#### AddJsonConverterFactory

##### Description
Adds a converter factory to use for serialization and deserialization.

##### Parameters
**factory** IConverterFactory - Converter Factory

##### Returns
ICosmosApiBuilder for method chaining.

### ICosmosApiClient Interface

### CosmosApiClientSettings

### ITx Interface

### IMsg Interface

### TypeValue
