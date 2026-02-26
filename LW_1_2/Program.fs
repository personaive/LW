open System

let rec checkNaturalNumber () =
    printfn "Введите натуральное число:"
    let input = Console.ReadLine()
    let (success, number) = Int32.TryParse input

    if not success || number <= 0 then
        printfn "Ошибка: введите натуральное число!"
        checkNaturalNumber()

    else
        number

let userNumber = 
    checkNaturalNumber()

let numberAsString = 
    string userNumber

let digitsList = 
    [ for c in numberAsString -> int c - int '0' ]  // каждый символ превращается в цифру

let evenDigits = 
    [ for d in digitsList do
        if d % 2 = 0 then
            yield d ]

let sumEvenDigits = List.sum evenDigits
printfn "Сумма чётных цифр числа: %d" sumEvenDigits