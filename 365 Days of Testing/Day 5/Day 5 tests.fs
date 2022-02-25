namespace Tests

open Expecto
open Day_5

module Day_5_tests =
    
    [<Tests>]
    let tests = testList "Cons, car, and cdr" [
    
        testCase "Trivial Example" <|
            fun () ->
                Expect.equal (car(cons(3, 4))) 3 "Failed 'car' Trivial Example"
                Expect.equal (cdr(cons(3, 4))) 4 "Failed 'cdr' Trivial Example"

        testProperty "car represents the first element" <|
            fun n m ->
                cons (n, m) 
                |> car
                |> (=) n

        testProperty "cdr represents the second element" <|
            fun n m ->
                cons (n, m) 
                |> cdr
                |> (=) m



    ]

