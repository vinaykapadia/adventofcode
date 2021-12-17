original source: [https://adventofcode.com/2016/day/7](https://adventofcode.com/2016/day/7)
## --- Day 7: Internet Protocol Version 7 ---
While snooping around the local network of EBHQ, you compile a list of [IP addresses](https://en.wikipedia.org/wiki/IP_address) (they're IPv7, of course; [IPv6](https://en.wikipedia.org/wiki/IPv6) is much too limited). You'd like to figure out which IPs support <em>TLS</em> (transport-layer snooping).

An IP supports TLS if it has an Autonomous Bridge Bypass Annotation, or <em>ABBA</em>.  An ABBA is any four-character sequence which consists of a pair of two different characters followed by the reverse of that pair, such as <code>xyyx</code> or <code>abba</code>.  However, the IP also must not have an ABBA within any hypernet sequences, which are contained by <em>square brackets</em>.

For example:


 - <code>abba[mnop]qrst</code> supports TLS (<code>abba</code> outside square brackets).
 - <code>abcd[bddb]xyyx</code> does <em>not</em> support TLS (<code>bddb</code> is within square brackets, even though <code>xyyx</code> is outside square brackets).
 - <code>aaaa[qwer]tyui</code> does <em>not</em> support TLS (<code>aaaa</code> is invalid; the interior characters must be different).
 - <code>ioxxoj[asdfgh]zxcvbn</code> supports TLS (<code>oxxo</code> is outside square brackets, even though it's within a larger string).

<em>How many IPs</em> in your puzzle input support TLS?


## --- Part Two ---
You would also like to know which IPs support <em>SSL</em> (super-secret listening).

An IP supports SSL if it has an Area-Broadcast Accessor, or <em>ABA</em>, anywhere in the supernet sequences (outside any square bracketed sections), and a corresponding Byte Allocation Block, or <em>BAB</em>, anywhere in the hypernet sequences. An ABA is any three-character sequence which consists of the same character twice with a different character between them, such as <code>xyx</code> or <code>aba</code>. A corresponding BAB is the same characters but in reversed positions: <code>yxy</code> and <code>bab</code>, respectively.

For example:


 - <code>aba[bab]xyz</code> supports SSL (<code>aba</code> outside square brackets with corresponding <code>bab</code> within square brackets).
 - <code>xyx[xyx]xyx</code> does <em>not</em> support SSL (<code>xyx</code>, but no corresponding <code>yxy</code>).
 - <code>aaa[kek]eke</code> supports SSL (<code>eke</code> in supernet with corresponding <code>kek</code> in hypernet; the <code>aaa</code> sequence is not related, because the interior character must be different).
 - <code>zazbz[bzb]cdb</code> supports SSL (<code>zaz</code> has no corresponding <code>aza</code>, but <code>zbz</code> has a corresponding <code>bzb</code>, even though <code>zaz</code> and <code>zbz</code> overlap).

<em>How many IPs</em> in your puzzle input support SSL?


