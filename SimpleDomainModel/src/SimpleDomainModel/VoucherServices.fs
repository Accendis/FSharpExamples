module VoucherServices

open CommonTypes.CurrencyTypes
open DeliveryModel
    
    let generateVoucher (request:DigitalItemDeliveryRequest) (voucherValue: decimal<BRL>) = 
        let user = request.customer.name
        let item = request.orderItem.product.productName
        let value = decimal voucherValue 
        printfn "Generating voucher for user %s regarding item %s of %M R$" user item value



    let validateVoucher _ = failwith "not implemented"
    let redeemVoucher _ = failwith "not implemented"