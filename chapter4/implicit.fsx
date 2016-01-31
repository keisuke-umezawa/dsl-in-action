open System
// implicit context
type Account =
    { Number : string;
      Names : list<string>;
      Address : string;
      Type : string;
      Email : string;}
with override x.ToString() = 
        sprintf "No: %s / Names: (%s) / Address: %s" x.Number (String.Join(", ", x.Names)) x.Address

type Registry =
    static member Register (a: Account) = printfn "Registering  %O" a

type Mailer private (MailTo : string, 
                     MailCc : string, 
                     MailSubject : string,
                     MailBody : string) =

    static member Default = Mailer(MailTo = "", 
                                   MailCc = "", 
                                   MailSubject = "",
                                   MailBody = "")
    member x.To(toRecipients) =
        Mailer(toRecipients, MailCc, MailSubject, MailBody)
    member x.Cc(ccRecipients) =
        Mailer(MailTo, ccRecipients, MailSubject, MailBody)
    member x.Subject(subject) =
        Mailer(MailTo, MailCc, subject, MailBody)
    member x.Body(body) =
        Mailer(MailTo, MailCc, MailSubject, body)
    member x.Send () =
        printfn "send email to %O" MailTo
let NewMailer = Mailer.Default

// script
let a1 = {
    Number = "CL-BXT-23765";
    Names = ["John Doe"; "Phili McCaay";];
    Address = " San Francisco";
    Type = "client";
    Email = "client@exapmle.com";
}

Registry.Register(a1);;

NewMailer.To(a1.Email).Subject("Hello!").Body("hoge").Send();;


