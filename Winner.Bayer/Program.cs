using WinnerBayer.Models;
using WinnerBayer.Services;

// TestData1
IEnumerable<Bayer> bayers1 = new List<Bayer>
{
    new Bayer {
        Name = "A",
        Bids = new List<Bid> {
            new Bid {
                Value = 110
            },
            new Bid {
                Value = 130
            }
        }
    },

    new Bayer {
        Name = "B"
    },

    new Bayer {
        Name = "C",
        Bids = new List<Bid> {
            new Bid {
                Value = 125
            }
        }
    },

    new Bayer {
        Name = "D",
         Bids = new List<Bid> {
            new Bid {
                Value = 105
            },
            new Bid {
                Value = 115
            },
            new Bid {
                Value = 90
            }
        }
    },

     new Bayer {
        Name = "E",
         Bids = new List<Bid> {
            new Bid {
                Value = 132
            },
            new Bid {
                Value = 135
            },
            new Bid {
                Value = 140
            }
        }
    },
};

ObjectForSale objectForSale1 = new ObjectForSale
{
    ReservePrice = 100
};

// TestData2
IEnumerable<Bayer> bayers2 = new List<Bayer>
{
    new Bayer {
        Name = "A",
        Bids = new List<Bid> {
            new Bid {
                Value = 110
            },
            new Bid {
                Value = 130
            }
        }
    },
};

ObjectForSale objectForSale2 = new ObjectForSale
{
    ReservePrice = 120
};


// TestData3
IEnumerable<Bayer> bayers3 = new List<Bayer>
{
    new Bayer {
        Name = "A",
        Bids = new List<Bid> {},
        }
};

ObjectForSale objectForSale3 = new ObjectForSale
{
    ReservePrice = 120
};

// Perform tests
ISaleService saleService = new SaleService();
// Lamda to perform tests
var PerformTest = (ObjectForSale objectForSale, IEnumerable<Bayer> bayers) =>
{

    var saleResult = saleService.SaleObject(objectForSale, bayers);
    if (saleResult.Winner != null)
    {
        Console.WriteLine("The winner bayer is : {0}", saleResult.Winner);
    }

    else
    {
        Console.WriteLine("No bayer applies a price");
    }
    Console.WriteLine("The winning price is {0}", saleResult.WinningPrice);
};


// Test with TestData1
Console.WriteLine("******************** Perform first Test ********************");
PerformTest(objectForSale1, bayers1);

// Test with TestData2
Console.WriteLine("******************** Perform second Test ********************");
PerformTest(objectForSale2, bayers2);

// Test with TestData2
Console.WriteLine("******************** Perform third Test ********************");
PerformTest(objectForSale3, bayers3);

Console.ReadKey();