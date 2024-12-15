open System

exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

// calculates the product of the digits in the string
let getNumericalStringProduct (string:string) : int= 
    
    string.ToCharArray() |> Array.fold(fun acc c -> acc * (int c - int '0')) 1

// generates subsets and then finds the one with the greatest product
let greatestSubsetProduct (str:string) (k:int) =
    let seqn = seq {
        for i in 0 .. str.Length - k do
            yield getNumericalStringProduct (str.Substring(i, k))
    }
    seqn |> Seq.max

let main args = 
    let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
    try 
        for testCase in 1..testCaseCount do
        let line = Console.ReadLine().Split [|' '|]
        let str = Console.ReadLine()
        let n = int line.[0]
        let k = int line.[1]
        let res = greatestSubsetProduct str k
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
