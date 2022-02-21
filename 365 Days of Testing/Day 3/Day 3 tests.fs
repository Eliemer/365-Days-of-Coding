namespace Tests

open Expecto
open Day_3
open BinaryTreeGenerator

module Day_3_tests =

    let config = { FsCheckConfig.defaultConfig with
                    arbitrary = [typeof<Generator>]}

    [<Tests>]
    let tests = ptestList "Serialization of Binary Trees" [
    
        testCase "Trivial Example" <| 
            fun () ->
                let tree = Branches (Value=1, 
                                    Left=Branches 
                                        (Value=2, 
                                        Left=Branches 
                                            (Value=3,
                                            Left=Leaf, 
                                            Right=Leaf), 
                                        Right=Leaf), 
                                    Right=Branches 
                                        (Value=4, 
                                        Left=Leaf, 
                                        Right=Leaf))
                
                Expect.equal (BinaryTree.serialize tree) "1(2(3(;););4(;))" "Failed trivial example" 
    
        testCase "Empty Tree" <|
            fun () ->
                Expect.equal (BinaryTree.serialize Leaf) "" "Empty tree must result in empty string"


        testCase "Singleton Tree" <|
            fun () ->
                Expect.equal (BinaryTree.serialize <| Branches(0, Leaf, Leaf)) "0(;)" "Failed Singleton Tree"

        testPropertyWithConfig config "Away and back again. Proof of inversibility" <|
            fun (tree : BinaryTree) ->
                BinaryTree.serialize tree
                |> BinaryTree.deserialize
                |> (=) tree

    ]
