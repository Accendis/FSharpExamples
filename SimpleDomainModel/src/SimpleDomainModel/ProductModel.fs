module ProductModel

open CommonTypes.CurrencyTypes
    
    type PhysicalProducItemType = Book | Other
    
    type DigitalProductItemType = DigitalMedia | Membership
    
    type ProductType = 
        | PhysicalItem of PhysicalProducItemType
        | DigitalItem of DigitalProductItemType

    //note: of course, this can be as complicated as wanted. It's not needed to invest in product modeling right now.
    type Product = 
        { productId : string
          productName : string
          itemType : ProductType
          listPrice : decimal<BRL> }
