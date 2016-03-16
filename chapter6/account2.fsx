﻿open System

// Instrument
type Currency =
    | USD
    | JPY
    | HKD

type TaxFee =
    | TradeTax
    | Comission
    | Surcharge
    | VAT


type Market = 
    | NYSE
    | TOKYO
    | HKG
    | SGP

type Date = System.DateTime
let TODAY = Date.Today
    
type IsIn = string
type DateOfIssue = Date

type InstrumentType = IsIn

type DateOfMaturity = Date
type Nominal = float 
type FixedIncome = InstrumentType * DateOfIssue * DateOfMaturity * Nominal

type PaymentSchedule = Map<string, float>
type Percent = float

type DiscountBondType = FixedIncome * Percent 

type Instrument =
    | Equity of InstrumentType * DateOfIssue
    | CouponBond of FixedIncome * PaymentSchedule
    | DiscountBond of DiscountBondType

let IBM = DiscountBond(("ISIN-1234", TODAY, TODAY, 1000.0), 4.0)

type Number = string
type Name = string
type OpenDate = Date
type AccountProperty = Number * Name * OpenDate

type Account =
    | ClientAccount of AccountProperty
    | BrokerAccount of AccountProperty

let Umezawa = ClientAccount("Ume-123", "Umezawa", TODAY)

type TradeDate = Date
type UnitPrice = float
type Quantity = float
type Principal = UnitPrice * Quantity
type TradeProperty 
    = Account * Instrument * Currency * TradeDate * Market * Principal


type Trade =
    | FixedIncomeTrade of TradeProperty
    | EquityTrade of TradeProperty

let trade = FixedIncomeTrade(Umezawa, IBM, USD, TODAY, NYSE, (100.0, 42.0))

// implicit conversion
type WithInstrumentQuantity = Instrument * Quantity
type WithAccountInstrumentQuantity = Account * Instrument * Quantity
type WithMktAccountInstrumentQuantity 
    = Market * Account * Instrument * Quantity

let discount_bonds instrument quantity = (instrument, quantity)
        
let for_client (account : Account) (wiq : WithInstrumentQuantity) = 
    let (i, q) = wiq
    (account, i, q)

let on (market : Market) (waiq : WithAccountInstrumentQuantity) = 
    let (a, i, q) = waiq
    (market, a, i, q)

let at price ccy (wmaiq : WithMktAccountInstrumentQuantity) =
    let (m, a, i, q) = wmaiq
    FixedIncomeTrade(a, i, ccy, TODAY, m, (q, price))

let trade1 
    = 100. |> discount_bonds IBM |> for_client Umezawa |> on NYSE |> at 72. USD
