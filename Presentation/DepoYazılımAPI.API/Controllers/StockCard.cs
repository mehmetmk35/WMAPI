using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Application.Features.Commands.DeleteStockCard;
using DepoYazılımAPI.Application.Features.Commands.StockCard.CreateStock;
using DepoYazılımAPI.Application.Features.Commands.StockCardImageFile;
using DepoYazılımAPI.Application.Features.Queries.StockCard.GetStockByStockCode;
using DepoYazılımAPI.Application.Features.Queries.StockCard.StockCard.GetAllStock;
using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Application.Repositorys.File.StockCardImageFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DepoYazılımAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]// buraya gelen isteklerde kullanıcı yetkilimi değilmi kontrol et  yetkili ise 200 değilse 401 döner 
    public class StockCardController : ControllerBase
    {  
        private readonly IStockCardReadRepository _stockCardReadRepository;
        private readonly IStockCardWriteRepository _stockCardWriteRepository;
        private readonly IStorageService _storageService;
        private readonly IStockCardImageFileWriteRepository _stockCardImageFileWriteRepository;
        private readonly IStockCardImageFileReadRepository _stockCardImageFileReadRepository;

        private readonly IMediator _mediator;

        public StockCardController(IStockCardReadRepository stockCardReadRepository, IStockCardWriteRepository stockCardWriteRepository, IStockCardImageFileWriteRepository stockCardImageFileWriteRepository, IStockCardImageFileReadRepository stockCardImageImageFileReadRepository, IStockCardImageFileReadRepository stockCardImageFileReadRepository, IStorageService storageService, IMediator mediator = null)
        {
            _stockCardReadRepository = stockCardReadRepository;
            _stockCardWriteRepository = stockCardWriteRepository;
            _stockCardImageFileWriteRepository = stockCardImageFileWriteRepository;
            _stockCardImageFileReadRepository = stockCardImageFileReadRepository;
            _storageService = storageService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Get(CreateStockCommandRequest createStockCommandRequest)
        {
            bool a=ModelState.IsValid;
            CreateStockCommandResponse  response= await  _mediator.Send(createStockCommandRequest);
            return Ok((int)HttpStatusCode.Created);
        }
        [HttpGet]
        public async Task<IActionResult> StokList([FromQuery] GetAllStockQueryRequest getAllStockQueryRequest)
         {
            GetAllStockQueryResponse response = await _mediator.Send(getAllStockQueryRequest);
            return Ok(response);
        }
        [HttpGet("{StockCode}")]
        public async Task<IActionResult> GetStockByStockCode([FromRoute]GetStockByStockCodeQueriesRequest getStockByStockCodeQueriesRequest  )
        {
            GetStockByStockCodeQueriesResponse response = await _mediator.Send(getStockByStockCodeQueriesRequest);
            return Ok(response);
        }

        [HttpDelete("{stockCode}")]
        public async Task<IActionResult> DeleteStockCard([FromRoute]DeleteStockCardCommandRequest deleteStockCardCommandRequest)
        {    await  _mediator.Send(deleteStockCardCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        public  async Task<IActionResult> Upload([FromQuery]StockCardImageFileCommandRequest stockCardImageFile)
        {
            stockCardImageFile.FormCollection = Request.Form.Files;

            await _mediator.Send(stockCardImageFile);
            return Ok();
        }
    }
    
    
    
}
