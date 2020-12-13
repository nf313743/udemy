open System.IO
open StudentScores


[<EntryPoint>]
let main argv =
    let someFilePath (args:string array) = 
        match args.Length with
        | 1 -> if File.Exists(args.[0]) then
                    Some args.[0]
               else
                    None
        | _ -> None

    let isValidPath someFilePath =
        match someFilePath with
        | Some x -> printfn "Processing %s" x
                    try
                        Summary.summarise x
                        0
                    with
                    | :? System.FormatException as ex->
                        printfn "Error: %s" ex.Message
                        printfn "The file was not in the expected format"
                        1
                    | :?  System.IO.IOException as ex->
                        printfn "Error: %s" ex.Message
                        printfn "The file is open in another program"
                        1
                    | ex -> 
                        printfn "Error: %s" ex.Message
                        1
        | None ->  printfn "Please specify a valid file"; 2

    argv |> someFilePath |> isValidPath