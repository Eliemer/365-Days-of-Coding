module Day_7

let countDecodes (xs : string) : int =

    let rec loop acc = function
        | [] | [_] -> acc
        | '1' :: y :: t -> loop (acc + 1) (y::t)
        | '2' :: y :: t ->
            if "0123456".Contains y then
                loop (acc + 1) (y::t)
            else
                loop acc (y::t)
        | _ :: y :: t -> loop acc (y::t)

    loop 1 <| Seq.toList xs