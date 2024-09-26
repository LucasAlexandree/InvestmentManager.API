using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.Entities;
using InvestmentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Application.Services
{
    public class AssetService : IAssetService
    {
        private readonly InvestmentDbContext _context;

        public AssetService(InvestmentDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAssetAsync(Guid userId, string type, string symbol, string description)
        {
            var asset = new Asset
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = type,
                Symbol = symbol,
                Description = description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return asset.Id;
        }

        public async Task EditAssetAsync(Guid assetId, string type, string symbol, string description)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset == null) throw new ArgumentException("Asset not found.");

            asset.Type = type;
            asset.Symbol = symbol;
            asset.Description = description;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAssetAsync(Guid assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset == null) throw new ArgumentException("Asset not found.");

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Asset>> GetUserAssetsAsync(Guid userId)
        {
            return await _context.Assets.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}
