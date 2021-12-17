original source: [https://adventofcode.com/2017/day/5](https://adventofcode.com/2017/day/5)
## --- Day 5: A Maze of Twisty Trampolines, All Alike ---
An urgent interrupt arrives from the CPU: it's trapped in a maze of jump instructions, and it would like assistance from any programs with spare cycles to help find the exit.

The message includes a list of the offsets for each jump. Jumps are relative: <code>-1</code> moves to the previous instruction, and <code>2</code> skips the next one. Start at the first instruction in the list. The goal is to follow the jumps until one leads <em>outside</em> the list.

In addition, these instructions are a little strange; after each jump, the offset of that instruction increases by <code>1</code>. So, if you come across an offset of <code>3</code>, you would move three instructions forward, but change it to a <code>4</code> for the next time it is encountered.

For example, consider the following list of jump offsets:

<pre>
<code>0
3
0
1
-3
</code>
</pre>

Positive jumps ("forward") move downward; negative jumps move upward. For legibility in this example, these offset values will be written all on one line, with the current instruction marked in parentheses. The following steps would be taken before an exit is found:


 - <code>(0) 3  0  1  -3 </code> - <em>before</em> we have taken any steps.
 - <code>(1) 3  0  1  -3 </code> - jump with offset <code>0</code> (that is, don't jump at all). Fortunately, the instruction is then incremented to <code>1</code>.
 - <code> 2 (3) 0  1  -3 </code> - step forward because of the instruction we just modified. The first instruction is incremented again, now to <code>2</code>.
 - <code> 2  4  0  1 (-3)</code> - jump all the way to the end; leave a <code>4</code> behind.
 - <code> 2 (4) 0  1  -2 </code> - go back to where we just were; increment <code>-3</code> to <code>-2</code>.
 - <code> 2  5  0  1  -2 </code> - jump <code>4</code> steps forward, escaping the maze.

In this example, the exit is reached in <code>5</code> steps.

<em>How many steps</em> does it take to reach the exit?


## --- Part Two ---
Now, the jumps are even stranger: after each jump, if the offset was <em>three or more</em>, instead <em>decrease</em> it by <code>1</code>. Otherwise, increase it by <code>1</code> as before.

Using this rule with the above example, the process now takes <code>10</code> steps, and the offset values after finding the exit are left as <code>2 3 2 3 -1</code>.

<em>How many steps</em> does it now take to reach the exit?


