original source: [https://adventofcode.com/2015/day/9](https://adventofcode.com/2015/day/9)
## --- Day 9: All in a Single Night ---
Every year, Santa manages to deliver all of his presents in a single night.

This year, however, he has some new locations to visit; his elves have provided him the distances between every pair of locations.  He can start and end at any two (different) locations he wants, but he must visit each location exactly once.  What is the <em>shortest distance</em> he can travel to achieve this?

For example, given the following distances:

<pre>
<code>London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141
</code>
</pre>

The possible routes are therefore:

<pre>
<code>Dublin -> London -> Belfast = 982
London -> Dublin -> Belfast = 605
London -> Belfast -> Dublin = 659
Dublin -> Belfast -> London = 659
Belfast -> Dublin -> London = 605
Belfast -> London -> Dublin = 982
</code>
</pre>

The shortest of these is <code>London -> Dublin -> Belfast = 605</code>, and so the answer is <code>605</code> in this example.

What is the distance of the shortest route?


## --- Part Two ---
The next year, just to show off, Santa decides to take the route with the <em>longest distance</em> instead.

He can still start and end at any two (different) locations he wants, and he still must visit each location exactly once.

For example, given the distances above, the longest route would be <code>982</code> via (for example) <code>Dublin -> London -> Belfast</code>.

What is the distance of the longest route?


