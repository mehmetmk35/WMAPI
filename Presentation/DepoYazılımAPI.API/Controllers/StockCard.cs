using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Application.ViewModels.StockCardR;
using DepoYazılımAPI.Domain.RequestParameters;
using DepoYazılımAPI.Domin.Entity.StockCard; 
using Microsoft.AspNetCore.Mvc;

namespace DepoYazılımAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockCardController : ControllerBase
    {  
        private readonly IStockCardReadRepository _stockCardReadRepository;
        private readonly IStockCardWriteRepository _stockCardWriteRepository;

        public StockCardController(IStockCardReadRepository stockCardReadRepository, IStockCardWriteRepository stockCardWriteRepository)
        {
            _stockCardReadRepository = stockCardReadRepository;
            _stockCardWriteRepository = stockCardWriteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Get(CreateStockCardRecord stockCardRecord)
        {
            if (ModelState.IsValid)
            {
                
            }
            await _stockCardWriteRepository.AddAsync(new StockCardRecord {
                StockCode = stockCardRecord.StockCode,
                CompanyName= stockCardRecord.CompanyName,
                BranchCode= stockCardRecord.BranchCode,
                CreatedBy= stockCardRecord.CreatedBy
            });
            await _stockCardWriteRepository.SaveAsync();

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> StokList([FromQuery]Pagination pagination)
         {
            var totalCount = _stockCardReadRepository.Get(false).Count();
             var stockList = _stockCardReadRepository.Get(false).Select(x => new
            {
                x.StockCode,
                x.StockName,
                x.BranchCode,
                x.CreatedAt,
                x.CreatedBy
            }).Skip(pagination.Size*pagination.Page).Take(pagination.Size);
            return Ok(new
            {
                totalCount, stockList
            });
        }

        [HttpDelete("{stockCode}")]
        public async Task<IActionResult> Delete(string stockCode)
        {
          
        await  _stockCardWriteRepository.Remove(stock => stock.StockCode == stockCode);
            return Ok();

        }
    }
}
