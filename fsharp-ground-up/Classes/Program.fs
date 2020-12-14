open Classes
open System

[<EntryPoint>]
let main argv =
    let namePrompt = ConsolePrompt("Please enter your name", 3)
    namePrompt.ColourScheme <- ConsoleColor.Cyan, ConsoleColor.DarkGray
    let name = namePrompt.GetValue()
    printfn "Hello %s" name

    let person = Person(name, null)
    printfn "%s" (person.Description())
    0