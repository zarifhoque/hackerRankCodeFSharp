open System


let main args =
    let n = Console.ReadLine() |> int
    let numbers = [for i in 1..n -> Console.ReadLine() |> bigint.Parse]
    let sum = numbers |> List.sum
    let sumStr = sum.ToString()
    let first10 = sumStr.Substring(0, 10)
    printfn "%s" first10
       
    0

main [| |]
