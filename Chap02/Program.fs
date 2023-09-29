
open System

open Common

do
    title "Exercise 1"

    let mutable total = 0
    let mutable greater = 0

    for i = 1 to 6 do
        for j = 1 to 6 do
            total <- total + 1
            if i + j > 7 then
                greater <- greater + 1
    printfn $"Probability is %d{greater} / %d{total} = %g{float greater / float total}"

do
    title "Exercise 2"

    let mutable total = 0
    let mutable greater = 0

    for i = 1 to 6 do
        for j = 1 to 6 do
            for k = 1 to 6 do
                total <- total + 1
                if i + j + k > 7 then
                    greater <- greater + 1
    printfn $"Probability is %d{greater} / %d{total} = %g{float greater / float total}"

do
    title "Exercise 3"

    // Pay 30 if Sox lose.
    // Get 5 if Sox win.
    // What is P(Sox win)?
    // Since 30 / 5 = 6 we believe that P(Sox win) is 6 times bigger than P(Sox lose).
    // P(Sox win) = 6 * (1 - P(Sox win))
    printfn "P(Sox win) = 6 / 7"
