using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ExadelBonusPlus.Services.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ExadelBonusPlus.WebApi
{
    [ApiController]
    [Route("api/[controller]/")]
    public class PromotionsController : ControllerBase
    {

        private readonly ILogger<PromotionsController> _logger;
        private List<Promotion> promotions;


        public PromotionsController(ILogger<PromotionsController> logger)
        {
            _logger = logger;

            promotions = new List<Promotion>();
            promotions.Add(new Promotion { Name = "Акция на пиццу", Description = "Заказ на сумму более 20 рублей - 10%" });
            promotions.Add(new Promotion { Name = "Акция на суши", Description = "Заказ на сумму более 30 рублей - 15%" });
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Promotion added ", Type = typeof(Promotion))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public  ActionResult<IEnumerable<Promotion>> GetPromotions()
        {
            return promotions;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Promotion added ", Type = typeof(Promotion))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public ActionResult<Promotion> AddPromotion()
        {
            return new Promotion();
        }

    }
}