namespace LAB4
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string dataToEncrypt, string Key);
        string Decrypt(string dataToDecrypt, string Key);
    }
}
