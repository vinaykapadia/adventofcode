original source: [https://adventofcode.com/2019/day/6](https://adventofcode.com/2019/day/6)
## --- Day 6: Universal Orbit Map ---
You've landed at the Universal Orbit Map facility on Mercury.  Because navigation in space often involves transferring between orbits, the orbit maps here are useful for finding efficient routes between, for example, you and Santa. You download a map of the local orbits (your puzzle input).

Except for the universal Center of Mass (<code>COM</code>), every object in space is in orbit around exactly one other object.  An [orbit](https://en.wikipedia.org/wiki/Orbit) looks roughly like this:

<pre>
<code>                  \
                   \
                    |
                    |
AAA--> o            o <--BBB
                    |
                    |
                   /
                  /
</code>
</pre>

In this diagram, the object <code>BBB</code> is in orbit around <code>AAA</code>. The path that <code>BBB</code> takes around <code>AAA</code> (drawn with lines) is only partly shown. In the map data, this orbital relationship is written <code>AAA)BBB</code>, which means "<code>BBB</code> is in orbit around <code>AAA</code>".

Before you use your map data to plot a course, you need to make sure it wasn't corrupted during the download.  To verify maps, the Universal Orbit Map facility uses <em>orbit count checksums</em> - the total number of <em>direct orbits</em> (like the one shown above) and <em>indirect orbits</em>.

	Whenever <code>A</code> orbits <code>B</code> and <code>B</code> orbits <code>C</code>, then <code>A</code> <em>indirectly orbits</em> <code>C</code>.  This chain can be any number of objects long: if <code>A</code> orbits <code>B</code>, <code>B</code> orbits <code>C</code>, and <code>C</code> orbits <code>D</code>, then <code>A</code> indirectly orbits <code>D</code>.

For example, suppose you have the following map:

<pre>
<code>COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
</code>
</pre>

Visually, the above map of orbits looks like this:

<pre>
<code>        G - H       J - K - L
       /           /
COM - B - C - D - E - F
               \
                I
</code>
</pre>

In this visual representation, when two objects are connected by a line, the one on the right directly orbits the one on the left.

Here, we can count the total number of orbits as follows:


 - <code>D</code> directly orbits <code>C</code> and indirectly orbits <code>B</code> and <code>COM</code>, a total of <code>3</code> orbits.
 - <code>L</code> directly orbits <code>K</code> and indirectly orbits <code>J</code>, <code>E</code>, <code>D</code>, <code>C</code>, <code>B</code>, and <code>COM</code>, a total of <code>7</code> orbits.
 - <code>COM</code> orbits nothing.

The total number of direct and indirect orbits in this example is <code><em>42</em></code>.

<em>What is the total number of direct and indirect orbits</em> in your map data?


