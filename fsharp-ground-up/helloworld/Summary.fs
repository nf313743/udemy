namespace StudentScores

module Summary =

    open System.IO

    let summarise filePath =
        let rows = File.ReadAllLines(filePath)
        let studentCount = rows.Length - 1
        printfn "Student count %i" studentCount
        rows 
        |> Array.skip 1
        |> Array.map Student.fromString
        |> Array.sortByDescending(fun x -> x.MeanScore)
        |> Array.iter Student.printMeanScore