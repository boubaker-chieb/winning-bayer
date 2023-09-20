using WinnerBayer.Exceptions;
using WinnerBayer.Models;
namespace WinnerBayer.Services
{
    public class SaleService : ISaleService
    {

        public SaleService() { }

        public Bayer FindWinner(IEnumerable<Bayer> bayers, ObjectForSale objectForSale)
        {

            var data = bayers
               .Select((bayer) => new
               {
                   maxBid = bayer.Bids
                        .Select(bid => bid.Value)
                        .Where(value => value >= objectForSale.ReservePrice)
                        .OrderByDescending(value => value)
                        .FirstOrDefault(),
                   bayer
               })
               .Where(x => x.maxBid >= objectForSale.ReservePrice)
               .OrderByDescending(x => x.maxBid);

            if (!data.Any())
            {
                throw new NoBayerException("No bayer applies a price");
            }

            return data.First().bayer;
        }

        public int FindWinningPrice(IEnumerable<Bayer> bayers, ObjectForSale objectForSale)
        {
            try
            {
                var winner = FindWinner(bayers, objectForSale);

                var secondBayer = bayers
                  .Select((bayer) => new
                  {
                      maxBid = bayer.Bids
                           .Select(bid => bid.Value)
                           .Where(value => value >= objectForSale.ReservePrice && value < winner.Bids.Max(b => b.Value))
                           .OrderByDescending(value => value)
                           .FirstOrDefault(),
                      bayer
                  })
                   .OrderByDescending(x => x.maxBid)
                   .FirstOrDefault();

                return secondBayer?.maxBid == null || secondBayer?.maxBid == 0 ? objectForSale.ReservePrice : (int)secondBayer?.maxBid;
            }
            catch (NoBayerException)
            {
                return objectForSale.ReservePrice;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

