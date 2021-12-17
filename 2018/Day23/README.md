original source: [https://adventofcode.com/2018/day/23](https://adventofcode.com/2018/day/23)
## --- Day 23: Experimental Emergency Teleportation ---
Using your torch to search the darkness of the rocky cavern, you finally locate the man's friend: a small <em>reindeer</em>.

You're not sure how it got so far in this cave.  It looks sick - too sick to walk - and too heavy for you to carry all the way back.  Sleighs won't be invented for another 1500 years, of course.

The only option is <em>experimental emergency teleportation</em>.

You hit the "experimental emergency teleportation" button on the device and push <em>I accept the risk</em> on no fewer than 18 different warning messages. Immediately, the device deploys hundreds of tiny <em>nanobots</em> which fly around the cavern, apparently assembling themselves into a very specific <em>formation</em>. The device lists the <code>X,Y,Z</code> position (<code>pos</code>) for each nanobot as well as its <em>signal radius</em> (<code>r</code>) on its tiny screen (your puzzle input).

Each nanobot can transmit signals to any integer coordinate which is a distance away from it <em>less than or equal to</em> its signal radius (as measured by [Manhattan distance](https://en.wikipedia.org/wiki/Taxicab_geometry)). Coordinates a distance away of less than or equal to a nanobot's signal radius are said to be <em>in range</em> of that nanobot.

Before you start the teleportation process, you should determine which nanobot is the <em>strongest</em> (that is, which has the largest signal radius) and then, for that nanobot, the <em>total number of nanobots that are in range</em> of it, <em>including itself</em>.

For example, given the following nanobots:

<pre>
<code>pos=<0,0,0>, r=4
pos=<1,0,0>, r=1
pos=<4,0,0>, r=3
pos=<0,2,0>, r=1
pos=<0,5,0>, r=3
pos=<0,0,3>, r=1
pos=<1,1,1>, r=1
pos=<1,1,2>, r=1
pos=<1,3,1>, r=1
</code>
</pre>

The strongest nanobot is the first one (position <code>0,0,0</code>) because its signal radius, <code>4</code> is the largest. Using that nanobot's location and signal radius, the following nanobots are in or out of range:


 - The nanobot at <code>0,0,0</code> is distance <code>0</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>1,0,0</code> is distance <code>1</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>4,0,0</code> is distance <code>4</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>0,2,0</code> is distance <code>2</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>0,5,0</code> is distance <code>5</code> away, and so it is <em>not</em> in range.
 - The nanobot at <code>0,0,3</code> is distance <code>3</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>1,1,1</code> is distance <code>3</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>1,1,2</code> is distance <code>4</code> away, and so it is <em>in range</em>.
 - The nanobot at <code>1,3,1</code> is distance <code>5</code> away, and so it is <em>not</em> in range.

In this example, in total, <code><em>7</em></code> nanobots are in range of the nanobot with the largest signal radius.

Find the nanobot with the largest signal radius.  <em>How many nanobots are in range</em> of its signals?


