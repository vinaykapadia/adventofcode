original source: [https://adventofcode.com/2015/day/23](https://adventofcode.com/2015/day/23)
## --- Day 23: Opening the Turing Lock ---
Little Jane Marie just got her very first computer for Christmas from some unknown benefactor.  It comes with instructions and an example program, but the computer itself seems to be malfunctioning.  She's curious what the program does, and would like you to help her run it.

The manual explains that the computer supports two [registers](https://en.wikipedia.org/wiki/Processor_register) and six [instructions](https://en.wikipedia.org/wiki/Instruction_set) (truly, it goes on to remind the reader, a state-of-the-art technology). The registers are named <code>a</code> and <code>b</code>, can hold any [non-negative integer](https://en.wikipedia.org/wiki/Natural_number), and begin with a value of <code>0</code>.  The instructions are as follows:


 - <code>hlf r</code> sets register <code>r</code> to <em>half</em> its current value, then continues with the next instruction.
 - <code>tpl r</code> sets register <code>r</code> to <em>triple</em> its current value, then continues with the next instruction.
 - <code>inc r</code> <em>increments</em> register <code>r</code>, adding <code>1</code> to it, then continues with the next instruction.
 - <code>jmp offset</code> is a <em>jump</em>; it continues with the instruction <code>offset</code> away <em>relative to itself</em>.
 - <code>jie r, offset</code> is like <code>jmp</code>, but only jumps if register <code>r</code> is <em>even</em> ("jump if even").
 - <code>jio r, offset</code> is like <code>jmp</code>, but only jumps if register <code>r</code> is <code>1</code> ("jump if <em>one</em>", not odd).

All three jump instructions work with an <em>offset</em> relative to that instruction.  The offset is always written with a prefix <code>+</code> or <code>-</code> to indicate the direction of the jump (forward or backward, respectively).  For example, <code>jmp +1</code> would simply continue with the next instruction, while <code>jmp +0</code> would continuously jump back to itself forever.

The program exits when it tries to run an instruction beyond the ones defined.

For example, this program sets <code>a</code> to <code>2</code>, because the <code>jio</code> instruction causes it to skip the <code>tpl</code> instruction:

<pre>
<code>inc a
jio a, +2
tpl a
inc a
</code>
</pre>

What is <em>the value in register <code>b</code></em> when the program in your puzzle input is finished executing?


## --- Part Two ---
The unknown benefactor is <em>very</em> thankful for releasi-- er, helping little Jane Marie with her computer.  Definitely not to distract you, what is the value in register <code>b</code> after the program is finished executing if register <code>a</code> starts as <code>1</code> instead?


