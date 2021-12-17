original source: [https://adventofcode.com/2016/day/8](https://adventofcode.com/2016/day/8)
## --- Day 8: Two-Factor Authentication ---
You come across a door implementing what you can only assume is an implementation of [two-factor authentication](https://en.wikipedia.org/wiki/Multi-factor_authentication) after a long game of [requirements](https://en.wikipedia.org/wiki/Requirement) [telephone](https://en.wikipedia.org/wiki/Chinese_whispers).

To get past the door, you first swipe a keycard (no problem; there was one on a nearby desk). Then, it displays a code on a [little screen](https://www.google.com/search?q=tiny+lcd&tbm=isch), and you type that code on a keypad. Then, presumably, the door unlocks.

Unfortunately, the screen has been smashed. After a few minutes, you've taken everything apart and figured out how it works. Now you just have to work out what the screen <em>would</em> have displayed.

The magnetic strip on the card you swiped encodes a series of instructions for the screen; these instructions are your puzzle input. The screen is <em><code>50</code> pixels wide and <code>6</code> pixels tall</em>, all of which start <em>off</em>, and is capable of three somewhat peculiar operations:


 - <code>rect AxB</code> turns <em>on</em> all of the pixels in a rectangle at the top-left of the screen which is <code>A</code> wide and <code>B</code> tall.
 - <code>rotate row y=A by B</code> shifts all of the pixels in row <code>A</code> (0 is the top row) <em>right</em> by <code>B</code> pixels. Pixels that would fall off the right end appear at the left end of the row.
 - <code>rotate column x=A by B</code> shifts all of the pixels in column <code>A</code> (0 is the left column) <em>down</em> by <code>B</code> pixels. Pixels that would fall off the bottom appear at the top of the column.

For example, here is a simple sequence on a smaller screen:


 - <code>rect 3x2</code> creates a small rectangle in the top-left corner:
<pre>
<code>###....
###....
.......</code>
</pre>

 - <code>rotate column x=1 by 1</code> rotates the second column down by one pixel:
<pre>
<code>#.#....
###....
.#.....</code>
</pre>

 - <code>rotate row y=0 by 4</code> rotates the top row right by four pixels:
<pre>
<code>....#.#
###....
.#.....</code>
</pre>

 - <code>rotate column x=1 by 1</code> again rotates the second column down by one pixel, causing the bottom pixel to wrap back to the top:
<pre>
<code>.#..#.#
#.#....
.#.....</code>
</pre>


As you can see, this display technology is extremely powerful, and will soon dominate the tiny-code-displaying-screen market.  That's what the advertisement on the back of the display tries to convince you, anyway.

There seems to be an intermediate check of the voltage used by the display: after you swipe your card, if the screen did work, <em>how many pixels should be lit?</em>


## --- Part Two ---
You notice that the screen is only capable of displaying capital letters; in the font it uses, each letter is <code>5</code> pixels wide and <code>6</code> tall.

After you swipe your card, <em>what code is the screen trying to display?</em>


