using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class StakingTests : BaseTest
    {
        public StakingTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }


        [Fact]
        public async Task AsyncGetDelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = await client
                .Staking
                .GetDelegationsAsync(Configuration.LocalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized into:");
            Dump(delegations);
            
            Assert.NotEmpty(delegations.Result);
            Assert.True(delegations.Result[0].Balance > 0);
            Assert.True(delegations.Result[0].Shares > 0);
        }
        
        [Fact]
        public void SyncGetDelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = client
                .Staking
                .GetDelegations(Configuration.LocalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized into:");
            Dump(delegations);
            
            Assert.NotEmpty(delegations.Result);
            Assert.True(delegations.Result[0].Balance > 0);
            Assert.True(delegations.Result[0].Shares > 0);
        }

        [Fact]
        public async Task AsyncPostSimulatedDelegationCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.LocalDelegator1Address)).Result;
            
            var chainId = await GetChainId(client);
            var baseRequest = new BaseReq(Configuration.LocalDelegator1Address, null, chainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));

            var postResult = await client
                .Staking
                .PostDelegationsSimulationAsync(delegateRequest);
            OutputHelper.WriteLine("Deserialized gas estimate:");
            Dump(postResult);
            OutputHelper.WriteLine("");
            
            Assert.NotNull(postResult);
        }

        [Fact]
        public async Task AsyncPostDelegationCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.LocalDelegator1Address)).Result;
            
            var chainId = await GetChainId(client);
            var baseRequest = new BaseReq(Configuration.LocalDelegator1Address, null, chainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));

            var postResult = await client
                .Staking
                .PostDelegationsAsync(delegateRequest);
            OutputHelper.WriteLine("Deserialized tx:");
            Dump(postResult);
            OutputHelper.WriteLine("");
            
            Assert.True(postResult.Msg.Count > 0);
            var msgDelegate = postResult
                .Msg
                .OfType<MsgDelegate>()
                .First();
            Assert.Equal("stake", msgDelegate.Amount.Denom);
            Assert.Equal(10, msgDelegate.Amount.Amount);
        }

        [Fact]
        public async Task AsyncGetDelegationByValidatorCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegation = await client
                .Staking
                .GetDelegationByValidatorAsync(Configuration.LocalDelegator1Address,
                    Configuration.LocalValidatorAddress);
            OutputHelper.WriteLine("Deserialized delegation:");
            Dump(delegation);
            OutputHelper.WriteLine("");
            
            Assert.True(delegation.Result.Balance > 0);
            Assert.True(delegation.Result.Shares > 0);
        }

        //There is a "Completion time" in response and it's 2020-05-13, wonder if it will be removed by that time and break this test.
        [Fact]
        public async Task AsyncGetUnbondingDelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = await client
                .Staking
                .GetUnbondingDelegationsAsync(Configuration.LocalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized delegations:");
            Dump(delegations);

            Assert.NotEmpty(delegations.Result);
            Assert.Equal(Configuration.LocalDelegator1Address, delegations.Result[0].DelegatorAddress);
            Assert.Equal(Configuration.LocalValidatorAddress, delegations.Result[0].ValidatorAddress);
            Assert.True(delegations.Result[0].Entries[0].Balance > 0);
        }

        [Fact]
        public async Task AsyncPostUnbondingCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.LocalDelegator1Address)).Result;
            
            var chainId = await GetChainId(client);
            var baseRequest = new BaseReq(Configuration.LocalDelegator1Address, null, chainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var undelegateRequest = new UndelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));
            var tx = (await client
                .Staking
                .PostUnbondingDelegationAsync(undelegateRequest));

            OutputHelper.WriteLine("Deserialized tx:");
            Dump(undelegateRequest);
            OutputHelper.WriteLine("");

            var undelegateMessage = tx.Msg
                .OfType<MsgUndelegate>()
                .First(); 
            
            Assert.Equal("stake", undelegateMessage.Amount.Denom);
            Assert.Equal(10, undelegateMessage.Amount.Amount);
            Assert.Equal(Configuration.LocalDelegator1Address, undelegateMessage.DelegatorAddress);
            Assert.Equal(Configuration.LocalValidatorAddress, undelegateMessage.ValidatorAddress);
        }

        [Fact]
        public async Task AsyncGetUnbondingDelegationsByValidatorNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var result = await client
                    .Staking
                    .GetUnbondingDelegationsByValidatorAsync(Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress);
            OutputHelper.WriteLine("Deserialized unbonding delegation:");
            Dump(result);

            var unbondingDelegation = result.Result;
            Assert.Equal(Configuration.LocalValidatorAddress, unbondingDelegation.ValidatorAddress);
            Assert.Equal(Configuration.LocalDelegator1Address, unbondingDelegation.DelegatorAddress);
            Assert.True(unbondingDelegation.Entries[0].Balance > 0);
        }

        [Fact]
        public async Task AsyncGetRedelegationsAllRedelegationsNotEmpty()
        {
            using var client = CreateClient();

            var result = await client
                .Staking
                .GetRedelegationsAsync();
            OutputHelper.WriteLine("Deserialized redelegations:");
            Dump(result);
            
            Assert.NotEmpty(result.Result);
        }

        [Fact]
        public async Task AsyncGetRedelegationsReturnsKnownDelegatorsAndValidators()
        {
            using var client = CreateClient();

            var result = await client
                .Staking
                .GetRedelegationsAsync(Configuration.GlobalDelegator1Address, Configuration.GlobalValidator1Address, Configuration.GlobalValidator2Address);
            OutputHelper.WriteLine("Deserialized redelegations:");
            Dump(result);

            foreach (var redelegation in result.Result)
            {
                Assert.Equal(Configuration.GlobalDelegator1Address, redelegation.DelegatorAddress);
                Assert.Equal(Configuration.GlobalValidator1Address, redelegation.ValidatorSrcAddress);
                Assert.Equal(Configuration.GlobalValidator2Address, redelegation.ValidatorDstAddress);
            }
        }

        [Fact]
        public async Task AsyncPostRedelegationSimulationCompletes()
        {
            using var client = CreateClient();
            
            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.GlobalDelegator1Address)).Result;
            var chainId = await GetChainId(client);
            var baseRequest = new BaseReq(Configuration.GlobalDelegator1Address, null, chainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var redelegationRequest = new RedelegateRequest(baseRequest, Configuration.GlobalDelegator1Address, Configuration.GlobalValidator1Address, Configuration.GlobalValidator2Address, new Coin("uatom", 10));

            var gasEstimation = await client
                .Staking
                .PostRedelegationSimulationAsync(redelegationRequest);
            
            OutputHelper.WriteLine("Deserialized gas estimation:");
            Dump(gasEstimation);
            
            Assert.NotNull(gasEstimation);
        }

        [Fact]
        public async Task PostRedelegationCompletes()
        {
            using var client = CreateClient();
            
            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.GlobalDelegator1Address)).Result;
            var chainId = await GetChainId(client);
            var baseRequest = new BaseReq(Configuration.GlobalDelegator1Address, null, chainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var redelegationRequest = new RedelegateRequest(baseRequest, Configuration.GlobalDelegator1Address, Configuration.GlobalValidator1Address, Configuration.GlobalValidator2Address, new Coin("uatom", 10));

            var tx = await client
                .Staking
                .PostRedelegationAsync(redelegationRequest);
            
            OutputHelper.WriteLine("Deserialized tx:");
            Dump(tx);

            var msgRedelegate = tx
                .Msg
                .OfType<MsgBeginRedelegate>()
                .First();
            Assert.Equal("uatom", msgRedelegate.Amount.Denom);
            Assert.Equal(10, msgRedelegate.Amount.Amount);
            Assert.Equal(Configuration.GlobalDelegator1Address, msgRedelegate.DelegatorAddress);
            Assert.Equal(Configuration.GlobalValidator1Address, msgRedelegate.ValidatorSrcAddress);
            Assert.Equal(Configuration.GlobalValidator2Address, msgRedelegate.ValidatorDstAddress);
        }

        [Fact]
        public async Task AsyncGetValidatorsCompletes()
        {
            using var client = CreateClient();

            var validators = await client
                .Staking
                .GetValidatorsAsync();
            
            OutputHelper.WriteLine("Deserialized validators:");
            Dump(validators);
            
            Assert.NotEmpty(validators.Result);
        }

        [Fact]
        public async Task AsyncGetValidatorsFilterAppliesCorrectly()
        {
            using var client = CreateClient();

            var validators = await client
                .Staking
                .GetValidatorsAsync(BondStatus.Bonded, limit: 3);
            
            OutputHelper.WriteLine("Deserialized validators:");
            Dump(validators);
            
            Assert.True(validators.Result.Count <= 3);
            Assert.True(validators.Result.All(v => v.Status == BondStatus.Bonded));
        }

        [Fact]
        public async Task AsyncGetValidatorsByDelegateReturnsKnownValue()
        {
            using var client = CreateClient();

            var validators = await client
                .Staking
                .GetValidatorsAsync(Configuration.GlobalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized validators:");
            Dump(validators);

            Assert.NotEmpty(validators.Result);
            var hasValidator1 = validators.Result.Any(v => string.Equals(v.OperatorAddress, Configuration.GlobalValidator1Address, StringComparison.Ordinal));
            Assert.True(hasValidator1);
        }

        [Fact]
        public async Task AsyncGetValidatorByDelegatorAndValidatorAddressReturnsQueriedValidator()
        {
            using var client = CreateClient();

            var validator = await client
                .Staking
                .GetValidatorAsync(Configuration.GlobalDelegator1Address, Configuration.GlobalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized validator:");
            Dump(validator);
            
            Assert.Equal(Configuration.GlobalValidator1Address, validator.Result.OperatorAddress);
        }

        [Fact]
        public async Task AsyncGetTransactionsReturnsTransactionsForKnownDelegate()
        {
            using var client = CreateClient();

            var txs = await client
                .Staking
                .GetTransactionsAsync(Configuration.GlobalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized transactions:");
            Dump(txs);
            
            Assert.NotEmpty(txs);
            foreach (var tx in txs)
            {
                Assert.NotEmpty(tx.Txs);
            }
        }

        [Fact]
        public async Task AsyncGetTransactionsBondFilterReturnsOnlyBondingTransactions()
        {
            using var client = CreateClient();

            var txTypes = new List<DelegatingTxType>()
            {
                DelegatingTxType.Bond
            };
            var txs = await client
                .Staking
                .GetTransactionsAsync(Configuration.GlobalDelegator1Address, txTypes);
            
            OutputHelper.WriteLine("Deserialized transactions:");
            Dump(txs);

            var allTxsAreBond = txs
                .All(paginatedTx =>
                {
                    return paginatedTx.Txs.All(t =>
                    {
                        return t.Tx.GetMsgs().Any(msg => msg is MsgDelegate);
                    });
                });
            Assert.True(allTxsAreBond);
        }

        [Fact]
        public async Task GetValidatorByValidatorAddressNotEmpty()
        {
            using var client = CreateClient();

            var validatorResponse = await client
                .Staking
                .GetValidatorAsync(Configuration.GlobalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized Validator:");
            Dump(validatorResponse);
            
            Assert.NotNull(validatorResponse);
            Assert.NotNull(validatorResponse.Result);
            Assert.NotEmpty(validatorResponse.Result.ConsPubKey);
        }

        //[Fact]
        //Browser shows ERR_INCOMPLETE_CHUNKING_ENCODING for that method, unable to test.
        public async Task GetDelegationsByValidatorHasKnownDelegator()
        {
            using var client = CreateClient();

            var delegations = await client
                .Staking
                .GetDelegationsByValidatorAsync(Configuration.GlobalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized Delegations:");
            Dump(delegations);

            Assert.Contains(delegations.Result,
                d => string.Equals(Configuration.GlobalDelegator1Address, d.DelegatorAddress));
        }
    }
}