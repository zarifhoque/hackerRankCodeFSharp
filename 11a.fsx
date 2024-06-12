open System
open System.Collections.Generic


exception NegativeNumberException of string
let checkIfNegativeInputInt (input: int)  :int = 
    if input < 0 then
        raise (NegativeNumberException "The int you have passed cannot be negative")
    input


let getRow (array2D: 'a[,]) (rowIndex: int) =
    [| for colIndex in 0 .. array2D.GetLength(1) - 1 -> array2D.[rowIndex, colIndex] |]


let getColumn (array2D: 'a[,]) (colIndex: int) =
    [| for rowIndex in 0 .. array2D.GetLength(0) - 1 -> array2D.[rowIndex, colIndex] |]


let rec takeInput (n: int) (arr: int array list) : list<array<int>> = 
    if n = 0 then arr // base case : if n is 0 return the array of arrays
    else 
        try
            let input = Console.ReadLine().Split([|' '; '\t'|], StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Array.map checkIfNegativeInputInt  // take input of numbers and map them onto array
            takeInput (n - 1) (arr @ [input]) // append the input array to the list of arrays
        with
        | :? FormatException ->
            printfn "Please enter valid integers separated by spaces or tabs."
            takeInput n arr

// this function converts list of arrays to 2D array
let listTo2DArray (listOfArrays:int array list) : int[,] =
    let rows = List.length listOfArrays
    let cols = if rows > 0 then Array.length listOfArrays.[0] else 0
    let array2D = Array2D.init rows cols (fun i j -> listOfArrays.[i].[j])
    array2D

let print (arr2d: int array2d) : unit = 
    printfn "%A" arr2d

// this function takes 2D array and returns the maximum product of 4 adjacent numbers in horizontal direction for all rows
let rec maxProdHorizontal (arr2d: int array2d) (index: int) : int=
    if index=20 then 
        0
    else
        let res = getRow arr2d index |> Array.windowed 4 |> Array.map (Array.fold (*) 1) |> Array.max
        max res (maxProdHorizontal arr2d (index+1))

// this function takes 2D array and returns the maximum product of 4 adjacent numbers in vertical direction for all columns
let rec maxProdVertical (arr2d: int array2d) (index: int) : int=
    if index=20 then 
        0
    else
        let res = getColumn arr2d index |> Array.windowed 4 |> Array.map (Array.fold (*) 1) |> Array.max
        max res (maxProdVertical arr2d (index+1))

// this function takes 2D array and returns the diagonals of the array whose length is greater than or equal to 4
let extractCounterDiagonals (arr2D: int[,]) : int array list =
    arr2D
    |> Array2D.mapi (fun (i: int) (j: int) (x: int) -> (i, j, x)) // map the 2D array to 3D array conatining 3 element tuples of the number and its indices in 2D
    |> Seq.cast<(int * int * int)> // cast the 3D array to sequence of 3 element tuples
    |> Seq.groupBy (fun ((i: int), (j: int), (_: int)) -> i + j) // group the sequence by the sum of indices
    |> Seq.map snd  // keep the values of the sequence
    |> Seq.map (Seq.map (fun (_, _, x) -> x)) // map the sequence to sequence of numbers
    |> Seq.filter (fun x -> Seq.length x >= 4) // filter the sequences whose length is greater than or equal to 4
    |> Seq.map ( fun (seq: int seq) -> Seq.toArray seq ) // convert the sequence to array
    |> Seq.toList // convert the sequence to list



// this function takes 2D array and returns the diagonals of the array whose length is greater than or equal to 4
// this takes the diagonals in the opposite direction to the extractDiagonals function
let extractDiagonals (arr2D: int[,]) : int array list =
    arr2D
    |> Array2D.mapi (fun (i: int) (j: int) (x: int) -> (i, j, x)) 
    |> Seq.cast<(int * int * int)>
    |> Seq.groupBy (fun (i, j, _) -> i - j) // group the sequence by the difference of indices instead of sum
    |> Seq.map snd 
    |> Seq.map (Seq.map (fun (_, _, x) -> x))
    |> Seq.filter (fun x -> Seq.length x >= 4)
    |> Seq.map ( fun (seq: int seq) -> Seq.toArray seq )
    |> Seq.toList


// take each diagnoal
// extract 4 window arrays from each array 
// fold them to get product
// take max of all products
let  maxProdDiagonal (diagnoals :int array list)  : int =
    let res = diagnoals 
            |> List.map (
                fun x -> x 
                        |> Array.windowed 4 
                        |> Array.map (Array.fold (*) 1) 
                        |> Array.max
                ) 
            |> List.max
    res

let maxProdCounterDiagonal (counterDiagonals :int array list) : int =
    let res = counterDiagonals 
            |> List.map (
                    fun x -> x 
                            |> Array.windowed 4 
                            |> Array.map (Array.fold (*) 1) 
                            |> Array.max) 
            |> List.max
    res

let main args : unit=
    // Take 2D 20*20 input
    try 
        let arr = takeInput 20 [] // take input of 20 arrays
        let arr2d = listTo2DArray arr // convert the list of arrays to 2D array
        let maxHorizontal = maxProdHorizontal arr2d 0 // get the maximum product of 4 adjacent numbers in horizontal direction
        let maxVertical = maxProdVertical arr2d 0 // get the maximum product of 4 adjacent numbers in vertical direction
        let diagonals = extractDiagonals arr2d // get the diagonals of the 2D array
        let counterDiagonals = extractCounterDiagonals arr2d // get the counter diagonals of the 2D array
        let maxDiagonal = maxProdDiagonal diagonals // get the maximum product of 4 adjacent numbers in diagonal direction
        let maxCounterDiagonal = maxProdCounterDiagonal counterDiagonals // get the maximum product of 4 adjacent numbers in counter diagonal direction
        let res = max maxHorizontal (max maxVertical (max maxDiagonal maxCounterDiagonal)) // get the maximum of all the maximum products
        printfn "%d" res
    with
    | :? System.FormatException -> printfn "Formatting error has occured"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | :? System.OutOfMemoryException -> printfn "Out of memory"
    | :? System.OverflowException -> printfn "Number is too large"
    | :? NegativeNumberException as e -> printfn "%s" e.Message
    | _ -> printfn "An error occurred"

    


main [| |]

// temp input 
// 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 
// 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 
// 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 
// 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 
// 5 5 5 5 5 5 5 5 5 5 5 5 5 5 5 5 5 5 5 5 
// 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 
// 7 7 7 7 7 7 7 7 7 7 7 7 7 7 7 7 7 7 7 7 
// 8 8 8 8 8 8 8 8 8 8 8 8 8 8 8 8 8 8 8 8 
// 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 
// 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 
// 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 11 
// 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 12 
// 13 13 13 13 13 13 13 13 13 13 13 13 13 13 13 13 13 13 13 13 
// 14 14 14 14 14 14 14 14 14 14 14 14 14 14 14 14 14 14 14 14 
// 15 15 15 15 15 15 15 15 15 15 15 15 15 15 15 15 15 15 15 15 
// 16 16 16 16 16 16 16 16 16 16 16 16 16 16 16 16 16 16 16 16 
// 17 17 17 17 17 17 17 17 17 17 17 17 17 17 17 17 17 17 17 17 
// 18 18 18 18 18 18 18 18 18 18 18 18 18 18 18 18 18 18 18 18 
// 19 19 19 19 19 19 19 19 19 19 19 19 19 19 19 19 19 19 19 19 
// 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 
