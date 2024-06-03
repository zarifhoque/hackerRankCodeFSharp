open System
open System.Numerics

let largestPrimeFactor (n: bigint) =
    let mutable n = n
    let mutable i = 2I
    let mutable largest = 0I
    while i * i <= n do
        while n % i = 0I do
            largest <- i
            n <- n / i
        i <- i + 1I
    if n > 1I then
        largest <- n
    largest

let t = Console.ReadLine() |> int

for _ in 1 .. t do
    let n = Console.ReadLine() |> BigInteger.Parse
    let result = largestPrimeFactor n
    printfn "%A" result
