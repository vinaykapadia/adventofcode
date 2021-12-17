original source: [https://adventofcode.com/2017/day/23](https://adventofcode.com/2017/day/23)
## --- Day 23: Coprocessor Conflagration ---
You decide to head directly to the CPU and fix the printer from there. As you get close, you find an <em>experimental coprocessor</em> doing so much work that the local programs are afraid it will [halt and catch fire](https://en.wikipedia.org/wiki/Halt_and_Catch_Fire). This would cause serious issues for the rest of the computer, so you head in and see what you can do.

The code it's running seems to be a variant of the kind you saw recently on that [tablet](18). The general functionality seems <em>very similar</em>, but some of the instructions are different:


 - <code>set X Y</code> <em>sets</em> register <code>X</code> to the value of <code>Y</code>.
 - <code>sub X Y</code> <em>decreases</em> register <code>X</code> by the value of <code>Y</code>.
 - <code>mul X Y</code> sets register <code>X</code> to the result of <em>multiplying</em> the value contained in register <code>X</code> by the value of <code>Y</code>.
 - <code>jnz X Y</code> <em>jumps</em> with an offset of the value of <code>Y</code>, but only if the value of <code>X</code> is <em>not zero</em>. (An offset of <code>2</code> skips the next instruction, an offset of <code>-1</code> jumps to the previous instruction, and so on.)
Only the instructions listed above are used. The eight registers here, named <code>a</code> through <code>h</code>, all start at <code>0</code>.


The coprocessor is currently set to some kind of <em>debug mode</em>, which allows for testing, but prevents it from doing any meaningful work.

If you run the program (your puzzle input), <em>how many times is the <code>mul</code> instruction invoked?</em>


## --- Part Two ---
Now, it's time to fix the problem.

The <em>debug mode switch</em> is wired directly to register <code>a</code>.  You flip the switch, which makes <em>register <code>a</code> now start at <code>1</code></em> when the program is executed.

Immediately, the coprocessor begins to overheat.  Whoever wrote this program obviously didn't choose a very efficient implementation.  You'll need to <em>optimize the program</em> if it has any hope of completing before Santa needs that printer working.

The coprocessor's ultimate goal is to determine the final value left in register <code>h</code> once the program completes. Technically, if it had that... it wouldn't even need to run the program.

After setting register <code>a</code> to <code>1</code>, if the program were to run to completion, <em>what value would be left in register <code>h</code>?</em>


