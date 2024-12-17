using IAITest.Core.Model;
using IAITest.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IAITest.Core.Repository
{
    public class AdRepository : IAdRepository
    {
        private string mainPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\");



        public async Task DeleteAd(int id)
        {
           
            try
            {
                Ad ad = new Ad();
                var ads = await GetAds();
                if (ads != null)
                {
                    ad = ads.Where(a => a.Id == id).FirstOrDefault();
                    ad.IsDeleted = true;
                       var jsonAds = JsonSerializer.Serialize(ads);
                await File.WriteAllTextAsync(Path.Combine(mainPath, @"ads.json"), jsonAds);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<List<Ad>> GetAds(AdFilter adFilter = null)
        {
            List<Ad> ads = new List<Ad>();
            var path = Path.Combine(mainPath, @"ads.json");
            if (File.Exists(path))
            {
                var jsonAds = await File.ReadAllTextAsync(path);
                ads = JsonSerializer.Deserialize<List<Ad>>(jsonAds);
                ads = ads.Where(a => a.IsDeleted == false).ToList();
                if (adFilter != null)
                {
                    if (adFilter.Location != null)
                    {
                        // needs to search location
                    }
                    if (!string.IsNullOrEmpty(adFilter.Text))
                    {
                        ads = ads.Where(a => a.Title.Contains(adFilter.Text) || a.Content.Contains(adFilter.Text)).ToList();
                    }
                }
            }
            return ads;
        }

        public async Task SaveNewAd(List<Ad> ads, Ad ad)
        {
            try
            {
                // Get the last id and then increment by one for unique id
                int id = 0;
                if (ads.Any())
                    id = ads.Max(a => a.Id);
                id++;
                ad.Id = id;
                ad.AdDate = DateTime.Now;
                ads.Add(ad);
                var jsonAds = JsonSerializer.Serialize(ads);
                await File.WriteAllTextAsync(Path.Combine(mainPath, @"ads.json"), jsonAds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Ad didn't save");
            }
        }

        public async Task UpdateAd(AdUpdate adUpdate)
        {
            var ads = await GetAds();
            var currAd = ads.Where(a => a.Id == adUpdate.Id).FirstOrDefault();
            if (currAd != null)
            {
                if (!string.IsNullOrEmpty(adUpdate.Title) && currAd.Title != adUpdate.Title)
                    currAd.Title = adUpdate.Title;
                if (!string.IsNullOrEmpty(adUpdate.Content) && currAd.Content != adUpdate.Content)
                    currAd.Content = adUpdate.Content;
                if (adUpdate.Location != null && (currAd.Location.Lat != adUpdate.Location.Lat ||
                    currAd.Location.Lng != adUpdate.Location.Lng))
                    currAd.Location = adUpdate.Location;
                    
                currAd.AdUpdateDate = DateTime.Now;
                var jsonAds = JsonSerializer.Serialize(ads);
                await File.WriteAllTextAsync(Path.Combine(mainPath, @"ads.json"), jsonAds);
            }
        }
    }
}
