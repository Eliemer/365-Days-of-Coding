namespace Tests

open Expecto
open FsCheck
open Day_7

module Day_7_tests =

    [<Tests>]
    let tests = testList "How many ways to decode message" [
    
        testCase "Trivial Examples" <|
            fun () ->
                Expect.equal (countDecodes "111") 3 "aaa, ak, ka"
                Expect.equal (countDecodes "141") 2 "ada, ma"
                Expect.equal (countDecodes "375") 1 "cge"

        testProperty "The sum of counts must be equal or bigger than the count of sums" <|
            fun (NonNegativeInt n, NonNegativeInt m) ->
                let x, y = string (n + 1), string (m + 1) // n, m must be greater than zero
                countDecodes x + (countDecodes y) >= countDecodes (x + y)
        
    ]