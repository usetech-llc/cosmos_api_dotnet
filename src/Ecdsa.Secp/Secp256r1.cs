namespace Ecdsa.Secp
{
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto.Parameters;

    public class Secp256r1 : EcdsaSecp256Base
    {
        public Secp256r1()
        {
            // set curve
            _curve = ECNamedCurveTable.GetByName("secp256r1");
            _curveSpec = new ECDomainParameters(_curve.Curve, _curve.G, _curve.N, _curve.H);
        }
    }
}
