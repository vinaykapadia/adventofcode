original source: [https://adventofcode.com/2015/day/4](https://adventofcode.com/2015/day/4)
## --- Day 4: The Ideal Stocking Stuffer ---
Santa needs help [mining](https://en.wikipedia.org/wiki/Bitcoin#Mining) some AdventCoins (very similar to [bitcoins](https://en.wikipedia.org/wiki/Bitcoin)) to use as gifts for all the economically forward-thinking little girls and boys.

To do this, he needs to find [MD5](https://en.wikipedia.org/wiki/MD5) hashes which, in [hexadecimal](https://en.wikipedia.org/wiki/Hexadecimal), start with at least <em>five zeroes</em>.  The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. To mine AdventCoins, you must find Santa the lowest positive number (no leading zeroes: <code>1</code>, <code>2</code>, <code>3</code>, ...) that produces such a hash.

For example:


 - If your secret key is <code>abcdef</code>, the answer is <code>609043</code>, because the MD5 hash of <code>abcdef609043</code> starts with five zeroes (<code>000001dbbfa...</code>), and it is the lowest such number to do so.
 - If your secret key is <code>pqrstuv</code>, the lowest number it combines with to make an MD5 hash starting with five zeroes is <code>1048970</code>; that is, the MD5 hash of <code>pqrstuv1048970</code> looks like <code>000006136ef...</code>.


## --- Part Two ---
Now find one that starts with <em>six zeroes</em>.


