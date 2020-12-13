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

    let summarise filePath =
        let rows = File.ReadAllLines(filePath)
        let studentCount = rows.Length - 1
        printfn "Student count %i" studentCount
        rows 
        |> Array.skip 1
        |> Array.map Student.fromString
        |> Array.groupBy(fun x-> x.Surname)
        |> Array.sortBy fst
        |> Array.map(fun (key, value) -> (key, (value |> Array.sortBy(fun x -> x.GivenName))))
        |> Array.iter (fun (surname, students) -> printGroupSummary surname students)