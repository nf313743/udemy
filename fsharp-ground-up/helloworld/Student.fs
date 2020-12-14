namespace StudentScores

type Student =
    { Surname: string
      GivenName: string
      Id: string
      SchoolName: string
      MeanScore: float
      MinScore: float
      MaxScore: float }

module Student =

    let nameParts (s: string) =
        let elements = s.Split(',')
        match elements with
        | [| surname |] ->
            {| Surname = surname.Trim()
               GivenName = "(None)" |}
        | [| surname; givenName |] ->
            {| Surname = surname.Trim()
               GivenName = givenName.Trim() |}
        | _ -> raise (System.FormatException(sprintf "Invalid name format: \"%s\"" s))


    let fromString (schoolCodes: Map<_, _>) (s: string) =
        let elements = s.Split('\t')
        let name = elements.[0] |> nameParts
        let id = elements.[1]
        let schoolCode = elements.[2] 
        let schoolName = schoolCodes.TryFind schoolCode |> Option.defaultValue "(Unknown)"
        let scores =
            elements
            |> Array.skip 3
            |> Array.map (TestResult.fromString)
            |> Array.choose TestResult.tryEffectiveScore

        { Surname = name.Surname
          GivenName = name.GivenName
          Id = id
          SchoolName = schoolName
          MeanScore = scores |> Array.average
          MinScore = scores |> Array.min
          MaxScore = scores |> Array.max }

    let printMeanScore (student) =
        printfn
            "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f"
            student.GivenName
            student.Surname
            student.Id
            student.MeanScore
            student.MinScore
            student.MaxScore
    
    let printSummary (student : Student) =
        printfn "%s, %s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.SchoolName student.MeanScore student.MinScore student.MaxScore