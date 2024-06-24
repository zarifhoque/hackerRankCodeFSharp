//Enter your code here. Read input from STDIN. Print output to STDOUT
open System

// Function to convert a number to words
let rec numberToWords (n: int64) =
    match n with
    | 0L -> []
    | 1L -> [ "One" ]
    | 2L -> [ "Two" ]
    | 3L -> [ "Three" ]
    | 4L -> [ "Four" ]
    | 5L -> [ "Five" ]
    | 6L -> [ "Six" ]
    | 7L -> [ "Seven" ]
    | 8L -> [ "Eight" ]
    | 9L -> [ "Nine" ]
    | 10L -> [ "Ten" ]
    | 11L -> [ "Eleven" ]
    | 12L -> [ "Twelve" ]
    | 13L -> [ "Thirteen" ]
    | 14L -> [ "Fourteen" ]
    | 15L -> [ "Fifteen" ]
    | 16L -> [ "Sixteen" ]
    | 17L -> [ "Seventeen" ]
    | 18L -> [ "Eighteen" ]
    | 19L -> [ "Nineteen" ]
    | 20L -> [ "Twenty" ]
    | 30L -> [ "Thirty" ]
    | 40L -> [ "Forty" ]
    | 50L -> [ "Fifty" ]
    | 60L -> [ "Sixty" ]
    | 70L -> [ "Seventy" ]
    | 80L -> [ "Eighty" ]
    | 90L -> [ "Ninety" ]
    | _ when n < 100L ->
        numberToWords (n / 10L * 10L) @ numberToWords (n % 10L)
    | _ when n < 1000L ->
        numberToWords (n / 100L) @ ["Hundred"] @ numberToWords (n % 100L)
    | _ when n < 1000000L ->
        numberToWords (n / 1000L) @ ["Thousand"] @ numberToWords (n % 1000L)
    | _ when n < 1000000000L ->
        numberToWords (n / 1000000L) @ ["Million"] @ numberToWords (n % 1000000L)
    | _ when n < 1000000000000L ->
        numberToWords (n / 1000000000L) @ ["Billion"] @ numberToWords (n % 1000000000L)
    | _ when n < 1000000000000000L ->
        numberToWords (n / 1000000000000L) @ ["Trillion"] @ numberToWords (n % 1000000000000L)
    | _ -> invalidOp "Number too large"

// Main function to handle input and output
[<EntryPoint>]
let main argv =
    try
        let sc = new System.IO.StreamReader(Console.OpenStandardInput())
        let testCaseCount = int (sc.ReadLine().Trim())
        for _ in 1..testCaseCount do
            let n = int64 (sc.ReadLine().Trim())
            let words = numberToWords n
            let result = String.concat " " words
            printfn "%s" result
        0
    with
    | :? System.FormatException -> printfn "Formatting error has occurred"; 1
    | :? System.OverflowException -> printfn "Overflow occurred"; 1
    | :? System.IO.IOException -> printfn "An IO exception occurred"; 1
    | :? System.ArgumentOutOfRangeException -> printfn "Argument out of range exception occurred"; 1
    | ex -> printfn "An error occurred: %s" (ex.Message); 1
