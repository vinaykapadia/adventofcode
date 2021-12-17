original source: [https://adventofcode.com/2016/day/12](https://adventofcode.com/2016/day/12)
## --- Day 12: Leonardo's Monorail ---
You finally reach the top floor of this building: a garden with a slanted glass ceiling. Looks like there are no more stars to be had.

While sitting on a nearby bench amidst some [tiger lilies](https://www.google.com/search?q=tiger+lilies&tbm=isch), you manage to decrypt some of the files you extracted from the servers downstairs.

According to these documents, Easter Bunny HQ isn't just this building - it's a collection of buildings in the nearby area. They're all connected by a local monorail, and there's another building not far from here! Unfortunately, being night, the monorail is currently not operating.

You remotely connect to the monorail control systems and discover that the boot sequence expects a password. The password-checking logic (your puzzle input) is easy to extract, but the code it uses is strange: it's assembunny code designed for the [new computer](11) you just assembled. You'll have to execute the code and get the password.

The assembunny code you've extracted operates on four [registers](https://en.wikipedia.org/wiki/Processor_register) (<code>a</code>, <code>b</code>, <code>c</code>, and <code>d</code>) that start at <code>0</code> and can hold any [integer](https://en.wikipedia.org/wiki/Integer). However, it seems to make use of only a few [instructions](https://en.wikipedia.org/wiki/Instruction_set):


 - <code>cpy x y</code> <em>copies</em> <code>x</code> (either an integer or the <em>value</em> of a register) into register <code>y</code>.
 - <code>inc x</code> <em>increases</em> the value of register <code>x</code> by one.
 - <code>dec x</code> <em>decreases</em> the value of register <code>x</code> by one.
 - <code>jnz x y</code> <em>jumps</em> to an instruction <code>y</code> away (positive means forward; negative means backward), but only if <code>x</code> is <em>not zero</em>.

The <code>jnz</code> instruction moves relative to itself: an offset of <code>-1</code> would continue at the previous instruction, while an offset of <code>2</code> would <em>skip over</em> the next instruction.

For example:

<pre>
<code>cpy 41 a
inc a
inc a
dec a
jnz a 2
dec a
</code>
</pre>

The above code would set register <code>a</code> to <code>41</code>, increase its value by <code>2</code>, decrease its value by <code>1</code>, and then skip the last <code>dec a</code> (because <code>a</code> is not zero, so the <code>jnz a 2</code> skips it), leaving register <code>a</code> at <code>42</code>. When you move past the last instruction, the program halts.

After executing the assembunny code in your puzzle input, <em>what value is left in register <code>a</code>?</em>


## --- Part Two ---
As you head down the fire escape to the monorail, you notice it didn't start; register <code>c</code> needs to be initialized to the position of the ignition key.

If you instead <em>initialize register <code>c</code> to be <code>1</code></em>, what value is now left in register <code>a</code>?


