using InvestmentManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPortfolioOverview(Guid userId)
        {
            var overview = await _dashboardService.GetPortfolioOverviewAsync(userId);
            return Ok(overview);
        }
    }
}
