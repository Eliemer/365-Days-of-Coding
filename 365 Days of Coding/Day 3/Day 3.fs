module Day_3

open System
open FParsec

type BinaryTree =
    | Leaf
    | Branches of Value: int * Left: BinaryTree * Right: BinaryTree

module BinaryTree =

    // parser helpers
    let private manyCharsBetween popen pclose pchar = popen >>? manyCharsTill pchar pclose
    //let anyStringBetween popen pclose = manyCharsBetween popen pclose anyChar
    let private anyDigitBetween popen pclose = between popen pclose pint32
    
    // recursive parser
    let private tree, treeRef = createParserForwardedToRef()
            
    // leaf case
    let private leaf = stringReturn "" Leaf .>> spaces
    
    // branch case
    //let private value = spaces >>. skipChar '*' |> anyDigitBetween <| skipChar '*' .>> spaces
    let private value = pint32
    let private left = skipChar '(' >>. spaces >>. tree .>> spaces .>> skipChar ';' 
    let private right = spaces >>. tree .>> spaces .>> skipChar ')'
    
    let private branch : Parser<BinaryTree, unit> = tuple3 (value) (left) (right) |>> Branches
    
    // tree parser
    treeRef.Value <-
        choice [
            branch
            leaf
        ]


    let serialize (tree: BinaryTree) : string =
        
        let rec recursiveSerialize = function
            | Leaf -> ""
            | Branches (value, left, right) ->
                $"{value}({recursiveSerialize left};{recursiveSerialize right})"

        recursiveSerialize tree

    let deserialize (str : string) : BinaryTree =
        match (run tree str) with
        | Failure (err, _, _) -> failwith err
        | Success (res, _, _) -> res
