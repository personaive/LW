open System

printfn "Введите Re1:"
let aRe =
    float (Console.ReadLine()) // a

printfn "Введите Im1:"
let aIm =
    float (Console.ReadLine()) // b

printfn "Введите Re2:"
let bRe =
    float (Console.ReadLine()) // c

printfn "Введите Im2:"
let bIm = 
    float (Console.ReadLine()) // d

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
    | 1 -> (aRe + bRe, aIm + bIm)                       // (a + bi) + (c + di)  
    | 2 -> (aRe - bRe, aIm - bIm)                       // (a + bi) - (c + di)
    | 3 -> (aRe*bRe - aIm*bIm, aRe*bIm + aIm*bRe)       // (ac - bd) + (ad + bc)i
    | 4 ->
        let denom = bRe*bRe + bIm*bIm                   // знаменатель: c^2 + d^2
        ((aRe*bRe + aIm*bIm)/denom,                     // действительная часть: (ac + bd) / (c^2 + d^2)
         (aIm*bRe - aRe*bIm)/denom)                     // мнимая часть: (bc − ad) / (c^2 + d^2)
    | 5 ->
        printfn "Введите степень:"
        let n = 
            int (Console.ReadLine())

        let rec power (re, im) n =
            if n = 0 then 
                (1.0, 0.0)     // любое число в степени 0 = 1

            elif n = 1 then 
                (re, im)       // в степени 1 = само число

            else
                let (pr, pi) = 
                    power (re, im) (n - 1)   // вызываем функцию для степени n - 1
                (re*pr - im*pi,              // (re, im) — исходное число
                 re*pi + im*pr)              // (pr, pi) — результат предыдущей степени

        power (aRe, aIm) n                   // вызываем функцию для первого числа
    | _ -> (0.0, 0.0)

let (resRe, resIm) = result

if resIm >= 0.0 then
    printfn "Результат: %f + %fi" resRe resIm

else
    printfn "Результат: %f - %fi" resRe (abs resIm)