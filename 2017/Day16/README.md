original source: [https://adventofcode.com/2017/day/16](https://adventofcode.com/2017/day/16)
## --- Day 16: Permutation Promenade ---
You come upon a very unusual sight; a group of programs here appear to be [dancing](https://www.youtube.com/watch?v=lyZQPjUT5B4&t=53).

There are sixteen programs in total, named <code>a</code> through <code>p</code>. They start by standing in a line: <code>a</code> stands in position <code>0</code>, <code>b</code> stands in position <code>1</code>, and so on until <code>p</code>, which stands in position <code>15</code>.

The programs' <em>dance</em> consists of a sequence of <em>dance moves</em>:


 - <em>Spin</em>, written <code>sX</code>, makes <code>X</code> programs move from the end to the front, but maintain their order otherwise. (For example, <code>s3</code> on <code>abcde</code> produces <code>cdeab</code>).
 - <em>Exchange</em>, written <code>xA/B</code>, makes the programs at positions <code>A</code> and <code>B</code> swap places.
 - <em>Partner</em>, written <code>pA/B</code>, makes the programs named <code>A</code> and <code>B</code> swap places.

For example, with only five programs standing in a line (<code>abcde</code>), they could do the following dance:


 - <code>s1</code>, a spin of size <code>1</code>: <code>eabcd</code>.
 - <code>x3/4</code>, swapping the last two programs: <code>eabdc</code>.
 - <code>pe/b</code>, swapping programs <code>e</code> and <code>b</code>: <code>baedc</code>.

After finishing their dance, the programs end up in order <code>baedc</code>.


You watch the dance for a while and record their dance moves (your puzzle input). <em>In what order are the programs standing</em> after their dance?


## --- Part Two ---
Now that you're starting to get a feel for the dance moves, you turn your attention to <em>the dance as a whole</em>.

Keeping the positions they ended up in from their previous dance, the programs perform it again and again: including the first dance, a total of <em>one billion</em> (<code>1000000000</code>) times.

In the example above, their second dance would <em>begin</em> with the order <code>baedc</code>, and use the same dance moves:


 - <code>s1</code>, a spin of size <code>1</code>: <code>cbaed</code>.
 - <code>x3/4</code>, swapping the last two programs: <code>cbade</code>.
 - <code>pe/b</code>, swapping programs <code>e</code> and <code>b</code>: <code>ceadb</code>.

<em>In what order are the programs standing</em> after their billion dances?


