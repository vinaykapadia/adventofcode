original source: [https://adventofcode.com/2019/day/17](https://adventofcode.com/2019/day/17)
## --- Day 17: Set and Forget ---
An early warning system detects an incoming [solar flare](https://en.wikipedia.org/wiki/Solar_flare) and automatically activates the ship's electromagnetic shield. Unfortunately, this has cut off the Wi-Fi for many small robots that, unaware of the impending danger, are now trapped on exterior scaffolding on the unsafe side of the shield. To rescue them, you'll have to act quickly!

The only tools at your disposal are some wired cameras and a small vacuum robot currently asleep at its charging station. The video quality is poor, but the vacuum robot has a needlessly bright LED that makes it easy to spot no matter where it is.

An [Intcode](9) program, the <em>Aft Scaffolding Control and Information Interface</em> (ASCII, your puzzle input), provides access to the cameras and the vacuum robot.  Currently, because the vacuum robot is asleep, you can only access the cameras.

Running the ASCII program on your Intcode computer will provide the current view of the scaffolds.  This is output, purely coincidentally, as [ASCII code](https://simple.wikipedia.org/wiki/ASCII): <code>35</code> means <code>#</code>, <code>46</code> means <code>.</code>, <code>10</code> starts a [new line](https://en.wikipedia.org/wiki/Newline#In_programming_languages) of output below the current one, and so on. (Within a line, characters are drawn left-to-right.)

In the camera output, <code>#</code> represents a scaffold and <code>.</code> represents open space. The vacuum robot is visible as <code>^</code>, <code>v</code>, <code><</code>, or <code>></code> depending on whether it is facing up, down, left, or right respectively. When drawn like this, the vacuum robot is <em>always on a scaffold</em>; if the vacuum robot ever walks off of a scaffold and begins <em>tumbling through space uncontrollably</em>, it will instead be visible as <code>X</code>.

In general, the scaffold forms a path, but it sometimes loops back onto itself.  For example, suppose you can see the following view from the cameras:

<pre>
<code>..#..........
..#..........
#######...###
#.#...#...#.#
#############
..#...#...#..
..#####...^..
</code>
</pre>

Here, the vacuum robot, <code>^</code> is facing up and sitting at one end of the scaffold near the bottom-right of the image. The scaffold continues up, loops across itself several times, and ends at the top-left of the image.

The first step is to calibrate the cameras by getting the <em>alignment parameters</em> of some well-defined points.  Locate all <em>scaffold intersections</em>; for each, its alignment parameter is the distance between its left edge and the left edge of the view multiplied by the distance between its top edge and the top edge of the view.  Here, the intersections from the above image are marked <code>O</code>:

<pre>
<code>..#..........
..#..........
##O####...###
#.#...#...#.#
##O###O###O##
..#...#...#..
..#####...^..
</code>
</pre>

For these intersections:


 - The top-left intersection is <code>2</code> units from the left of the image and <code>2</code> units from the top of the image, so its alignment parameter is <code>2 * 2 = <em>4</em></code>.
 - The bottom-left intersection is <code>2</code> units from the left and <code>4</code> units from the top, so its alignment parameter is <code>2 * 4 = <em>8</em></code>.
 - The bottom-middle intersection is <code>6</code> from the left and <code>4</code> from the top, so its alignment parameter is <code><em>24</em></code>.
 - The bottom-right intersection's alignment parameter is <code><em>40</em></code>.

To calibrate the cameras, you need the <em>sum of the alignment parameters</em>.  In the above example, this is <code><em>76</em></code>.

Run your ASCII program. <em>What is the sum of the alignment parameters</em> for the scaffold intersections?


