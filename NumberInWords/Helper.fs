namespace NumberInWords

module Helper =
    let getFractionalPart (number : int) (divider : int) =
        match number with
            | 0 -> 0
            | _ when divider <> 0 -> number - number / divider * divider
            | _ -> 0

    let getIntegralPart (number : int) (divider : int) =
        number - (getFractionalPart number divider)

    let valueToTriplet (value : int) =
        (String.replicate ((3 - string(value).Length % 3) % 3) "0") + string(value)