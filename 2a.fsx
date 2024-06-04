open System
open System.Collections.Generic
open System.Numerics

let dict = Dictionary<int64, int64>()  // Use BigInteger for sum

// Recursive Fibonacci function with memoization
let rec fib n =
    match n with
    | 0L -> 0L
    | 1L -> 1L
    | _ ->
        if dict.ContainsKey(n) then
            dict.[n]
        else
            let value = fib(n - 1L) + fib(n - 2L)
            dict.[n] <- value
            value

// [<EntryPoint>]
let main args =
    let t = Console.ReadLine() |> int64
    for _ in 1L .. t do  // Loop for each test case
        let n = Console.ReadLine() |> int64  // Read n for each case

        let sum = Seq.initInfinite (fun i -> fib(int64 i)) 
                   |> Seq.filter (fun elm -> elm % 2L = 0L) 
                   |> Seq.takeWhile (fun x -> x < n)
                   |> Seq.fold (fun acc x -> acc + BigInteger(x)) BigInteger.Zero  // BigInteger sum
        Console.WriteLine(sum)
    0
        
main [||]
