original source: [https://adventofcode.com/2017/day/19](https://adventofcode.com/2017/day/19)
## --- Day 19: A Series of Tubes ---
Somehow, a network packet got lost and ended up here.  It's trying to follow a routing diagram (your puzzle input), but it's confused about where to go.

Its starting point is just off the top of the diagram. Lines (drawn with <code>|</code>, <code>-</code>, and <code>+</code>) show the path it needs to take, starting by going down onto the only line connected to the top of the diagram. It needs to follow this path until it reaches the end (located somewhere within the diagram) and stop there.

Sometimes, the lines cross over each other; in these cases, it needs to continue going the same direction, and only turn left or right when there's no other option.  In addition, someone has left <em>letters</em> on the line; these also don't change its direction, but it can use them to keep track of where it's been. For example:

<pre>
<code>     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ 

</code>
</pre>

Given this diagram, the packet needs to take the following path:


 - Starting at the only line touching the top of the diagram, it must go down, pass through <code>A</code>, and continue onward to the first <code>+</code>.
 - Travel right, up, and right, passing through <code>B</code> in the process.
 - Continue down (collecting <code>C</code>), right, and up (collecting <code>D</code>).
 - Finally, go all the way left through <code>E</code> and stopping at <code>F</code>.

Following the path to the end, the letters it sees on its path are <code>ABCDEF</code>.

The little packet looks up at you, hoping you can help it find the way.  <em>What letters will it see</em> (in the order it would see them) if it follows the path? (The routing diagram is very wide; make sure you view it without line wrapping.)


## --- Part Two ---
The packet is curious how many steps it needs to go.

For example, using the same routing diagram from the example above...

<pre>
<code>     |          
     |  +--+    
     A  |  C    
 F---|--|-E---+ 
     |  |  |  D 
     +B-+  +--+ 

</code>
</pre>

...the packet would go:


 - <code>6</code> steps down (including the first line at the top of the diagram).
 - <code>3</code> steps right.
 - <code>4</code> steps up.
 - <code>3</code> steps right.
 - <code>4</code> steps down.
 - <code>3</code> steps right.
 - <code>2</code> steps up.
 - <code>13</code> steps left (including the <code>F</code> it stops on).

This would result in a total of <code>38</code> steps.

<em>How many steps</em> does the packet need to go?


