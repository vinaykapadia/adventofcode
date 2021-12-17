original source: [https://adventofcode.com/2015/day/11](https://adventofcode.com/2015/day/11)
## --- Day 11: Corporate Policy ---
Santa's previous password expired, and he needs help choosing a new one.

To help him remember his new password after the old one expires, Santa has devised a method of coming up with a password based on the previous one.  Corporate policy dictates that passwords must be exactly eight lowercase letters (for security reasons), so he finds his new password by <em>incrementing</em> his old password string repeatedly until it is valid.

Incrementing is just like counting with numbers: <code>xx</code>, <code>xy</code>, <code>xz</code>, <code>ya</code>, <code>yb</code>, and so on. Increase the rightmost letter one step; if it was <code>z</code>, it wraps around to <code>a</code>, and repeat with the next letter to the left until one doesn't wrap around.

Unfortunately for Santa, a new Security-Elf recently started, and he has imposed some additional password requirements:


 - Passwords must include one increasing straight of at least three letters, like <code>abc</code>, <code>bcd</code>, <code>cde</code>, and so on, up to <code>xyz</code>. They cannot skip letters; <code>abd</code> doesn't count.
 - Passwords may not contain the letters <code>i</code>, <code>o</code>, or <code>l</code>, as these letters can be mistaken for other characters and are therefore confusing.
 - Passwords must contain at least two different, non-overlapping pairs of letters, like <code>aa</code>, <code>bb</code>, or <code>zz</code>.

For example:


 - <code>hijklmmn</code> meets the first requirement (because it contains the straight <code>hij</code>) but fails the second requirement requirement (because it contains <code>i</code> and <code>l</code>).
 - <code>abbceffg</code> meets the third requirement (because it repeats <code>bb</code> and <code>ff</code>) but fails the first requirement.
 - <code>abbcegjk</code> fails the third requirement, because it only has one double letter (<code>bb</code>).
 - The next password after <code>abcdefgh</code> is <code>abcdffaa</code>.
 - The next password after <code>ghijklmn</code> is <code>ghjaabcc</code>, because you eventually skip all the passwords that start with <code>ghi...</code>, since <code>i</code> is not allowed.

Given Santa's current password (your puzzle input), what should his <em>next password</em> be?


## --- Part Two ---
Santa's password expired again.  What's the next one?


