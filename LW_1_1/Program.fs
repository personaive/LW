open System

let rec readLengths strings =
    if strings <= 0 then 
        []
    else
        let line = 
            Console.ReadLine()

        line.Length :: readLengths (strings - 1) // добавляем длину строки в список и вызываем функцию для n - 1

[<EntryPoint>]
let main argv =

    printfn "Введите количество строк:" 
    let count = int (Console.ReadLine())

    printfn "Введите строки:"
    let lengths = readLengths count

    printfn "%A" lengths

    0