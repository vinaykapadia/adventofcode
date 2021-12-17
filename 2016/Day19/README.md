original source: [https://adventofcode.com/2016/day/19](https://adventofcode.com/2016/day/19)
## --- Day 19: An Elephant Named Joseph ---
The Elves contact you over a highly secure emergency channel. Back at the North Pole, the Elves are busy misunderstanding [White Elephant parties](https://en.wikipedia.org/wiki/White_elephant_gift_exchange).

Each Elf brings a present. They all sit in a circle, numbered starting with position <code>1</code>. Then, starting with the first Elf, they take turns stealing all the presents from the Elf to their left.  An Elf with no presents is removed from the circle and does not take turns.

For example, with five Elves (numbered <code>1</code> to <code>5</code>):

<pre>
<code>  1
5   2
 4 3
</code>
</pre>


 - Elf <code>1</code> takes Elf <code>2</code>'s present.
 - Elf <code>2</code> has no presents and is skipped.
 - Elf <code>3</code> takes Elf <code>4</code>'s present.
 - Elf <code>4</code> has no presents and is also skipped.
 - Elf <code>5</code> takes Elf <code>1</code>'s two presents.
 - Neither Elf <code>1</code> nor Elf <code>2</code> have any presents, so both are skipped.
 - Elf <code>3</code> takes Elf <code>5</code>'s three presents.

So, with <em>five</em> Elves, the Elf that sits starting in position <code>3</code> gets all the presents.

With the number of Elves given in your puzzle input, <em>which Elf gets all the presents?</em>


