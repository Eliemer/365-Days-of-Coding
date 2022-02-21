namespace Tests

open Expecto
open Day_4

module Day_4_tests =
    

    [<Tests>]
    let tests = testList "Find the missing integer" [
    
        testCase "Trivial Example" <|
            fun () ->
                Expect.equal (findMissingInRange [3;4;-1;1]) 2 "Failed Trivial Example"

        testCase "May contain duplicates" <|
            fun () ->
                Expect.equal (findMissingInRange [3;3;3;3;4;-1;1]) 2 "Failed to handle duplicate entries"

        testCase "Must return first POSITIVE integer" <| 
            fun () ->
                Expect.equal (findMissingInRange [-10;-9;-8;-6]) 0 "Failed to handle negative numbers"
    ]
