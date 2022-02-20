module BinaryTreeGenerator

open FsCheck
open Expecto
open Day_3

type Generator =
    static member BinaryTree () : Arbitrary<BinaryTree> =
        Arb.fromGen (gen {
            let rec tree' = function
                | 0 -> Gen.constant Leaf
                | n when n > 0 ->
                    let subtree = tree' (n/2)
                    Gen.oneof [ Gen.constant Leaf
                                Gen.map3 (fun (v) l r -> 
                                    Branches (v, l, r)) Arb.generate<int> subtree subtree]

                | _ -> invalidArg "n" "Only positive arguments are allowed"

            return! Gen.sized tree'
        })