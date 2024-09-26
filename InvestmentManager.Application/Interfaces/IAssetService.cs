using InvestmentManager.Application.DTOs;

namespace InvestmentManager.Application.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDto>> GetAllAssetsAsync();
        Task<AssetDto> GetAssetByIdAsync(Guid id);
        Task<AssetDto> CreateAssetAsync(AssetDto assetDto);
        Task UpdateAssetAsync(AssetDto assetDto);
        Task DeleteAssetAsync(Guid id);
    }
}
