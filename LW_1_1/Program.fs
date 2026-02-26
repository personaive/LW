open System

let rec сheckForNumber () =
    printfn "Введите количество строк:"
    let input = Console.ReadLine()
    let (isNumber, count) = Int32.TryParse input

    if not isNumber then
        printfn "Ошибка: введите число!"
        сheckForNumber()

    elif count <= 0 then
        printfn "Ошибка: число не должно быть отрицательным!"
        сheckForNumber()

    else
        count

let count = сheckForNumber()

printfn "Введите строки:"
let lines = 
    [ for _ in 1 .. count -> Console.ReadLine() ]

let lengths =
    lines |> List.map String.length

printfn "Список длин строк: %A" lengths