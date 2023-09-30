
open System

open Common

do
    title "Exercise 1"

    printfn "P(vaccine | gbs) = P(gbs | vaccine) p(vaccine) / P(gbs)"

do
    title "Exercise 2"

    printfn "P(female, not color blind) = P(not color blind | female) P(female) ="
    printfn $"  = (1 - P(color blind | female)) P(female) = (1 - 0.005) * 0.5 = %g{0.995 * 0.5}"

do
    title "Exercise 3"

    printfn "P(color blind or gbs | vaccine, male) ="
    printfn "  = P(color blind | male) + P(gbs | vaccine) - P(color blind | male) * P(gbs | vaccine) ="
    printfn $"  = %g{0.08 + 3. / 100_000. - 0.08 * 3. / 100_000.}"
