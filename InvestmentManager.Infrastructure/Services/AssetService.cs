using InvestmentManager.Application.DTOs;
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

        public async Task<IEnumerable<AssetDto>> GetAllAssetsAsync()
        {
            return await _context.Assets
                .Select(a => new AssetDto
                {
                    Id = a.Id,
                    Symbol = a.Symbol,
                    Type = a.Type,
                    Description = a.Description
                }).ToListAsync();
        }

        public async Task<AssetDto> GetAssetByIdAsync(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null) return null;

            return new AssetDto
            {
                Id = asset.Id,
                Symbol = asset.Symbol,
                Type = asset.Type,
                Description = asset.Description
            };
        }

        public async Task<AssetDto> CreateAssetAsync(AssetDto assetDto)
        {
            var asset = new Asset
            {
                Id = Guid.NewGuid(),
                Symbol = assetDto.Symbol,
                Type = assetDto.Type,
                Description = assetDto.Description
            };

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return new AssetDto
            {
                Id = asset.Id,
                Symbol = asset.Symbol,
                Type = asset.Type,
                Description = asset.Description
            };
        }

        public async Task UpdateAssetAsync(AssetDto assetDto)
        {
            var asset = await _context.Assets.FindAsync(assetDto.Id);
            if (asset == null) return;

            asset.Symbol = assetDto.Symbol;
            asset.Type = assetDto.Type;
            asset.Description = assetDto.Description;

            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssetAsync(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null) return;

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }
    }
}
