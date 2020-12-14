type State =
    {
        N: int
        Pn1: int
        Pn2:int
    }


module MathSequence =
    let pell = 
        {N = 0; Pn1 = 0; Pn2 =0}
        |> Seq.unfold(fun state ->
            let pn = 
                match state.N with
                |0 | 1 -> state.N
                | _ ->  2 * state.Pn1 + state.Pn2
            
            let newStart = {N=state.N + 1; Pn1=pn; Pn2= state.Pn1}
            Some (pn, newStart))


module Drunkard = 
    let r = System.Random()

    let step() =
        r.Next(-1, 2)

    type Position = { X: int; Y: int}

    let walk =
        {X = 0; Y = 0}
        |> Seq.unfold(fun position ->
            let x' = position.X + step()
            let y' = position.Y + step()
            let position' = { X = x'; Y = y'}
            Some(position', position')
            )

[<EntryPoint>]
let main argv =
    // MathSequence.pell
    // |> Seq.truncate 10
    // |> Seq.iter(fun x -> printf "%i, " x)
    Drunkard.walk
    |> Seq.take 1000
    |> Seq.iter (fun x-> printfn "X: %i Y: %i" x.X x.Y)
    0