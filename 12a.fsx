open System

exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

// dictionary to store vals
let dict = System.Collections.Generic.Dictionary<int, int>()

let rec buildValForTriangleNumbers (index: int) = 
    match index with 
    | 1 -> 1
    | _ -> 
        match dict.TryGetValue(index) with
        | true, v -> v
        | _ -> 
            let v = 
                buildValForTriangleNumbers (index - 1) + index 
            dict.Add(index, v)
            v
let numberOfDivisors (input: int) = 
    let divisorSeqn = {1..input}
    divisorSeqn |> Seq.filter (fun divisor -> input % divisor  = 0) |> Seq.length
let infiniteSequenceOfTriangleNumbers = Seq.initInfinite( fun (i: int) -> buildValForTriangleNumbers (i + 1))

let main args: unit =
    try 
        let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase in 1..testCaseCount do
            let input = Console.ReadLine()
                        |> int 
                        |> checkIfNegativeInputInt
            infiniteSequenceOfTriangleNumbers 
                    |> Seq.filter (fun triangleNumber -> numberOfDivisors triangleNumber > input) 
                    |> Seq.head 
                    |> printfn "%d"
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"

    

main [| |]
