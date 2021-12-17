original source: [https://adventofcode.com/2017/day/9](https://adventofcode.com/2017/day/9)
## --- Day 9: Stream Processing ---
A large stream blocks your path. According to the locals, it's not safe to cross the stream at the moment because it's full of <em>garbage</em>. You look down at the stream; rather than water, you discover that it's a <em>stream of characters</em>.

You sit for a while and record part of the stream (your puzzle input). The characters represent <em>groups</em> - sequences that begin with <code>{</code> and end with <code>}</code>. Within a group, there are zero or more other things, separated by commas: either another <em>group</em> or <em>garbage</em>. Since groups can contain other groups, a <code>}</code> only closes the <em>most-recently-opened unclosed group</em> - that is, they are nestable. Your puzzle input represents a single, large group which itself contains many smaller ones.

Sometimes, instead of a group, you will find <em>garbage</em>. Garbage begins with <code><</code> and ends with <code>></code>. Between those angle brackets, almost any character can appear, including <code>{</code> and <code>}</code>. <em>Within</em> garbage, <code><</code> has no special meaning.

In a futile attempt to clean up the garbage, some program has <em>canceled</em> some of the characters within it using <code>!</code>: inside garbage, <em>any</em> character that comes after <code>!</code> should be <em>ignored</em>, including <code><</code>, <code>></code>, and even another <code>!</code>.

You don't see any characters that deviate from these rules.  Outside garbage, you only find well-formed groups, and garbage always terminates according to the rules above.

Here are some self-contained pieces of garbage:


 - <code><></code>, empty garbage.
 - <code><random characters></code>, garbage containing random characters.
 - <code><<<<></code>, because the extra <code><</code> are ignored.
 - <code><{!>}></code>, because the first <code>></code> is canceled.
 - <code><!!></code>, because the second <code>!</code> is canceled, allowing the <code>></code> to terminate the garbage.
 - <code><!!!>></code>, because the second <code>!</code> and the first <code>></code> are canceled.
 - <code><{o"i!a,<{i<a></code>, which ends at the first <code>></code>.

Here are some examples of whole streams and the number of groups they contain:


 - <code>{}</code>, <code>1</code> group.
 - <code>{{{}}}</code>, <code>3</code> groups.
 - <code>{{},{}}</code>, also <code>3</code> groups.
 - <code>{{{},{},{{}}}}</code>, <code>6</code> groups.
 - <code>{<{},{},{{}}>}</code>, <code>1</code> group (which itself contains garbage).
 - <code>{<a>,<a>,<a>,<a>}</code>, <code>1</code> group.
 - <code>{{<a>},{<a>},{<a>},{<a>}}</code>, <code>5</code> groups.
 - <code>{{<!>},{<!>},{<!>},{<a>}}</code>, <code>2</code> groups (since all but the last <code>></code> are canceled).

Your goal is to find the total score for all groups in your input. Each group is assigned a <em>score</em> which is one more than the score of the group that immediately contains it. (The outermost group gets a score of <code>1</code>.)


 - <code>{}</code>, score of <code>1</code>.
 - <code>{{{}}}</code>, score of <code>1 + 2 + 3 = 6</code>.
 - <code>{{},{}}</code>, score of <code>1 + 2 + 2 = 5</code>.
 - <code>{{{},{},{{}}}}</code>, score of <code>1 + 2 + 3 + 3 + 3 + 4 = 16</code>.
 - <code>{<a>,<a>,<a>,<a>}</code>, score of <code>1</code>.
 - <code>{{<ab>},{<ab>},{<ab>},{<ab>}}</code>, score of <code>1 + 2 + 2 + 2 + 2 = 9</code>.
 - <code>{{<!!>},{<!!>},{<!!>},{<!!>}}</code>, score of <code>1 + 2 + 2 + 2 + 2 = 9</code>.
 - <code>{{<a!>},{<a!>},{<a!>},{<ab>}}</code>, score of <code>1 + 2 = 3</code>.

<em>What is the total score</em> for all groups in your input?


## --- Part Two ---
Now, you're ready to remove the garbage.

To prove you've removed it, you need to count all of the characters within the garbage.  The leading and trailing <code><</code> and <code>></code> don't count, nor do any canceled characters or the <code>!</code> doing the canceling.


 - <code><></code>, <code>0</code> characters.
 - <code><random characters></code>, <code>17</code> characters.
 - <code><<<<></code>, <code>3</code> characters.
 - <code><{!>}></code>, <code>2</code> characters.
 - <code><!!></code>, <code>0</code> characters.
 - <code><!!!>></code>, <code>0</code> characters.
 - <code><{o"i!a,<{i<a></code>, <code>10</code> characters.

<em>How many non-canceled characters are within the garbage</em> in your puzzle input?


