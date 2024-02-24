
open System

open FSharp.Stats.Distributions
open Plotly.NET

open Common

do
    // Why is this called likelihood?
    // In the previous chapter likelihood was defined as P(data | belief).
    // What's data and what's belief?
    // Is belief than Han survives with chance 20000 to 1?
    // Is this chance reflected in likelihood P(data | belief)?
    title "C-PO's likelihood of surviving"

    let file = "plot-of-han-survival-according-to-c3po.html"

    seq { 0 .. 400 }
    |> Seq.map (fun x ->
        let p = float x / 400. * 0.003  // Show probabilities 0 .. 0.003.
        // It's interesting that graph looks differently for α=1 β=3720
        // than for α=2 β=7440.
        p, Continuous.Beta.PDF 2 7440 p)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    // Why is this called prior?
    // In the previous chapter prior was defined as P(belief).
    title "Prior belief of Han survival"

    let file = "plot-of-han-survival-prior.html"

    seq { 0 .. 400 }
    |> Seq.map (fun x ->
        let p = float x / 400. * (1. - 0.999) + 0.999  // Show probabilities 0.999 .. 1.
        p, Continuous.Beta.PDF 20_000 1 p)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "Combining our belief (prior) and belief of C-3PO (likelihood) into posterior"

    let file = "plot-of-han-survival-posterior.html"

    seq { 0 .. 400 }
    |> Seq.map (fun x ->
        let p = float x / 400. * (0.8 - 0.6) + 0.6  // Show probabilities 0.6 .. 0.8.
        p, Continuous.Beta.PDF (20_000. + 2.) (1. + 7440.) p)
    |> fun xy -> Chart.Point(xy)
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "Exercise 1"

    // 6 heads, 1 tails.
    // Probability that rate of flipping heads is between 0.4 and 0.6.
    let heads = 6
    let tails = 1
    printfn "Probability is %g" (Continuous.Beta.CDF heads tails 0.6 - Continuous.Beta.CDF heads tails 0.4)

do
    title "Exercise 2"

    // Find prior distribution that coin is fair.
    // Ie. distribution where rate of flipping heads is between 0.4 and 0.6
    // with probability at least 0.95.

    // In the solution they add 6 and 1 to heads and tails. Why? With Han solo we don't add that.
    let heads = 50
    let tails = 50  // I found it experimentally.
    printfn "Probability is %g" (Continuous.Beta.CDF heads tails 0.6 - Continuous.Beta.CDF heads tails 0.4)

do
    title "Exercise 3"

    // How many heads shall we add to the numbers from Exercise 2 to convince us
    // that coin is not fair. Ie. probability drops below 0.5.

    // Again in the solution they add 6 and 1 to heads and tails.
    let heads = 75  // 25 additional heads - I found it experimentally.
    let tails = 50
    printfn "Probability is %g" (Continuous.Beta.CDF heads tails 0.6 - Continuous.Beta.CDF heads tails 0.4)
