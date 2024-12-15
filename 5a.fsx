open System


exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

let divisibleBy1ToN n: int =
    let numbersSequence: int seq =
        seq { 1..n }
    let solutionSequence = Seq.initInfinite (fun i ->  i + 1)
    // find the first number that is divided by all numbers in numSeqn
    solutionSequence 
    |> Seq.find (fun numItem -> numbersSequence |> Seq.forall (fun solItem -> numItem % solItem = 0))


let main args: unit = 
    try 
        let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase in 1..testCaseCount do
            let input = Console.ReadLine() |> int |> checkIfNegativeInputInt
            let result = divisibleBy1ToN input
            Console.WriteLine(result)
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"
    

main [| |]
