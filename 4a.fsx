open System

let prodSeqn =
    seq {
        for i = 999 downto 100 do
            for j = 999 downto 100 do
                yield i * j
    }

let isPall n = 
    let s = n.ToString()
    let rev = new String (Array.rev (s.ToCharArray()))
    s = rev

let checkIfDivisibleByTwo3DigitNumbers n = 
    prodSeqn |> Seq.exists (fun x -> x=n)    

let solution n =
    let resSeqn = seq {for j=n-1 downto 1 do yield j}
    Seq.find(fun x -> isPall x && checkIfDivisibleByTwo3DigitNumbers x) resSeqn |> printfn "%d"
    
let main args = 
    let t = Console.ReadLine() |> int
    for i = 1 to t do
        let n = Console.ReadLine() |> int
        solution n
    0

main [| |]