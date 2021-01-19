using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ExadelBonusPlus.Services.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;
using ExadelBonusPlus.Services;

namespace ExadelBonusPlus.WebApi
{
    [ApiController]
    [Route("api/[controller]/")]
    public class PromotionsController : ControllerBase
    {

        private readonly ILogger<PromotionsController> _logger;
        private readonly IPromotionService _promotionService;
        
        public PromotionsController(ILogger<PromotionsController> logger, IPromotionService promotionService)
        {
            _logger = logger;
            _promotionService = promotionService;

        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Promotions", Type = typeof(List<Promotion>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public  async Task<ActionResult<IEnumerable<Promotion>>> FindPromotions()
        {
            try
            {
                return Ok(await _promotionService.FindPromotionsAsync());
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Promotion added ", Type = typeof(Promotion))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<Promotion>> AddPromotion([FromBody]Promotion promotion)
        {
            try
            {
                return Ok(await _promotionService.AddPromotionAsync(promotion));
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Promotion updated ", Type = typeof(Promotion))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<Promotion>> UpdatePromotion([FromBody] Promotion promotion)
        {
            try
            {
                return Ok(await _promotionService.UpdatePromotionAsync(promotion));
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Promotion deleted ", Type = typeof(Promotion))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<Promotion>> AddPromotion([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _promotionService.DeletePromotionAsync(id));
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}