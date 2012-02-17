// Learn more about F# at http://fsharp.net

namespace NumberInWords
module Translator = 
    open Helper
    open Dictionary

    let getWordsFor (value : int) =
        match value with
            | 0 -> ""
            | _ -> hundreds (valueToTriplet(value).[0]) + " " + 
                   tens (valueToTriplet(value).[1]) (valueToTriplet(value).[2]) + " " +
                   units (valueToTriplet(value).[2]) (valueToTriplet(value).[1])

    let convertDegreeToWords  (degree : int) (value : int) = 
        match degree with
            | 1 -> getWordsFor value
            | 2 -> getWordsFor value + " тысяч" + 
                   (terminationForThousands (valueToTriplet(value).[1]) (valueToTriplet(value).[2]))
            | 3 -> getWordsFor value + " миллион" + 
                   (terminationForMillions (valueToTriplet(value).[1]) (valueToTriplet(value).[2]))
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

