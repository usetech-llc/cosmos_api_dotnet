namespace CosmosApi.Crypto
{
    public class BinaryPrivateKey
    {
        public string? Type { get; }
        public byte[] Value { get; }

        public BinaryPrivateKey(string? type, byte[] value)
        {
            Type = type;
            Value = value;
        }
    }
}