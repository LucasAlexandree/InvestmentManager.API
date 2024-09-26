using InvestmentManager.Domain.Entities;

namespace InvestmentManager.Application.Interfaces
{
    public interface IAssetService
    {
        Task<Guid> AddAssetAsync(Guid userId, string type, string symbol, string description);
        Task EditAssetAsync(Guid assetId, string type, string symbol, string description);
        Task RemoveAssetAsync(Guid assetId);
        Task<IEnumerable<Asset>> GetUserAssetsAsync(Guid userId);
    }
}
