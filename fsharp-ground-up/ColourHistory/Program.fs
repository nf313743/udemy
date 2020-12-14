open ColourManagement
open System.Drawing


let listColours (history: ColourHistory) = 
    history.Colours()
    |> Seq.iter (printf "%A")
    printfn ""

[<EntryPoint>]
let main argv =
    let history = ColourHistory([Color.Indigo; Color.Violet], 7)
    history |> listColours

    history.Add(Color.Blue)
    history |> listColours

    printfn "%O" (history.TryLatest())

    history.Add(Color.Blue)
    history |> listColours

    history.RemoveLatest()
    history.RemoveLatest()
    history.RemoveLatest()
    history.RemoveLatest()
    history.RemoveLatest()
    history.RemoveLatest()

    history |> listColours

    0 