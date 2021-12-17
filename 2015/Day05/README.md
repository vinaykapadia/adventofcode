original source: [https://adventofcode.com/2015/day/5](https://adventofcode.com/2015/day/5)
## --- Day 5: Doesn't He Have Intern-Elves For This? ---
Santa needs help figuring out which strings in his text file are naughty or nice.

A <em>nice string</em> is one with all of the following properties:


 - It contains at least three vowels (<code>aeiou</code> only), like <code>aei</code>, <code>xazegov</code>, or <code>aeiouaeiouaeiou</code>.
 - It contains at least one letter that appears twice in a row, like <code>xx</code>, <code>abcdde</code> (<code>dd</code>), or <code>aabbccdd</code> (<code>aa</code>, <code>bb</code>, <code>cc</code>, or <code>dd</code>).
 - It does <em>not</em> contain the strings <code>ab</code>, <code>cd</code>, <code>pq</code>, or <code>xy</code>, even if they are part of one of the other requirements.

For example:


 - <code>ugknbfddgicrmopn</code> is nice because it has at least three vowels (<code>u...i...o...</code>), a double letter (<code>...dd...</code>), and none of the disallowed substrings.
 - <code>aaa</code> is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
 - <code>jchzalrnumimnmhp</code> is naughty because it has no double letter.
 - <code>haegwjzuvuyypxyu</code> is naughty because it contains the string <code>xy</code>.
 - <code>dvszwmarrgswjxmb</code> is naughty because it contains only one vowel.

How many strings are nice?


## --- Part Two ---
Realizing the error of his ways, Santa has switched to a better model of determining whether a string is naughty or nice.  None of the old rules apply, as they are all clearly ridiculous.

Now, a nice string is one with all of the following properties:


 - It contains a pair of any two letters that appears at least twice in the string without overlapping, like <code>xyxy</code> (<code>xy</code>) or <code>aabcdefgaa</code> (<code>aa</code>), but not like <code>aaa</code> (<code>aa</code>, but it overlaps).
 - It contains at least one letter which repeats with exactly one letter between them, like <code>xyx</code>, <code>abcdefeghi</code> (<code>efe</code>), or even <code>aaa</code>.

For example:


 - <code>qjhvhtzxzqqjkmpb</code> is nice because is has a pair that appears twice (<code>qj</code>) and a letter that repeats with exactly one letter between them (<code>zxz</code>).
 - <code>xxyxx</code> is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
 - <code>uurcxstgmygtbstg</code> is naughty because it has a pair (<code>tg</code>) but no repeat with a single letter between them.
 - <code>ieodomkazucvgmuy</code> is naughty because it has a repeating letter with one between (<code>odo</code>), but no pair that appears twice.

How many strings are nice under these new rules?


