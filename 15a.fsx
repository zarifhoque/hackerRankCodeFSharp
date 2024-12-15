open System
open System.Collections.Generic

let modulo : int64 = 1000000007L

exception NegativeNumberException of string

let checkIfNegativeInputint64 (input:int64) :int64 =
    if input < 0L then
        raise (NegativeNumberException "The bigint you have passed cannot be negative")
    input

let rec numberOfPaths (n: int64) (m: int64) : int64 =
    match n, m with
    | 0L, 0L -> 1L // the case when we reach the end
    | 0L, _ -> numberOfPaths 0L (m - 1L) // the case when we reach the right edge
    | _, 0L -> numberOfPaths (n - 1L) 0L  // the case when we reach the bottom edge
    | _, _ -> numberOfPaths (n - 1L) m + numberOfPaths n (m - 1L) // the case when we are in the middle



let rec numberOfPathsMemoized n m (pathVals: Dictionary<(int64 * int64), int64>) =
    match pathVals.TryGetValue((n, m)) with
    | true, v -> v // the case when we have already calculated the value
    | _ ->
        let v =
            match n, m with 
            | 0L, 0L -> 1L // the case when we reach the end
            | 0L, _ -> numberOfPathsMemoized 0L (m - 1L) pathVals // the case when we reach the right edge
            | _, 0L -> numberOfPathsMemoized (n - 1L) 0L pathVals // the case when we reach the bottom edge
            | _, _ -> 
                let left = numberOfPathsMemoized (n - 1L) m pathVals // the case when we are in the middle
                let up = numberOfPathsMemoized n (m - 1L) pathVals // the case when we are in the middle
                (left + up) % modulo
        pathVals.Add((n, m), v) // store the value in the dictionary for future use
        v

let main args =
    try 
        let testCaseCount = Console.ReadLine() |> int64 |> checkIfNegativeInputint64
        for testCase in 1L..testCaseCount do
            let input = Console.ReadLine()
            let numbers = input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries) |> Array.map int64
            let n = numbers.[0] |> checkIfNegativeInputint64
            let m = numbers.[1] |> checkIfNegativeInputint64
            let pathVals = Dictionary<(int64 * int64), int64>()
            let res = numberOfPathsMemoized n m pathVals
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
