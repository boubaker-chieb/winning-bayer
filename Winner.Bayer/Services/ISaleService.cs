using WinnerBayer.Models;

namespace WinnerBayer.Services
{
	public interface ISaleService
	{
        /// <summary>
        /// Sale object to list of bayers.
        /// </summary>
        /// <param name="objectForSale"></param>
        /// <param name="bayers"></param>
        /// <returns>Sale result, including winner and winning price</returns>
        SaleResult SaleObject(ObjectForSale objectForSale, IEnumerable<Bayer> bayers);
    }
}

