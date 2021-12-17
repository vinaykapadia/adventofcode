original source: [https://adventofcode.com/2016/day/18](https://adventofcode.com/2016/day/18)
## --- Day 18: Like a Rogue ---
As you enter this room, you hear a loud click! Some of the tiles in the floor here seem to be pressure plates for [traps](https://nethackwiki.com/wiki/Trap), and the trap you just triggered has run out of... whatever it tried to do to you. You doubt you'll be so lucky next time.

Upon closer examination, the traps and safe tiles in this room seem to follow a pattern. The tiles are arranged into rows that are all the same width; you take note of the safe tiles (<code>.</code>) and traps (<code>^</code>) in the first row (your puzzle input).

The type of tile (trapped or safe) in each row is based on the types of the tiles in the same position, and to either side of that position, in the previous row. (If either side is off either end of the row, it counts as "safe" because there isn't a trap embedded in the wall.)

For example, suppose you know the first row (with tiles marked by letters) and want to determine the next row (with tiles marked by numbers):

<pre>
<code>ABCDE
12345
</code>
</pre>

The type of tile <code>2</code> is based on the types of tiles <code>A</code>, <code>B</code>, and <code>C</code>; the type of tile <code>5</code> is based on tiles <code>D</code>, <code>E</code>, and an imaginary "safe" tile. Let's call these three tiles from the previous row the <em>left</em>, <em>center</em>, and <em>right</em> tiles, respectively. Then, a new tile is a <em>trap</em> only in one of the following situations:


 - Its <em>left</em> and <em>center</em> tiles are traps, but its <em>right</em> tile is not.
 - Its <em>center</em> and <em>right</em> tiles are traps, but its <em>left</em> tile is not.
 - Only its <em>left</em> tile is a trap.
 - Only its <em>right</em> tile is a trap.

In any other situation, the new tile is safe.

Then, starting with the row <code>..^^.</code>, you can determine the next row by applying those rules to each new tile:


 - The leftmost character on the next row considers the left (nonexistent, so we assume "safe"), center (the first <code>.</code>, which means "safe"), and right (the second <code>.</code>, also "safe") tiles on the previous row. Because all of the trap rules require a trap in at least one of the previous three tiles, the first tile on this new row is also safe, <code>.</code>.
 - The second character on the next row considers its left (<code>.</code>), center (<code>.</code>), and right (<code>^</code>) tiles from the previous row. This matches the fourth rule: only the right tile is a trap. Therefore, the next tile in this new row is a trap, <code>^</code>.
 - The third character considers <code>.^^</code>, which matches the second trap rule: its center and right tiles are traps, but its left tile is not. Therefore, this tile is also a trap, <code>^</code>.
 - The last two characters in this new row match the first and third rules, respectively, and so they are both also traps, <code>^</code>.

After these steps, we now know the next row of tiles in the room: <code>.^^^^</code>. Then, we continue on to the next row, using the same rules, and get <code>^^..^</code>. After determining two new rows, our map looks like this:

<pre>
<code>..^^.
.^^^^
^^..^
</code>
</pre>

Here's a larger example with ten tiles per row and ten rows:

<pre>
<code>.^^.^.^^^^
^^^...^..^
^.^^.^.^^.
..^^...^^^
.^^^^.^^.^
^^..^.^^..
^^^^..^^^.
^..^^^^.^^
.^^^..^.^^
^^.^^^..^^
</code>
</pre>

In ten rows, this larger example has <code>38</code> safe tiles.

Starting with the map in your puzzle input, in a total of <code>40</code> rows (including the starting row), <em>how many safe tiles</em> are there?


