open System
open System.Numerics

exception NegativeNumberException of string

let largestPrimeFactor (input: bigint) = 
    let isPrime (input: bigint) = 
        let checkingNumbers: BigInteger seq = seq {2I..bigint(sqrt(double(input)))}
        checkingNumbers |> Seq.forall (fun number -> input % number <> 0I)
    
    let candidateNumbers: BigInteger seq = seq {2I..input}
    candidateNumbers |> Seq.filter (fun number -> input % number = 0I && isPrime number) |> Seq.max


let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

let checkIfNegativeInputBigInt (input:bigint) :bigint =
    if input < 0I then
        raise (NegativeNumberException "The bigint you have passed cannot be negative")
    input


try 
    let testCaseCount: int = Console.ReadLine() |> int |>  checkIfNegativeInputInt
    

    for testCase in 1 .. testCaseCount do
        let input = Console.ReadLine() |> BigInteger.Parse  |> checkIfNegativeInputBigInt
        let result = largestPrimeFactor input
        printfn "%A" result
with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"

