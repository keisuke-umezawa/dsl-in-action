#r @"Q:\umezawa\dev\local\fsharp\dsl-in-action\chapter3_scalar\bin\Debug\chapter3_scalar.dll"

type AccountDsl(account : chapter3scalar.Account) =
    let _account = account
    member x.names() = _account.names

    member x.belongsTo(name : string) =
        name.Contains(_account.firstName) || _account.names.Contains(name)
      
    member x.addName(name : string) =
        AccountDsl(_account.addName(name))
        
    member x.firstName() =
        x.firstName()
        
let inline (<<) (account : AccountDsl) (name : string) =
    account.addName(name)
    
let account = chapter3scalar.Account("55", "Kei")

account.names

let accountDsl = AccountDsl(account)


accountDsl << "Keisuke"

accountDsl << "Kaisuke"

accountDsl.belongsTo("Keisuke")

accountDsl.belongsTo("Yusuke")

accountDsl.names()

Seq.filter (fun x -> x = "Keisuke") (accountDsl.names())

accountDsl.calculate (chapter3scalar.CalculatorImpl())


// exact example
let acc1 = AccountDsl(chapter3scalar.Account("acc-1", "David P."))
let acc2 = AccountDsl(chapter3scalar.Account("acc-2", "John S."))
let acc3 = AccountDsl(chapter3scalar.Account("acc-3", "Fried T."))

acc1 << "Mary R." << "Shawn P." << "John S."

let accounts = [acc1; acc2; acc3]

accounts |> Seq.filter (fun x -> x.belongsTo "John S.")
         |> Seq.map (fun x -> x.firstName)
         |> Seq.iter (printfn "%O")