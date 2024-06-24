open System
open System.Numerics  // Needed for BigInteger

exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int) : int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

let rec factorial (n: int) : BigInteger =
    if n <= 1 then
        1I
    else
        bigint n * factorial (n - 1)

let sumOfDigits (n: BigInteger) : int =
    n.ToString().ToCharArray()
    |> Array.map (fun c -> int c - int '0')
    |> Array.sum

let main args =
    try 
        let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase in 1..testCaseCount do
            let n = Console.ReadLine() |> int |> checkIfNegativeInputInt
            let factN = factorial n
            let sumDigits = sumOfDigits factN
            printfn "%d" sumDigits
    with
    | :? System.FormatException -> printfn "Formatting error has occurred"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | ex -> printfn "An error occurred: %s" (ex.ToString())
    1  // Return an integer indicating success

main [| |]
