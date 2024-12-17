using IAITest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Services
{
    public interface IAdService
    {
        Task<List<Ad>> GetAds(AdFilter filter);

        Task<AdResponse> SaveNewAd(Ad ad);

        Task<AdResponse> UpdateAd(AdUpdate adApdate);

        Task<AdResponse> DeleteAd(int adId);
    }
}
