#r @"Q:\umezawa\dev\local\fsharp\dsl-in-action\chapter3_scalar\bin\Debug\chapter3_scalar.dll"

type AccountDsl(account : chapter3scalar.Account) =
    let _account = account
    member x.names() = _account.Names_

    member x.belongsTo(name : string) =
        name.Contains(_account.FirstName_) || _account.Names_.Contains(name)
      
    member x.addName(name : string) =
        AccountDsl(_account.addName(name))
        

let inline (<<) (account : AccountDsl) (name : string) =
    account.addName(name)
    

let account = chapter3scalar.Account("55", "Keisuke")

account.Names_

let accountDsl = AccountDsl(account)

accountDsl.names()

accountDsl << "Keisuke"

accountDsl.belongsTo("Keisuke")

accountDsl.belongsTo("Yusuke")