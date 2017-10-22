module OrderModel

    open CustomerModel
    open PaymentModel
    open ProductModel
    open CommonTypes.CurrencyTypes
    open System
   
    type OrderDeclinationReason =
        | OutOfStock
        | PaymentRejected
        | OtherReason
    
    type OrderFulfillmentStatus = 
        | AwaitingProcessing
        | ProcessingPayment
        | Shipped
        | Delivered
        | Declined of reason : OrderDeclinationReason
        
    type OrderItem = 
        { orderItemId : int
          orderId: System.Guid
          product : Product
          listPrice : decimal<BRL>
          sellingPrice : decimal<BRL> }

    /// This is a representation of an order after validation.
    type Order = 
        { orderId : System.Guid
          customer : Customer
          items : OrderItem list
          shippingAddress : CustomerAddress
          closeDate : DateTime option
          orderFullfilmentStatus: OrderFulfillmentStatus
          payment : Payment 
        }

    type Invoice = 
        { invoiceId: int
          invoiceDate: DateTime
          billingAddres : CustomerAddress
          shippingAddress : CustomerAddress
          order : Order }

