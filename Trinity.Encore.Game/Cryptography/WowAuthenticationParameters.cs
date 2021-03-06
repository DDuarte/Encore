using System.Security.Cryptography;
using Trinity.Core.Cryptography;
using Trinity.Core.Cryptography.SRP;

namespace Trinity.Encore.Game.Cryptography
{
    public sealed class WowAuthenticationParameters : SRPParameters
    {
        public const int KeySize = 32;

        public const int GeneratorSize = 1;

        public WowAuthenticationParameters(SRPVersion version = SRPVersion.SRP6, bool caseSensitive = false)
            : base(version, caseSensitive)
        {
        }

        protected override void SetupParameters()
        {
            Hash = new SHA1Managed();
            Generator = new BigInteger(7);
            Modulus = new BigInteger("B79B3E2A87823CAB8F5EBFBF8EB10108535006298B5BADBD5B53E1895E644B89");
        }

        public override int KeyLength
        {
            get { return KeySize; }
        }
    }
}
