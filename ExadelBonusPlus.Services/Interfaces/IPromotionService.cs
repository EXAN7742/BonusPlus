using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExadelBonusPlus.Services.Models;

namespace ExadelBonusPlus.Services
{
    public interface IPromotionService
    {
        Task<Promotion> AddPromotionAsync(Promotion model);

        Task<List<Promotion>> FindPromotionsAsync();

        Task<Promotion> UpdatePromotionAsync(Promotion model);

        Task<Promotion> DeletePromotionAsync(Guid id);
    }
}
