open System


exception NegativeNumberException of string
let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

// count down to when n=0
let rec collatzCount (n: int) (count: int) : int = 
    match n with
    | 1 -> count // base case
    | _ when n % 2 = 0 -> collatzCount (n / 2) (count + 1) // even case
    | _ -> collatzCount (3 * n + 1) (count + 1) // odd case

let main args : unit =
    try
        let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase in 1..testCaseCount do
            let input = Console.ReadLine() 
                        |> int 
                        |> checkIfNegativeInputInt
            let candidateNumbers = seq {1..input}
            let collatzResults = candidateNumbers 
                                |> Seq.map (fun x -> x,collatzCount x 1) 
            let maxCollatz = collatzResults |> Seq.maxBy snd
            let result = collatzResults 
                        |> Seq.filter (fun x -> snd x = snd maxCollatz) 
                        |> Seq.max 
                        |> fst
            result |> string |> Console.WriteLine    
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"
    
main [| |]
