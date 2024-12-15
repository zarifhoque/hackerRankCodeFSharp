open System

exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

let main args: int =
    try 
        let testCaseCount  = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase in 1..testCaseCount do
            let n = Console.ReadLine() |> int |> checkIfNegativeInputInt
            let constant = bigint.Parse("2")
            let res = bigint.Pow(constant, n)
            let resStr = res.ToString()
            let sum = resStr.ToCharArray() 
                    |> Array.map (fun c -> int32 c - int32 '0') 
                    |> Array.sum 
                    |> int

            printfn "%d" sum
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"          
    0

main [| |]


