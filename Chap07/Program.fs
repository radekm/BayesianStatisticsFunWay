
open System

open Common

do
    title "Exercise 1"

    // Kansas state has 105 counties.
    // Missouri state has 114 counties.
    // Kansas City metropolitan area has 15 counties, 9 in Missouri and 6 in Kansas.
    // P(Kansas state | Kansas City metropolitan area) = ?

    printfn "P(Kansas state | Kansas City metropolitan area) = "
    printfn "  = P(Kansas City metropolitan area | Kansas state) * P(Kansas state) / P(Kansas City metropolitan area) ="
    printfn $"  = %g{(6. / 105.) * (105. / (105. + 114.)) / ((9. + 6.) / (105. + 114.))}"
    printfn $"or simply %g{6. / 15.}"

do
    title "Exercise 2"

    // 52 cards in a deck (26 red, 26 black).
    // 4 aces in a deck (2 red, 2 black).
    // After removing red ace and pulling black card what is the probability the ace was pulled?
    // P(pulled ace | red ace removed, pulled black card) = ?

    printfn "P(pulled ace | red ace removed, pulled black card) = "
    printfn "  = P(pulled black card | red ace removed, pulled ace) * P(pulled ace | red ace removed) /"
    printfn "    / P(pulled black card | red ace removed) ="
    printfn $"  = %g{(2. / 3.) * (3. / 51.) / (26. / 51.)}"
    printfn $"or simply %g{2. / 26.}"
