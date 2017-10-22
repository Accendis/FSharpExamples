module CustomerModel

open System.Text.RegularExpressions
    
    /// In Brazil this number is used to uniquely identify people. It's an identity document.
    type Cpf = Cpf of string
    
    let createValidCpf (cpfString : string) = 
        if cpfString.Length = 11 then Some cpfString
        else None
    
    /// representation of a valid e-mail address - tiny types helps in the creation of a stronger domain model
    type EmailAddress = EmailAddress of email : string
    
    /// creates a valid e-mail address using a string as input.
    let createEmail (s : string) = 
        if Regex.IsMatch(s, @"^\S+@\S+\.\S+$") then Some(EmailAddress s)
        else None
    
    /// receives the strongly type e-mail address and gives back the inner string
    let unwrapEmail (EmailAddress innerEmailString) = innerEmailString
    
    type CustomerAddress =  
        {   zipcode : string
            address1: string } //maybe this can be more restrictive...
    
    type Customer = 
        {   cpf : Cpf
            name : string
            email : EmailAddress }
