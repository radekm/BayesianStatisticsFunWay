
open System

open FSharp.Stats.Distributions

open Common

// Without Bessel's correction.
// So the results are closer to answers in the book.
let stDev (numbers : list<float>) =
    let mu = FSharp.Stats.List.mean numbers
    numbers
    |> List.map (fun n -> Math.Pow(n - mu, 2))
    |> FSharp.Stats.List.mean
    |> Math.Sqrt

do
    title "Exercise 1"

    // Probability observing value bigger than five sigma.
    printfn "Probability is %g" (1. - Continuous.Normal.CDF 0 1 5)

do
    title "Exercise 2"

    let measurements = [100.; 99.8; 101.; 100.5; 99.7]
    let mu = FSharp.Stats.Seq.mean measurements
    let sigma = stDev measurements
    // Fever is any temperature greater than 100.4 degrees of Fahrenheit.
    // What is probability of fever?
    printfn $"Mean %g{mu}, standard deviation %g{sigma}."
    printfn "Probability that patient has fever is %g" (1. - Continuous.Normal.CDF mu sigma 100.4)

do
    title "Exercise 3"

    let measurements = [2.5; 3.; 3.5; 4; 2]
    let mu = FSharp.Stats.Seq.mean measurements
    let sigma = stDev measurements
    // If well is 500 meters deep or more then the duration of the fall would be:
    let g = 9.8
    let distance = 500.
    let duration = Math.Sqrt(2. * distance / g)
    printfn $"Mean %g{mu}, standard deviation %g{sigma}, duration %g{duration}."
    printfn "Probability that well is over %g meters deep is %g"
        distance (1. - Continuous.Normal.CDF mu sigma duration)

    title "Exercise 4"

    let distance = 0.
    let duration = Math.Sqrt(2. * distance / g)
    printfn $"Mean %g{mu}, standard deviation %g{sigma}, duration %g{duration}."
    printfn "Probability that there is no well is %g" (Continuous.Normal.CDF mu sigma duration)
