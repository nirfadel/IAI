using IAITest.Core.Model;
using IAITest.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;
        public AdController(IAdService adService)
        {
            _adService = adService;
        }
        [HttpGet]
        public async Task<List<Ad>> Get([FromQuery]AdFilter adFilter)
        {
            return await _adService.GetAds(adFilter);
        }

        [HttpPost]
        public async Task<AdResponse> Post(Ad ad)
        {
            return await _adService.SaveNewAd(ad);
        }

        [HttpPut]
        public async Task<AdResponse> Put(AdUpdate adUpdate)
        {
            return await _adService.UpdateAd(adUpdate);
        }

        [HttpDelete("{Id}")]

        public async Task<AdResponse> Delete(int Id)
        {
            return await _adService.DeleteAd(Id);
        }


    }
}
