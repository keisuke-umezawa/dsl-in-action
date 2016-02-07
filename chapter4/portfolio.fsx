// Listing 4.10 Generic Implementation of groupBy

type Instrument = string
type Quantity = int
type TradedQuantity = TradedQuantity of Instrument * Quantity

let instrument (TradedQuantity(i, _)) = i
let quantity (TradedQuantity(_, q)) = q

type Account = string
type ActivityReport = ActivityReport of Account * TradedQuantity list
with member x.groupBy (fn: TradedQuantity -> 'T) =
            match x with
            | ActivityReport(name, tqs) ->
                tqs |> Seq.groupBy fn |> Seq.toList

let tradeList xs = List.map TradedQuantity xs

let activityReport = 
    ActivityReport("keisuke", 
        tradeList [("IBM", 360); ("GOOGLE", 200); ("YAHOO", 350); ("TOYOTA", 350);])
      
printfn "Activity Report grouping by instrument:\n %A" <| activityReport.groupBy(instrument)
printfn "Activity Report grouping by quantity:\n %A" <| activityReport.groupBy(quantity)