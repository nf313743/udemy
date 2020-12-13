namespace Section14

module ArraySection =

    let calcSum start endv =
        let arr = [| for i in start..endv -> i * i |]
        let sum = arr |> Array.sum
        printfn "Sum: %i" sum

    let calcSum2 endv =
        let arr = Array.init endv (fun x -> (x + 1) * (x + 1))
        let sum = arr |> Array.sum
        printfn "Sum: %i" sum
