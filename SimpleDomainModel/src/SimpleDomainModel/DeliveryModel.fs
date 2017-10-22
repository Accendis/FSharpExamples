module DeliveryModel

open System
open OrderModel
open CustomerModel
open CommonTypes.RestrictedStrings
open CommonTypes.CurrencyTypes

    type PhysicalItemDeliveryRequest = 
        { orderId : Guid
          orderItem : OrderItem
          customer : Customer
          shippingLabelContent : String50
          shippingLabelAdditionalContent : String100 option }
    
    type DigitalDeliveryWorkflow = 
        | MembershipActivationAndEmail
        | EmailNotificationAndVoucher of voucherValue: decimal<BRL>
    

    type DigitalItemDeliveryRequest = 
        { orderId : Guid
          orderItem : OrderItem
          customer : Customer
          notificationSubject: String50
          notificationMessage: String
          deliveryWorkflow : DigitalDeliveryWorkflow }
