original source: [https://adventofcode.com/2017/day/17](https://adventofcode.com/2017/day/17)
## --- Day 17: Spinlock ---
Suddenly, whirling in the distance, you notice what looks like a massive, pixelated hurricane: a deadly [spinlock](https://en.wikipedia.org/wiki/Spinlock). This spinlock isn't just consuming computing power, but memory, too; vast, digital mountains are being ripped from the ground and consumed by the vortex.

If you don't move quickly, fixing that printer will be the least of your problems.

This spinlock's algorithm is simple but efficient, quickly consuming everything in its path. It starts with a circular buffer containing only the value <code>0</code>, which it marks as the <em>current position</em>. It then steps forward through the circular buffer some number of steps (your puzzle input) before inserting the first new value, <code>1</code>, after the value it stopped on.  The inserted value becomes the <em>current position</em>. Then, it steps forward from there the same number of steps, and wherever it stops, inserts after it the second new value, <code>2</code>, and uses that as the new <em>current position</em> again.

It repeats this process of <em>stepping forward</em>, <em>inserting a new value</em>, and <em>using the location of the inserted value as the new current position</em> a total of <code><em>2017</em></code> times, inserting <code>2017</code> as its final operation, and ending with a total of <code>2018</code> values (including <code>0</code>) in the circular buffer.

For example, if the spinlock were to step <code>3</code> times per insert, the circular buffer would begin to evolve like this (using parentheses to mark the current position after each iteration of the algorithm):


 - <code>(0)</code>, the initial state before any insertions.
 - <code>0 (1)</code>: the spinlock steps forward three times (<code>0</code>, <code>0</code>, <code>0</code>), and then inserts the first value, <code>1</code>, after it. <code>1</code> becomes the current position.
 - <code>0 (2) 1</code>: the spinlock steps forward three times (<code>0</code>, <code>1</code>, <code>0</code>), and then inserts the second value, <code>2</code>, after it. <code>2</code> becomes the current position.
 - <code>0  2 (3) 1</code>: the spinlock steps forward three times (<code>1</code>, <code>0</code>, <code>2</code>), and then inserts the third value, <code>3</code>, after it. <code>3</code> becomes the current position.

And so on:


 - <code>0  2 (4) 3  1</code>
 - <code>0 (5) 2  4  3  1</code>
 - <code>0  5  2  4  3 (6) 1</code>
 - <code>0  5 (7) 2  4  3  6  1</code>
 - <code>0  5  7  2  4  3 (8) 6  1</code>
 - <code>0 (9) 5  7  2  4  3  8  6  1</code>

Eventually, after 2017 insertions, the section of the circular buffer near the last insertion looks like this:

<pre>
<code>1512  1134  151 (2017) 638  1513  851</code>
</pre>

Perhaps, if you can identify the value that will ultimately be <em>after</em> the last value written (<code>2017</code>), you can short-circuit the spinlock.  In this example, that would be <code>638</code>.

<em>What is the value after <code>2017</code></em> in your completed circular buffer?


## --- Part Two ---
The spinlock does not short-circuit.  Instead, it gets <em>more</em> angry. At least, you assume that's what happened; it's spinning significantly faster than it was a moment ago.

You have good news and bad news.

The good news is that you have improved calculations for how to stop the spinlock. They indicate that you actually need to identify <em>the value after <code>0</code></em> in the current state of the circular buffer.

The bad news is that while you were determining this, the spinlock has just finished inserting its fifty millionth value (<code>50000000</code>).

<em>What is the value after <code>0</code></em> the moment <code>50000000</code> is inserted?


