using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using CosmosApi.Crypto;
using CosmosApi.Extensions;
using CosmosApi.Models;
using CosmosApi.Test.Endpoints;
using CosmosApi.Test.TestData;
using NBitcoin.Secp256k1;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Client
{
    public class SigningTests : BaseTest
    {
        public SigningTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void BytesForSigningComputedCorrectlyForStdTx()
        {
            using var client = CreateClient();

            var stdSignDoc = SigningData.StdSignDoc();
            var bytes = client.GetSignBytes(stdSignDoc);

            OutputHelper.WriteLine("StdSignDoc:");
            Dump(stdSignDoc);

            OutputHelper.WriteLine("SignBytes:");
            OutputHelper.WriteLine(bytes.ToHexString());
            OutputHelper.WriteLine("");
            
            var expectedBytes = SigningData.StdSignDocBytes();
            OutputHelper.WriteLine("Expected SignBytes:");
            OutputHelper.WriteLine(expectedBytes.ToHexString());
            OutputHelper.WriteLine("");

            Assert.Equal( 
                expectedBytes,
                bytes);
        }

        [Fact]
        public void SignedBytesVerified()
        {
            using var client = CreateClient();
            var random = new Random();
            var bytesToSign = new byte[1024 * 8];
            random.NextBytes(bytesToSign);
            var keyBytes = KeysParser.Parse(Configuration.Validator1PrivateKey, Configuration.Validator1Passphrase);
            var key = Context.Instance.CreateECPrivKey(keyBytes);
            
            OutputHelper.WriteLine("Signing random bytes:");
            OutputHelper.WriteLine(bytesToSign.ToBase64String());
            OutputHelper.WriteLine("");

            var signedBytes = client.Sign(bytesToSign, keyBytes);
            OutputHelper.WriteLine("Signed bytes:");
            OutputHelper.WriteLine(signedBytes.ToBase64String());

            var publicKey = key.CreatePubKey();
            SecpECDSASignature.TryCreateFromCompact(signedBytes, out var sign);
            using var sha = new SHA256Managed();
            var verificationResult = publicKey.SigVerify(sign!, sha.ComputeHash(bytesToSign));
            OutputHelper.WriteLine($"Verification result: {verificationResult}");
            Assert.True(verificationResult);
        }
    }
}