original source: [https://adventofcode.com/2019/day/24](https://adventofcode.com/2019/day/24)
## --- Day 24: Planet of Discord ---
You land on [Eris](https://en.wikipedia.org/wiki/Eris_(dwarf_planet)), your last stop before reaching Santa.  As soon as you do, your sensors start picking up strange life forms moving around: Eris is infested with [bugs](https://www.nationalgeographic.org/thisday/sep9/worlds-first-computer-bug/)! With an over 24-hour roundtrip for messages between you and Earth, you'll have to deal with this problem on your own.

Eris isn't a very large place; a scan of the entire area fits into a 5x5 grid (your puzzle input). The scan shows <em>bugs</em> (<code>#</code>) and <em>empty spaces</em> (<code>.</code>).

Each <em>minute</em>, The bugs live and die based on the number of bugs in the <em>four adjacent tiles</em>:


 - A bug <em>dies</em> (becoming an empty space) unless there is <em>exactly one</em> bug adjacent to it.
 - An empty space <em>becomes infested</em> with a bug if <em>exactly one or two</em> bugs are adjacent to it.

Otherwise, a bug or empty space remains the same.  (Tiles on the edges of the grid have fewer than four adjacent tiles; the missing tiles count as empty space.) This process happens in every location <em>simultaneously</em>; that is, within the same minute, the number of adjacent bugs is counted for every tile first, and then the tiles are updated.

Here are the first few minutes of an example scenario:

<pre>
<code>Initial state:
....#
#..#.
#..##
..#..
#....

After 1 minute:
#..#.
####.
###.#
##.##
.##..

After 2 minutes:
#####
....#
....#
...#.
#.###

After 3 minutes:
#....
####.
...##
#.##.
.##.#

After 4 minutes:
####.
....#
##..#
.....
##...
</code>
</pre>

To understand the nature of the bugs, watch for the first time a layout of bugs and empty spaces <em>matches any previous layout</em>. In the example above, the first layout to appear twice is:

<pre>
<code>.....
.....
.....
#....
.#...
</code>
</pre>

To calculate the <em>biodiversity rating</em> for this layout, consider each tile left-to-right in the top row, then left-to-right in the second row, and so on. Each of these tiles is worth biodiversity points equal to <em>increasing powers of two</em>: 1, 2, 4, 8, 16, 32, and so on.  Add up the biodiversity points for tiles with bugs; in this example, the 16th tile (<code>32768</code> points) and 22nd tile (<code>2097152</code> points) have bugs, a total biodiversity rating of <code><em>2129920</em></code>.

<em>What is the biodiversity rating for the first layout that appears twice?</em>


