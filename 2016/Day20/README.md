original source: [https://adventofcode.com/2016/day/20](https://adventofcode.com/2016/day/20)
## --- Day 20: Firewall Rules ---
You'd like to set up a small hidden computer here so you can use it to get back into the network later. However, the corporate firewall only allows communication with certain external [IP addresses](https://en.wikipedia.org/wiki/IPv4#Addressing).

You've retrieved the list of blocked IPs from the firewall, but the list seems to be messy and poorly maintained, and it's not clear which IPs are allowed. Also, rather than being written in [dot-decimal](https://en.wikipedia.org/wiki/Dot-decimal_notation) notation, they are written as plain [32-bit integers](https://en.wikipedia.org/wiki/32-bit), which can have any value from <code>0</code> through <code>4294967295</code>, inclusive.

For example, suppose only the values <code>0</code> through <code>9</code> were valid, and that you retrieved the following blacklist:

<pre>
<code>5-8
0-2
4-7
</code>
</pre>

The blacklist specifies ranges of IPs (inclusive of both the start and end value) that are <em>not</em> allowed. Then, the only IPs that this firewall allows are <code>3</code> and <code>9</code>, since those are the only numbers not in any range.

Given the list of blocked IPs you retrieved from the firewall (your puzzle input), <em>what is the lowest-valued IP</em> that is not blocked?


