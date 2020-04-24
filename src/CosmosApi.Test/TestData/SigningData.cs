using System.Collections.Generic;
using CosmosApi.Extensions;
using CosmosApi.Models;

namespace CosmosApi.Test.TestData
{
    public class SigningData
    {
        public static StdSignDoc StdSignDoc()
        {
            return new StdSignDoc()
            {
                Fee = new StdFee(100000, new List<Coin>()),
                Memo = "test_memo",
                Sequence = 17,
                AccountNumber = 13,
                ChainId = "test_chain",
                Messages = new List<IMsg>()
                {
                    new MsgSend()
                    {
                        FromAddress = "cosmos1qypqxpq9qcuhfwyx",
                        ToAddress = "cosmos1v4nxw5wt6j7",
                        Amount = new List<Coin>()
                        {
                            new Coin("foocoin", 10)
                        }
                    }
                }
            };
        }

        public static byte[] StdSignDocBytes() => ByteArrayExtensions.ParseHexString(
            "7b226163636f756e745f6e756d626572223a223133222c22636861696e5f6964223a22746573745f636861696e222c22666565223a7b22616d6f756e74223a5b5d2c22676173223a22313030303030227d2c226d656d6f223a22746573745f6d656d6f222c226d736773223a5b7b2274797065223a22636f736d6f732d73646b2f4d736753656e64222c2276616c7565223a7b22616d6f756e74223a5b7b22616d6f756e74223a223130222c2264656e6f6d223a22666f6f636f696e227d5d2c2266726f6d5f61646472657373223a22636f736d6f733171797071787071397163756866777978222c22746f5f61646472657373223a22636f736d6f733176346e7877357774366a37227d7d5d2c2273657175656e6365223a223137227d");
    }
}