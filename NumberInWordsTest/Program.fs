namespace NumberInWordsTest
module Test =
    open System
    open NumberInWords.Translator

    [<EntryPoint>]
    let main (args : string[]) =
        printfn "%A" (fromNumber 1150569874)
        System.Console.ReadKey() |> ignore
        0