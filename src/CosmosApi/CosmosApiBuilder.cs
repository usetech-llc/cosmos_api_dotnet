using System;
using System.Collections.Immutable;
using CosmosApi.Models;
using Newtonsoft.Json;

namespace CosmosApi
{
    public class CosmosApiBuilder : ICosmosApiBuilder
    {
        private readonly ImmutableList<Action<CosmosApiClientSettings>> _settingConfigurators = ImmutableList.Create<Action<CosmosApiClientSettings>>();

        internal CosmosApiBuilder(ImmutableList<Action<CosmosApiClientSettings>> settingConfigurators)
        {
            _settingConfigurators = settingConfigurators;
        }

        public CosmosApiBuilder()
        {
        }

        public ICosmosApiClient CreateClient()
        {
            var settings = new CosmosApiClientSettings();
            foreach (var configurator in _settingConfigurators)
            {
                configurator(settings);
            }
            
            return new CosmosApiClient(settings);
        }

        public ICosmosApiBuilder Configure(Action<CosmosApiClientSettings> configurator)
        {
            return new CosmosApiBuilder(_settingConfigurators.Add(configurator));
        }

        public ICosmosApiBuilder UseAuthorization(string username, string password)
        {
            return Configure(s =>
            {
                s.Password = password;
                s.Username = username;
            });
        }

        public ICosmosApiBuilder UseBaseUrl(string url)
        {
            return Configure(s => s.BaseUrl = url);
        }

        public ICosmosApiBuilder RegisterTxType<T>(string jsonName) where T : ITx
        {
            return Configure(s => s.TxConverter.AddType<T>(jsonName));
        }

        public ICosmosApiBuilder RegisterMsgType<T>(string jsonName) where T : IMsg
        {
            return Configure(s => s.MsgConverter.AddType<T>(jsonName));
        }

        public ICosmosApiBuilder RegisterAccountType<T>(string jsonName) where T : IAccount
        {
            return Configure(s => s.AccountConverter.AddType<T>(jsonName));
        }

        public ICosmosApiBuilder RegisterProposalContentType<T>(string jsonName) where T : IProposalContent
        {
            return Configure(s => s.ProposalContentConverter.AddType<T>(jsonName));
        }

        public ICosmosApiBuilder AddJsonConverter(JsonConverter converter)
        {
            return Configure(configuration => configuration.Converters.Add(converter));
        }

        public ICosmosApiBuilder RegisterCosmosSdkTypeConverters()
        {
            return Configure(configuration =>
            {
                configuration.TxConverter.AddType<StdTx>("cosmos-sdk/StdTx");
                
                configuration.MsgConverter.AddType<MsgMultiSend>("cosmos-sdk/MsgMultiSend");
                configuration.MsgConverter.AddType<MsgSend>("cosmos-sdk/MsgSend");
                configuration.MsgConverter.AddType<MsgDelegate>("cosmos-sdk/MsgDelegate");
                configuration.MsgConverter.AddType<MsgUndelegate>("cosmos-sdk/MsgUndelegate");
                configuration.MsgConverter.AddType<MsgBeginRedelegate>("cosmos-sdk/MsgBeginRedelegate");
                configuration.MsgConverter.AddType<MsgSubmitProposal>("cosmos-sdk/MsgSubmitProposal");
                configuration.MsgConverter.AddType<MsgVerifyInvariant>("cosmos-sdk/MsgVerifyInvariant");
                configuration.MsgConverter.AddType<MsgSetWithdrawAddress>("cosmos-sdk/MsgModifyWithdrawAddress");
                configuration.MsgConverter.AddType<MsgWithdrawDelegatorReward>("cosmos-sdk/MsgWithdrawDelegationReward");
                configuration.MsgConverter.AddType<MsgWithdrawValidatorCommission>("cosmos-sdk/MsgWithdrawValidatorCommission");
                configuration.MsgConverter.AddType<MsgDeposit>("cosmos-sdk/MsgDeposit");
                configuration.MsgConverter.AddType<MsgVote>("cosmos-sdk/MsgVote");
                configuration.MsgConverter.AddType<MsgUnjail>("cosmos-sdk/MsgUnjail");
                configuration.MsgConverter.AddType<MsgCreateValidator>("cosmos-sdk/MsgCreateValidator");

                configuration.AccountConverter.AddType<BaseAccount>("cosmos-sdk/Account");
                
                configuration.ProposalContentConverter.AddType<TextProposal>("cosmos-sdk/TextProposal");
                configuration.ProposalContentConverter.AddType<CommunityPoolSpendProposal>("cosmos-sdk/CommunityPoolSpendProposal");
                configuration.ProposalContentConverter.AddType<SoftwareUpgradeProposal>("cosmos-sdk/SoftwareUpgradeProposal");
                configuration.ProposalContentConverter.AddType<ParameterChangeProposal>("cosmos-sdk/ParameterChangeProposal");
            });
        }
    }
}