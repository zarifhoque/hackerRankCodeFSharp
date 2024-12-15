open System

exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    else
        input


let isPrime (x: int): bool = 
    // mathematically guaranteed to be no primes after sqrt(x)
    let checkingSeqn = {2..(int32(Math.Sqrt(float x)))} 
    checkingSeqn |> Seq.forall (fun it -> x % it <> 0)

// we check if the number is prime, if it is we decrement n and increment the candidate
// if it is not we increment the candidate and check again
// we are guaranteed to find the nth prime number when we hit base case n = 0
let rec generateNthPrime (n: int) (candidate: int): int =
    match n with
    | 0 -> candidate 
    | _ -> 
        let nextCandidate = candidate + 1
        if isPrime nextCandidate then
            generateNthPrime (n-1) nextCandidate
        else
            generateNthPrime n nextCandidate

let main args = 
    try 
        let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase in 1..testCaseCount do
            let input = Console.ReadLine() |> int |> checkIfNegativeInputInt
            let result = generateNthPrime input 1
            Console.WriteLine(result)
    with 
        | :? System.FormatException -> printfn "Formatting error has occured"
        | :? System.IO.IOException -> printfn "An IO exception occurred"
        | :? System.OutOfMemoryException -> printfn "Out of memory"
        | :? System.OverflowException -> printfn "Number is too large"
        | :? NegativeNumberException as e -> printfn "%s" e.Message
        | _ -> printfn "An error occurred"

    0

main [| |]

