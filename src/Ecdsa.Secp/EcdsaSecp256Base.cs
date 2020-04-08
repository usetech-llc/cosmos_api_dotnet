namespace Ecdsa.Secp
{
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Security;

    public abstract class EcdsaSecp256Base
    {
        protected ECDomainParameters _curveSpec;
        protected X9ECParameters _curve;

        public virtual Keypair GenerateKeys()
        {
            var kg = GeneratorUtilities.GetKeyPairGenerator("ECDSA");
            kg.Init(new ECKeyGenerationParameters(_curveSpec, new SecureRandom()));
            var keys = kg.GenerateKeyPair();
            return new Keypair(
                ((ECPublicKeyParameters)keys.Public).Q.GetEncoded(),
                ((ECPrivateKeyParameters)keys.Private).D.ToByteArray());
        }

        public virtual byte[] SignMessage(byte[] privateKey, byte[] message)
        {
            var privateKeyParameters = new ECPrivateKeyParameters(new BigInteger(privateKey), _curveSpec);
            var signer = SignerUtilities.GetSigner("SHA-256withECDSA");
            signer.Init(true, privateKeyParameters);
            signer.BlockUpdate(message, 0, message.Length);
            return signer.GenerateSignature();
        }

        public virtual bool Verify(byte[] publicKey, byte[] message, byte[] signature)
        {
            var pubKeyParameters = new ECPublicKeyParameters("ECDSA", _curve.Curve.DecodePoint(publicKey), _curveSpec);
            var verifier = SignerUtilities.GetSigner("SHA-256withECDSA");
            verifier.Init(false, pubKeyParameters);
            verifier.BlockUpdate(message, 0, message.Length);
            return verifier.VerifySignature(signature);
        }
    }
}
