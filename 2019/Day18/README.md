original source: [https://adventofcode.com/2019/day/18](https://adventofcode.com/2019/day/18)
## --- Day 18: Many-Worlds Interpretation ---
As you approach Neptune, a planetary security system detects you and activates a giant [tractor beam](https://en.wikipedia.org/wiki/Tractor_beam) on [Triton](https://en.wikipedia.org/wiki/Triton_(moon))!  You have no choice but to land.

A scan of the local area reveals only one interesting feature: a massive underground vault.  You generate a map of the tunnels (your puzzle input).  The tunnels are too narrow to move diagonally.

Only one <em>entrance</em> (marked <code>@</code>) is present among the <em>open passages</em> (marked <code>.</code>) and <em>stone walls</em> (<code>#</code>), but you also detect an assortment of <em>keys</em> (shown as lowercase letters) and <em>doors</em> (shown as uppercase letters). Keys of a given letter open the door of the same letter: <code>a</code> opens <code>A</code>, <code>b</code> opens <code>B</code>, and so on.  You aren't sure which key you need to disable the tractor beam, so you'll need to <em>collect all of them</em>.

For example, suppose you have the following map:

<pre>
<code>#########
#b.A.@.a#
#########
</code>
</pre>

Starting from the entrance (<code>@</code>), you can only access a large door (<code>A</code>) and a key (<code>a</code>). Moving toward the door doesn't help you, but you can move <code>2</code> steps to collect the key, unlocking <code>A</code> in the process:

<pre>
<code>#########
#b.....@#
#########
</code>
</pre>

Then, you can move <code>6</code> steps to collect the only other key, <code>b</code>:

<pre>
<code>#########
#@......#
#########
</code>
</pre>

So, collecting every key took a total of <code><em>8</em></code> steps.

Here is a larger example:

<pre>
<code>########################
#f.D.E.e.C.b.A.@.a.B.c.#
######################.#
#d.....................#
########################
</code>
</pre>

The only reasonable move is to take key <code>a</code> and unlock door <code>A</code>:

<pre>
<code>########################
#f.D.E.e.C.b.....@.B.c.#
######################.#
#d.....................#
########################
</code>
</pre>

Then, do the same with key <code>b</code>:

<pre>
<code>########################
#f.D.E.e.C.@.........c.#
######################.#
#d.....................#
########################
</code>
</pre>

...and the same with key <code>c</code>:

<pre>
<code>########################
#f.D.E.e.............@.#
######################.#
#d.....................#
########################
</code>
</pre>

Now, you have a choice between keys <code>d</code> and <code>e</code>.  While key <code>e</code> is closer, collecting it now would be slower in the long run than collecting key <code>d</code> first, so that's the best choice:

<pre>
<code>########################
#f...E.e...............#
######################.#
#@.....................#
########################
</code>
</pre>

Finally, collect key <code>e</code> to unlock door <code>E</code>, then collect key <code>f</code>, taking a grand total of <code><em>86</em></code> steps.

Here are a few more examples:


 - <pre>
<code>########################
#...............b.C.D.f#
#.######################
#.....@.a.B.c.d.A.e.F.g#
########################
</code>
</pre>

Shortest path is <code>132</code> steps: <code>b</code>, <code>a</code>, <code>c</code>, <code>d</code>, <code>f</code>, <code>e</code>, <code>g</code>

 - <pre>
<code>#################
#i.G..c...e..H.p#
########.########
#j.A..b...f..D.o#
########@########
#k.E..a...g..B.n#
########.########
#l.F..d...h..C.m#
#################
</code>
</pre>

Shortest paths are <code>136</code> steps;
one is: <code>a</code>, <code>f</code>, <code>b</code>, <code>j</code>, <code>g</code>, <code>n</code>, <code>h</code>, <code>d</code>, <code>l</code>, <code>o</code>, <code>e</code>, <code>p</code>, <code>c</code>, <code>i</code>, <code>k</code>, <code>m</code>

 - <pre>
<code>########################
#@..............ac.GI.b#
###d#e#f################
###A#B#C################
###g#h#i################
########################
</code>
</pre>

Shortest paths are <code>81</code> steps; one is: <code>a</code>, <code>c</code>, <code>f</code>, <code>i</code>, <code>d</code>, <code>g</code>, <code>b</code>, <code>e</code>, <code>h</code>


<em>How many steps is the shortest path that collects all of the keys?</em>


