namespace Ecdsa.Secp
{
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto.Parameters;

    public class Secp256k1 : EcdsaSecp256Base
    {
        public Secp256k1()
        {
            // set curve
            _curve = ECNamedCurveTable.GetByName("secp256k1");
            _curveSpec = new ECDomainParameters(_curve.Curve, _curve.G, _curve.N, _curve.H);
        }
    }
}
