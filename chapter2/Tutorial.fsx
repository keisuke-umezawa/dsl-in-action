#load "Order.fs"

open Order

let pricer quantity price = quantity * price

let o = Order.Default.buy("MSFT", 10).limitPrice(200).valueAs(pricer)
