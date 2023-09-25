using WinnerBayer.Models;
namespace WinnerBayer.Services
{
    public class SaleService : ISaleService
    {
        public SaleService() {}

        public SaleResult SaleObject(ObjectForSale objectForSale, IEnumerable<Bayer> bayers)
        {

            var data = bayers
               .AsParallel()
               .Select((bayer) => new
               {
                   MaxBid = bayer.Bids
                        .Select(bid => bid.Value)
                        .Where(value => value >= objectForSale.ReservePrice)
                        .OrderByDescending(value => value)
                        .FirstOrDefault(),
                   BayerName = bayer.Name
               })
               .Where(x => x.MaxBid >= objectForSale.ReservePrice)
               .OrderByDescending(x => x.MaxBid);

            if (!data.Any())
            {
                return new SaleResult
                {
                    Winner = null,
                    WinningPrice = objectForSale.ReservePrice

                };
            }
            var winnerData = data.First();
            var listData = data.ToList();
            listData.RemoveAt(0);
            return new SaleResult {

                Winner = winnerData.BayerName,
                WinningPrice = listData.FirstOrDefault()?.MaxBid ?? objectForSale.ReservePrice
            };
        }
    }
}

