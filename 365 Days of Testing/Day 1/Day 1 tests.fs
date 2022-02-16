module Day_1_tests

open Expecto
open Day_1

let config = { FsCheckConfig.defaultConfig with 
                 maxTest = 100; }

[<Tests>]
let tests =
    testList "Day One Tests" [
        
        testCase "Trivial Example" <|
            fun () ->
                Expect.isTrue (containsSumInAnyPair 4 [1;2;3]) "Trivial Success"

        testCase "Cannot repeat values to achieve sum" <|
            fun () ->
                Expect.isFalse (containsSumInAnyPair 4 [2]) "Function is repeating values"

        testPropertyWithConfig config "Empty list should always return false" <|
            fun n -> 
                false = containsSumInAnyPair n []

        testPropertyWithConfig config "List with one element must contain exactly k to return true" <|
            fun k ->
                containsSumInAnyPair k [k]

        testPropertyWithConfig config "List order does not matter" <|
            fun k xs ->
                containsSumInAnyPair k xs = containsSumInAnyPair k (List.rev xs)
    ]
