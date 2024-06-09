open System

// dictionary to store vals
let dict = System.Collections.Generic.Dictionary<int, int>()

let rec buildVal n = 
    match n with 
    | 1 -> 1
    | _ -> 
        match dict.TryGetValue(n) with
        | true, v -> v
        | _ -> 
            let v = 
                buildVal (n - 1) + n 
            dict.Add(n, v)
            v
let seqn = Seq.initInfinite( fun i -> buildVal (i + 1))

let numberOfDivisors n = 
    let seqn = {1..n}
    seqn |> Seq.filter (fun x -> n % x = 0) |> Seq.length

let main args = 
    let t = Console.ReadLine() |> int
    for _ in 1..t do
        let n = Console.ReadLine() |> int
        seqn |> Seq.filter (fun x -> numberOfDivisors x > n) |> Seq.head |> printfn "%d"
    0

main [| |]
