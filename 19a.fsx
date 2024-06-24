open System

// Define a Date type
type Date = { Year:int; Month:int; Day:int }

// Function to determine if a year is a leap year
let isLeapYear year =
    (year % 4 = 0 && year % 100 <> 0) || (year % 400 = 0)

// Function to calculate days in a month for a given year
let daysInMonth (year:int) (month:int) =
    match month with
    | 1 | 3 | 5 | 7 | 8 | 10 | 12 -> 31
    | 4 | 6 | 9 | 11 -> 30
    | 2 -> if isLeapYear year then 29 else 28
    | _ -> failwith "Invalid month"

// Function to convert a Date to total days since 1 Jan 1900
let dateToDays (date:Date) =
    let daysBeforeYearStart = (date.Year - 1) * 365 + (date.Year - 1) / 4 - (date.Year - 1) / 100 + (date.Year - 1) / 400
    let daysInMonths = [ for m in 1..(date.Month - 1) -> daysInMonth date.Year m ] |> List.sum
    daysBeforeYearStart + daysInMonths + date.Day

// Function to get the next date
let getNextDate date =
    let daysInCurrentMonth = daysInMonth date.Year date.Month
    if date.Day < daysInCurrentMonth then
        { Year = date.Year; Month = date.Month; Day = date.Day + 1 }
    else if date.Month = 12 then
        { Year = date.Year + 1; Month = 1; Day = 1 }
    else
        { Year = date.Year; Month = date.Month + 1; Day = 1 }

// Function to check if a Date is a Sunday (returns true for Sunday)
let isSunday date =
    let days = dateToDays date
    (days % 7) = 0

// Function to count Sundays on the first of the month between two dates (inclusive)
let rec countSundaysOnFirstOfMonths date endDate count =
    if date.Year > endDate.Year ||
       (date.Year = endDate.Year && date.Month > endDate.Month) ||
       (date.Year = endDate.Year && date.Month = endDate.Month && date.Day > endDate.Day) then
        count
    else
        let nextDate = getNextDate date
        if date.Day = 1 && isSunday date then
            countSundaysOnFirstOfMonths nextDate endDate (count + 1)
        else
            countSundaysOnFirstOfMonths nextDate endDate count

// Main function to handle input and output
let main args =
    try 
        let testCaseCount = Console.ReadLine() |> int 
        for _ in 1..testCaseCount do
            let line1 = Console.ReadLine().Split([|' '|]) |> Array.map int
            let line2 = Console.ReadLine().Split([|' '|]) |> Array.map int
            let startYear = line1.[0]
            let startMonth = line1.[1]
            let startDay = line1.[2]
            let endYear = line2.[0]
            let endMonth = line2.[1]
            let endDay = line2.[2]

            let startDate = { Year = startYear; Month = startMonth; Day = startDay }
            // if startDate.Day <> 1 then 
            //     startDate = getNextDate startDate
            if startDate.Day <> 1 then getNextDate startDate else startDate

            let endDate = { Year = endYear; Month = endMonth; Day = endDay }
            
            // Calculate number of Sundays on the first of the month
            let result = countSundaysOnFirstOfMonths startDate endDate 0
            printfn "%d" result

    with 
    | :? System.FormatException -> printfn "Formatting error has occurred"
    | :? System.IO.IOException -> printfn "An IO exception occurred"
    | _ -> printfn "An error occurred"

main [||]
