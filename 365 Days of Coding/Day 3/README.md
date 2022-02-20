# Problem Statement
### Difficulty: `Medium`

Given the root of a binary tree, implement `serialize(root)` which serializes the tree into a string, and `deserialize(s)`, which deserializes the string back into the tree

# Example

Given the following `Node` class

```py
class Node:
	def __init__(self, val, left=None, right=None):
		self.val = val
		self.left = left
		self.right = right
```
The following test should pass:

```py
node = Node('root', Node('left', Node('left.left')), Node('right'))

assert deserialize(serialize(node)).left.left.val = "left.left"
```