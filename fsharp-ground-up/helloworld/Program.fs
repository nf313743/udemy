open System

let sayHello (argv: string array)=
    argv
    |> Array.filter(String.IsNullOrWhiteSpace >> not)
    |> Array.iter(fun x -> printfn "Hello %s" x)

[<EntryPoint>]
let main argv =
    sayHello argv
 
    0