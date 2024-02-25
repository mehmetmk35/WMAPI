﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Features.Queries.StockCard.GetStockByStockCode
{
    public class GetStockByStockCodeQueriesRequest:IRequest<GetStockByStockCodeQueriesResponse>
    {
        public string StockCode { get; set; }
    }
}
