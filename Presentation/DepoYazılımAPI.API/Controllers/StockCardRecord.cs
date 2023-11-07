using DepoYazılımAPI.Application.Abstractions;
using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Domin.Entity.StockCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepoYazılımAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockCardRecordController : ControllerBase
    {  
        private readonly IStockCardReadRepository _stockCardReadRepository;
        private readonly IStockCardWriteRepository _stockCardWriteRepository;

        public StockCardRecordController(IStockCardReadRepository stockCardReadRepository, IStockCardWriteRepository stockCardWriteRepository)
        {
            _stockCardReadRepository = stockCardReadRepository;
            _stockCardWriteRepository = stockCardWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _stockCardWriteRepository.Remove(x => x.StockCode == "test2");
            await _stockCardWriteRepository.SaveAsync();
            return Ok("ok");
        }
    }
}
