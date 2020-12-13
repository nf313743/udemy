open System.IO

let printMeanScore (row: string) = 
    let elements = row.Split('\t')
    let name = elements.[0]
    let id = elements.[1]
    let scores =
        elements
        |> Array.skip 2
        |> Array.map float
    let mean = scores |> Array.average
    let min = scores |> Array.min
    let max = scores |> Array.max

    printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" name id mean min max

let summarise filePath =
    let rows = File.ReadAllLines(filePath)
    let studentCount = rows.Length - 1
    printfn "Student count %i" studentCount
    rows |> Array.skip 1 |> Array.iter printMeanScore
    

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
                    summarise x
                    0
        | None ->  printfn "Please specify a valid file"; 1

    

    argv |> someFilePath |> isValidPath