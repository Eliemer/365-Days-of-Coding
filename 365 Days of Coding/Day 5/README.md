# Problem Statement
### Difficulty: `Medium`

`cons(a, b)` constructs a pair, and `car(pair)` and `cdr(pair)` returns the first and last element of that pair, respectively.

Given this implementation of `cons`:

```py
def cons(a, b):
	def pair(f):
		return f(a, b)
	return pair
```
implement `car` and `cdr`

# Example

`car(cons(3, 4))` returns 3,
and `cdr(cons(3, 4))` returns 4.
