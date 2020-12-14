namespace ColourManagement

open System.Drawing

type ColourHistory(initialColours:seq<Color>, maxLength:int) =
    let mutable colours =
        initialColours
        |> Seq.truncate maxLength
        |> List.ofSeq
    
    member this.Colours() =
        colours |> Seq.ofList
    
    member this.Add(colour: Color) =
        let colours' =
            colour:: colours
            |> List.distinct
            |> List.truncate maxLength
        colours <- colours'
    
    member this.TryLatest() =
        match colours with
        | head :: _ -> Some head
        | [] -> None
    
    member this.RemoveLatest() =
        match colours with
        | _ ::tail -> colours <- tail
        | [] -> ()