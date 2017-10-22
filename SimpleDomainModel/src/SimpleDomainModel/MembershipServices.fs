module MembershipServices

open DeliveryModel
    
    let activateMembership (request:DigitalItemDeliveryRequest) = 
        let user = request.customer.name
        let item = request.orderItem.product.productName
        printfn "Activating membership for user %s with for item %s" user item

    
    let checkMembership request = failwith "not implemented"