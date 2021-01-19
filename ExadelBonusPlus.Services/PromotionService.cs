using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExadelBonusPlus.Services.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExadelBonusPlus.Services
{
    public class PromotionService : IPromotionService
    {
        private List<Promotion> _promotions;  //temporary hard code :)
        private readonly MongoCollectionBase<Promotion> _promotionsDB;

        public PromotionService(IExadelBonusDbSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);


            _promotionsDB = (MongoCollectionBase<Promotion>)database.GetCollection<Promotion>("Promotions");

            _promotions = new List<Promotion>();
            _promotions.Add(new Promotion 
            {
                Name = "Акция на пиццу",
                Description = "Заказ на сумму более 20 рублей - 10%",
                Estimate = 10,
                DateStart = DateTime.Today,
                DateEnd = DateTime.Today,
                Location = new Location{City = "Minsk",Country = "Belarus", Address = "пр. Машерова, 10", Latitude = 33, Longitude = 50},
                Vendor = 1,
                Tags = new List<string>(){"пицца","еда"}
            });
            _promotions.Add(new Promotion
            {
                Name = "Акция на суши",
                Description = "Заказ на сумму более 30 рублей - 15%",
                Estimate = 10,
                DateStart = DateTime.Today,
                DateEnd = DateTime.Today,
                Location = new Location { City = "Minsk", Country = "Belarus", Address = "пр. Машерова, 10", Latitude = 33, Longitude = 50 },
                Vendor = 1,
                Tags = new List<string>() { "суши", "еда" }
            });
        }

        public async Task<Promotion> AddPromotionAsync(Promotion model)
        { 
            await _promotionsDB.InsertOneAsync(model);

            return model;
        }

        public async Task<List<Promotion>> FindPromotionsAsync()
        {
            return await _promotionsDB.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Promotion> UpdatePromotionAsync(Promotion model)
        {
            var result = _promotions[0];
            return result is null ? throw new InvalidOperationException("Update promotion error") : result;
        }

        public async Task<Promotion> DeletePromotionAsync(Guid id)
        {
            var result = _promotions[0];
            return result is null ? throw new InvalidOperationException("Delete promotion error") : result;
        }
    }
}
