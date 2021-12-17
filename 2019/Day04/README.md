original source: [https://adventofcode.com/2019/day/4](https://adventofcode.com/2019/day/4)
## --- Day 4: Secure Container ---
You arrive at the Venus fuel depot only to discover it's protected by a password.  The Elves had written the password on a sticky note, but someone threw it out.

However, they do remember a few key facts about the password:


 - It is a six-digit number.
 - The value is within the range given in your puzzle input.
 - Two adjacent digits are the same (like <code>22</code> in <code>1<em>22</em>345</code>).
 - Going from left to right, the digits <em>never decrease</em>; they only ever increase or stay the same (like <code>111123</code> or <code>135679</code>).

Other than the range rule, the following are true:


 - <code>111111</code> meets these criteria (double <code>11</code>, never decreases).
 - <code>2234<em>50</em></code> does not meet these criteria (decreasing pair of digits <code>50</code>).
 - <code>123789</code> does not meet these criteria (no double).

<em>How many different passwords</em> within the range given in your puzzle input meet these criteria?


## --- Part Two ---
An Elf just remembered one more important detail: the two adjacent matching digits <em>are not part of a larger group of matching digits</em>.

Given this additional criterion, but still ignoring the range rule, the following are now true:


 - <code>112233</code> meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
 - <code>123<em>444</em></code> no longer meets the criteria (the repeated <code>44</code> is part of a larger group of <code>444</code>).
 - <code>111122</code> meets the criteria (even though <code>1</code> is repeated more than twice, it still contains a double <code>22</code>).

<em>How many different passwords</em> within the range given in your puzzle input meet all of the criteria?


