using ProductionQuality.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionQuality.Server.Interfaces
{
    public interface ICompnayService
    {
        Task AddPriceHistory(int companyId, int price);
        Task<List<decimal>> GetPrices(int companyId);
        Task AddHistoryPriceAfterUpdatingRequirements(PriceInformation information, int companyId);
        Task<Queue<PriceInformation>> GetPricesAfterUpdating(int companyId);
    }
}
