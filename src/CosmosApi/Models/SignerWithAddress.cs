namespace CosmosApi.Models
{
    public class SignerWithAddress
    {
        public string Address { get; set; } = null!;
        public string EncodedPrivateKey { get; set; } = null!;
        public string Passphrase { get; set; } = null!;

        public SignerWithAddress()
        {
        }
        
        public SignerWithAddress(string address, string encodedPrivateKey, string passphrase)
        {
            Address = address;
            EncodedPrivateKey = encodedPrivateKey;
            Passphrase = passphrase;
        }

    }
}