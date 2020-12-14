namespace Classes
open System

type Person(name:string, colour:string) =
    do
        if String.IsNullOrWhiteSpace(name) then
            raise
            <| ArgumentException("Null or empty", "name")

    let favColour =
        match String.IsNullOrWhiteSpace(colour) with
        | true -> "(None)"
        | false -> colour

    member this.Description() =
        sprintf "Name: %s, favourite colour: %s" name favColour
