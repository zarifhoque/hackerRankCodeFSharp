open System

exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

let main args int =
    try 
        let n = Console.ReadLine() |> int |> checkIfNegativeInputInt
        let numbers = [for i in 1..n -> Console.ReadLine() |> bigint.Parse]
        let sum = numbers |> List.sum
        let sumStr = sum.ToString()
        let first10 = sumStr.Substring(0, 10)
        printfn "%s" first10
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred" 

       
    0

main [| |]
