
open System

open FSharp.Stats.Distributions
open Plotly.NET

open Common


do
    title "Comparing binomial distributions"

    let file = "plot-comparing-binomial-distributions.html"

    seq { 0 .. 100 }
    |> Seq.map (fun x ->
        let p = float x / 100.
        p, Discrete.Binomial.PMF p 41 14)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "Beta distribution"

    let file = "plot-beta-distribution.html"

    seq { 0 .. 100 }
    |> Seq.map (fun x ->
        let p = float x / 100.
        p, Continuous.Beta.PDF 14 27 p)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "Beta distribution CDF"

    printfn "Probability that mysterious box returns two coins with probability less than 1/2 is %g"
        (Continuous.Beta.CDF 14 27 0.5)

do
    title "Gacha game"

    printfn "Probability that chance of pulling desire card is bigger than 0.005: %g"
        (1. - Continuous.Beta.CDF 5 1195 0.005)

do
    title "Exercise 1"

    // 4 heads, 6 tails.
    // Probability that coin will land on heads more than 60 % of the time?
    printfn "Probability is %g" (1. - Continuous.Beta.CDF 4 6 0.6)

do
    title "Exercise 2"

    // 9 heads, 11 tails.
    // Probability that coin is fair (ie. p is between 0.45 and 0.55)?
    printfn "Probability is %g" (Continuous.Beta.CDF 9 11 0.55 - Continuous.Beta.CDF 9 11 0.45)

do
    title "Exercise 3"

    // 109 heads, 111 tails.
    // Probability that coin is fair (ie. p is between 0.45 and 0.55)?
    printfn "Probability is %g" (Continuous.Beta.CDF 109 111 0.55 - Continuous.Beta.CDF 109 111 0.45)
