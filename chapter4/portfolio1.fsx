// Listing 4.10 Generic Implementation of groupBy

type Instrument = string
type Quantity = int
type TradedQuantity = TradedQuantity of Instrument * Quantity

let instrument (TradedQuantity(i, _)) = i
let quantity (TradedQuantity(_, q)) = q


type Account = string
type ActivityReport = ActivityReport of Account * list<TradedQuantity>

let tradeQuantity (ActivityReport(_, quantityList)) = quantityList
let account (ActivityReport(acc, _)) = acc

type ActivityReport with 
    member x.groupBy (fn: TradedQuantity -> 'T) =
        tradeQuantity x |> List.groupBy fn
        
let tradeList xs = List.map TradedQuantity xs

let activityReport = 
    ActivityReport("keisuke", 
        tradeList [("IBM", 360); ("GOOGLE", 200); ("YAHOO", 350); ("TOYOTA", 350);])
activityReport.groupBy(instrument)
