open System
open System.Collections.Generic

let rec numberOfPaths n m =
    match n, m with
    | 0L, 0L -> 1L
    | 0L, _ -> numberOfPaths 0L (m - 1L) 
    | _, 0L -> numberOfPaths (n - 1L) 0L 
    | _, _ -> numberOfPaths (n - 1L) m + numberOfPaths n (m - 1L) 

let modulo = 1000000007L

let rec numberOfPathsMemoized n m (dict: Dictionary<(int64 * int64), int64>) =
    match dict.TryGetValue((n, m)) with
    | true, v -> v
    | _ ->
        let v =
            match n, m with
            | 0L, 0L -> 1L
            | 0L, _ -> numberOfPathsMemoized 0L (m - 1L) dict
            | _, 0L -> numberOfPathsMemoized (n - 1L) 0L dict
            | _, _ -> 
                let left = numberOfPathsMemoized (n - 1L) m dict
                let up = numberOfPathsMemoized n (m - 1L) dict
                (left + up) % modulo
        dict.Add((n, m), v)
        v

let main args =
    let t = Console.ReadLine() |> int64
    for _ in 1L..t do
        let input = Console.ReadLine()
        let numbers = input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries) |> Array.map int64
        let n = numbers.[0]
        let m = numbers.[1]
        let dict = Dictionary<(int64 * int64), int64>()
        let res = numberOfPathsMemoized n m dict
        printfn "%d" res
    0

main [| |]
