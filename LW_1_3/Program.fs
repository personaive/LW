open System 

let add (aRe, aIm) (bRe, bIm) =
    (aRe + bRe, aIm + bIm) // сложения: (a+bi) + (c+di) = (a+c) + (b+d)i

let subtract (aRe, aIm) (bRe, bIm) =
    (aRe - bRe, aIm - bIm) // вычитания: (a+bi) - (c+di) = (a-c) + (b-d)i

let multiply (aRe, aIm) (bRe, bIm) =
    (aRe * bRe - aIm * bIm, aRe * bIm + aIm * bRe) // умножения: (a+bi)*(c+di) = (ac-bd) + (ad+bc)i

let divide (aRe, aIm) (bRe, bIm) =                                      
    let denom = bRe * bRe + bIm * bIm // знаменатель: c^2 + d^2
    ((aRe * bRe + aIm * bIm) / denom, // действительная: (ac+bd)/(c^2+d^2)
     (aIm * bRe - aRe * bIm) / denom) // мнимая: (bc-ad)/(c^2+d^2)

let rec power (re, im) n =
    if n = 0 then 
        (1.0, 0.0)
    elif n = 1 then 
        (re, im)
    else
        let (pr, pi) = 
            power (re, im) (n - 1)
        (re * pr - im * pi, // действительная часть: re*prevRe - im*prevIm
         re * pi + im * pr) // мнимая часть: re*prevIm + im*prevRe

[<EntryPoint>]
let main argv =

    printfn "Введите Re1:"
    let aRe =
        float (Console.ReadLine())

    printfn "Введите Im1:"
    let aIm =
        float (Console.ReadLine())

    printfn "Введите Re2:"
    let bRe =
        float (Console.ReadLine())

    printfn "Введите Im2:"
    let bIm =
        float (Console.ReadLine())

    printfn "Выберите операцию:"
    printfn "1 - Сложение"
    printfn "2 - Вычитание"
    printfn "3 - Умножение"
    printfn "4 - Деление"
    printfn "5 - Возведение первого числа в степень"

    let choice =
        int (Console.ReadLine())

    let result =
        match choice with
        | 1 -> add (aRe, aIm) (bRe, bIm)
        | 2 -> subtract (aRe, aIm) (bRe, bIm)
        | 3 -> multiply (aRe, aIm) (bRe, bIm)
        | 4 -> divide (aRe, aIm) (bRe, bIm)
        | 5 -> 
            printfn "Введите степень:"
            let n = 
                int (Console.ReadLine())

            power (aRe, aIm) n
        | _ -> (0.0, 0.0)

    let (resRe, resIm) =
        result

    if resIm >= 0.0 then
        printfn "Результат: %f + %fi" resRe resIm
    else
        printfn "Результат: %f - %fi" resRe (abs resIm)

    0