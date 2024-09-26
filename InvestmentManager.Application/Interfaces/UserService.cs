namespace InvestmentManager.Application.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RegisterUserAsync(string name, string email, string password);
        Task<Guid> LoginUserAsync(string email, string password);
        Task<bool> RecoverPasswordAsync(string email);
    }
}
