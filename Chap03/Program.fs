
open System

open Common

do
    title "Exercise 1"

    printfn "Probability is %g" <| Math.Pow(1./20., 3)

do
    title "Exercise 2"

    // P(rain) = 0.1
    // P(forget umbrella) = 0.5
    // P(rain & forget umbrella) = ?
    printfn "Probability is %g" (0.1 * 0.5)

do
    title "Exercise 3"

    let pSalmonella = 1. / 20_000.
    // P(rain) = 0.1
    // P(forget umbrella) = 0.5
    // P(rain & forget umbrella) = ?
    printfn "Probability of at least one of two eggs having salmonella %g" (2. * pSalmonella - Math.Pow(pSalmonella, 2))
    printfn "or %g" (1. - Math.Pow(1. - pSalmonella, 2))

do
    title "Exercise 4"

    // P(two heads or three sixes) = ?
    let pHeads = Math.Pow(1. / 2., 2)
    let pSix = Math.Pow(1. / 6., 3)
    printfn "Probability is %g" (pHeads + pSix - pHeads * pSix)
