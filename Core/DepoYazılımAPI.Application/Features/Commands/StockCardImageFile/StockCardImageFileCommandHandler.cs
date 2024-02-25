using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Application.Repositorys.File.StockCardImageFile;
using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Domin.Entity.StockCard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Features.Commands.StockCardImageFile
{
    public class StockCardImageFileCommandHandler : IRequestHandler<StockCardImageFileCommandRequest, StockCardImageFileCommandResponse>
    {
        readonly IStockCardImageFileWriteRepository _stockCardImageFileWriteRepository;
        readonly IStockCardReadRepository _stockCardReadRepository;
        private readonly IStorageService _storageService;
        public StockCardImageFileCommandHandler(IStockCardImageFileWriteRepository stockCardImageFileWriteRepository = null, IStockCardReadRepository stockCardReadRepository = null, IStorageService storageService = null)
        {
            _stockCardImageFileWriteRepository = stockCardImageFileWriteRepository;
            _stockCardReadRepository = stockCardReadRepository;
            _storageService = storageService;
        }
        public async Task<StockCardImageFileCommandResponse> Handle(StockCardImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string Filename, string pathOrContainerName)> datas = await _storageService.UploadAsync("photo-images", request.FormCollection);

            StockCardRecord stockCardRecord = await _stockCardReadRepository.GetSingleAsync(x => x.StockCode == request.StockCode);


            await _stockCardImageFileWriteRepository.AddRangeAsync(datas.Select(d => new Domin.Entity.FileUpload.StockCardImageFile
            {//requeste eklenecekir
                BranchCode = 1,
                CompanyName = "test1",
                CreatedBy = "mehmet",
                Name = d.Filename,
                Storage = _storageService.StorageName,
                Path = d.pathOrContainerName,
                StockCardRecord = new List<StockCardRecord> { stockCardRecord }

            }).ToList());

            await _stockCardImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
