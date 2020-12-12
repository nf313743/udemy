open System

let indexedForLoop (argv: string array) = 
    for i in 0..argv.Length-1 do
        printfn "Hello %s" argv.[i]
    ()

let iteratorForLoop(argv: string array) =
    for person in argv do
            printfn "Hello %s" person
    ()

let iterFucnction (argv: string array)=
    argv
    |> Array.iter(fun x -> printfn "Hello %s" x)

[<EntryPoint>]
let main argv =
    indexedForLoop argv
    iteratorForLoop argv
    iterFucnction argv
    0