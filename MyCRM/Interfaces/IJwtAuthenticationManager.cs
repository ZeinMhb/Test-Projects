namespace CRM.Interfaces
{
    public interface IJwtAuthenticationManager
    {
       string Authenticate(string username, string password);
    }
}
