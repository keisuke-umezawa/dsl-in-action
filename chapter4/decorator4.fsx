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
    member x.evaluate() = x.Value
    static member (=>) (trade : Trade, decorator) =
        trade.evaluate |> decorator
        

let taxFeeDecorator (calculator) = 
    let taxFee calculateFunctor = fun () -> calculateFunctor() * 0.8 
    taxFee(calculator)


let d = Trade.make "a" "b" "c" 100.

let decoratad = d => taxFeeDecorator

decorated();;