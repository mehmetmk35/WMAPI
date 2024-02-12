using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Application.Repositorys.File.StockCardImageFile;
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
        private readonly IStorageService _storageService;
        private readonly IStockCardImageFileWriteRepository _stockCardImageFileWriteRepository;
        private readonly IStockCardImageFileReadRepository _stockCardImageFileReadRepository;

        public StockCardController(IStockCardReadRepository stockCardReadRepository, IStockCardWriteRepository stockCardWriteRepository, IStockCardImageFileWriteRepository stockCardImageFileWriteRepository, IStockCardImageFileReadRepository stockCardImageImageFileReadRepository, IStockCardImageFileReadRepository stockCardImageFileReadRepository, IStorageService storageService)
        {
            _stockCardReadRepository = stockCardReadRepository;
            _stockCardWriteRepository = stockCardWriteRepository;
            _stockCardImageFileWriteRepository = stockCardImageFileWriteRepository;
            _stockCardImageFileReadRepository = stockCardImageFileReadRepository;
            _storageService = storageService;
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
            var totalCount = _stockCardReadRepository.GetWhere(x => x.IsDeleted == false, false).Count();
             var stockList = _stockCardReadRepository.GetWhere(x=>x.IsDeleted==false,false).Select(x => new
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
            _stockCardWriteRepository.SaveAsync();
            return Ok();

        }

        [HttpPost("[action]")]
        public  async Task<IActionResult> Upload()
        {
            List<(string Filename, string pathOrContainerName)> datas= await _storageService.UploadAsync("resource/files", Request.Form.Files);

             await _stockCardImageFileWriteRepository.AddRangeAsync(datas.Select(d => new Domin.Entity.FileUpload.StockCardImageFile
            {
                BranchCode = 1,
                CompanyName = "test1",
                CreatedBy = "mehmet",
                Name = d.Filename,
                Storage = _storageService.StorageName,
                Path = d.pathOrContainerName
            }).ToList());
            
            return Ok();
        }
    }
    
    
    
}
