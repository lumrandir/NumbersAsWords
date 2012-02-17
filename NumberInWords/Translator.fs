// Learn more about F# at http://fsharp.net

namespace NumberInWords
module Translator = 
    open Helper
    
    let hundreds (c : char) =
        match c with
            | '1' -> "сто"
            | '2' -> "двести"
            | '3' -> "триста"
            | '4' -> "четыреста"
            | '5' -> "пятьсот"
            | '6' -> "шестьсот"
            | '7' -> "семьсот"
            | '8' -> "восемьсот"
            | '9' -> "девятьсот"
            | _   -> ""

    let getWordsForHundreds (value : int) =
        match value with
            | 0 -> ""
            | _ -> hundreds

        

    let convertDegreeToWords  (degree : int) (value : int) = 
        match degree with
            | 1 -> getWordsForHundreds value
            | 2 -> "тысяча"
            | 3 -> "миллион"
            | _ -> ""

    let rec convertToWordsByDegree (degree : int) (num : int) (result : string) =
        match num with
            | 0 -> result
            | _ -> convertToWordsByDegree (degree + 1) 
                                          (getIntegralPart num (int(1000.0 ** float(degree))))
                                          (convertDegreeToWords degree (getFractionalPart num (int(1000.0 ** float(degree)))) + " " + result)

    let fromNumber (num : int) = 
        match num with
            | 0 -> "ноль"
            | _ -> convertToWordsByDegree 1 num ""

