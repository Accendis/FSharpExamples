module DeliveryService

open System
open CustomerModel
open CommonTypes.RestrictedStrings
open OrderModel
open MembershipServices
open CommonTypes.CurrencyTypes
open NotificationServices
open VoucherServices
open DeliveryModel


    let deliverPhysicalItem (deliveryRequest: PhysicalItemDeliveryRequest) = 
        printfn "%s" <| "Sending physical Item for order: " + deliveryRequest.orderId.ToString()
    
    let requestMembershipActivation (request : DigitalItemDeliveryRequest) = 
        activateMembership request
        request
    
    let notifyUserViaEmail (request : DigitalItemDeliveryRequest) = 
        let message = 
            { destination = request.customer.email
              subject = request.notificationSubject
              message = request.notificationMessage }
        sendEmail message
        request
    
    let requestVoucherGeneration (request : DigitalItemDeliveryRequest) (voucherValue : decimal<BRL>) = 
        generateVoucher request voucherValue
        request
    
    let deliverDigitalItem deliveryRequest = 
        match deliveryRequest.deliveryWorkflow with

        | MembershipActivationAndEmail -> 
            printfn "starting workflow: membership activation and e-mail notification..."
            deliveryRequest
            |> requestMembershipActivation
            |> notifyUserViaEmail
            |> ignore

        | EmailNotificationAndVoucher voucherValue -> 
            printfn "starting workflow: e-mail notification and voucher generation..."
            deliveryRequest
            |> notifyUserViaEmail
            |> requestVoucherGeneration <| voucherValue
            |> ignore