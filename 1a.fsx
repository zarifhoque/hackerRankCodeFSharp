open System

let t = Console.ReadLine() |> int 

for i in 1 .. t do
    // take input of a number 
    let n = Console.ReadLine() |> int

    // generate a list of numbers from 1 to n-1 (not including n)
    let numbers = [1 .. n-1]

    // filter and then sum
    let res = numbers |> List.filter(fun number -> number % 3 = 0 || number % 5 = 0) |> List.sum 

    // print the result
    printfn "%d" res
