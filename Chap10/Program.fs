
open System

open Common

do
    title "Exercise 1"

    printfn "Thermometer is showing lower temperatures than actual."

do
    title "Exercise 2"

    let normal = 98.6
    let myAverage = (97.5 + 98.) / 2.
    let childAverage = (100. + 99.5 + 99.6 + 100.2) / 4.
    printfn $"Because I believe I have normal temperature and thermometer showed on average %f{myAverage}"
    printfn $"which is %f{normal - myAverage} lower than normal then we have to adjust child average %f{childAverage}"
    printfn $"by the same amount which gives %f{childAverage + normal - myAverage}"
