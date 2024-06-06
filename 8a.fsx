open System

let getSubsetResult (stringSubset:string) = 
    stringSubset.ToCharArray() |> Array.fold(fun acc c -> acc * (int c - int '0')) 1


let solution (str:string) (k:int) =
    let seqn = seq {
        for i in 0 .. str.Length - k do
            yield getSubsetResult (str.Substring(i, k))
    }
    seqn |> Seq.max

let main args = 
    let t = Console.ReadLine() |> int
    for i in 1..t do
        let line = Console.ReadLine().Split [|' '|]
        let str = Console.ReadLine()
        let n = int line.[0]
        let k = int line.[1]
        let res = solution str k
        printfn "%d" res
    0

main [| |]
