original source: [https://adventofcode.com/2017/day/2](https://adventofcode.com/2017/day/2)
## --- Day 2: Corruption Checksum ---
As you walk through the door, a glowing humanoid shape yells in your direction. "You there! Your state appears to be idle. Come help us repair the corruption in this spreadsheet - if we take another millisecond, we'll have to display an hourglass cursor!"

The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's <em>checksum</em>. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.

For example, given the following spreadsheet:

<pre>
<code>5 1 9 5
7 5 3
2 4 6 8</code>
</pre>


 - The first row's largest and smallest values are <code>9</code> and <code>1</code>, and their difference is <code>8</code>.
 - The second row's largest and smallest values are <code>7</code> and <code>3</code>, and their difference is <code>4</code>.
 - The third row's difference is <code>6</code>.

In this example, the spreadsheet's checksum would be <code>8 + 4 + 6 = 18</code>.

<em>What is the checksum</em> for the spreadsheet in your puzzle input?


## --- Part Two ---
"Great work; looks like we're on the right track after all.  Here's a <em>star</em> for your effort." However, the program seems a little worried. Can programs <em>be</em> worried?

"Based on what we're seeing, it looks like all the User wanted is some information about the <em>evenly divisible values</em> in the spreadsheet.  Unfortunately, none of us are equipped for that kind of calculation - most of us specialize in bitwise operations."

It sounds like the goal is to find the only two numbers in each row where one evenly divides the other - that is, where the result of the division operation is a whole number. They would like you to find those numbers on each line, divide them, and add up each line's result.

For example, given the following spreadsheet:

<pre>
<code>5 9 2 8
9 4 7 3
3 8 6 5</code>
</pre>


 - In the first row, the only two numbers that evenly divide are <code>8</code> and <code>2</code>; the result of this division is <code>4</code>.
 - In the second row, the two numbers are <code>9</code> and <code>3</code>; the result is <code>3</code>.
 - In the third row, the result is <code>2</code>.

In this example, the sum of the results would be <code>4 + 3 + 2 = 9</code>.

What is the <em>sum of each row's result</em> in your puzzle input?


