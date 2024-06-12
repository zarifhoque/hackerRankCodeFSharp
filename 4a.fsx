open System


exception NegativeNumberException of string
let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input
let productSequence =
    seq {
        for i = 999 downto 100 do
            for j = 999 downto 100 do
                yield i * j
    }

let isPallindrome input = 
    let inputStr: string= input.ToString()
    let inputStrReversed: string = new String (Array.rev (inputStr.ToCharArray()))
    inputStr = inputStrReversed

let checkIfDivisibleByTwo3DigitNumbers input = 
    productSequence |> Seq.exists (fun element -> element=input)    

let solution input: unit =
    let resSeqn: int seq = seq {for j=input-1 downto 1 do yield j}
    Seq.find(fun (x: int) -> isPallindrome x && checkIfDivisibleByTwo3DigitNumbers x) resSeqn |> printfn "%d"
    
let main args: int = 
    try
        let testCaseCount: int = Console.ReadLine() |> int |> checkIfNegativeInputInt
        for testCase = 1 to testCaseCount do
            let n: int = Console.ReadLine() |> int |> checkIfNegativeInputInt
            solution n
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"
    0

main [| |]