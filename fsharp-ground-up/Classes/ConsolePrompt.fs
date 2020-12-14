namespace Classes

open System

type ConsolePrompt(message: string, maxTries) =
    do
        if String.IsNullOrWhiteSpace(message) then
            raise
            <| ArgumentException("Null or empty", "message")

    let trimmedMessage = message.Trim()
    let mutable tryCount = 0

    let mutable foreground = ConsoleColor.White
    let mutable background = ConsoleColor.Black

    member this.ColourScheme
        with get () = foreground, background
        and set (fg, bg) =
            if fg = bg then
                raise
                <| ArgumentException("Colours cannot be the same")

            foreground <- fg
            background <- bg

    member this.GetValue() =
        tryCount <- tryCount + 1
        Console.ForegroundColor <- foreground
        Console.BackgroundColor <- background
        printf "%s: " trimmedMessage
        Console.ResetColor()
        let input = Console.ReadLine()
        if String.IsNullOrWhiteSpace(input)
           && tryCount < maxTries then
            if this.BeepOnError then Console.Beep()
            this.GetValue()
        else
            input

    member val BeepOnError = true with get, set
