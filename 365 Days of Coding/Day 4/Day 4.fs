module Day_4

let sumOfRange min max =
    let high = max * (max + 1)
    let low = min * (min - 1)

    (high - low) / 2

let findMissingInRange xs =
    let ys = List.filter ((<) 0) xs 
    match ys with
    | [] -> 0
    | h :: t -> 
        let zs = List.distinct ys
        let min = List.min zs
        let max = List.max zs

        (List.reduce (+) zs)
        |> (-) (sumOfRange min max)
    