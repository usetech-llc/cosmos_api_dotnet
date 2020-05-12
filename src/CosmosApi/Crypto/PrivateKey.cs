namespace CosmosApi.Crypto
{
    public class PrivateKey
    {
        public string? Type { get; }
        public byte[] Value { get; }

        public PrivateKey(string? type, byte[] value)
        {
            Type = type;
            Value = value;
        }
    }
}