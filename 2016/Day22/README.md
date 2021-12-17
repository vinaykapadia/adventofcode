original source: [https://adventofcode.com/2016/day/22](https://adventofcode.com/2016/day/22)
## --- Day 22: Grid Computing ---
You gain access to a massive storage cluster arranged in a grid; each storage node is only connected to the four nodes directly adjacent to it (three if the node is on an edge, two if it's in a corner).

You can directly access data <em>only</em> on node <code>/dev/grid/node-x0-y0</code>, but you can perform some limited actions on the other nodes:


 - You can get the disk usage of all nodes (via [<code>df</code>](https://en.wikipedia.org/wiki/Df_(Unix)#Example)). The result of doing this is in your puzzle input.
 - You can instruct a node to <em>move</em> (not copy) <em>all</em> of its data to an adjacent node (if the destination node has enough space to receive the data). The sending node is left empty after this operation.

Nodes are named by their position: the node named <code>node-x10-y10</code> is adjacent to nodes <code>node-x9-y10</code>, <code>node-x11-y10</code>, <code>node-x10-y9</code>, and <code>node-x10-y11</code>.

Before you begin, you need to understand the arrangement of data on these nodes. Even though you can only move data between directly connected nodes, you're going to need to rearrange a lot of the data to get access to the data you need.  Therefore, you need to work out how you might be able to shift data around.

To do this, you'd like to count the number of <em>viable pairs</em> of nodes.  A viable pair is any two nodes (A,B), <em>regardless of whether they are directly connected</em>, such that:


 - Node A is <em>not</em> empty (its <code>Used</code> is not zero).
 - Nodes A and B are <em>not the same</em> node.
 - The data on node A (its <code>Used</code>) <em>would fit</em> on node B (its <code>Avail</code>).

<em>How many viable pairs</em> of nodes are there?


