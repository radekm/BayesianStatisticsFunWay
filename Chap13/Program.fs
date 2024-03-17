
open System

open FSharp.Stats.Distributions
open Plotly.NET

open Common

/// `InvCDF` for beta distribution is currently not implemented.
/// So we implemented simple version.
let approxInvCdfForBeta alpha beta desiredValue =
    let step = 0.00001
    let mutable bestP = 0.0
    let mutable bestDist = abs (desiredValue - Continuous.Beta.CDF alpha beta bestP)

    let mutable p = step
    while p <= 1 do
        let dist = abs (desiredValue - Continuous.Beta.CDF alpha beta p)
        if dist < bestDist then
            bestP <- p
            bestDist <- dist
        p <- p + step

    bestP

do
    title "Exercise 1"

    let alpha = 300.
    let beta = 40_000. - alpha

    let file = "plot-of-cdf.html"
    seq { 0 .. 400 }
    |> Seq.map (fun x ->
        let p = float x / 400. * 0.02  // Show probabilities 0 .. 0.02.
        p, Continuous.Beta.CDF alpha beta p)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

    let file = "plot-of-quantile-function.html"
    seq { 0 .. 400 }
    |> Seq.map (fun x ->
        let p = float x / 400.
        p, approxInvCdfForBeta alpha beta p)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "Exercise 2"

    let measurements = [7.8; 9.4; 10.; 7.9; 9.4; 7.; 7.; 7.1; 8.9; 7.4]
    let mu = FSharp.Stats.Seq.mean measurements
    let sigma = FSharp.Stats.Seq.stDev measurements

    let invCdf = Continuous.Normal.InvCDF mu sigma
    printfn "99 %% confidence interval is %g %g"
        (invCdf 0.0005) (invCdf 0.9995)

do
    title "Exercise 3"

    let alpha = 10
    let beta = 30 - alpha
    let invCdf = approxInvCdfForBeta alpha beta
    printfn "95 %% confidence interval for candies sold in next 40 houses: %g %g"
        (40. * invCdf 0.025) (40. * invCdf 0.975)
