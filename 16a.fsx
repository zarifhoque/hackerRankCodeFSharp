open System


let main args =
    let t  = Console.ReadLine() |> int
    for _ in 1..t do
        let n = Console.ReadLine() |> int
        let constant = bigint.Parse("2")
        let res = bigint.Pow(constant, n)
        let resStr = res.ToString()
        let sum = resStr.ToCharArray() |> Array.map (fun c -> int32 c - int32 '0') |> Array.sum |> int
        printfn "%d" sum
         

    
    0

main [| |]


