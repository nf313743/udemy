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
                    Summary.summarise x
                    0
        | None ->  printfn "Please specify a valid file"; 1
        
    argv |> someFilePath |> isValidPath