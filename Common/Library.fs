module Common

open System

let title (text : string) =
    let sep = String('-', 60)
    printfn $"\n%s{sep}"
    printfn $"---- %s{text}"
    printfn $"%s{sep}\n"
