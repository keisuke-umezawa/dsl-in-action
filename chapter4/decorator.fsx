open System
// decorator

type Trade(ref : string, account : string, instrument : string,
           principal : double) =
    let mutable calculateFunctor = fun () -> principal

    member this.calculator
        with get() = calculateFunctor
        and set(f) = calculateFunctor <- f

    member this.value() = calculateFunctor()

let taxFee(calculateFunctor) =
    fun () -> calculateFunctor() * 0.8 
let comissionFee(calculateFunctor) =
    fun () -> calculateFunctor() + 2.0

let taxFeeDecorator (trade : Trade) = 
    trade.calculator <- taxFee(trade.calculator)
    trade
let comissionDecorator (trade : Trade) = 
    trade.calculator <- comissionFee(trade.calculator)
    trade

let d = Trade("a", "b", "c", 100.)

(Trade("a", "b", "c", 100.) |> taxFeeDecorator 
    |> comissionDecorator).value()