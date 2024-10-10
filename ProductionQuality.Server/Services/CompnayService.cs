using ProductionQuality.Server.Interfaces;
using ProductionQuality.Server.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionQuality.Server.Services
{
    public  class CompnayService : ICompnayService
    {
        object locker = new();
        public async Task<List<decimal>> GetPrices(int companyId)
        {
            var company  = companies.FirstOrDefault(x => x.Id == companyId);
            if (company == null)
                throw new Exception($"Compnay {companyId} not found");
            else
                return company.PriceHistory.TakeLast(10).ToList();
        }

        public async Task AddPriceHistory(int companyId, int price)
        {
            var company = companies.FirstOrDefault(x => x.Id == companyId);
            if (company == null)
                throw new Exception($"Compnay {companyId} not found");
            else
            {
                lock (locker)
                {
                    company.PriceHistory.Add(price);
                    company.Price = price;
                }
            }
        }

        public async Task AddHistoryPriceAfterUpdatingRequirements(PriceInformation information,int companyId)
        {
            var company = companies.FirstOrDefault(x => x.Id == companyId);

            if (company == null)
                throw new Exception($"Compnay {companyId} not found");
            else
            {
                lock (locker)
                {
                    if(company.HistoryPrice.Count >= 10)
                    {
                        company.HistoryPrice.Dequeue();
                        company.HistoryPrice.Enqueue(information);
                        company.Price = information.Price;
                    }
                    
                }
            }
        }

        public async Task<Queue<PriceInformation>> GetPricesAfterUpdating(int companyId)
        {
            var company = companies.FirstOrDefault(x => x.Id == companyId);
            if (company == null)
                throw new Exception($"Compnay {companyId} not found");
            else
                return company.HistoryPrice;
        }


        public static List<Company> companies = new List<Company>()
        {
            new ()
            {
                Price = 11, Id = 1, PriceHistory = new List<decimal>(){11}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 31, Id = 2, PriceHistory = new List<decimal>(){31}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 25, Id = 3, PriceHistory = new List<decimal>(){25}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 18, Id = 4, PriceHistory = new List<decimal>(){18}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 22, Id = 5, PriceHistory = new List<decimal>(){22}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 24, Id = 6, PriceHistory = new List<decimal>(){24}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 15, Id = 7, PriceHistory = new List<decimal>(){15}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 20, Id = 8, PriceHistory = new List<decimal>(){20}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 21, Id = 9, PriceHistory = new List<decimal>(){21}, HistoryPrice = new Queue<PriceInformation>(10)
            },
            new ()
            {
                Price = 36, Id = 10, PriceHistory = new List<decimal>(){36}, HistoryPrice = new Queue<PriceInformation>(10)
            }
        };

    }
}
