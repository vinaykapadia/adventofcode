original source: [https://adventofcode.com/2017/day/12](https://adventofcode.com/2017/day/12)
## --- Day 12: Digital Plumber ---
Walking along the memory banks of the stream, you find a small village that is experiencing a little confusion: some programs can't communicate with each other.

Programs in this village communicate using a fixed system of <em>pipes</em>. Messages are passed between programs using these pipes, but most programs aren't connected to each other directly.  Instead, programs pass messages between each other until the message reaches the intended recipient.

For some reason, though, some of these messages aren't ever reaching their intended recipient, and the programs suspect that some pipes are missing. They would like you to investigate.

You walk through the village and record the ID of each program and the IDs with which it can communicate directly (your puzzle input). Each program has one or more programs with which it can communicate, and these pipes are bidirectional; if <code>8</code> says it can communicate with <code>11</code>, then <code>11</code> will say it can communicate with <code>8</code>.

You need to figure out how many programs are in the group that contains program ID <code>0</code>.

For example, suppose you go door-to-door like a travelling salesman and record the following list:

<pre>
<code>0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5
</code>
</pre>

In this example, the following programs are in the group that contains program ID <code>0</code>:


 - Program <code>0</code> by definition.
 - Program <code>2</code>, directly connected to program <code>0</code>.
 - Program <code>3</code> via program <code>2</code>.
 - Program <code>4</code> via program <code>2</code>.
 - Program <code>5</code> via programs <code>6</code>, then <code>4</code>, then <code>2</code>.
 - Program <code>6</code> via programs <code>4</code>, then <code>2</code>.

Therefore, a total of <code>6</code> programs are in this group; all but program <code>1</code>, which has a pipe that connects it to itself.

<em>How many programs</em> are in the group that contains program ID <code>0</code>?


## --- Part Two ---
There are more programs than just the ones in the group containing program ID <code>0</code>. The rest of them have no way of reaching that group, and still might have no way of reaching each other.

A <em>group</em> is a collection of programs that can all communicate via pipes either directly or indirectly. The programs you identified just a moment ago are all part of the same group. Now, they would like you to determine the total number of groups.

In the example above, there were <code>2</code> groups: one consisting of programs <code>0,2,3,4,5,6</code>, and the other consisting solely of program <code>1</code>.

<em>How many groups are there</em> in total?


