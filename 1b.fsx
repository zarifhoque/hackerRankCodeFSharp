open System

let sumOfMultiples a n =
    let mutable m =  (2*a + (n-1)*a)
    m <- m*n
    m <- m/2

    m

let t = Console.ReadLine() |> int

for _ in 1 .. t do
    let n = Console.ReadLine() |> int
    let sum3 = sumOfMultiples 3 ((n-1)/3)
    let sum5 = sumOfMultiples 5 ((n-1)/5)
    let sum15 = sumOfMultiples 15 ((n-1)/15)
    let result = sum3 + sum5 - sum15
    printfn "%d" result
