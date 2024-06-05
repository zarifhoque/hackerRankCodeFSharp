open System


let isPrime x = 
    let checkingSeqn = {2..(int32(Math.Sqrt(float x)))}
    checkingSeqn |> Seq.forall (fun it -> x % it <> 0)

let rec generateNthPrime n candidate =
    match n with
    | 0 -> candidate 
    | _ -> 
        let nextCandidate = candidate + 1
        if isPrime nextCandidate then
            generateNthPrime (n-1) nextCandidate
        else
            generateNthPrime n nextCandidate

let main args = 
    let t = Console.ReadLine() |> int
    for i in 1..t do
        let n = Console.ReadLine() |> int
        let result = generateNthPrime n 1
        Console.WriteLine(result)
    0

main [| |]

