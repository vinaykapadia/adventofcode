original source: [https://adventofcode.com/2017/day/21](https://adventofcode.com/2017/day/21)
## --- Day 21: Fractal Art ---
You find a program trying to generate some art. It uses a strange process that involves repeatedly enhancing the detail of an image through a set of rules.

The image consists of a two-dimensional square grid of pixels that are either on (<code>#</code>) or off (<code>.</code>). The program always begins with this pattern:

<pre>
<code>.#.
..#
###
</code>
</pre>

Because the pattern is both <code>3</code> pixels wide and <code>3</code> pixels tall, it is said to have a <em>size</em> of <code>3</code>.

Then, the program repeats the following process:


 - If the size is evenly divisible by <code>2</code>, break the pixels up into <code>2x2</code> squares, and convert each <code>2x2</code> square into a <code>3x3</code> square by following the corresponding <em>enhancement rule</em>.
 - Otherwise, the size is evenly divisible by <code>3</code>; break the pixels up into <code>3x3</code> squares, and convert each <code>3x3</code> square into a <code>4x4</code> square by following the corresponding <em>enhancement rule</em>.

Because each square of pixels is replaced by a larger one, the image gains pixels and so its <em>size</em> increases.

The artist's book of enhancement rules is nearby (your puzzle input); however, it seems to be missing rules.  The artist explains that sometimes, one must <em>rotate</em> or <em>flip</em> the input pattern to find a match. (Never rotate or flip the output pattern, though.) Each pattern is written concisely: rows are listed as single units, ordered top-down, and separated by slashes. For example, the following rules correspond to the adjacent patterns:

<pre>
<code>../.#  =  ..
          .#

                .#.
.#./..#/###  =  ..#
                ###

                        #..#
#..#/..../#..#/.##.  =  ....
                        #..#
                        .##.
</code>
</pre>

When searching for a rule to use, rotate and flip the pattern as necessary.  For example, all of the following patterns match the same rule:

<pre>
<code>.#.   .#.   #..   ###
..#   #..   #.#   ..#
###   ###   ##.   .#.
</code>
</pre>

Suppose the book contained the following two rules:

<pre>
<code>../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#
</code>
</pre>

As before, the program begins with this pattern:

<pre>
<code>.#.
..#
###
</code>
</pre>

The size of the grid (<code>3</code>) is not divisible by <code>2</code>, but it is divisible by <code>3</code>. It divides evenly into a single square; the square matches the second rule, which produces:

<pre>
<code>#..#
....
....
#..#
</code>
</pre>

The size of this enhanced grid (<code>4</code>) is evenly divisible by <code>2</code>, so that rule is used. It divides evenly into four squares:

<pre>
<code>#.|.#
..|..
--+--
..|..
#.|.#
</code>
</pre>

Each of these squares matches the same rule (<code>../.# => ##./#../...</code>), three of which require some flipping and rotation to line up with the rule. The output for the rule is the same in all four cases:

<pre>
<code>##.|##.
#..|#..
...|...
---+---
##.|##.
#..|#..
...|...
</code>
</pre>

Finally, the squares are joined into a new grid:

<pre>
<code>##.##.
#..#..
......
##.##.
#..#..
......
</code>
</pre>

Thus, after <code>2</code> iterations, the grid contains <code>12</code> pixels that are <em>on</em>.

<em>How many pixels stay on</em> after <code>5</code> iterations?


