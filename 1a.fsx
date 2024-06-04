
module eulerProblem1A =
    
    open System
    
    let sumUptoN (n:int64) (a:int64) =        
        a * n * (n + 1L) / 2L

    // [<EntryPoint>]
    let main argv =
            let t = Console.ReadLine() |> int64
            for _ in 1L .. t do
                // get long value
                let n = Console.ReadLine() |> int64
                let sum3 = sumUptoN ((n-1L)/3L) 3L
                let sum5 = sumUptoN ((n-1L)/5L) 5L
                let sum15 = sumUptoN ((n-1L)/15L) 15L
                let result = sum3 + sum5 - sum15
                printfn "%d" result
            0 // return an integer exit code
    main [|""|]
