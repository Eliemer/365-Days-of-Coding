module Day_8


type BinaryNode<'T> = {
    Left: BinaryTree<'T>
    Right: BinaryTree<'T>
    Value: 'T
}

and BinaryTree<'T> =
    | Leaf of 'T
    | Node of BinaryNode<'T>

type private UnivalResult = { Count : int; IsUnival : bool }

let countUnivalSubtress (tree: BinaryTree<'T>) : int =

    let rec loop = function
        | Leaf l -> {Count = 1; IsUnival = true}
        | Node node ->
            let left = loop node.Left
            let right = loop node.Right
            match node.Left, node.Right with
            | Leaf l, Leaf r ->
                if (l = r && l = node.Value) then
                    {Count = 1 + right.Count + left.Count; IsUnival = true}
                else
                    {Count = right.Count + left.Count; IsUnival = false}

            | Node l, Leaf r ->
                if l.Value = r && r = node.Value && left.IsUnival then
                    {Count = 1 + right.Count + left.Count; IsUnival = true}
                else
                    {Count = right.Count + left.Count; IsUnival = false}

            | Leaf l, Node r ->
                if l = r.Value && r.Value = node.Value && right.IsUnival then
                    {Count = 1 + right.Count + left.Count; IsUnival = true}
                else
                    {Count = right.Count + left.Count; IsUnival = false}

            | Node l, Node r ->
                if l.Value = r.Value && r.Value = node.Value && left.IsUnival && right.IsUnival then
                    {Count = 1 + right.Count + left.Count; IsUnival = true}
                else
                    {Count = right.Count + left.Count; IsUnival = false}
        
    let res = loop tree
    res.Count