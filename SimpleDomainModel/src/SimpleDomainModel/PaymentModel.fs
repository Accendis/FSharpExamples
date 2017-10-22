module PaymentModel
open System

    type PaymentMethod = 
        | CreditCard of hashed : string
        | Debit
        | BrazilianBoleto
        | Paypal
        | Pagseguro

    type PaymentProcessingStatus = 
        | New
        | AwaitingPayment of dateOfOrderSubmisssion : DateTime
        | Paid of dateApproved : DateTime
        | Rejected of dateRejected : DateTime

    type Payment = 
        { paymentId : System.Guid
          authorizationNumber : string
          amount : decimal
          paymentStatus : PaymentProcessingStatus
          paymentMethod : PaymentMethod }
