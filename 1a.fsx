open System


exception NegativeNumberException of string



let checkIfNegativeInputint64 (input:int64) :int64 =
    if input < 0L then
        raise (NegativeNumberException "The bigint you have passed cannot be negative")
    input

let sumOfMultipleOfThreeOrFive (endingTerm: int64) : int64 = 
    let sumationOfAUptoN (endingTerm: int64) (startingTerm: int64) : int64  =
        let numberOfTerms: int64 = ((endingTerm-1L)/startingTerm)
        startingTerm * numberOfTerms * (numberOfTerms + 1L) / 2L

    let sumOf3:  int64 = sumationOfAUptoN endingTerm 3L
    let sumOf5:  int64 = sumationOfAUptoN endingTerm 5L
    let sumOf15: int64 = sumationOfAUptoN endingTerm 15L
    sumOf3 + sumOf5 - sumOf15

let main args: unit =
    try 
        let numberOfTestCases = Console.ReadLine()|> int64 |> checkIfNegativeInputint64
        if numberOfTestCases < 1L then
            raise (NegativeNumberException "Invalid input")

        for testCase in 1L .. numberOfTestCases do
            
            let input = Console.ReadLine() |> int64
            if input < 1L then
                raise (NegativeNumberException "Invalid input")
            let result = sumOfMultipleOfThreeOrFive (int64 input)
            printfn "%d" result
        
    with 
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.OverflowException -> printfn "Overflow occurred"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.ArgumentOutOfRangeException -> printfn "Argument out of range exception occurred"
    | :? NegativeNumberException as ex -> printfn "%s" ex.Message
    | _ -> printfn "An error occurred"


main [||]
