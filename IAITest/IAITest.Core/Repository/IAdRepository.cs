using IAITest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Repository
{
    public interface IAdRepository
    {
        Task<List<Ad>> GetAds(AdFilter adFilter);

        Task SaveNewAd(List<Ad> ads, Ad ad);

        Task UpdateAd(AdUpdate adUpdate);

        Task DeleteAd(int id);
    }
}
