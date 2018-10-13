namespace Security
{
    public interface ICryptoService
    {
        string CreateSalt();
        string HashText(string Text, string salt);
    }
}