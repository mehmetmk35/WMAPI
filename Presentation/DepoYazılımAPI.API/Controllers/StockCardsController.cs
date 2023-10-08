using DepoYazılımAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepoYazılımAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockCardsController : ControllerBase
    {   private readonly IStockCardListService _stockCardListService;
        public StockCardsController(IStockCardListService service)
        {
            _stockCardListService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
           var lists = _stockCardListService.GetStockCardList();
                return Ok(lists);
        }
    }
}
