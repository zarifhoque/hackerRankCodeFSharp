open System
open System.Collections.Generic

let getRow (array2D: 'a[,]) (rowIndex: int) =
    [| for colIndex in 0 .. array2D.GetLength(1) - 1 -> array2D.[rowIndex, colIndex] |]


let getColumn (array2D: 'a[,]) (colIndex: int) =
    [| for rowIndex in 0 .. array2D.GetLength(0) - 1 -> array2D.[rowIndex, colIndex] |]


let rec takeInput n arr = 
    if n = 0 then arr
    else 
        try
            let input = Console.ReadLine().Split([|' '; '\t'|], StringSplitOptions.RemoveEmptyEntries) |> Array.map int
            takeInput (n - 1) (arr @ [input])
        with
        | :? FormatException ->
            printfn "Input string was not in a correct format. Please enter valid integers separated by spaces."
            takeInput n arr

let listTo2DArray (listOfArrays) : int[,] =
    let rows = List.length listOfArrays
    let cols = if rows > 0 then Array.length listOfArrays.[0] else 0
    let array2D = Array2D.init rows cols (fun i j -> listOfArrays.[i].[j])
    array2D

let print arr2d = 
    printfn "%A" arr2d

let rec maxProdHorizontal arr2d index =
    if index=20 then 
        0
    else
        let res = getRow arr2d index |> Array.windowed 4 |> Array.map (Array.fold (*) 1) |> Array.max
        max res (maxProdHorizontal arr2d (index+1))

let rec maxProdVertical arr2d index =
    if index=20 then 
        0
    else
        let res = getColumn arr2d index |> Array.windowed 4 |> Array.map (Array.fold (*) 1) |> Array.max
        max res (maxProdVertical arr2d (index+1))

let extractCounterDiagonals (arr2D: int[,]) =
    arr2D
    |> Array2D.mapi (fun i j x -> (i, j, x)) 
    |> Seq.cast<(int * int * int)>
    |> Seq.groupBy (fun (i, j, _) -> i + j)
    |> Seq.map snd 
    |> Seq.map (Seq.map (fun (_, _, x) -> x))
    |> Seq.filter (fun x -> Seq.length x >= 4)
    |> Seq.map ( fun (seq: int seq) -> Seq.toArray seq )
    |> Seq.toList



let extractDiagonals (arr2D: int[,]) =
    arr2D
    |> Array2D.mapi (fun i j x -> (i, j, x)) 
    |> Seq.cast<(int * int * int)>
    |> Seq.groupBy (fun (i, j, _) -> i - j)
    |> Seq.map snd 
    |> Seq.map (Seq.map (fun (_, _, x) -> x))
    |> Seq.filter (fun x -> Seq.length x >= 4)
    |> Seq.map ( fun (seq: int seq) -> Seq.toArray seq )
    |> Seq.toList


// take each diagnoal
// extract 4 window arrays from each array 
// fold them to get product
// take max of all products
let  maxProdDiagonal diagnoals  =
    let res = diagnoals |> List.map (fun x -> x |> Array.windowed 4 |> Array.map (Array.fold (*) 1) |> Array.max) |> List.max
    res

let maxProdCounterDiagonal counterDiagonals =
    let res = counterDiagonals |> List.map (fun x -> x |> Array.windowed 4 |> Array.map (Array.fold (*) 1) |> Array.max) |> List.max
    res

let main args =
    // Take 2D 20*20 input
    let arr = takeInput 20 []
    let arr2d = listTo2DArray arr
    let maxHorizontal = maxProdHorizontal arr2d 0
    let maxVertical = maxProdVertical arr2d 0
    let diagonals = extractDiagonals arr2d
    let counterDiagonals = extractCounterDiagonals arr2d
    let maxDiagonal = maxProdDiagonal diagonals
    let maxCounterDiagonal = maxProdCounterDiagonal counterDiagonals
    let res = max maxHorizontal (max maxVertical (max maxDiagonal maxCounterDiagonal))
    printfn "%d" res
   
    
    0

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
