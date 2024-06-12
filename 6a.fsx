open System
open System.Numerics

exception NegativeNumberException of string


let checkIfNegativeInputBigInt (input:bigint) :bigint =
    if input < 0I then
        raise (NegativeNumberException "The bigint you have passed cannot be negative")
    input


let solution (input: BigInteger): BigInteger = 
    // the mathematical formulas have been checked for correctness
    let sumOfSquares (input: BigInteger): BigInteger = 
        (input * (input + 1I) * (2I * input + 1I)) / 6I

    let squareOfSum (input: BigInteger): BigInteger = 
        ((input * (input + 1I)) / 2I) * ((input * (input + 1I)) / 2I)

    abs (sumOfSquares input - squareOfSum input)

let testCaseCount = Console.ReadLine() |> BigInteger.Parse |> checkIfNegativeInputBigInt

for testCase in 1I .. testCaseCount do
    try 
        let input: bigint = Console.ReadLine() |> BigInteger.Parse |> checkIfNegativeInputBigInt
        let res: BigInteger = solution input
        printfn "%A" res
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"



    

