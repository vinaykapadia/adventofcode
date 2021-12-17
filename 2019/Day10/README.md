original source: [https://adventofcode.com/2019/day/10](https://adventofcode.com/2019/day/10)
## --- Day 10: Monitoring Station ---
You fly into the asteroid belt and reach the Ceres monitoring station.  The Elves here have an emergency: they're having trouble tracking all of the asteroids and can't be sure they're safe.

The Elves would like to build a new monitoring station in a nearby area of space; they hand you a map of all of the asteroids in that region (your puzzle input).

The map indicates whether each position is empty (<code>.</code>) or contains an asteroid (<code>#</code>).  The asteroids are much smaller than they appear on the map, and every asteroid is exactly in the center of its marked position.  The asteroids can be described with <code>X,Y</code> coordinates where <code>X</code> is the distance from the left edge and <code>Y</code> is the distance from the top edge (so the top-left corner is <code>0,0</code> and the position immediately to its right is <code>1,0</code>).

Your job is to figure out which asteroid would be the best place to build a <em>new monitoring station</em>. A monitoring station can <em>detect</em> any asteroid to which it has <em>direct line of sight</em> - that is, there cannot be another asteroid <em>exactly</em> between them. This line of sight can be at any angle, not just lines aligned to the grid or diagonally. The <em>best</em> location is the asteroid that can <em>detect</em> the largest number of other asteroids.

For example, consider the following map:

<pre>
<code>.#..#
.....
#####
....#
...<em>#</em>#
</code>
</pre>

The best location for a new monitoring station on this map is the highlighted asteroid at <code>3,4</code> because it can detect <code>8</code> asteroids, more than any other location. (The only asteroid it cannot detect is the one at <code>1,0</code>; its view of this asteroid is blocked by the asteroid at <code>2,2</code>.) All other asteroids are worse locations; they can detect <code>7</code> or fewer other asteroids. Here is the number of other asteroids a monitoring station on each asteroid could detect:

<pre>
<code>.7..7
.....
67775
....7
...87
</code>
</pre>

Here is an asteroid (<code>#</code>) and some examples of the ways its line of sight might be blocked. If there were another asteroid at the location of a capital letter, the locations marked with the corresponding lowercase letter would be blocked and could not be detected:

<pre>
<code>#.........
...A......
...B..a...
.EDCG....a
..F.c.b...
.....c....
..efd.c.gb
.......c..
....f...c.
...e..d..c
</code>
</pre>

Here are some larger examples:


 - Best is <code>5,8</code> with <code>33</code> other asteroids detected:

<pre>
<code>......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...<em>#</em>..#.
.#....####
</code>
</pre>

 - Best is <code>1,2</code> with <code>35</code> other asteroids detected:

<pre>
<code>#.#...#.#.
.###....#.
.<em>#</em>....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.
</code>
</pre>

 - Best is <code>6,3</code> with <code>41</code> other asteroids detected:

<pre>
<code>.#..#..###
####.###.#
....###.#.
..###.<em>#</em>#.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#..
</code>
</pre>

 - Best is <code>11,13</code> with <code>210</code> other asteroids detected:

<pre>
<code>.#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.####<em>#</em>#####...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##
</code>
</pre>


Find the best location for a new monitoring station.  <em>How many other asteroids can be detected from that location?</em>


## --- Part Two ---
Once you give them the coordinates, the Elves quickly deploy an Instant Monitoring Station to the location and discover the worst: there are simply too many asteroids.

The only solution is <em>complete vaporization by giant laser</em>.

Fortunately, in addition to an asteroid scanner, the new monitoring station also comes equipped with a giant rotating laser perfect for vaporizing asteroids. The laser starts by pointing <em>up</em> and always rotates <em>clockwise</em>, vaporizing any asteroid it hits.

If multiple asteroids are <em>exactly</em> in line with the station, the laser only has enough power to vaporize <em>one</em> of them before continuing its rotation. In other words, the same asteroids that can be <em>detected</em> can be vaporized, but if vaporizing one asteroid makes another one detectable, the newly-detected asteroid won't be vaporized until the laser has returned to the same position by rotating a full 360 degrees.

For example, consider the following map, where the asteroid with the new monitoring station (and laser) is marked <code>X</code>:

<pre>
<code>.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##
</code>
</pre>

The first nine asteroids to get vaporized, in order, would be:

<pre>
<code>.#....###<em>2</em><em>4</em>...#..
##...##.<em>1</em><em>3</em>#<em>6</em><em>7</em>..<em>9</em>#
##...#...<em>5</em>.<em>8</em>####.
..#.....X...###..
..#.#.....#....##
</code>
</pre>

Note that some asteroids (the ones behind the asteroids marked <code>1</code>, <code>5</code>, and <code>7</code>) won't have a chance to be vaporized until the next full rotation.  The laser continues rotating; the next nine to be vaporized are:

<pre>
<code>.#....###.....#..
##...##...#.....#
##...#......<em>1</em><em>2</em><em>3</em><em>4</em>.
..#.....X...<em>5</em>##..
..#.<em>9</em>.....<em>8</em>....<em>7</em><em>6</em>
</code>
</pre>

The next nine to be vaporized are then:

<pre>
<code>.<em>8</em>....###.....#..
<em>5</em><em>6</em>...<em>9</em>#...#.....#
<em>3</em><em>4</em>...<em>7</em>...........
..<em>2</em>.....X....##..
..<em>1</em>..............
</code>
</pre>

Finally, the laser completes its first full rotation (<code>1</code> through <code>3</code>), a second rotation (<code>4</code> through <code>8</code>), and vaporizes the last asteroid (<code>9</code>) partway through its third rotation:

<pre>
<code>......<em>2</em><em>3</em><em>4</em>.....<em>6</em>..
......<em>1</em>...<em>5</em>.....<em>7</em>
.................
........X....<em>8</em><em>9</em>..
.................
</code>
</pre>

In the large example above (the one with the best monitoring station location at <code>11,13</code>):


 - The 1st asteroid to be vaporized is at <code>11,12</code>.
 - The 2nd asteroid to be vaporized is at <code>12,1</code>.
 - The 3rd asteroid to be vaporized is at <code>12,2</code>.
 - The 10th asteroid to be vaporized is at <code>12,8</code>.
 - The 20th asteroid to be vaporized is at <code>16,0</code>.
 - The 50th asteroid to be vaporized is at <code>16,9</code>.
 - The 100th asteroid to be vaporized is at <code>10,16</code>.
 - The 199th asteroid to be vaporized is at <code>9,6</code>.
 - <em>The 200th asteroid to be vaporized is at <code>8,2</code>.</em>
 - The 201st asteroid to be vaporized is at <code>10,9</code>.
 - The 299th and final asteroid to be vaporized is at <code>11,1</code>.

The Elves are placing bets on which will be the <em>200th</em> asteroid to be vaporized.  Win the bet by determining which asteroid that will be; <em>what do you get if you multiply its X coordinate by <code>100</code> and then add its Y coordinate?</em> (For example, <code>8,2</code> becomes <em><code>802</code></em>.)


