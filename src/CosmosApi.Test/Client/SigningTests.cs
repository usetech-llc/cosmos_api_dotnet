using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CosmosApi.Crypto;
using CosmosApi.Extensions;
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
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var stdSignDoc = SigningData.StdSignDoc();
            var bytes = Encoding.UTF8.GetBytes(client.Serializer.SerializeSortedAndCompact(stdSignDoc));

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
        public async Task SignedBytesVerified()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            var random = new Random();
            var bytesToSign = new byte[1024 * 8];
            random.NextBytes(bytesToSign);
            var privateKey = client.CryptoService.ParsePrivateKey(Configuration.LocalAccount1PrivateKey, Configuration.LocalAccount1Passphrase);
            var account = await client.Auth.GetAuthAccountByAddressAsync(Configuration.LocalAccount1Address);
            
            OutputHelper.WriteLine("Signing random bytes:");
            OutputHelper.WriteLine(bytesToSign.ToBase64String());
            OutputHelper.WriteLine("");

            var signedBytes = client.CryptoService.Sign(bytesToSign, privateKey);
            OutputHelper.WriteLine("Signed bytes:");
            OutputHelper.WriteLine(signedBytes.ToBase64String());

            var verificationResult = client.CryptoService.VerifySign(bytesToSign, signedBytes, account.Result.GetPublicKey());
            OutputHelper.WriteLine($"Verification result: {verificationResult}");
            Assert.True(verificationResult);
        }
    }
}