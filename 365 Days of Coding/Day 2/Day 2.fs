module Day_2

let inline productOfAllOtherIndices (xs : ^a list) : ^a list =

    let rec loop acc res = function
        | [] -> List.rev res
        | [x] -> List.rev (acc :: res)
        | x :: y :: ys ->
            let term = (acc * List.reduce (*) (y::ys))
            loop (acc * x) (term :: res) (y::ys)

    match xs with 
    | [] -> []
    | h :: t ->
        loop LanguagePrimitives.GenericOne [] (h::t)

let inline productOfAllOtherIndicesImperative (xs : ^a list) : ^a list =

    [ for i, x in List.indexed xs do
        List.fold (*) LanguagePrimitives.GenericOne (List.removeAt i xs) ]

// fails for lists containing zero
let inline productOfAllOtherIndicesSimple (xs : ^a list) : ^a list =

    let total = List.fold (*) LanguagePrimitives.GenericOne xs
    List.map (fun x -> total / x) xs 