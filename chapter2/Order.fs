module Order 
type BuyOrSellType =
    | Buy
    | Sell
    override x.ToString() =
        match x with
        | Buy -> "Buy"
        | Sell -> "Sell"

type Order =
    { Security : string;
        Quantity : int;
        LimitPrice : int;
        BuyOrSell : BuyOrSellType;
    }
    static member Default = 
        { Security = "";
          Quantity = 0;
          LimitPrice = 0;
          BuyOrSell = Buy;
        }


    member x.buy(security, quantity) =
        { Security = security;
          Quantity = quantity;
          LimitPrice = x.LimitPrice;
          BuyOrSell = Buy;
        }

    member x.sell(security, quantity) =
        { Security = security;
          Quantity = quantity;
          LimitPrice = x.LimitPrice;
          BuyOrSell = Sell;
        }

    member x.limitPrice(price) =
        { Security = x.Security;
          Quantity = x.Quantity;
          LimitPrice = price;
          BuyOrSell = Sell;
        }

    member x.valueAs(f) : int =
        f x.Quantity x.LimitPrice

