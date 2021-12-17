original source: [https://adventofcode.com/2015/day/18](https://adventofcode.com/2015/day/18)
## --- Day 18: Like a GIF For Your Yard ---
After the [million lights incident](6), the fire code has gotten stricter: now, at most ten thousand lights are allowed.  You arrange them in a 100x100 grid.

Never one to let you down, Santa again mails you instructions on the ideal lighting configuration.  With so few lights, he says, you'll have to resort to <em>animation</em>.

Start by setting your lights to the included initial configuration (your puzzle input).  A <code>#</code> means "on", and a <code>.</code> means "off".

Then, animate your grid in steps, where each step decides the next configuration based on the current one.  Each light's next state (either on or off) depends on its current state and the current states of the eight lights adjacent to it (including diagonals).  Lights on the edge of the grid might have fewer than eight neighbors; the missing ones always count as "off".

For example, in a simplified 6x6 grid, the light marked <code>A</code> has the neighbors numbered <code>1</code> through <code>8</code>, and the light marked <code>B</code>, which is on an edge, only has the neighbors marked <code>1</code> through <code>5</code>:

<pre>
<code>1B5...
234...
......
..123.
..8A4.
..765.
</code>
</pre>

The state a light should have next is based on its current state (on or off) plus the <em>number of neighbors that are on</em>:


 - A light which is <em>on</em> stays on when <code>2</code> or <code>3</code> neighbors are on, and turns off otherwise.
 - A light which is <em>off</em> turns on if exactly <code>3</code> neighbors are on, and stays off otherwise.

All of the lights update simultaneously; they all consider the same current state before moving to the next.

Here's a few steps from an example configuration of another 6x6 grid:

<pre>
<code>Initial state:
.#.#.#
...##.
#....#
..#...
#.#..#
####..

After 1 step:
..##..
..##.#
...##.
......
#.....
#.##..

After 2 steps:
..###.
......
..###.
......
.#....
.#....

After 3 steps:
...#..
......
...#..
..##..
......
......

After 4 steps:
......
......
..##..
..##..
......
......
</code>
</pre>

After <code>4</code> steps, this example has four lights on.

In your grid of 100x100 lights, given your initial configuration, <em>how many lights are on after 100 steps</em>?


## --- Part Two ---
You flip the instructions over; Santa goes on to point out that this is all just an implementation of [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway's_Game_of_Life).  At least, it was, until you notice that something's wrong with the grid of lights you bought: four lights, one in each corner, are <em>stuck on</em> and can't be turned off.  The example above will actually run like this:

<pre>
<code>Initial state:
##.#.#
...##.
#....#
..#...
#.#..#
####.#

After 1 step:
#.##.#
####.#
...##.
......
#...#.
#.####

After 2 steps:
#..#.#
#....#
.#.##.
...##.
.#..##
##.###

After 3 steps:
#...##
####.#
..##.#
......
##....
####.#

After 4 steps:
#.####
#....#
...#..
.##...
#.....
#.#..#

After 5 steps:
##.###
.##..#
.##...
.##...
#.#...
##...#
</code>
</pre>

After <code>5</code> steps, this example now has <code>17</code> lights on.

In your grid of 100x100 lights, given your initial configuration, but with the four corners always in the <em>on</em> state, <em>how many lights are on after 100 steps</em>?


