# Problem Statement
### Difficulty: `Easy`
A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.

Given the root to a binary tree, count the number of unival subtrees.

# Example
The following tree has 5 unival subtrees:
```
	0
   / \
  1   0
     / \
	1   0
   / \
  1   1
```
| Subtree's root | 
| --- |
| `left` |
| `right.left` |
| `right.left.left` | 
| `right.left.right`  |
| `right.right` |