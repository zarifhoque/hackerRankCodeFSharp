open System
open System.Numerics


let t = Console.ReadLine() |> BigInteger.Parse

for _ in 1I .. t do
    let n = Console.ReadLine() |> BigInteger.Parse
    // let val1 = [1I..n] |> List.map (fun x -> x*x) |> List.sum 
    // let val2 = [1I..n] |> List.sum |> fun x -> x*x
    // formula method 
    let val1 = (n * (n + 1I) * (2I * n + 1I)) / 6I
    let val2 = ((n * (n + 1I)) / 2I) * ((n * (n + 1I)) / 2I)
    
    let res = abs (val2 - val1)

    printfn "%A" res
    

