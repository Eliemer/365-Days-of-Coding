module Day_1

let containsSumInAnyPair (k: int) (xs: int list) : bool =
    
    let rec innerLoop acc x = function
        | [] -> acc
        | h :: t ->
            h + x = k || innerLoop (acc || false) x t
    
    let rec loop acc = function
        | [] -> acc
        | h::t ->
            let temp = innerLoop false h t
            temp || loop (acc || temp) t

    loop false (0::xs) // added zero to allow single elements to return true if equal to k