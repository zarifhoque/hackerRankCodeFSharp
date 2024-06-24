open System


exception NegativeNumberException of string
let checkIfNegativeInputint64 (input:int) :int =
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input
let rec maxPathSum (triangle: int[][]) row col =
    // if we reach the last row return the value you have accumulated so far
    if row = Array.length triangle - 1 then
        triangle.[row].[col]
    else
        // call to left and right branches
        let leftPathSum = maxPathSum triangle (row + 1) col
        let rightPathSum = maxPathSum triangle (row + 1) (col + 1)
        
        // sum with the calling cell value and return above the call stack
        triangle.[row].[col] + max leftPathSum rightPathSum

        
let main args: unit =
    try 
        let testCaseCount = Console.ReadLine() |> int 
        // printfn "Number of Test Cases : %d" t
        for testCase in 1..testCaseCount do
            let triangleSize = Console.ReadLine() |> int
            // Calculate the maximum path sum
            let inputTriangle =
                let numRows = int(triangleSize)
                Array.init numRows (fun _ ->
                    Console.ReadLine().Split() |> Array.map int)
            let maxSum = maxPathSum inputTriangle 0 0
            printfn "%d" maxSum
    with 
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.OverflowException -> printfn "Overflow occurred"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.ArgumentOutOfRangeException -> printfn "Argument out of range exception occurred"
    | :? NegativeNumberException as ex -> printfn "%s" ex.Message
    | _ -> printfn "An error occurred"


main [||]