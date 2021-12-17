original source: [https://adventofcode.com/2017/day/14](https://adventofcode.com/2017/day/14)
## --- Day 14: Disk Defragmentation ---
Suddenly, a scheduled job activates the system's [disk defragmenter](https://en.wikipedia.org/wiki/Defragmentation). Were the situation different, you might [sit and watch it for a while](https://www.youtube.com/watch?v=kPv1gQ5Rs8A&t=37), but today, you just don't have that kind of time. It's soaking up valuable system resources that are needed elsewhere, and so the only option is to help it finish its task as soon as possible.

The disk in question consists of a 128x128 grid; each square of the grid is either <em>free</em> or <em>used</em>. On this disk, the state of the grid is tracked by the bits in a sequence of [knot hashes](10).

A total of 128 knot hashes are calculated, each corresponding to a single row in the grid; each hash contains 128 bits which correspond to individual grid squares. Each bit of a hash indicates whether that square is <em>free</em> (<code>0</code>) or <em>used</em> (<code>1</code>).

The hash inputs are a key string (your puzzle input), a dash, and a number from <code>0</code> to <code>127</code> corresponding to the row.  For example, if your key string were <code>flqrgnkx</code>, then the first row would be given by the bits of the knot hash of <code>flqrgnkx-0</code>, the second row from the bits of the knot hash of <code>flqrgnkx-1</code>, and so on until the last row, <code>flqrgnkx-127</code>.

The output of a knot hash is traditionally represented by 32 hexadecimal digits; each of these digits correspond to 4 bits, for a total of <code>4 * 32 = 128</code> bits. To convert to bits, turn each hexadecimal digit to its equivalent binary value, high-bit first: <code>0</code> becomes <code>0000</code>, <code>1</code> becomes <code>0001</code>, <code>e</code> becomes <code>1110</code>, <code>f</code> becomes <code>1111</code>, and so on; a hash that begins with <code>a0c2017...</code> in hexadecimal would begin with <code>10100000110000100000000101110000...</code> in binary.

Continuing this process, the <em>first 8 rows and columns</em> for key <code>flqrgnkx</code> appear as follows, using <code>#</code> to denote used squares, and <code>.</code> to denote free ones:

<pre>
<code>##.#.#..-->
.#.#.#.#   
....#.#.   
#.#.##.#   
.##.#...   
##..#..#   
.#...#..   
##.#.##.-->
|      |   
V      V   
</code>
</pre>

In this example, <code>8108</code> squares are used across the entire 128x128 grid.

Given your actual key string, <em>how many squares are used</em>?


## --- Part Two ---
Now, all the defragmenter needs to know is the number of <em>regions</em>. A region is a group of <em>used</em> squares that are all <em>adjacent</em>, not including diagonals. Every used square is in exactly one region: lone used squares form their own isolated regions, while several adjacent squares all count as a single region.

In the example above, the following nine regions are visible, each marked with a distinct digit:

<pre>
<code>11.2.3..-->
.1.2.3.4   
....5.6.   
7.8.55.9   
.88.5...   
88..5..8   
.8...8..   
88.8.88.-->
|      |   
V      V   
</code>
</pre>

Of particular interest is the region marked <code>8</code>; while it does not appear contiguous in this small view, all of the squares marked <code>8</code> are connected when considering the whole 128x128 grid. In total, in this example, <code>1242</code> regions are present.

<em>How many regions</em> are present given your key string?


