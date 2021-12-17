original source: [https://adventofcode.com/2016/day/6](https://adventofcode.com/2016/day/6)
## --- Day 6: Signals and Noise ---
Something is jamming your communications with Santa. Fortunately, your signal is only partially jammed, and protocol in situations like this is to switch to a simple [repetition code](https://en.wikipedia.org/wiki/Repetition_code) to get the message through.

In this model, the same message is sent repeatedly.  You've recorded the repeating message signal (your puzzle input), but the data seems quite corrupted - almost too badly to recover. <em>Almost</em>.

All you need to do is figure out which character is most frequent for each position. For example, suppose you had recorded the following messages:

<pre>
<code>eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar
</code>
</pre>

The most common character in the first column is <code>e</code>; in the second, <code>a</code>; in the third, <code>s</code>, and so on. Combining these characters returns the error-corrected message, <code>easter</code>.

Given the recording in your puzzle input, <em>what is the error-corrected version</em> of the message being sent?


## --- Part Two ---
Of course, that <em>would</em> be the message - if you hadn't agreed to use a <em>modified repetition code</em> instead.

In this modified code, the sender instead transmits what looks like random data, but for each character, the character they actually want to send is <em>slightly less likely</em> than the others. Even after signal-jamming noise, you can look at the letter distributions in each column and choose the <em>least common</em> letter to reconstruct the original message.

In the above example, the least common character in the first column is <code>a</code>; in the second, <code>d</code>, and so on. Repeating this process for the remaining characters produces the original message, <code>advent</code>.

Given the recording in your puzzle input and this new decoding methodology, <em>what is the original message</em> that Santa is trying to send?


