using GeekTrust.Models;

namespace GeekTrust.Contracts
{
    public interface ICipher
    {
        ///<summary>Deciphers the provided message to determine if the Recipient is an ally.</summary>
        bool Decipher(SecretMessage message);
    }
}
