original source: [https://adventofcode.com/2016/day/23](https://adventofcode.com/2016/day/23)
## --- Day 23: Safe Cracking ---
This is one of the top floors of the nicest tower in EBHQ. The Easter Bunny's private office is here, complete with a safe hidden behind a painting, and who <em>wouldn't</em> hide a star in a safe behind a painting?

The safe has a digital screen and keypad for code entry. A sticky note attached to the safe has a password hint on it: "eggs". The painting is of a large rabbit coloring some eggs. You see <code>7</code>.

When you go to type the code, though, nothing appears on the display; instead, the keypad comes apart in your hands, apparently having been smashed. Behind it is some kind of socket - one that matches a connector in your [prototype computer](11)! You pull apart the smashed keypad and extract the logic circuit, plug it into your computer, and plug your computer into the safe.


Now, you just need to figure out what output the keypad would have sent to the safe. You extract the [assembunny code](12) from the logic chip (your puzzle input).

The code looks like it uses <em>almost</em> the same architecture and instruction set that the [monorail computer](12) used! You should be able to <em>use the same assembunny interpreter</em> for this as you did there, but with one new instruction:

<code>tgl x</code> <em>toggles</em> the instruction <code>x</code> away (pointing at instructions like <code>jnz</code> does: positive means forward; negative means backward):


 - For <em>one-argument</em> instructions, <code>inc</code> becomes <code>dec</code>, and all other one-argument instructions become <code>inc</code>.
 - For <em>two-argument</em> instructions, <code>jnz</code> becomes <code>cpy</code>, and all other two-instructions become <code>jnz</code>.
 - The arguments of a toggled instruction are <em>not affected</em>.
 - If an attempt is made to toggle an instruction outside the program, <em>nothing happens</em>.
 - If toggling produces an <em>invalid instruction</em> (like <code>cpy 1 2</code>) and an attempt is later made to execute that instruction, <em>skip it instead</em>.
 - If <code>tgl</code> toggles <em>itself</em> (for example, if <code>a</code> is <code>0</code>, <code>tgl a</code> would target itself and become <code>inc a</code>), the resulting instruction is not executed until the next time it is reached.

For example, given this program:

<pre>
<code>cpy 2 a
tgl a
tgl a
tgl a
cpy 1 a
dec a
dec a
</code>
</pre>


 - <code>cpy 2 a</code> initializes register <code>a</code> to <code>2</code>.
 - The first <code>tgl a</code> toggles an instruction <code>a</code> (<code>2</code>) away from it, which changes the third <code>tgl a</code> into <code>inc a</code>.
 - The second <code>tgl a</code> also modifies an instruction <code>2</code> away from it, which changes the <code>cpy 1 a</code> into <code>jnz 1 a</code>.
 - The fourth line, which is now <code>inc a</code>, increments <code>a</code> to <code>3</code>.
 - Finally, the fifth line, which is now <code>jnz 1 a</code>, jumps <code>a</code> (<code>3</code>) instructions ahead, skipping the <code>dec a</code> instructions.

In this example, the final value in register <code>a</code> is <code>3</code>.

The rest of the electronics seem to place the keypad entry (the number of eggs, <code>7</code>) in register <code>a</code>, run the code, and then send the value left in register <code>a</code> to the safe.

<em>What value</em> should be sent to the safe?


