using IAITest.Core.Model;
using IAITest.Core.Repository;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Services
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _adRepository;
        public AdService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }
        public async Task<AdResponse> DeleteAd(int adId)
        {
            try
            {
                await _adRepository.DeleteAd(adId);
                return new AdResponse { Status = System.Net.HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new AdResponse { Status = System.Net.HttpStatusCode.BadRequest, Error = ex.Message };
            }
           
        }

        public async Task<List<Ad>> GetAds(AdFilter filter)
        {
            return await _adRepository.GetAds(filter);
        }

        public async Task<AdResponse> SaveNewAd(Ad ad)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(ad.Title))
            {
                sb.AppendLine("Title is mandatory!");
            }
            if (string.IsNullOrEmpty(ad.Content))
            {
                sb.AppendLine("Content of Ad is mandatory!");
            }
            if (sb.Length > 0)
            {
                return new AdResponse() { Status = System.Net.HttpStatusCode.NoContent, Error = sb.ToString() };
            }
            
            var ads = await _adRepository.GetAds(null);

            if (ads != null) {
                await _adRepository.SaveNewAd(ads, ad);
            }
            return new AdResponse { Status = System.Net.HttpStatusCode.OK };
        }

        public async Task<AdResponse> UpdateAd(AdUpdate adUpdate)
        {
            await _adRepository.UpdateAd(adUpdate);
            return new AdResponse { Status = System.Net.HttpStatusCode.OK };
        }
    }
}
