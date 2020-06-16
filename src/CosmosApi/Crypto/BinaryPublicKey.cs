namespace CosmosApi.Crypto
{
    public class BinaryPublicKey
    {
        public string? Type { get; set; }
        public byte[] Value { get; set; } = null!;

        public BinaryPublicKey()
        {
        }

        public BinaryPublicKey(string? type, byte[] value)
        {
            Type = type;
            Value = value;
        }
    }
}