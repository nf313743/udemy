namespace StudentScores

module Float = 
    let tryFromString (s:string) =
        match System.Double.TryParse(s) with
        | true, value -> Some value
        | false, _ -> None
    
    let tryFromStringOrValue d s  = 
        s |> tryFromString |> Option.defaultValue d