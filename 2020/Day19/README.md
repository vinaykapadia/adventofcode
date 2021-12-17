original source: [https://adventofcode.com/2020/day/19](https://adventofcode.com/2020/day/19)
## --- Day 19: Monster Messages ---
You land in an airport surrounded by dense forest. As you walk to your high-speed train, the Elves at the Mythical Information Bureau contact you again. They think their satellite has collected an image of a <em>sea monster</em>! Unfortunately, the connection to the satellite is having problems, and many of the messages sent back from the satellite have been corrupted.

They sent you a list of <em>the rules valid messages should obey</em> and a list of <em>received messages</em> they've collected so far (your puzzle input).

The <em>rules for valid messages</em> (the top part of your puzzle input) are numbered and build upon each other. For example:

<pre>
<code>0: 1 2
1: "a"
2: 1 3 | 3 1
3: "b"
</code>
</pre>

Some rules, like <code>3: "b"</code>, simply match a single character (in this case, <code>b</code>).

The remaining rules list the sub-rules that must be followed; for example, the rule <code>0: 1 2</code> means that to match rule <code>0</code>, the text being checked must match rule <code>1</code>, and the text after the part that matched rule <code>1</code> must then match rule <code>2</code>.

Some of the rules have multiple lists of sub-rules separated by a pipe (<code>|</code>). This means that <em>at least one</em> list of sub-rules must match. (The ones that match might be different each time the rule is encountered.) For example, the rule <code>2: 1 3 | 3 1</code> means that to match rule <code>2</code>, the text being checked must match rule <code>1</code> followed by rule <code>3</code> <em>or</em> it must match rule <code>3</code> followed by rule <code>1</code>.

Fortunately, there are no loops in the rules, so the list of possible matches will be finite. Since rule <code>1</code> matches <code>a</code> and rule <code>3</code> matches <code>b</code>, rule <code>2</code> matches either <code>ab</code> or <code>ba</code>. Therefore, rule <code>0</code> matches <code>aab</code> or <code>aba</code>.

Here's a more interesting example:

<pre>
<code>0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: "a"
5: "b"
</code>
</pre>

Here, because rule <code>4</code> matches <code>a</code> and rule <code>5</code> matches <code>b</code>, rule <code>2</code> matches two letters that are the same (<code>aa</code> or <code>bb</code>), and rule <code>3</code> matches two letters that are different (<code>ab</code> or <code>ba</code>).

Since rule <code>1</code> matches rules <code>2</code> and <code>3</code> once each in either order, it must match two pairs of letters, one pair with matching letters and one pair with different letters. This leaves eight possibilities: <code>aaab</code>, <code>aaba</code>, <code>bbab</code>, <code>bbba</code>, <code>abaa</code>, <code>abbb</code>, <code>baaa</code>, or <code>babb</code>.

Rule <code>0</code>, therefore, matches <code>a</code> (rule <code>4</code>), then any of the eight options from rule <code>1</code>, then <code>b</code> (rule <code>5</code>): <code>aaaabb</code>, <code>aaabab</code>, <code>abbabb</code>, <code>abbbab</code>, <code>aabaab</code>, <code>aabbbb</code>, <code>abaaab</code>, or <code>ababbb</code>.

The <em>received messages</em> (the bottom part of your puzzle input) need to be checked against the rules so you can determine which are valid and which are corrupted. Including the rules and the messages together, this might look like:

<pre>
<code>0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: "a"
5: "b"

ababbb
bababa
abbbab
aaabbb
aaaabbb
</code>
</pre>

Your goal is to determine <em>the number of messages that completely match rule <code>0</code></em>. In the above example, <code>ababbb</code> and <code>abbbab</code> match, but <code>bababa</code>, <code>aaabbb</code>, and <code>aaaabbb</code> do not, producing the answer <em><code>2</code></em>. The whole message must match all of rule <code>0</code>; there can't be extra unmatched characters in the message. (For example, <code>aaaabbb</code> might appear to match rule <code>0</code> above, but it has an extra unmatched <code>b</code> on the end.)

<em>How many messages completely match rule <code>0</code>?</em>


