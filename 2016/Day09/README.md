original source: [https://adventofcode.com/2016/day/9](https://adventofcode.com/2016/day/9)
## --- Day 9: Explosives in Cyberspace ---
Wandering around a secure area, you come across a datalink port to a new part of the network. After briefly scanning it for interesting files, you find one file in particular that catches your attention. It's compressed with an experimental format, but fortunately, the documentation for the format is nearby.

The format compresses a sequence of characters. Whitespace is ignored. To indicate that some sequence should be repeated, a marker is added to the file, like <code>(10x2)</code>. To decompress this marker, take the subsequent <code>10</code> characters and repeat them <code>2</code> times. Then, continue reading the file <em>after</em> the repeated data.  The marker itself is not included in the decompressed output.

If parentheses or other characters appear within the data referenced by a marker, that's okay - treat it like normal data, not a marker, and then resume looking for markers after the decompressed section.

For example:


 - <code>ADVENT</code> contains no markers and decompresses to itself with no changes, resulting in a decompressed length of <code>6</code>.
 - <code>A(1x5)BC</code> repeats only the <code>B</code> a total of <code>5</code> times, becoming <code>ABBBBBC</code> for a decompressed length of <code>7</code>.
 - <code>(3x3)XYZ</code> becomes <code>XYZXYZXYZ</code> for a decompressed length of <code>9</code>.
 - <code>A(2x2)BCD(2x2)EFG</code> doubles the <code>BC</code> and <code>EF</code>, becoming <code>ABCBCDEFEFG</code> for a decompressed length of <code>11</code>.
 - <code>(6x1)(1x3)A</code> simply becomes <code>(1x3)A</code> - the <code>(1x3)</code> looks like a marker, but because it's within a data section of another marker, it is not treated any differently from the <code>A</code> that comes after it. It has a decompressed length of <code>6</code>.
 - <code>X(8x2)(3x3)ABCY</code> becomes <code>X(3x3)ABC(3x3)ABCY</code> (for a decompressed length of <code>18</code>), because the decompressed data from the <code>(8x2)</code> marker (the <code>(3x3)ABC</code>) is skipped and not processed further.

What is the <em>decompressed length</em> of the file (your puzzle input)? Don't count whitespace.


## --- Part Two ---
Apparently, the file actually uses <em>version two</em> of the format.

In version two, the only difference is that markers within decompressed data <em>are</em> decompressed. This, the documentation explains, provides much more substantial compression capabilities, allowing many-gigabyte files to be stored in only a few kilobytes.

For example:


 - <code>(3x3)XYZ</code> still becomes <code>XYZXYZXYZ</code>, as the decompressed section contains no markers.
 - <code>X(8x2)(3x3)ABCY</code> becomes <code>XABCABCABCABCABCABCY</code>, because the decompressed data from the <code>(8x2)</code> marker is then further decompressed, thus triggering the <code>(3x3)</code> marker twice for a total of six <code>ABC</code> sequences.
 - <code>(27x12)(20x12)(13x14)(7x10)(1x12)A</code> decompresses into a string of <code>A</code> repeated <code>241920</code> times.
 - <code>(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN</code> becomes <code>445</code> characters long.

Unfortunately, the computer you brought probably doesn't have enough memory to actually decompress the file; you'll have to <em>come up with another way</em> to get its decompressed length.

What is the <em>decompressed length</em> of the file using this improved format?


