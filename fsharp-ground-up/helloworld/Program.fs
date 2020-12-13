open System.IO

type Student = 
    {
        Name:string
        Id:string
        MeanScore:float
        MinScore: float
        MaxScore:float
    }


module Student =
    let fromString(s:string) =
        let elements = s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]
        let scores =
            elements
            |> Array.skip 2
            |> Array.map float
        {
            Name = name
            Id = id
            MeanScore = scores |> Array.average
            MinScore = scores |> Array.min
            MaxScore = scores |> Array.max
        }

    let printMeanScore (student) = 
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let summarise filePath =
    let rows = File.ReadAllLines(filePath)
    let studentCount = rows.Length - 1
    printfn "Student count %i" studentCount
    rows 
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortByDescending(fun x -> x.MeanScore)
    |> Array.iter Student.printMeanScore
    

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