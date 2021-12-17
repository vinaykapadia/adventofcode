original source: [https://adventofcode.com/2016/day/13](https://adventofcode.com/2016/day/13)
## --- Day 13: A Maze of Twisty Little Cubicles ---
You arrive at the first floor of this new building to discover a much less welcoming environment than the shiny atrium of the last one.  Instead, you are in a maze of twisty little cubicles, all alike.

Every location in this area is addressed by a pair of non-negative integers (<code>x,y</code>). Each such coordinate is either a wall or an open space. You can't move diagonally. The cube maze starts at <code>0,0</code> and seems to extend infinitely toward <em>positive</em> <code>x</code> and <code>y</code>; negative values are <em>invalid</em>, as they represent a location outside the building. You are in a small waiting area at <code>1,1</code>.

While it seems chaotic, a nearby morale-boosting poster explains, the layout is actually quite logical. You can determine whether a given <code>x,y</code> coordinate will be a wall or an open space using a simple system:


 - Find <code>x*x + 3*x + 2*x*y + y + y*y</code>.
 - Add the office designer's favorite number (your puzzle input).
 - Find the [binary representation](https://en.wikipedia.org/wiki/Binary_number) of that sum; count the <em>number</em> of [bits](https://en.wikipedia.org/wiki/Bit) that are <code>1</code>.

 - If the number of bits that are <code>1</code> is <em>even</em>, it's an <em>open space</em>.
 - If the number of bits that are <code>1</code> is <em>odd</em>, it's a <em>wall</em>.



For example, if the office designer's favorite number were <code>10</code>, drawing walls as <code>#</code> and open spaces as <code>.</code>, the corner of the building containing <code>0,0</code> would look like this:

<pre>
<code>  0123456789
0 .#.####.##
1 ..#..#...#
2 #....##...
3 ###.#.###.
4 .##..#..#.
5 ..##....#.
6 #...##.###
</code>
</pre>

Now, suppose you wanted to reach <code>7,4</code>. The shortest route you could take is marked as <code>O</code>:

<pre>
<code>  0123456789
0 .#.####.##
1 .O#..#...#
2 #OOO.##...
3 ###O#.###.
4 .##OO#OO#.
5 ..##OOO.#.
6 #...##.###
</code>
</pre>

Thus, reaching <code>7,4</code> would take a minimum of <code>11</code> steps (starting from your current location, <code>1,1</code>).

What is the <em>fewest number of steps required</em> for you to reach <code>31,39</code>?


