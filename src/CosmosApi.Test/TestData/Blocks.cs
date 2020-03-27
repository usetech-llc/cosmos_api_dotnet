using System;
using CosmosApi.Extensions;
using CosmosApi.Models;

namespace CosmosApi.Test.TestData
{
    public class Blocks
    {
        private static DateTimeOffset ParseDateTime(string str) =>
            DateTimeOffset.Parse(str);

        private static byte[] ParseHex(string str) => ByteArrayExtensions.ParseHexString(str);
        private static byte[] ParseBase64(string str) => ByteArrayExtensions.ParseBase64(str);

        /// <summary>
        /// Creates block response, which was made by querying https://api.cosmos.network/blocks/3
        /// And converting resulting json to C# code. 
        /// </summary>
        public static BlockQuery BlockQueryHeight3()
        {
            return new BlockQuery()
            {
                BlockMeta = BlockMetaHeight3(),
                Block = BlockHeight3(),
            };
        }

        private static Block BlockHeight3()
        {
            var block = new Block()
            {
                Header = new BlockHeader()
                {
                    Version = new BlockHeaderVersion()
                    {
                        Block = 10,
                        App = 0
                    },
                    ChainId = "cosmoshub-3",
                    Height = 3,
                    Time = ParseDateTime("2019-12-11T16:31:40.962459814Z"),
                    NumTxs = 0,
                    TotalTxs = 0,
                    LastBlockId = new BlockID()
                    {
                        Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                        Parts = new BlockIDParts()
                        {
                            Total = 1,
                            Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                        }
                    },
                    LastCommitHash = ParseHex("7B04B817963FBAE67E819E0F65C9374DC85360946BF572BE5041AA30967D52B0"),
                    DataHash = new byte[0],
                    ValidatorsHash = ParseHex("D6C5C2B123802BD4910BAC6F9E9A6FDC29BC4AF8128FE996C6C5FDA3CEB08B31"),
                    NextValidatorsHash = ParseHex("D6C5C2B123802BD4910BAC6F9E9A6FDC29BC4AF8128FE996C6C5FDA3CEB08B31"),
                    ConsensusHash = ParseHex("0F2908883A105C793B74495EB7D6DF2EEA479ED7FC9349206A65CB0F9987A0B8"),
                    AppHash = ParseHex("91A08E1315CDED3B19C6719D2E7A8762BED55C4CD81E415F9F77B92C63BE89A4"),
                    LastResultsHash = new byte[0],
                    EvidenceHash = new byte[0],
                    ProposerAddress = ParseHex("2199EAE894CA391FA82F01C2C614BFEB103D056C")
                },
                Data = new BlockData()
                {
                    Transactions = null
                },
                Evidence = new EvidenceData()
                {
                    Evidence = null
                },
                LastCommit = new BlockLastCommit()
                {
                    BlockId = new BlockID()
                    {
                        Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                        Parts = new BlockIDParts()
                        {
                            Total = 1,
                            Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                        }
                    },
                    Precommits = new CommitSig?[]
                    {
                                             new CommitSig()
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.109988985Z"),
                                                 ValidatorAddress = ParseHex("000001E443FD237E4B616E2FA69DF4EE3D49A94F"),
                                                 ValidatorIndex = 0,
                                                 Signature = ParseBase64(
                                                     "RKTopeIZMI8iUcj7xiN8woOm/g4Axo1x0Yn6B5BSkUsH99Ivy+uECG4vDTbXmE0/CDSHt6yvehLUGMs5rFKPCA==")
                                             },
                                             new CommitSig()
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.052551621Z"),
                                                 ValidatorAddress = ParseHex("000AA5ABF590A815EBCBDAE070AFF50BE571EB8B"),
                                                 ValidatorIndex = 1,
                                                 Signature = ParseBase64(
                                                     "I1h/uKL//ivmXtefzExvKl9hUulOlPlFi5UuSip8A2+8NRxx5Wiq1adV0lIMmcpOaM8GaKE3QWuFtJR8qAkhDA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.913215324Z"),
                                                 ValidatorAddress = ParseHex("019B9CA2944D3CC36C7C73283EF3D58E56C8A5D4"),
                                                 ValidatorIndex = 2,
                                                 Signature = ParseBase64(
                                                     "EMJSMExnOanSIMmNUkmvIXGabexYU8BdIUn7eAO+sUZxa66+cJHpR7embYL9qsgDnsCLKiAvrQpz/XThKg4qCw==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.973058952Z"),
                                                 ValidatorAddress = ParseHex("099E2B09583331AFDE35E5FA96673D2CA7DEA316"),
                                                 ValidatorIndex = 4,
                                                 Signature = ParseBase64(
                                                     "tkuES8xwZDLItCmFaGW3IZ7xLsgAn6mYGc/3gRtQksAJs9gONhHIhnnxmZxmrLrKeRwgWLiMnxcnbSLeuKHtCw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.86869629Z"),
                                                 ValidatorAddress = ParseHex("0D2186876D26D882F7BE50DED92BD3CB53838143"),
                                                 ValidatorIndex = 5,
                                                 Signature = ParseBase64(
                                                     "cHR2DXPkEiWxyl0v/Tr41Sr1ctNfyRVB1gYmNkXu25ueaSeqZPFTourWTyxjnJZrYNk57glNNbyC2fpccE+BCQ==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.073774014Z"),
                                                 ValidatorAddress = ParseHex("1AE0BD432F9A5122474A646325D1AFA6068692E9"),
                                                 ValidatorIndex = 7,
                                                 Signature = ParseBase64(
                                                     "WfCTuvU5eXWIIe0ORWrYIwhgnXLljNdtsoVA+ghGClki32weHv180CfLql0oyD7a7hgx+7Yar5WGVwl1ft5EBA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.908249991Z"),
                                                 ValidatorAddress = ParseHex("1E9CE94FD0BA5CFEB901F90BC658D64D85B134D2"),
                                                 ValidatorIndex = 8,
                                                 Signature = ParseBase64(
                                                     "qZZjkhtMO8RnJDCvnA3S8XCfkXpIhxh2CwXaGiPVM0yZrlMwpUlWrbOE7tNu3TpSgU/wnH6VNeoj7YdwJIlHCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.908094811Z"),
                                                 ValidatorAddress = ParseHex("2199EAE894CA391FA82F01C2C614BFEB103D056C"),
                                                 ValidatorIndex = 9,
                                                 Signature = ParseBase64(
                                                     "ZofUbdA+7UX+fczNhG9cje1W9UwVcwkcnbBl2zp6NLKaui9up1ofW9LulcAl9jHEEuD32VFaw13oVMUkwVgkBw==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.906521359Z"),
                                                 ValidatorAddress = ParseHex("2B9A55D3BF93D7375DD207B75C5ED4D2B91D9146"),
                                                 ValidatorIndex = 11,
                                                 Signature = ParseBase64(
                                                     "znp3IkSjEy39K+N35v2DP7NqLbV6R/7+5lrx2hIMwJgj7HFN/XBhbakDszgxgx9aDRChSckVL82F/I5beXRQCw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.935094205Z"),
                                                 ValidatorAddress = ParseHex("2C528D2345ED6E953C1C0819E2C3A01ABFCBA557"),
                                                 ValidatorIndex = 12,
                                                 Signature = ParseBase64(
                                                     "YbYfGXkA4To/N5AMYpU0uWXocyw6sVhWYKLIMCOEgC5VR1SnZtbDHjb+/PDkFUKr00b/1+yy5XNobI2/CJvoCA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.995566952Z"),
                                                 ValidatorAddress = ParseHex("2C9CCC317FB283D54AC748838A64F29106039E51"),
                                                 ValidatorIndex = 13,
                                                 Signature = ParseBase64(
                                                     "pO3D364l7+YsG11GUQeM4MHVuA7PBl6InLihqmRKj+00+KU0p8qu3X8rPBHJW3midonW9B6K82HaAsCpXI1dCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.919846319Z"),
                                                 ValidatorAddress = ParseHex("31920F9BC3A39B66876CC7D6D5E589E10393BF0E"),
                                                 ValidatorIndex = 14,
                                                 Signature = ParseBase64(
                                                     "bdnrxzb3bPRF50yK5FdPv3jySGTpvGxhr1GmWM2TkWMEpLF7M/Jt52a7ybBBMKwsvbUrfl7zw8sTUI6NUYhIBA==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.937814314Z"),
                                                 ValidatorAddress = ParseHex("34337FEEE36B03CC9D5C9F59B308C0E317DB607C"),
                                                 ValidatorIndex = 16,
                                                 Signature = ParseBase64(
                                                     "obtXAYgTbC5eicEVSNyYrIeARGtX/1ni1hV2YhtbzFGhfE+9ZRsXtk4bEooIk0ApA2Q8jyEMeXxzd6sU+nSUAA==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.96022764Z"),
                                                 ValidatorAddress = ParseHex("407F144D1C9DEA4EE6A8CBC2D4C022A657506B83"),
                                                 ValidatorIndex = 18,
                                                 Signature = ParseBase64(
                                                     "wBNnfgAQUJTRu8ekVMVqQWA182Tgf9nrFvc4z9BZhF9uaMoLp/4wAQFv0Vp6QkaXm3qH4TlzvMRc7YKL7V6vBA==")
                                             },
                                             null,
                                             null,
                                             null,
                                             null,
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.966805838Z"),
                                                 ValidatorAddress = ParseHex("4C92230FAC162303D981C06DD22663A4FC7622BC"),
                                                 ValidatorIndex = 24,
                                                 Signature = ParseBase64(
                                                     "sdME5iKKgKJG21Cjfs3Ygl1/vlqoCdeKpPeQDroEg7MqBmdKUZ2NRPhFs/6DijHstY9NCGM3TzDhTIWEjxr+DQ==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.093939806Z"),
                                                 ValidatorAddress = ParseHex("51205659A717DFFB96E054F8BD1108730E17AEA7"),
                                                 ValidatorIndex = 26,
                                                 Signature = ParseBase64(
                                                     "UNJE0xvlU+p3kPIR7Z7gJDUqoDJg+7xGgc5uPRbGkCgUkCvYVSWdXSkJbsd0vw6Extm0CD7+j07jYUhJilI1AQ==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.838708036Z"),
                                                 ValidatorAddress = ParseHex("52E1646134432BF9532B4881C6ED32E40AE5A2DD"),
                                                 ValidatorIndex = 28,
                                                 Signature = ParseBase64(
                                                     "0ZHr5FaSdwWMdZ4pxmYf/cuaoQJLTGqxZCwYiBpMUoGHK3iIgGEcUM46ShbNqxtOoUsaBjk2F4RGIR2WITMAAg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.033447159Z"),
                                                 ValidatorAddress = ParseHex("5731848E19257705AA28CC7EFAA8C708EE014D52"),
                                                 ValidatorIndex = 29,
                                                 Signature = ParseBase64(
                                                     "yFzs5y+Hj7LXceQE8XKAH7vqK5ttu0O0ejybdpbmWF+iFcq8xxjJ9Gt84quusycq2atfcXjq+NZV3/F1ioZ/CA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.93709884Z"),
                                                 ValidatorAddress = ParseHex("57713BB7421C7FEB381B863FC87DED5E829AA961"),
                                                 ValidatorIndex = 30,
                                                 Signature = ParseBase64(
                                                     "bE05DOGLeZLvy1QJ+1myJ+vRd9u667NwgWXS6TFoEkUINDD488oVSJCiNkPY4b7CWB7vgR8Rsz1gqWzG0M5pAg==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.017136596Z"),
                                                 ValidatorAddress = ParseHex("671460930CCDC9B06C5D055E4D550EB8DAF2291E"),
                                                 ValidatorIndex = 32,
                                                 Signature = ParseBase64(
                                                     "PclfGsTG3OC9Hsav7O+ZF0M9zQjANVXHcQzev+zBzn+/tzXDyENONMlZcBCQoEubG5cu5JLfxR6md2MwAandDg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.962459814Z"),
                                                 ValidatorAddress = ParseHex("679B89785973BE94D4FDF8B66F84A929932E91C5"),
                                                 ValidatorIndex = 33,
                                                 Signature = ParseBase64(
                                                     "pQMw/AOUT+LLys77jgXSWx6l/Z+FjRiIEFaCnJR6+c57EMrA3hhpowRiQoQ3b6vlVoNwtENb2epxKUNTaNzuAg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.067171933Z"),
                                                 ValidatorAddress = ParseHex("68F5BBEACEF114C720EA9C98BFA2FFDE01C54FD1"),
                                                 ValidatorIndex = 34,
                                                 Signature = ParseBase64(
                                                     "0zfFuXaBNHw/HE6bRvUwTthVVqqICqScoXVPg7MBbJvsR18mWEiDt/gRGDFe9j5yte58DsBQ2ULSMtiJ3iEUCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.018137521Z"),
                                                 ValidatorAddress = ParseHex("696ABC95186FD65A07050C28AB00C9358A315030"),
                                                 ValidatorIndex = 35,
                                                 Signature = ParseBase64(
                                                     "pep1hCpDA43pxKGoUl3UXxpxKcDAbBABII2jS6U1ZwfBGxGJZUEBRN5X1+9RQ5blWRgGAl0vau7HAqY4iOBGCw==")
                                             },
                                             null,
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.00176892Z"),
                                                 ValidatorAddress = ParseHex("70C5B4E6779C59A24CFD9146581E27021C2AEC26"),
                                                 ValidatorIndex = 38,
                                                 Signature = ParseBase64(
                                                     "My1Zsg9S2HgpZHokN6nzN9ujncGojWzql7oSnmVq4RInXZ5KLryL6Akva8e7wmy3P+x/+G7sjPzxcppBdEigDw==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.999672648Z"),
                                                 ValidatorAddress = ParseHex("75DAB316F4CA1367F532AB71A80B7FA65AB69039"),
                                                 ValidatorIndex = 40,
                                                 Signature = ParseBase64(
                                                     "CRa5/mg0Q5PMW0MM/MJAEU7lRl3Oz7EHnm5ULcT2DQHuSiBWFpHC4N4Agq3sSa7PwuqLUXmHVjP0yn2d9ByeBg==")
                                             },
                                             null,
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.073829252Z"),
                                                 ValidatorAddress = ParseHex("7B3A2EFE5B3FCDF819FCF52607314CEFE4754BB6"),
                                                 ValidatorIndex = 43,
                                                 Signature = ParseBase64(
                                                     "zrzwpVHqS1Mmu18KMWUVcZJcE6Pu/AM7e2mhq/fFbFHptsTscZtj89k9FdlPU4+i18Vr7hyoWBD6N5OWbp2+Dg==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.879005476Z"),
                                                 ValidatorAddress = ParseHex("808D6B054A0B6D3FF5F5EAF0A65CFC64C543F833"),
                                                 ValidatorIndex = 45,
                                                 Signature = ParseBase64(
                                                     "3uCVov1kkHRbYLbGMRDGgTXqbGtsqcM/mwGBy0cRwMBN20UNk1AXmAObPRcBEtmBBUm+nNWrAm8nIvfwmepRAw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.994152514Z"),
                                                 ValidatorAddress = ParseHex("818964B4FB36D28109C3E853778B33231B27C5FC"),
                                                 ValidatorIndex = 46,
                                                 Signature = ParseBase64(
                                                     "JWQY4JCAcqn9W32Ou5GqYaCyfYxogjWZ5QMzABk9gWTaWtFaBuNd7c/+4PUiM/x+JKBRU2ibOzCJMiG/Dud/Aw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.910447378Z"),
                                                 ValidatorAddress = ParseHex("81965FE8A15FA8078C9202F32E4CFA72F85F2A22"),
                                                 ValidatorIndex = 47,
                                                 Signature = ParseBase64(
                                                     "k/SJj/tUhOZFH8UMRS5baC8NKmx1zbnbe9UggUijczmzDAUDLpcZu6cDBvoCx24TQnDIwJaG7tV6P+REuY7CAw==")
                                             },
                                             null,
                                             null,
                                             null,
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.123659145Z"),
                                                 ValidatorAddress = ParseHex("8E0EE37B7B1A038DD145E30F1EF97DF3619EF429"),
                                                 ValidatorIndex = 52,
                                                 Signature = ParseBase64(
                                                     "BMOtBTxWNAXx9R7H8kPfImB+9vre5T1KCCZgcTqMLQs7D0PHV6VIAmFiE2uGGW8qObUoqn1L/8Ej+4zsVN5bCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.903127369Z"),
                                                 ValidatorAddress = ParseHex("8FE3CFFA6A07B093E441BB84DA1B6DABF53AFA2D"),
                                                 ValidatorIndex = 53,
                                                 Signature = ParseBase64(
                                                     "nNz5Tg7i2Jip9f2bOOXQ9dHfrjtadAeI9zOxiIcHa7FWtBWwCIvu1QJwY5nIbEZrCwzVF9CGen5W1IU8MOoGBQ==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.158091219Z"),
                                                 ValidatorAddress = ParseHex("955A47C8AC8632825DD475E90913D40AB09D3FB4"),
                                                 ValidatorIndex = 55,
                                                 Signature = ParseBase64(
                                                     "b6jXEgOyU7ScbJP812ij++y+7LBHbe+FDgyeayGCyle52+tDXKJnYotnkC2TCuTSHv3I9v2JzTnATFfmdqYRAQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:12.445614036Z"),
                                                 ValidatorAddress = ParseHex("95E060D07713070FE9822F6C50BD76BCCBF9F17A"),
                                                 ValidatorIndex = 56,
                                                 Signature = ParseBase64(
                                                     "S6CymLIW+mq41qILxtVX0FtVGhuBgYNReUf6gtN98zVyq7dZxmIrIL1grfElnOs25qP0JTCHmRCjD8CzGQNKCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.968875753Z"),
                                                 ValidatorAddress = ParseHex("9C17C94F7313BB4D6E064287BEEDE5D3888E8855"),
                                                 ValidatorIndex = 57,
                                                 Signature = ParseBase64(
                                                     "2tGuufCcYurb/gsu1GE6EL6t9e9VpD/7hnU3W3G1wHdoGo18TEvxjebtDfhnYeeojjFKjepW2TvrXdeDgLb5Cg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.018509858Z"),
                                                 ValidatorAddress = ParseHex("9D07B301D23C547266D55D1B6C5A78CA473383A1"),
                                                 ValidatorIndex = 58,
                                                 Signature = ParseBase64(
                                                     "oMXj8Ic+fDY2t0vfo8uq7fOxMGPz26txQF3rjQnIFhK9xE36NfDN3qIp22isqJXJHy3VPCTpo0RErJjQDBoSBw==")
                                             },
                                             null,
                                             null,
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.032857629Z"),
                                                 ValidatorAddress = ParseHex("9EE94DBB86F72337192BF291B0E767FD2729F00A"),
                                                 ValidatorIndex = 62,
                                                 Signature = ParseBase64(
                                                     "t5PXyq3FXq5+xYNiJEEhOOz8L5/2PYUTYUhdXEzzMzh8GwP5BAvsRSrqnm2eVlr+XtkGxj/rlCz8Yf8cNqY7AQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.081717698Z"),
                                                 ValidatorAddress = ParseHex("A03DC128D38DB0BC5F18AE1872F1CB2E1FD41157"),
                                                 ValidatorIndex = 63,
                                                 Signature = ParseBase64(
                                                     "JSYPj09brDSjx2ehOstX67p43BBqYZqme+M3c2SZwHk8ju+R3SAY6MEuBS5py2ghzdg9quS5wVSZOXoSKTxKAg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.918386699Z"),
                                                 ValidatorAddress = ParseHex("A4F1D5534F3FA905A4DA606E8A10834976511FF7"),
                                                 ValidatorIndex = 64,
                                                 Signature = ParseBase64(
                                                     "GssIr3GnTr8xI6sLgQtk4RHNOcN3Tu3Sbd27O3NlnIpmXcQj1cOuJNnGzTuqNaYOz66CBUOFRoEyCcYqVXETCg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.012614971Z"),
                                                 ValidatorAddress = ParseHex("A6935D877B9776C45B96EEAE526959A3B9A5AB1A"),
                                                 ValidatorIndex = 65,
                                                 Signature = ParseBase64(
                                                     "mcmSGpiTid3+iv+sYL+OHk3xnszrRPBBM1nnDjEySPGmzO6cO+gp0/iXR/ZQKR6C/uLHCRS3Ds8Ah9OYYTuAAg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.042765425Z"),
                                                 ValidatorAddress = ParseHex("AC2D56057CD84765E6FBE318979093E8E44AA18F"),
                                                 ValidatorIndex = 66,
                                                 Signature = ParseBase64(
                                                     "wSuYOATfeySHcjco8kT2gYdpJjfM3nPPAW9EhP+wu02zGCJ1t7C2xzZJVDjKVcPfKEm23H8mwg4tgMydjBqMDQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:30:32.513022225Z"),
                                                 ValidatorAddress = ParseHex("AC885F3EE81E7ED07FE7B2E067443A855F997BA1"),
                                                 ValidatorIndex = 67,
                                                 Signature = ParseBase64(
                                                     "5YICYBL0N4+Hj5UEo36pXBFWei/S1fF/NndwoEEe/SzyFIpkPdpfwQxuQP+58uMOQ+xIRzMFjqzKCdgejFBpCw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.897052825Z"),
                                                 ValidatorAddress = ParseHex("B00A6323737F321EB0B8D59C6FD497A14B60938A"),
                                                 ValidatorIndex = 68,
                                                 Signature = ParseBase64(
                                                     "156+vrrLZWHLCfoKYJoFt/SonNAs4twNYaqJpCzJep0/gwm6UHgNB4x1eL5eNQwwCMK25FAJeDsZHi7y2vzvAg==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.077836778Z"),
                                                 ValidatorAddress = ParseHex("B0765A2F6FCC11D8AC46275FAC06DD35F54217C1"),
                                                 ValidatorIndex = 70,
                                                 Signature = ParseBase64(
                                                     "E4B9r5voYk1iiHWTddgoBI91kERr7YVuM+NnnzqQzNbfdHA1b8ScY/oYej8nkjp26e2+Ux4zTNLK7IuVh1KGAQ==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.992539594Z"),
                                                 ValidatorAddress = ParseHex("B34591DA79AAD0213534E2E915F50DE5CDBDF250"),
                                                 ValidatorIndex = 72,
                                                 Signature = ParseBase64(
                                                     "f/v3cvXnbISfzSm1NO1RcNSzDxjnVs5lleplzDuQkyC9zs9kgutbqTO5+V/ENrcdAITpCJN4tw+mzIU5cTaLAQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.978785939Z"),
                                                 ValidatorAddress = ParseHex("B4999CD535E4CD32B590BEB47020A724F40B65E5"),
                                                 ValidatorIndex = 73,
                                                 Signature = ParseBase64(
                                                     "Bv3EH54XfcyABsP0JCXyfOySbUJqZA3XTcVT9eDYoonUf3IwPa2SbBaet2Gt8gjJXltsTE8IVU6XqaWG7gZHCg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.895284951Z"),
                                                 ValidatorAddress = ParseHex("B4E1085F1C9EBB0EA994452CB1B8124BA89BED1A"),
                                                 ValidatorIndex = 74,
                                                 Signature = ParseBase64(
                                                     "JKrVTTnWlcBsrk7pFCokoFLOj+6R9cvKBy6TgxZpSbotgsXWNSQGfQqAAQgW3MqUiUuWiDyBI+SCB1X8pHkHDA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.860559921Z"),
                                                 ValidatorAddress = ParseHex("B543A7DF48780AEFEF593A003CD060B593C4E6B5"),
                                                 ValidatorIndex = 75,
                                                 Signature = ParseBase64(
                                                     "zA0pmjCYjw107qOg44t+L/vx2Tba4jdMd8l1qJDd2EVwzRNtm4TPazaHRUbUPM07IUVvVvFOjskxLRDdUXfzCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.930114355Z"),
                                                 ValidatorAddress = ParseHex("B6D7360C27F1DC36DD9BFCF23037BE8B04429209"),
                                                 ValidatorIndex = 76,
                                                 Signature = ParseBase64(
                                                     "Cup+n0uOOl2yRpDotl85MB8lkSHKc9WlMtsde/7rlL5gvGj0wAG+qBYQL6xDxNephVBVpx+cWI1Va3y0DF6VCw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.942233886Z"),
                                                 ValidatorAddress = ParseHex("BAC33F340F3497751F124868F049EC2E8930AC2F"),
                                                 ValidatorIndex = 77,
                                                 Signature = ParseBase64(
                                                     "oy6/81hcD6OulbVduGkygEbmQivn8ixinD98iurMEAxHCx475SMIedi7MoMko4oj4M7ACfxhLS9V0iZ1ScxiCg==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.940507998Z"),
                                                 ValidatorAddress = ParseHex("C2356622B495725961B5B201A382DD57CD3305EC"),
                                                 ValidatorIndex = 79,
                                                 Signature = ParseBase64(
                                                     "b8E+4AUTjMFbPOa9I2cfXt/obCPAvAt9VpZDmX2dsBvTnA2t4UEohk0lxdh1pHOehs0Y+/aPFq8ULOhAN5XqCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.878742804Z"),
                                                 ValidatorAddress = ParseHex("C2DDD9700CF5DEC0457DC423829B31EA8FD4F9D4"),
                                                 ValidatorIndex = 80,
                                                 Signature = ParseBase64(
                                                     "r1eHtcaINQIXB5WtPG5MZVxExy71HpebSQGkSuj//HABtwNhE8k8I9iAgezDq8hqL/u0xMbv+jmyeF+yMG7ODA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.989458844Z"),
                                                 ValidatorAddress = ParseHex("C4903229B9EAD415C79E8FA69D2BBA6117617C41"),
                                                 ValidatorIndex = 81,
                                                 Signature = ParseBase64(
                                                     "2eP37tNldVouYRAjSEYe1RGBD5+XaZvdM6LZZpVRfxyRsqTt0/ZFCMDkoBL0ngFL6LLqzBZkZZyOhjPMCaYZAw==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.977018053Z"),
                                                 ValidatorAddress = ParseHex("CA6696F5FE66A480BF21460319BE979930852DD0"),
                                                 ValidatorIndex = 83,
                                                 Signature = ParseBase64(
                                                     "DB1bduram+EsMz3LlI4M97IwfUlog/vvjbLuEPyXGUNn7KX6T0HisOCetAWe+viFyaNJAqWtthYri/I/1vkWDw==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.939925092Z"),
                                                 ValidatorAddress = ParseHex("CC05882978FC5FDD6A7721687E14C0299AE004B8"),
                                                 ValidatorIndex = 84,
                                                 Signature = ParseBase64(
                                                     "2NyH5UxC53cLPMhbxZcbZ/0Ydws3QuuFd7zHj9SxEMXYZtUhnW+B84QCGLovgDFPwedmFP5WJoCn8Y38friwDA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.021607624Z"),
                                                 ValidatorAddress = ParseHex("D14A542E8756C3A942D9FD8873DC2E9A7798A17F"),
                                                 ValidatorIndex = 85,
                                                 Signature = ParseBase64(
                                                     "J9HGtSnvMYP5Hx/Or2XUMVZvpkxu7E94sV8CBVa//8YWfb0Ixz9NgkzM5HvIv0BKHn7uZ+RI91tdQbAUZKe6Dw==")
                                             },
                                             null,
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex(""),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 0,
                                                         Hash = ParseHex("")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:44.457622932Z"),
                                                 ValidatorAddress = ParseHex("D9F8A41B782AA6A66ADC81F953923C7DCE7B6001"),
                                                 ValidatorIndex = 88,
                                                 Signature = ParseBase64(
                                                     "tQ6HxI1GwjhWeSiHRQhEdHHvb1+0ZGlMT8UsC2xTnEyiufvOgjhM0XACZlLjcIuPBSR/f1Pr8TnJPhJfNnDLBg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.164157532Z"),
                                                 ValidatorAddress = ParseHex("DA6AAAA959C9EF88A3EB37B1F107CB2667EBBAAB"),
                                                 ValidatorIndex = 89,
                                                 Signature = ParseBase64(
                                                     "saHCa7Pb6CTbNobys5eLSpCebFyghipwgpH0zwKBXIP1PQiZ2nt2Vlv2lKF8CVUo3aqPx1tab6F45/SngdUmAQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.885302966Z"),
                                                 ValidatorAddress = ParseHex("E800740C68C81B30345C3AE2BA638FA56FF67EEF"),
                                                 ValidatorIndex = 90,
                                                 Signature = ParseBase64(
                                                     "rDO4C+6pT8pCEluHUXQlDhK4qMX7ou9D6wVIUwSXFKK2zwK2u2q+3WX0+PXCj7NRbNt9gXBGbG87CkSXoVQdCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.842984556Z"),
                                                 ValidatorAddress = ParseHex("EB1DF22507B79CE700F86C4C8B13D7DF01DFDA9C"),
                                                 ValidatorIndex = 91,
                                                 Signature = ParseBase64(
                                                     "B6O8gTpB6+pzX9IZw3czVlCto1W95LMx6O5gussKY2/l5Tsxick50EK08KqEYw4wM+YzjqucP16Ls6iVBf1mCg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.060279469Z"),
                                                 ValidatorAddress = ParseHex("EBED694E6CE1224FB1E8A2DD8EE63A38568B1E2B"),
                                                 ValidatorIndex = 92,
                                                 Signature = ParseBase64(
                                                     "XnHesmKh0g1a9LkmWqWNFSQ7MUNy7WcIH6xsNH/v0EV6uxYZI/D3EfXTxZYeXsoFTOx0NSP6zyHgJIaaCisKDQ==")
                                             },
                                             null,
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.88618877Z"),
                                                 ValidatorAddress = ParseHex("EE73A19751D58C5EC044C11E3FB7AE685A10D2C1"),
                                                 ValidatorIndex = 94,
                                                 Signature = ParseBase64(
                                                     "m3ZcMJO0RaJfK0/r6BwK0mIky52qIqYrlMkSZOBBQ+iTy31jahygDvOE08l02Nb34i27x9PTcrmirl6loKqYBA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.8488736Z"),
                                                 ValidatorAddress = ParseHex("F4CAB410DE5567DB203BD56C694FB78D482479A1"),
                                                 ValidatorIndex = 95,
                                                 Signature = ParseBase64(
                                                     "CDPu6DxnW59RGIR9K2BKYJs4/4z99hF/8BYoH+BUCrRXsudS3FwoCncYYzpdkmquY1rVv1DzIxM8f2aVEFczDg==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.887523094Z"),
                                                 ValidatorAddress = ParseHex("F55714243D32FB65B6D95A29D0350EA0CABBA8EA"),
                                                 ValidatorIndex = 96,
                                                 Signature = ParseBase64(
                                                     "508vE5/kgmq+2bQKPYA1HrGlr4xDfXrpNcC4RiuYQlwhpfJhKHFxJiW5VX5cTOD4dAnh9MWB8gbxOHO4CpJoCQ==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:41.094926933Z"),
                                                 ValidatorAddress = ParseHex("F919902709B7482F01C030E8B57BF93B8D87043B"),
                                                 ValidatorIndex = 97,
                                                 Signature = ParseBase64(
                                                     "Z4fmgqkErYDITUtM5I3NYNuRkUxrdYMFSSvY7Z8UPw6hX1miWQSrQaefHeswwwLDDdGVORIzbuloDJ43Hlq+DA==")
                                             },
                                             new CommitSig
                                             {
                                                 Type = SignedMsgType.PrecommitType,
                                                 Height = 2,
                                                 Round = 1,
                                                 BlockId = new BlockID()
                                                 {
                                                     Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                                                     Parts = new BlockIDParts()
                                                     {
                                                         Total = 1,
                                                         Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3")
                                                     }
                                                 },
                                                 Timestamp = ParseDateTime("2019-12-11T16:31:40.983259861Z"),
                                                 ValidatorAddress = ParseHex("FA0E5DFACCDCF74957A742144FE55BE61D433377"),
                                                 ValidatorIndex = 98,
                                                 Signature = ParseBase64(
                                                     "oTSwsCMsxBKdosYypiVf+jA8hUEXYi1ShUrr4ocTfC5+yb37MJ4ldpRIr50PqOfoe/byCXP31d8/BSWIk272Cg==")
                                             },
                                             null
                                         }
                }
            };

            return block;
        }

        private static BlockQueryBlockMeta BlockMetaHeight3()
        {
            return new BlockQueryBlockMeta()
            {
                BlockId = new BlockID()
                {
                    Hash = ParseHex("BFF3272C3138EE5E81670A46C19BDBCDE8EA94C2F6633DFAB3A7D785B2E7924B"),
                    Parts = new BlockIDParts()
                    {
                        Hash = ParseHex("4248E0B4269F69BBE22DECA4E02E9AACF641D0C010F43CBD5027D1BE36343037"),
                        Total = 1
                    }
                },
                Header = new BlockHeader()
                {
                    Version = new BlockHeaderVersion()
                    {
                        App = 0,
                        Block = 10
                    },
                    ChainId = "cosmoshub-3",
                    Height = 3,
                    Time = ParseDateTime("2019-12-11T16:31:40.962459814Z"),
                    NumTxs = 0,
                    TotalTxs = 0,
                    LastBlockId = new BlockID()
                    {
                        Hash = ParseHex("8696E740680DB1FA6FA6F609B217C02B92070F8B4FD2C72E82B6FC99D63BF5B7"),
                        Parts = new BlockIDParts()
                        {
                            Hash = ParseHex("9B0D8257C6F5752D71B05F4C7C6A5D157C54BCD8C33D35724AA04AE096AFCCB3"),
                            Total = 1
                        }
                    },
                    LastCommitHash = ParseHex("7B04B817963FBAE67E819E0F65C9374DC85360946BF572BE5041AA30967D52B0"),
                    DataHash = new byte[0],
                    ValidatorsHash = ParseHex("D6C5C2B123802BD4910BAC6F9E9A6FDC29BC4AF8128FE996C6C5FDA3CEB08B31"),
                    NextValidatorsHash = ParseHex("D6C5C2B123802BD4910BAC6F9E9A6FDC29BC4AF8128FE996C6C5FDA3CEB08B31"),
                    ConsensusHash = ParseHex("0F2908883A105C793B74495EB7D6DF2EEA479ED7FC9349206A65CB0F9987A0B8"),
                    AppHash = ParseHex("91A08E1315CDED3B19C6719D2E7A8762BED55C4CD81E415F9F77B92C63BE89A4"),
                    LastResultsHash = new byte[0],
                    EvidenceHash = new byte[0],
                    ProposerAddress = ParseHex("2199EAE894CA391FA82F01C2C614BFEB103D056C")
                }
            };
        }
    }
}