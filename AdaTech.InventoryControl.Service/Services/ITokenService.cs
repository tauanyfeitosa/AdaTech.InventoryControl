namespace AdaTech.InventoryControl.Service.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, string password);
    }
}