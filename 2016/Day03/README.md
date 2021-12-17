original source: [https://adventofcode.com/2016/day/3](https://adventofcode.com/2016/day/3)
## --- Day 3: Squares With Three Sides ---
Now that you can think clearly, you move deeper into the labyrinth of hallways and office furniture that makes up this part of Easter Bunny HQ. This must be a graphic design department; the walls are covered in specifications for triangles.

Or are they?

The design document gives the side lengths of each triangle it describes, but... <code>5 10 25</code>?  Some of these aren't triangles. You can't help but mark the impossible ones.

In a valid triangle, the sum of any two sides must be larger than the remaining side.  For example, the "triangle" given above is impossible, because <code>5 + 10</code> is not larger than <code>25</code>.

In your puzzle input, <em>how many</em> of the listed triangles are <em>possible</em>?


## --- Part Two ---
Now that you've helpfully marked up their design documents, it occurs to you that triangles are specified in groups of three <em>vertically</em>.  Each set of three numbers in a column specifies a triangle.  Rows are unrelated.

For example, given the following specification, numbers with the same hundreds digit would be part of the same triangle:

<pre>
<code>101 301 501
102 302 502
103 303 503
201 401 601
202 402 602
203 403 603
</code>
</pre>

In your puzzle input, and instead reading by columns, <em>how many</em> of the listed triangles are <em>possible</em>?


