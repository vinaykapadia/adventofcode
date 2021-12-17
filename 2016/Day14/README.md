original source: [https://adventofcode.com/2016/day/14](https://adventofcode.com/2016/day/14)
## --- Day 14: One-Time Pad ---
In order to communicate securely with Santa while you're on this mission, you've been using a [one-time pad](https://en.wikipedia.org/wiki/One-time_pad) that you [generate](https://en.wikipedia.org/wiki/Security_through_obscurity) using a pre-agreed algorithm. Unfortunately, you've run out of keys in your one-time pad, and so you need to generate some more.

To generate keys, you first get a stream of random data by taking the [MD5](https://en.wikipedia.org/wiki/MD5) of a pre-arranged [salt](https://en.wikipedia.org/wiki/Salt_(cryptography)) (your puzzle input) and an increasing integer index (starting with <code>0</code>, and represented in decimal); the resulting MD5 hash should be represented as a string of <em>lowercase</em> hexadecimal digits.

However, not all of these MD5 hashes are <em>keys</em>, and you need <code>64</code> new keys for your one-time pad.  A hash is a key <em>only if</em>:


 - It contains <em>three</em> of the same character in a row, like <code>777</code>. Only consider the first such triplet in a hash.
 - One of the next <code>1000</code> hashes in the stream contains that same character <em>five</em> times in a row, like <code>77777</code>.

Considering future hashes for five-of-a-kind sequences does not cause those hashes to be skipped; instead, regardless of whether the current hash is a key, always resume testing for keys starting with the very next hash.

For example, if the pre-arranged salt is <code>abc</code>:


 - The first index which produces a triple is <code>18</code>, because the MD5 hash of <code>abc18</code> contains <code>...cc38887a5...</code>. However, index <code>18</code> does not count as a key for your one-time pad, because none of the next thousand hashes (index <code>19</code> through index <code>1018</code>) contain <code>88888</code>.
 - The next index which produces a triple is <code>39</code>; the hash of <code>abc39</code> contains <code>eee</code>. It is also the first key: one of the next thousand hashes (the one at index 816) contains <code>eeeee</code>.
 - None of the next six triples are keys, but the one after that, at index <code>92</code>, is: it contains <code>999</code> and index <code>200</code> contains <code>99999</code>.
 - Eventually, index <code>22728</code> meets all of the criteria to generate the <code>64</code>th key.

So, using our example salt of <code>abc</code>, index <code>22728</code> produces the <code>64</code>th key.

Given the actual salt in your puzzle input, <em>what index</em> produces your <code>64</code>th one-time pad key?


## --- Part Two ---
Of course, in order to make this process [even more secure](https://en.wikipedia.org/wiki/MD5#Security), you've also implemented [key stretching](https://en.wikipedia.org/wiki/Key_stretching).

Key stretching forces attackers to spend more time generating hashes. Unfortunately, it forces everyone else to spend more time, too.

To implement key stretching, whenever you generate a hash, before you use it, you first find the MD5 hash of that hash, then the MD5 hash of <em>that</em> hash, and so on, a total of <em><code>2016</code> additional hashings</em>. Always use lowercase hexadecimal representations of hashes.

For example, to find the stretched hash for index <code>0</code> and salt <code>abc</code>:


 - Find the MD5 hash of <code>abc0</code>: <code>577571be4de9dcce85a041ba0410f29f</code>.
 - Then, find the MD5 hash of that hash: <code>eec80a0c92dc8a0777c619d9bb51e910</code>.
 - Then, find the MD5 hash of that hash: <code>16062ce768787384c81fe17a7a60c7e3</code>.
 - ...repeat many times...
 - Then, find the MD5 hash of that hash: <code>a107ff634856bb300138cac6568c0f24</code>.

So, the stretched hash for index <code>0</code> in this situation is <code>a107ff...</code>. In the end, you find the original hash (one use of MD5), then find the hash-of-the-previous-hash <code>2016</code> times, for a total of <code>2017</code> uses of MD5.

The rest of the process remains the same, but now the keys are entirely different. Again for salt <code>abc</code>:


 - The first triple (<code>222</code>, at index <code>5</code>) has no matching <code>22222</code> in the next thousand hashes.
 - The second triple (<code>eee</code>, at index <code>10</code>) hash a matching <code>eeeee</code> at index <code>89</code>, and so it is the first key.
 - Eventually, index <code>22551</code> produces the <code>64</code>th key (triple <code>fff</code> with matching <code>fffff</code> at index <code>22859</code>.

Given the actual salt in your puzzle input and using <code>2016</code> extra MD5 calls of key stretching, <em>what index</em> now produces your <code>64</code>th one-time pad key?


