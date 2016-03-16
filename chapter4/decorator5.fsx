open System
// decorator
type Trade =
    { Reference : string;
      Account : string;
      Instrument : string;
      Value : double; }
    static member make reference account instrument principal =
        { Reference = reference; 
          Account = account;
          Instrument = instrument;
          Value = principal; }

type Calculator =
    | DefaultCalculator of (Trade -> float)
    | TaxFeeDecoratedCalculator of (Trade -> float)
    | UnTaxFeeDecoratedCalculator of (Trade -> float)
    member x.Of trade =
        match x with
        | UnTaxFeeDecoratedCalculator(f) | TaxFeeDecoratedCalculator(f) 
        | DefaultCalculator(f) -> 
        f trade
    
        
let defaultCalculator = DefaultCalculator(fun trade -> trade.Value)

let taxFeeDecorator calculator = 
    match calculator with
    | TaxFeeDecoratedCalculator(f) -> TaxFeeDecoratedCalculator(f)
    | UnTaxFeeDecoratedCalculator(f) | DefaultCalculator(f) -> 
        let decorated = fun trade -> (f trade) * 0.8
        TaxFeeDecoratedCalculator(decorated)

let unTaxFeeDecorator calculator = 
    match calculator with
    | UnTaxFeeDecoratedCalculator(f) -> UnTaxFeeDecoratedCalculator(f)
    | TaxFeeDecoratedCalculator(f) | DefaultCalculator(f) -> 
        let decorated = fun trade -> (f trade) / 0.8
        UnTaxFeeDecoratedCalculator(decorated)


let d = Trade.make "a" "b" "c" 100.

let calculator = defaultCalculator

let decoratedCalculator = calculator |> unTaxFeeDecorator |> taxFeeDecorator

let value = decoratedCalculator.Of d

