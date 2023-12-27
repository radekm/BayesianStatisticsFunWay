
open System

open Common

do
    title "Exercise 1"

    // H1 = robbed,
    // H2 = window broken by baseball & door left unlocked & forgot laptop at work,
    // D = broken window & open front door & missing laptop.
    // P(D | H1) = 3/100.
    // P(D | H2) = 1.
    // P(H1) = 1/1000.
    // P(H2) = 1/21900000.

    let unnormalizedPosteriorH1 = 1./1000. * 3. / 100.
    let unnormalizedPosteriorH2 = 1./21_900_000. * 1.
    printfn "P(H1 | D) / P(H2 | D) ="
    printfn $"  = %g{unnormalizedPosteriorH1}/%g{unnormalizedPosteriorH2} ="
    printfn $"  = %g{unnormalizedPosteriorH1 / unnormalizedPosteriorH2}"

do
    title "Exercise 2"

    // H1 = robbed,
    // H2 = window broken by baseball & door left unlocked & forgot laptop at work,
    // D = broken window & open front door & missing laptop.
    // P(D | H1) = 3/100.
    // P(D | H2) = 1.
    // P(H1) = ?.
    // P(H2) = 1/21900000.
    // P(H1) * P(D | H1) / P(H2) / P(D | H2) = 1.
    // P(H1) = P(H2) * P(D | H2) / P(D | H1).

    printfn $"P(H1) = %g{1. / 21_900_000. * 1. / 3. * 100.}"
