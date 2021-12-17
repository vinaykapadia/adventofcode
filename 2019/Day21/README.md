original source: [https://adventofcode.com/2019/day/21](https://adventofcode.com/2019/day/21)
## --- Day 21: Springdroid Adventure ---
You lift off from Pluto and start flying in the direction of Santa.

While experimenting further with the tractor beam, you accidentally pull an asteroid directly into your ship!  It deals significant damage to your hull and causes your ship to begin tumbling violently.

You can send a droid out to investigate, but the tumbling is causing enough [artificial gravity](https://en.wikipedia.org/wiki/Artificial_gravity) that one wrong step could send the droid through a hole in the hull and flying out into space.

The clear choice for this mission is a droid that can <em>jump</em> over the holes in the hull - a <em>springdroid</em>.

You can use an [Intcode](9) program (your puzzle input) running on an [ASCII-capable](17) computer to [program](https://en.wikipedia.org/wiki/Programmable_read-only_memory) the springdroid. However, springdroids don't run Intcode; instead, they run a simplified assembly language called <em>springscript</em>.

While a springdroid is certainly capable of navigating the artificial gravity and giant holes, it has one downside: it can only remember at most <em>15</em> springscript instructions.

The springdroid will move forward automatically, constantly thinking about <em>whether to jump</em>.  The springscript program defines the logic for this decision.

Springscript programs only use [Boolean values](https://en.wikipedia.org/wiki/Boolean_data_type), not numbers or strings.  Two registers are available: <code>T</code>, the <em>temporary value</em> register, and <code>J</code>, the <em>jump</em> register.  If the jump register is <em>true</em> at the end of the springscript program, the springdroid will try to jump. Both of these registers start with the value <em>false</em>.

Springdroids have a sensor that can detect <em>whether there is ground</em> at various distances in the direction it is facing; these values are provided in <em>read-only registers</em>.  Your springdroid can detect ground at four distances: one tile away (<code>A</code>), two tiles away (<code>B</code>), three tiles away (<code>C</code>), and four tiles away (<code>D</code>). If there is ground at the given distance, the register will be <em>true</em>; if there is a hole, the register will be <em>false</em>.

There are only <em>three instructions</em> available in springscript:


 - <code>AND X Y</code> sets <code>Y</code> to <em>true</em> if both <code>X</code> and <code>Y</code> are <em>true</em>; otherwise, it sets <code>Y</code> to <em>false</em>.
 - <code>OR X Y</code> sets <code>Y</code> to <em>true</em> if at least one of <code>X</code> or <code>Y</code> is <em>true</em>; otherwise, it sets <code>Y</code> to <em>false</em>.
 - <code>NOT X Y</code> sets <code>Y</code> to <em>true</em> if <code>X</code> is <em>false</em>; otherwise, it sets <code>Y</code> to <em>false</em>.

In all three instructions, the second argument (<code>Y</code>) needs to be a <em>writable register</em> (either <code>T</code> or <code>J</code>). The first argument (<code>X</code>) can be <em>any register</em> (including <code>A</code>, <code>B</code>, <code>C</code>, or <code>D</code>).

For example, the one-instruction program <code>NOT A J</code> means "if the tile immediately in front of me is not ground, jump".

Or, here is a program that jumps if a three-tile-wide hole (with ground on the other side of the hole) is detected:

<pre>
<code>NOT A J
NOT B T
AND T J
NOT C T
AND T J
AND D J
</code>
</pre>

The Intcode program expects ASCII inputs and outputs.  It will begin by displaying a prompt; then, input the desired instructions one per line. End each line with a newline (ASCII code <code>10</code>). <em>When you have finished entering your program</em>, provide the command <code>WALK</code> followed by a newline to instruct the springdroid to begin surveying the hull.

If the springdroid <em>falls into space</em>, an ASCII rendering of the last moments of its life will be produced.  In these, <code>@</code> is the springdroid, <code>#</code> is hull, and <code>.</code> is empty space.  For example, suppose you program the springdroid like this:

<pre>
<code>NOT D J
WALK
</code>
</pre>

This one-instruction program sets <code>J</code> to <em>true</em> if and only if there is no ground four tiles away.  In other words, it attempts to jump into any hole it finds:

<pre>
<code>.................
.................
<em>@</em>................
#####.###########

.................
.................
.<em>@</em>...............
#####.###########

.................
..<em>@</em>..............
.................
#####.###########

...<em>@</em>.............
.................
.................
#####.###########

.................
....<em>@</em>............
.................
#####.###########

.................
.................
.....<em>@</em>...........
#####.###########

.................
.................
.................
#####<em>@</em>###########
</code>
</pre>

However, if the springdroid successfully makes it across, it will use an output instruction to indicate the <em>amount of damage to the hull</em> as a single giant integer outside the normal ASCII range.

Program the springdroid with logic that allows it to survey the hull without falling into space.  <em>What amount of hull damage does it report?</em>


