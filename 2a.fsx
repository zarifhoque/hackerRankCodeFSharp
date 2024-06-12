open System
open System.Collections.Generic
open System.Numerics


exception NegativeNumberException of string
let fibonacciLookupFor = Dictionary<int64, int64>()  // Store the memoized valeus of the fibonacci numbers here

// Recursive Fibonacci function with memoization

let getFibonacciValueFOr (index: int64) (typeOfAlgorithm: string) : int64 =
    let rec nonMemoizedFibonacciImplementation (index: int64 ) : int64 =
        match index with
        | 0L -> 0L // Base case for 0
        | 1L -> 1L // Base case for 1
        | _ -> nonMemoizedFibonacciImplementation(index - 1L) + nonMemoizedFibonacciImplementation(index - 2L) // Recursive call

    let rec memoizedFibonacciImplementation (index: int64 ) : int64 =
        match index with
        | 0L -> 0L // Base case for 0
        | 1L -> 1L // Base case for 1
        | _ ->
            if fibonacciLookupFor.ContainsKey(index) then // The case when the dictionary already contains the computed value
                fibonacciLookupFor.[index]
            else
                let value :int64 = memoizedFibonacciImplementation(index - 1L) + memoizedFibonacciImplementation(index - 2L) // Recursive call
                fibonacciLookupFor.[index] <- value // Assign obtained value to dictionary for further memoization 
                value

    match typeOfAlgorithm with
    | "memoized" -> memoizedFibonacciImplementation index
    | "non-memoized" -> nonMemoizedFibonacciImplementation index
    | _ -> raise (System.ArgumentOutOfRangeException("Invalid argument"))



let main args: unit =
    try 
        let testCaseCount = Console.ReadLine() |> int64
        if testCaseCount<0L then raise (NegativeNumberException "Negative number")
        else
            for testCase in 1L .. testCaseCount do  // Loop for each test case
                
                let input = Console.ReadLine() |> int64  // Read input for each case
                if input<0L then raise (NegativeNumberException "Negative number")
                else
        
                    let sum = Seq.initInfinite (fun index -> getFibonacciValueFOr(int64 index ) "memoized" )  
                            |> Seq.filter (fun element -> element % 2L = 0L) 
                            |> Seq.takeWhile (fun element -> element < input)
                            |> Seq.fold (fun accumulator element -> accumulator + BigInteger(element)) BigInteger.Zero  // BigInteger sum
                    Console.WriteLine(sum)
                
    with 
    | :? System.IO.IOException -> printfn "Error reading input try again"
    | :? System.FormatException -> printfn "Invalid input"
    | :? System.OverflowException -> printfn "Number too large"
    | :? System.ArgumentOutOfRangeException -> printfn "Invalid argument"
    | :? NegativeNumberException as e -> printfn "Negative number exception: %s" e.Message
    | _ -> printfn "An error occurred"
        
main [||]
