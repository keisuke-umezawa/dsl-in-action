open System
// decorator
type Trade =
    { Reference : string;
      Account : string;
      Instrument : string;
      Calculator : unit -> double; }
    member this.value = this.Calculator()
    static member make ref account instrument principal =
        { Reference = ref; 
          Account = account;
          Instrument = instrument;
          Calculator = (fun() -> principal); }
        
let defaultCalculator principal = 
    fun () -> principal

let taxFee(calculateFunctor) =
    fun () -> calculateFunctor() * 0.8 

let comissionFee(calculateFunctor) =
    fun () -> calculateFunctor() + 2.0

let taxFeeDecorator (trade : Trade) = 
    { trade with Calculator = taxFee(trade.Calculator) }
let comissionDecorator (trade : Trade) = 
    { trade with Calculator = comissionFee(trade.Calculator) }

let d = Trade.make "a" "b" "c" 100.

let decorated = d |> taxFeeDecorator |> comissionDecorator

decorated.value;;
