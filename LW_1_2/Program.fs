open System

let rec sumEvenDigits n =
    if n = 0 then
        0
    else
        let digit =
            n % 10
        let rest =
            n / 10
        if digit % 2 = 0 then
            digit + sumEvenDigits rest
        else
            sumEvenDigits rest

[<EntryPoint>]
let main argv =

    printfn "Введите натуральное число:"
    let number = 
        int (Console.ReadLine())

    let result = 
        sumEvenDigits number

    printfn "Сумма чётных цифр: %d" result

    0