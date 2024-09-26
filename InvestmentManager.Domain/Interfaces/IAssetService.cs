using InvestmentManager.Domain.Entities;

namespace InvestmentManager.Application.Interfaces
{
    public interface IAssetService
    {
        Task<Asset> AddAssetAsync(Asset asset);
        Task<Asset> UpdateAssetAsync(Guid id, Asset updatedAsset);
        Task<bool> RemoveAssetAsync(Guid id);
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task<Asset> GetAssetByIdAsync(Guid id);
    }
}
