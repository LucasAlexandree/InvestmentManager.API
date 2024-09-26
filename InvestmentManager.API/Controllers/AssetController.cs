using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset([FromBody] Asset asset)
        {
            var createdAsset = await _assetService.AddAssetAsync(asset);
            return Ok(createdAsset);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(Guid id, [FromBody] Asset updatedAsset)
        {
            var asset = await _assetService.UpdateAssetAsync(id, updatedAsset);
            if (asset == null) return NotFound("Ativo não encontrado.");
            return Ok(asset);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsset(Guid id)
        {
            var result = await _assetService.RemoveAssetAsync(id);
            if (!result) return NotFound("Ativo não encontrado.");
            return Ok("Ativo removido com sucesso.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var assets = await _assetService.GetAllAssetsAsync();
            return Ok(assets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetById(Guid id)
        {
            var asset = await _assetService.GetAssetByIdAsync(id);
            if (asset == null) return NotFound("Ativo não encontrado.");
            return Ok(asset);
        }
    }
}
