open System


exception NegativeNumberException of string

let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input

// generate all possible pythagorean triplets
let generatePythagoreanTripletCandidates (limit: int) : seq<int * int * int> =
    seq {
        for i in 1..limit do
            for j in 1..limit do
                let k = limit - i - j
                if i * i + j * j = k * k then
                    yield (i, j, k)
    }

let main args : unit = 
    let testCaseCount = Console.ReadLine() |> int |> checkIfNegativeInputInt
    try 
        for testCase in 1..testCaseCount do
            let input = Console.ReadLine() |> int |> checkIfNegativeInputInt
            let allPossibleSolutions = 
                generatePythagoreanTripletCandidates input
                |> Seq.filter (fun (i:int, j:int, k:int) -> i + j + k = input) // check if the sum of the triplet is equal to the input
                |> Seq.map (fun (i:int, j:int, k:int) -> i * j * k) // check if the product of the triplet is equal to the input
            if Seq.isEmpty allPossibleSolutions then // if no solution is found
                printfn "-1"
            else
                let res = allPossibleSolutions |> Seq.max // get the maximum value
                printfn "%d" res
    with 
        | :? System.FormatException -> printfn "Formatting error has occured"
        | :? System.IO.IOException -> printfn "An IO exception occurred"
        | :? System.OutOfMemoryException -> printfn "Out of memory"
        | :? System.OverflowException -> printfn "Number is too large"
        | :? NegativeNumberException as e -> printfn "%s" e.Message
        | _ -> printfn "An error occurred"

main [| |]
