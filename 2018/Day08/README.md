original source: [https://adventofcode.com/2018/day/8](https://adventofcode.com/2018/day/8)
## --- Day 8: Memory Maneuver ---
The sleigh is much easier to pull than you'd expect for something its weight. Unfortunately, neither you nor the Elves know which way the North Pole is from here.

You check your wrist device for anything that might help.  It seems to have some kind of navigation system!  Activating the navigation system produces more bad news: "Failed to start navigation system. Could not read software license file."

The navigation system's license file consists of a list of numbers (your puzzle input).  The numbers define a data structure which, when processed, produces some kind of [tree](https://en.wikipedia.org/wiki/Tree_(data_structure)) that can be used to calculate the license number.

The <em>tree</em> is made up of <em>nodes</em>; a single, outermost node forms the tree's <em>root</em>, and it contains all other nodes in the tree (or contains nodes that contain nodes, and so on).

Specifically, a node consists of:


 - A <em>header</em>, which is always exactly two numbers:

 - The quantity of child nodes.
 - The quantity of metadata entries.

 - Zero or more <em>child nodes</em> (as specified in the header).
 - One or more <em>metadata entries</em> (as specified in the header).

Each child node is itself a node that has its own header, child nodes, and metadata. For example:

<pre>
<code>2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2
A----------------------------------
    B----------- C-----------
                     D-----
</code>
</pre>

In this example, each node of the tree is also marked with an underline starting with a letter for easier identification. In it, there are four nodes:


 - <code>A</code>, which has <code>2</code> child nodes (<code>B</code>, <code>C</code>) and <code>3</code> metadata entries (<code>1</code>, <code>1</code>, <code>2</code>).
 - <code>B</code>, which has <code>0</code> child nodes and <code>3</code> metadata entries (<code>10</code>, <code>11</code>, <code>12</code>).
 - <code>C</code>, which has <code>1</code> child node (<code>D</code>) and <code>1</code> metadata entry (<code>2</code>).
 - <code>D</code>, which has <code>0</code> child nodes and <code>1</code> metadata entry (<code>99</code>).

The first check done on the license file is to simply add up all of the metadata entries.  In this example, that sum is <code>1+1+2+10+11+12+2+99=<em>138</em></code>.

<em>What is the sum of all metadata entries?</em>


