module NotificationServices

open CustomerModel
open CommonTypes.RestrictedStrings

    
    type EmailMessage = 
        { destination : EmailAddress
          subject : String50
          message : string }
    
    let sendEmail emailMessage = 
        let destination = unwrapEmail emailMessage.destination
        let subject = unwrapString50 emailMessage.subject

        printfn "%s" <| "Sending notificatio via e-mail to: " + destination + " with subject: " + subject 
    
    let sendSms smsMessage = failwith "not implemented"
    let sendPushNotification pushNotificationMessage = failwith "not implemented"

