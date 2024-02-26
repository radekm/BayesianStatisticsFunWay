
open System

open Common

do
    title "Exercise 1"

    printfn "When most observations have small distance from the mean but few have huge distance."

do
    title "Exercise 2"

    let nums = [1..10] |> List.map float
    let mean = nums |> List.average
    let var = (nums |> List.sumBy (fun n -> Math.Pow(mean - n, 2))) / float nums.Length
    let stdDev = Math.Sqrt var
    printfn $"Mean is %f{mean}, variance is %f{var}, standard deviation is %f{stdDev}"
