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
                .GetDelegationsAsync(Configuration.LocalAccount1Address);
            
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
                .GetDelegations(Configuration.LocalAccount1Address);
            
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

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
            var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, new Coin("stake", 10));

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

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
            var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, new Coin("stake", 10));

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
        public async Task AsyncGetDelegationByValidatorNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegation = await client
                .Staking
                .GetDelegationByValidatorAsync(Configuration.LocalAccount1Address,
                    Configuration.LocalValidator1Address);
            OutputHelper.WriteLine("Deserialized delegation:");
            Dump(delegation);
            OutputHelper.WriteLine("");
            
            Assert.True(delegation.Result.Balance > 0);
            Assert.True(delegation.Result.Shares > 0);
        }

        [Fact]
        public async Task AsyncGetUnbondingDelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = await client
                .Staking
                .GetUnbondingDelegationsAsync(Configuration.LocalAccount1Address);
            
            OutputHelper.WriteLine("Deserialized delegations:");
            Dump(delegations);
            
            Assert.NotEmpty(delegations.Result);
            Assert.All(delegations.Result, d => { UnbondingDelegationNotEmpty(d); });
        }

        private void UnbondingDelegationNotEmpty(UnbondingDelegation d)
        {
            Assert.Equal(Configuration.LocalAccount1Address, d.DelegatorAddress);
            Assert.Equal(Configuration.LocalValidator1Address, d.ValidatorAddress);
            Assert.NotEmpty(d.Entries);
            Assert.All(d.Entries, entry =>
            {
                Assert.True(entry.Balance > 0);
                Assert.True(entry.InitialBalance > 0);
                Assert.True(entry.CreationHeight > 0);
            });
        }

        [Fact]
        public async Task AsyncPostUnbondingCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
            var undelegateRequest = new UndelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, new Coin("stake", 10));
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
            Assert.Equal(Configuration.LocalValidator1Address, undelegateMessage.ValidatorAddress);
        }

        [Fact]
        public async Task AsyncGetUnbondingDelegationsByValidatorNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var result = await client
                    .Staking
                    .GetUnbondingDelegationsByValidatorAsync(Configuration.LocalAccount1Address, Configuration.LocalValidator1Address);
            OutputHelper.WriteLine("Deserialized unbonding delegation:");
            Dump(result);
            
            UnbondingDelegationNotEmpty(result.Result);   
        }

        //[Fact]
        //can't figure out how to make redelegate on local network.
        public async Task AsyncGetRedelegationsAllRedelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var result = await client
                .Staking
                .GetRedelegationsAsync();
            OutputHelper.WriteLine("Deserialized redelegations:");
            Dump(result);
            
            Assert.NotEmpty(result.Result);
            Assert.All(result.Result, r =>
            {
                Assert.NotEmpty(r.DelegatorAddress);
                Assert.NotEmpty(r.ValidatorDstAddress);
                Assert.NotEmpty(r.ValidatorSrcAddress);
                Assert.NotEmpty(r.Entries);
                Assert.All(r.Entries, entry =>
                {
                    Assert.True(entry.CreationHeight > 0);
                    Assert.True(entry.InitialBalance > 0);
                    Assert.True(entry.SharesDst > 0);
                });
            });
        }

        //[Fact]
        //can't figure out how to make redelegate on local network.
        public async Task AsyncGetRedelegationsReturnsKnownDelegatorsAndValidators()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var result = await client
                .Staking
                .GetRedelegationsAsync(Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, Configuration.LocalValidator1Address);
            OutputHelper.WriteLine("Deserialized redelegations:");
            Dump(result);

            Assert.NotEmpty(result.Result);
            Assert.All(result.Result, redelegation =>
            {
                Assert.Equal(Configuration.LocalDelegator1Address, redelegation.DelegatorAddress);
                Assert.Equal(Configuration.LocalValidator1Address, redelegation.ValidatorSrcAddress);
                Assert.Equal(Configuration.LocalValidator1Address, redelegation.ValidatorDstAddress);
                Assert.True(redelegation.Entries.Count == 1);
                var entry = redelegation.Entries[0];
                Assert.True(entry.CreationHeight > 0);
                Assert.True(entry.InitialBalance > 0);
                Assert.True(entry.SharesDst > 0);
            });
        }

        [Fact]
        public async Task AsyncPostRedelegationSimulationCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
            var redelegationRequest = new RedelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, Configuration.LocalValidator2Address, new Coin("stake", 10));

            var gasEstimation = await client
                .Staking
                .PostRedelegationSimulationAsync(redelegationRequest);
            
            OutputHelper.WriteLine("Deserialized gas estimation:");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostRedelegationCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null);
            var redelegationRequest = new RedelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidator1Address, Configuration.LocalValidator2Address, new Coin("stake", 10));

            var tx = await client
                .Staking
                .PostRedelegationAsync(redelegationRequest);
            
            OutputHelper.WriteLine("Deserialized tx:");
            Dump(tx);

            var msgRedelegate = tx
                .Msg
                .OfType<MsgBeginRedelegate>()
                .First();
            Assert.Equal("stake", msgRedelegate.Amount.Denom);
            Assert.Equal(10, msgRedelegate.Amount.Amount);
            Assert.Equal(Configuration.LocalDelegator1Address, msgRedelegate.DelegatorAddress);
            Assert.Equal(Configuration.LocalValidator1Address, msgRedelegate.ValidatorSrcAddress);
            Assert.Equal(Configuration.LocalValidator2Address, msgRedelegate.ValidatorDstAddress);
        }

        [Fact]
        public async Task AsyncGetValidatorsCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validators = await client
                .Staking
                .GetValidatorsAsync();
            
            OutputHelper.WriteLine("Deserialized validators:");
            Dump(validators);
            
            Assert.NotEmpty(validators.Result);
            Assert.All(validators.Result, ValidatorNotEmpty);
        }

        private static void ValidatorNotEmpty(Validator v)
        {
            Assert.NotEmpty(v.OperatorAddress);
            Assert.NotEmpty(v.ConsPubKey);
            Assert.True(v.Commission.CommissionRates.Rate > 0);
            Assert.True(v.Commission.CommissionRates.MaxRate > 0);
            Assert.True(v.Commission.CommissionRates.MaxChangeRate > 0);
            Assert.True(v.MinSelfDelegation > 0);
            Assert.True(v.Tokens > 0);
            Assert.True(v.DelegatorShares > 0);
            Assert.Equal(BondStatus.Bonded, v.Status);
        }

        [Fact]
        public async Task AsyncGetValidatorsFilterAppliesCorrectly()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validators = await client
                .Staking
                .GetValidatorsAsync(BondStatus.Bonded, limit: 3);
            
            OutputHelper.WriteLine("Deserialized validators:");
            Dump(validators);
            
            Assert.True(validators.Result.Count <= 3);
            Assert.True(validators.Result.All(v => v.Status == BondStatus.Bonded));
            Assert.All(validators.Result, ValidatorNotEmpty);
        }

        [Fact]
        public async Task AsyncGetValidatorsByDelegateReturnsKnownValue()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validators = await client
                .Staking
                .GetValidatorsAsync(Configuration.LocalAccount1Address);
            
            OutputHelper.WriteLine("Deserialized validators:");
            Dump(validators);

            Assert.NotEmpty(validators.Result);
            var hasValidator1 = validators.Result.Any(v => string.Equals(v.OperatorAddress, Configuration.LocalValidator1Address, StringComparison.Ordinal));
            Assert.True(hasValidator1);
            Assert.All(validators.Result, ValidatorNotEmpty);
        }

        [Fact]
        public async Task AsyncGetValidatorByDelegatorAndValidatorAddressReturnsQueriedValidator()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validator = await client
                .Staking
                .GetValidatorAsync(Configuration.LocalAccount1Address, Configuration.LocalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized validator:");
            Dump(validator);
            
            Assert.Equal(Configuration.LocalValidator1Address, validator.Result.OperatorAddress);
            ValidatorNotEmpty(validator.Result);
        }

        [Fact]
        public async Task AsyncGetTransactionsReturnsTransactionsForKnownDelegate()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var txs = await client
                .Staking
                .GetTransactionsAsync(Configuration.LocalAccount1Address);
            
            OutputHelper.WriteLine("Deserialized transactions:");
            Dump(txs);
            
            Assert.NotEmpty(txs);
            Assert.All(txs, tx =>
            {
                Assert.NotEmpty(tx.Txs);
                Assert.All(tx.Txs, TxIsDelegateAndNotEmpty);
            });
        }

        [Fact]
        public async Task AsyncGetTransactionsBondFilterReturnsOnlyBondingTransactions()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var txTypes = new List<DelegatingTxType>()
            {
                DelegatingTxType.Bond
            };
            var txs = await client
                .Staking
                .GetTransactionsAsync(Configuration.LocalAccount1Address, txTypes);
            
            OutputHelper.WriteLine("Deserialized transactions:");
            Dump(txs);

            
            Assert.NotEmpty(txs);
            Assert.All(txs, tx =>
            {
                Assert.NotEmpty(tx.Txs);
                Assert.All(tx.Txs, TxIsDelegateAndNotEmpty);
            });
        }

        [Fact]
        public async Task GetValidatorByValidatorAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validatorResponse = await client
                .Staking
                .GetValidatorAsync(Configuration.LocalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized Validator:");
            Dump(validatorResponse);
            
            ValidatorNotEmpty(validatorResponse.Result);
        }

        [Fact]
        public async Task GetDelegationsByValidatorHasKnownDelegator()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = await client
                .Staking
                .GetDelegationsByValidatorAsync(Configuration.LocalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized Delegations:");
            Dump(delegations);

            Assert.All(delegations.Result,
                d =>
                {
                    Assert.Equal(Configuration.LocalValidator1Address, d.ValidatorAddress);
                    Assert.NotEmpty(d.DelegatorAddress);
                });
        }

        [Fact]
        public async Task GetUnbondingDelegationsByValidatorCompletes()
        {    
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var unbondingDelegations = await client
                .Staking
                .GetUnbondingDelegationsByValidatorAsync(Configuration.LocalValidator1Address);
            
            OutputHelper.WriteLine("Deserialized Unbonding Delegations:");
            Dump(unbondingDelegations);
            Assert.NotEmpty(unbondingDelegations.Result);
            Assert.All(unbondingDelegations.Result, UnbondingDelegationNotEmpty);
        }

        [Fact]
        public async Task GetStakingPoolNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var pool = await client
                .Staking
                .GetStakingPoolAsync();
            
            OutputHelper.WriteLine("Deserialized Staking Pool:");
            Dump(pool);
            
            Assert.NotNull(pool);
            Assert.NotNull(pool.Result);
            Assert.True(pool.Result.NotBondedTokens >= 0);
            Assert.True(pool.Result.BondedTokens >= 0);
        }

        [Fact]
        public async Task GetStakingParametersNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var @params = await client
                .Staking
                .GetStakingParamsAsync();
            
            OutputHelper.WriteLine("Deserialized Staking Params:");
            Dump(@params);
            
            Assert.NotNull(@params);
            Assert.NotNull(@params.Result);
            Assert.True(@params.Result.MaxEntries > 0);
            Assert.True(@params.Result.MaxValidators > 0);
            Assert.True(@params.Result.UnbondingTime > 0);
            Assert.NotEmpty(@params.Result.BondDenom);
        }
    }
}