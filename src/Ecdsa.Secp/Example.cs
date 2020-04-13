namespace Ecdsa.Secp
{
    using System;
    using System.Linq;
    using System.Text;

    public class Example
    {
        static string BytesToHexString(byte[] bytes)
        {
            return string.Join(string.Empty, bytes.Select(i => i.ToString("x2")));
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        static void ExecExample()
        {
            var sk = StringToByteArray("e867203c831452daab78342f7d99c89c31d0ff905d5e14738034fe4eb12c6e1a");
            var pk = StringToByteArray("04A7EE9F51BA8455233BBB3453AC994784A45DEFF95E0EB8FA41B26706C5AEA3CFFEBC7438CF55A7CC2EBF1F1627B86D406DB445B35620FEDCDA6FA50A0DDBB9C1");
            var messageBytes = Encoding.UTF8.GetBytes("aSgoFqkKPaijYZoKFLr8QojVnV02O2ggNni8ppKJz7rfEhRUaZ3Qqm4UpGbwKKtR5AvhFXBz8xoLCgVzdGFrZRICMTAiJDFmMjViMGE3LTc3NjQtNGU5ZC1iNGIwLTVhOWU4YzhhYzQ4Mw==");

            Console.WriteLine("secp256k1--------------------------- ");
            var secp256k1 = new Secp256k1();

            Console.WriteLine("Public              : " + BytesToHexString(pk));
            var tk = secp256k1.DerivePubKeyFromPrivKey(sk);
            Console.WriteLine("Public (generated)  : " + BytesToHexString(tk));

            var cpk = secp256k1.CompressKey(pk);
            var dcpk = secp256k1.DecompressKey(cpk);

            Console.WriteLine("Public(  compressed): " + BytesToHexString(cpk));
            Console.WriteLine("Public(decompressed): " + BytesToHexString(dcpk));

            var k1Sig = secp256k1.SignMessage(sk, messageBytes);
            Console.WriteLine("Signature: " + BytesToHexString(k1Sig));
            Console.WriteLine("Validate       : " + secp256k1.Verify(tk, messageBytes, k1Sig));
            Console.WriteLine("Validate(real) : " + secp256k1.Verify(pk, messageBytes, k1Sig));

            Console.ReadLine();
        }
    }
}
