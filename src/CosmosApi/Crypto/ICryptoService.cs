using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CosmosApi.Models;
using CosmosApi.Serialization;

namespace CosmosApi.Crypto
{
    public interface ICryptoService
    {
        /// <summary>
        /// Parses encoded private key.
        /// </summary>
        /// <param name="encodedKey"></param>
        /// <param name="passphrase"></param>
        /// <returns></returns>
        PrivateKey ParsePrivateKey(string encodedKey, string? passphrase);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytesToSign"></param>
        /// <param name="key"></param>
        /// <param name="keyType"></param>
        /// <returns></returns>
        byte[] Sign(byte[] bytesToSign, byte[] key, string? keyType);


        public StdSignature MakeStdSignature(string chainId, ulong accountNumber, ulong sequence, StdFee fee, IList<IMsg> msgs, string memo,
            ISerializer serializer, string encodedPrivateKey, string passphrase, PublicKey? publicKey = default)
        {
            var key = ParsePrivateKey(encodedPrivateKey, passphrase);
            return MakeStdSignature(chainId, accountNumber, sequence, fee, msgs, memo, serializer, key, publicKey);
        }

        public StdSignature MakeStdSignature(string chainId, ulong accountNumber, ulong sequence, StdFee fee, IList<IMsg> msgs, string memo,
            ISerializer serializer, PrivateKey privateKey, PublicKey? publicKey = default)
        {
            var stdSignDoc = new StdSignDoc(accountNumber, chainId, fee, memo, msgs, sequence);

            var bytesToSign = Encoding.UTF8.GetBytes(serializer.SerializeSortedAndCompact(stdSignDoc));
            byte[] signedBytes = Sign(bytesToSign, privateKey.Value, privateKey.Type);

            if (publicKey?.Type == null ||
                !string.Equals(privateKey.Type, publicKey.Type, StringComparison.OrdinalIgnoreCase))
            {
                publicKey = null;
            }
            return new StdSignature(signedBytes, publicKey);
        }

        void SignStdTx(StdTx tx, IEnumerable<Signer> signers, string chainId, ISerializer serializer)
        {
            tx.Signatures = signers
                .Select(s => MakeStdSignature(chainId, s.Account.GetAccountNumber(), s.Account.GetSequence(), tx.Fee, tx.Msg, tx.Memo, serializer, s.EncodedPrivateKey, s.Passphrase, s.Account.GetPublicKey()))
                .ToList();
        }
        
    }
}