namespace StudentScores

module Summary =

    open System.IO

    let printGroupSummary(surname:string)(students:Student[])=
        printfn "%s" (surname.ToUpperInvariant())
        students
        |> Array.iter (fun student -> 
            printfn "\t%20s\t%s\t%0.1f\t%0.1f\t%0.1f" 
                student.GivenName 
                student.Id 
                student.MeanScore 
                student.MinScore
                student.MaxScore)

    let summarise schoolCodesFilePath filePath =
        let rows = 
            File.ReadLines filePath
            |> Seq.cache
        let studentCount = (rows |> Seq.length ) - 1
        printfn "Student count %i" studentCount
        let schoolCodes = SchoolCodes.load schoolCodesFilePath
        rows 
        |> Seq.skip 1
        |> Seq.map (Student.fromString schoolCodes)
        |> Seq.sortByDescending(fun x-> x.MeanScore)
        |> Seq.iter Student.printSummary
        