module OrderItemProcessingModel

open System
open OrderModel
open ProductModel
open CustomerModel
open CommonTypes.RestrictedStrings
open CommonTypes.CurrencyTypes
open DeliveryModel
    
    let processPhysicalOrderItem (order:Order) item = 
            printfn "processing order item: common physical item..."
            let request = 
                { orderId = order.orderId
                  orderItem = item
                  customer = order.customer
                  shippingLabelContent = 
                      match createString50 ("Label for Order " + order.orderId.ToString()) with
                      | Some x -> x
                      | None -> failwith "Invalid Shipment Label Content"
                  shippingLabelAdditionalContent = None }
            DeliveryService.deliverPhysicalItem request


    let processBookOrderItem (order:Order) item = 
            printfn "processing order item: physical book..."
            let request = 
                    { orderId = order.orderId
                      orderItem = item
                      customer = order.customer
                      shippingLabelContent = 
                          match createString50 ("Label for Order " + order.orderId.ToString()) with
                          | Some x -> x
                          | None -> failwith "Invalid Shipment Label Content"
                      shippingLabelAdditionalContent = 
                          match createString100 ("Item isento de impostos conforme disposto na Constituição Art. 150, VI, d.") with
                          | Some x -> Some x
                          | None -> failwith "Invalid Supplementary Shipment Label Content"}
            DeliveryService.deliverPhysicalItem request



    let processMembershipOrderItem (order:Order) item = 
        printfn "processing order item: membership activation..."
        let request = 
            {   orderId = order.orderId
                orderItem = item
                customer = order.customer
                deliveryWorkflow = MembershipActivationAndEmail
                notificationSubject = Option.get  (createString50 "Membership Activation")
                notificationMessage = "Notification message for membership activation."
            }
        DeliveryService.deliverDigitalItem request
    
    let processDigitalMediaOrderItem (order:Order) item = 
        printfn "processing order item: digital media delivery..."
        let request = 
            {   orderId = order.orderId
                orderItem = item
                customer = order.customer
                deliveryWorkflow = EmailNotificationAndVoucher 10.0M<BRL> //passing the value of the voucher - strongly typed value
                notificationSubject = Option.get  (createString50 "Digital Media Delivery")
                notificationMessage = "Notification message informing availability of digital media."
            }
        DeliveryService.deliverDigitalItem request

    let startOrderFullfilment (order:Order) = 
        
        let rec handleOrderItems (orderItems: OrderItem list) =
            match orderItems with 
            | [] -> printfn "Itens processados"
            | currentItem::restOfItems -> 
                match currentItem.product.itemType with 
                    | PhysicalItem item  -> 
                        match item with
                            | Book -> processBookOrderItem order currentItem
                            | Other -> processPhysicalOrderItem order currentItem
                    | DigitalItem item -> 
                        match item with 
                            | DigitalMedia -> processDigitalMediaOrderItem order currentItem
                            | Membership -> processMembershipOrderItem order currentItem
                handleOrderItems restOfItems

        handleOrderItems order.items