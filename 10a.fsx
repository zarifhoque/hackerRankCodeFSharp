open System

let isPrime n =
    let upperBound = int64 (sqrt (float n))
    let checkingNumbers = seq { 2L .. upperBound }
    checkingNumbers |> Seq.forall (fun i -> n % i <> 0L)

let sumOfPrimesBelow n =
    seq { 2L .. n }
    |> Seq.filter isPrime
    |> Seq.sum

let main args = 
    let t = Console.ReadLine() |> int64
    for _ in 1L..t do
        let n = Console.ReadLine() |> int64
        let res = sumOfPrimesBelow n
        printfn "%d" res

    0

main [| |]
