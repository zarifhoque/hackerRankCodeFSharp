open System

exception NegativeNumberException of string
let checkIfNegativeInputInt64 (input:int64) :int64 =
    if input < 0L then
        raise (NegativeNumberException "The bigint you have passed cannot be negative")
    input

let isPrime (n:int64) :bool =
    let upperBound = int64 (sqrt (float n)) // mathematically guaranteed to not exceed this limit
    let checkingNumbers = seq { 2L .. upperBound } // generate the numbers via which we will check
    checkingNumbers |> Seq.forall (fun (i: int64) -> n % i <> 0L) // check if n is divisible by any of the numbers

let sumOfPrimesBelow (n: int64) : int64 =
    let candidateNumbers:int64 seq =  seq { 2L .. n }
    candidateNumbers |> Seq.filter isPrime |> Seq.sum // filter out the primes and sum them

let main args = 
    try 
        let testcases = Console.ReadLine() |> int64 |> checkIfNegativeInputInt64
        for _ in 1L..testcases do
                    let n = Console.ReadLine() |> int64
                    let res = sumOfPrimesBelow n
                    printfn "%d" res
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"

    0

main [| |]
