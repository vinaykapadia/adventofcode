original source: [https://adventofcode.com/2018/day/6](https://adventofcode.com/2018/day/6)
## --- Day 6: Chronal Coordinates ---
The device on your wrist beeps several times, and once again you feel like you're falling.

"Situation critical," the device announces. "Destination indeterminate. Chronal interference detected. Please specify new target coordinates."

The device then produces a list of coordinates (your puzzle input). Are they places it thinks are safe or dangerous? It recommends you check manual page 729. The Elves did not give you a manual.

<em>If they're dangerous,</em> maybe you can minimize the danger by finding the coordinate that gives the largest distance from the other points.

Using only the [Manhattan distance](https://en.wikipedia.org/wiki/Taxicab_geometry), determine the <em>area</em> around each coordinate by counting the number of [integer](https://en.wikipedia.org/wiki/Integer) X,Y locations that are <em>closest</em> to that coordinate (and aren't <em>tied in distance</em> to any other coordinate).

Your goal is to find the size of the <em>largest area</em> that isn't infinite. For example, consider the following list of coordinates:

<pre>
<code>1, 1
1, 6
8, 3
3, 4
5, 5
8, 9
</code>
</pre>

If we name these coordinates <code>A</code> through <code>F</code>, we can draw them on a grid, putting <code>0,0</code> at the top left:

<pre>
<code>..........
.A........
..........
........C.
...D......
.....E....
.B........
..........
..........
........F.
</code>
</pre>

This view is partial - the actual grid extends infinitely in all directions.  Using the Manhattan distance, each location's closest coordinate can be determined, shown here in lowercase:

<pre>
<code>aaaaa.cccc
a<em>A</em>aaa.cccc
aaaddecccc
aadddecc<em>C</em>c
..d<em>D</em>deeccc
bb.de<em>E</em>eecc
b<em>B</em>b.eeee..
bbb.eeefff
bbb.eeffff
bbb.ffff<em>F</em>f
</code>
</pre>

Locations shown as <code>.</code> are equally far from two or more coordinates, and so they don't count as being closest to any.

In this example, the areas of coordinates A, B, C, and F are infinite - while not shown here, their areas extend forever outside the visible grid. However, the areas of coordinates D and E are finite: D is closest to 9 locations, and E is closest to 17 (both including the coordinate's location itself).  Therefore, in this example, the size of the largest area is <em>17</em>.

<em>What is the size of the largest area</em> that isn't infinite?


