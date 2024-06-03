open System
open System.Collections.Generic

// Dictionary to store previously computed Fibonacci numbers
let dict = Dictionary<int, bigint>()

// Recursive Fibonacci function with memoization
let rec fib n = 
    match n with
    | 0 -> 0I
    | 1 -> 1I
    | _ ->
        if dict.ContainsKey(n) then
            dict.[n]
        else
            let value = fib (n - 1) + fib (n - 2)
            dict.[n] <- value
            value

// Read number of test cases
let t = Console.ReadLine() |> int 

for _ in 1 .. t do
    // Read input number
    let n = Console.ReadLine() |> bigint.Parse
    
    let mutable input = 0
    let mutable res = 0I
    let mutable fibValue = fib input
    while fibValue <= n do
        if fibValue % 2I = 0I then 
            res <- res + fibValue
        input <- input + 1
        fibValue <- fib input

    // Print the result
    printfn "%A" res
