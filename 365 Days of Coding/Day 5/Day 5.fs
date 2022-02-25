module Day_5

let cons (a, b) =
    fun f -> f (a, b)

let car (g : ('a * 'b -> 'a) -> 'a) : 'a =
    g (fun (x, _) -> x)

let cdr (g: ('a * 'b -> 'b) -> 'b) : 'b =
    g (fun (_, y) -> y)
