open System

let generatePythagoreanTriplets limit =
    seq {
        for i in 1..limit do
            for j in 1..limit do
                let k = limit - i - j
                if i * i + j * j = k * k then
                    yield (i, j, k)
    }

let main args = 
    let t = Console.ReadLine() |> int
    for _ in 1..t do
        let n = Console.ReadLine() |> int
        let allPossibleSolutions = 
            generatePythagoreanTriplets n
            |> Seq.filter (fun (i, j, k) -> i + j + k = n)
            |> Seq.map (fun (i, j, k) -> i * j * k)
        if Seq.isEmpty allPossibleSolutions then
            printfn "-1"
        else
            let res = allPossibleSolutions |> Seq.max
            printfn "%d" res
        
    0

main [| |]
