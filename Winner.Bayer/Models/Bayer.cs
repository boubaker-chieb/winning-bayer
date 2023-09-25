namespace WinnerBayer.Models
{
	public class Bayer
	{
		public string Name { get; set; }
		public IEnumerable<Bid> Bids { get; set; } = new List<Bid>();
    }
}

