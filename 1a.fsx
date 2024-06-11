open System


let sumOfMultipleOfThreeOrFive (endingTerm: int64) : int64 = 
    let sumationOfAUptoN (endingTerm: int64) (startingTerm: int64) : int64  =
        let numberOfTerms : int64 = ((endingTerm-1L)/startingTerm)
        startingTerm * numberOfTerms * (numberOfTerms + 1L) / 2L

    let sumOf3:  int64 = sumationOfAUptoN endingTerm 3L
    let sumOf5:  int64 = sumationOfAUptoN endingTerm 5L
    let sumOf15: int64 = sumationOfAUptoN endingTerm 15L
    sumOf3 + sumOf5 - sumOf15

let main argv =
    try 
        let numberOfTestCases = Console.ReadLine() |> int64
        for testCase in 1L .. numberOfTestCases do
            try 
                let input = Console.ReadLine() |> int64
                let result = sumOfMultipleOfThreeOrFive (int64 input)
                printfn "%d" result
            with 
                | :? System.FormatException -> printfn "Invalid input"
                | :? System.OverflowException -> printfn "Invalid input"

    with 
    | :? System.FormatException -> printfn "Invalid input"
    | :? System.OverflowException -> printfn "Invalid input"

    0 // return an integer exit code

main [|""|]
