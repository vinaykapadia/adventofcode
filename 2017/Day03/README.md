original source: [https://adventofcode.com/2017/day/3](https://adventofcode.com/2017/day/3)
## --- Day 3: Spiral Memory ---
You come across an experimental new kind of memory stored on an infinite two-dimensional grid.

Each square on the grid is allocated in a spiral pattern starting at a location marked <code>1</code> and then counting up while spiraling outward. For example, the first few squares are allocated like this:

<pre>
<code>17  16  15  14  13
18   5   4   3  12
19   6   1   2  11
20   7   8   9  10
21  22  23---> ...
</code>
</pre>

While this is very space-efficient (no squares are skipped), requested data must be carried back to square <code>1</code> (the location of the only access port for this memory system) by programs that can only move up, down, left, or right. They always take the shortest path: the [Manhattan Distance](https://en.wikipedia.org/wiki/Taxicab_geometry) between the location of the data and square <code>1</code>.

For example:


 - Data from square <code>1</code> is carried <code>0</code> steps, since it's at the access port.
 - Data from square <code>12</code> is carried <code>3</code> steps, such as: down, left, left.
 - Data from square <code>23</code> is carried only <code>2</code> steps: up twice.
 - Data from square <code>1024</code> must be carried <code>31</code> steps.

<em>How many steps</em> are required to carry the data from the square identified in your puzzle input all the way to the access port?


## --- Part Two ---
As a stress test on the system, the programs here clear the grid and then store the value <code>1</code> in square <code>1</code>. Then, in the same allocation order as shown above, they store the sum of the values in all adjacent squares, including diagonals.

So, the first few squares' values are chosen as follows:


 - Square <code>1</code> starts with the value <code>1</code>.
 - Square <code>2</code> has only one adjacent filled square (with value <code>1</code>), so it also stores <code>1</code>.
 - Square <code>3</code> has both of the above squares as neighbors and stores the sum of their values, <code>2</code>.
 - Square <code>4</code> has all three of the aforementioned squares as neighbors and stores the sum of their values, <code>4</code>.
 - Square <code>5</code> only has the first and fourth squares as neighbors, so it gets the value <code>5</code>.

Once a square is written, its value does not change. Therefore, the first few squares would receive the following values:

<pre>
<code>147  142  133  122   59
304    5    4    2   57
330   10    1    1   54
351   11   23   25   26
362  747  806--->   ...
</code>
</pre>

What is the <em>first value written</em> that is <em>larger</em> than your puzzle input?


