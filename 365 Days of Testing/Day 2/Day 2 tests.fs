namespace Tests

open Expecto
open Day_2

module Day_2_tests =


    [<Tests>]
    let tests =
        ptestList "Day Two Tests" [
    
            testCase "Trivial Example" <|
                fun () ->
                    Expect.equal (productOfAllOtherIndices [1..5]) [120; 60; 40; 30; 24] "Failed to produce trivial example"

            testCase "2nd Trivial Example" <|
                fun () -> 
                    Expect.equal (productOfAllOtherIndices [1..3]) [6;3;2] "Failed to produce trivial example"

            testProperty "On Empty List" <|
                fun () ->
                    productOfAllOtherIndices [] = []

            testProperty "A list with one element" <|
                fun n ->
                    productOfAllOtherIndices [n] = [1]

            testProperty "Two elements transpose" <|
                fun n m ->
                    productOfAllOtherIndices [n; m] = [m; n]

            testProperty "Mathematics of result" <|
                fun xs ->
                    let len = List.length xs
                    let folder state t =
                        state * (pown t (len-1))

                    if len > 1 then
                        List.fold folder (bigint 1) xs = List.fold (*) (bigint 1) (productOfAllOtherIndices xs)
                        
                    else
                        true
        ]

    [<Tests>]
    let testsImperative =
        ptestList "Day Two Tests (Imperative)" [

            testCase "Trivial Example" <|
                fun () ->
                    Expect.equal (productOfAllOtherIndicesImperative [1..5]) [120; 60; 40; 30; 24] "Failed to produce trivial example"

            testCase "2nd Trivial Example" <|
                fun () -> 
                    Expect.equal (productOfAllOtherIndicesImperative [1..3]) [6;3;2] "Failed to produce trivial example"

            testProperty "On Empty List" <|
                fun () ->
                    productOfAllOtherIndicesImperative [] = []

            testProperty "A list with one element" <|
                fun n ->
                    productOfAllOtherIndicesImperative [n] = [1]

            testProperty "Two elements transpose" <|
                fun n m ->
                    productOfAllOtherIndicesImperative [n; m] = [m; n]

            testProperty "Mathematics of result" <|
                fun xs ->
                    let len = List.length xs
                    let folder state t =
                        state * (pown t (len-1))

                    if len > 1 then
                        List.fold folder (bigint 1) xs = List.fold (*) (bigint 1) (productOfAllOtherIndicesImperative xs)
                    
                    else
                        true
    ]