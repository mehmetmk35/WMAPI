using DepoYazılımAPI.Domin.Entity.StockCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DepoYazılımAPI.Application.Abstractions
{
    public interface IStockCardListService
    {
        List<StockCardList> GetStockCardList();
    }
}
