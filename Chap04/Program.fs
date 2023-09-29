
open System

open FSharp.Stats.Distributions
open Plotly.NET

open Common

do
    title "12 heads in 24 coin tosses"

    printfn "Probability is %g" (Discrete.Binomial.PMF 0.5 24 12)

do
    title "10 coin tosses plot"

    let file = "plot-10-coin-tosses.html"
    Chart.Column(seq { for k in 0 .. 10 -> k, Discrete.Binomial.PMF 0.5 10 k })
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "10 dice rolls plot"

    let file = "plot-10-dice-rolls.html"
    Chart.Column(seq { for k in 0 .. 10 -> k, Discrete.Binomial.PMF (1. / 6.) 10 k })
    |> Chart.saveHtml file
    printfn "See file %s" file

do
    title "Gacha game"

    let pDesiredCard = 0.0072
    printfn "Pulling 100 card there's %g probability to pull at least one desired card"
        (1. - Discrete.Binomial.PMF pDesiredCard 100 0)

do
    title "Exercise 1"

    printfn "Parameters are p = 0.1, n = 12, k = 1"

do
    title "Exercise 2"

    printfn "In 5 pulls we can pull exactly 1 ace in 5 possible ways"
    printfn "(either on the first pull or on the second pull or ...)"

do
    title "Exercise 3"

    let pAce = 4. / 52.
    printfn "Pulling exactly 5 aces in 10 pulls has probability %g" (Discrete.Binomial.PMF pAce 10 5)

do
    title "Exercise 4"

    let pJobOffer = 1. / 5.
    printfn "Getting at least 2 job offers in 7 interviews has probability %g"
        (1. - Discrete.Binomial.CDF pJobOffer 7 1.)  // We don't get 0 and 1 job offer.
    printfn "or without CDF %g"
        (1. - Discrete.Binomial.PMF pJobOffer 7 0 - Discrete.Binomial.PMF pJobOffer 7 1)

do
    title "Exercise 5"

    let pJobOffer = 1. / 10.
    printfn "Getting at least 2 job offers in 25 interviews has probability %g"
        (1. - Discrete.Binomial.CDF pJobOffer 25 1.)  // We don't get 0 and 1 job offer.
