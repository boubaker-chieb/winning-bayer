using WinnerBayer.Models;

namespace WinnerBayer.Services
{
	public interface ISaleService
	{
        /// <summary>
        /// Find a winner in a list of bayers for an object to sale.
        /// </summary>
        /// <param name="bayers"></param>
        /// <param name="objectForSale"></param>
        /// <returns>The winning bayer</returns>
        Bayer FindWinner(IEnumerable<Bayer> bayers, ObjectForSale objectForSale);

        /// <summary>
        /// Find the winning price in a list of bayers for an object to sale.
        /// </summary>
        /// <param name="bayers"></param>
        /// <param name="objectForSale"></param>
        /// <param name="winner"></param>
        /// <returns>The winning price</returns>
        int FindWinningPrice(IEnumerable<Bayer> bayers, ObjectForSale objectForSale, Bayer? winner);
    }
}

