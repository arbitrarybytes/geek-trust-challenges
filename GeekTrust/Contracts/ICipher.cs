using GeekTrust.Models;

namespace GeekTrust.Contracts
{
    public interface ICipher
    {
        ///<summary>Deciphers the provided message to determine if the Recipient is an ally.</summary>
        string Decipher(SecretMessage message);

        bool IsAlly(SecretMessage message);
    }
}
