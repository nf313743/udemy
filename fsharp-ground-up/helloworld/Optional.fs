namespace StudentScores

type Optional<'T> =
    | Something of 'T
    | Nothing

module Optional =
    let defaultValue (d: 'T) (optional: Optional<'T>) =
        match optional with
        | Something v -> v
        | Nothing -> d


module Demo =
    let a = Something "abc"
    let b = Something 2
    let c = Something 1.2
    let d = Nothing
