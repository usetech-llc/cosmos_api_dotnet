namespace Ecdsa.Secp
{
    public class Keypair
    {
        public byte[] PublicKey { get => _publicKey; }
        public byte[] PrivateKey { get => _privateKey; }

        private readonly byte[] _publicKey;
        private readonly byte[] _privateKey;

        public Keypair(byte[] publicKey, byte[] privateKey)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
        }
    }
}
