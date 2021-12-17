original source: [https://adventofcode.com/2015/day/8](https://adventofcode.com/2015/day/8)
## --- Day 8: Matchsticks ---
Space on the sleigh is limited this year, and so Santa will be bringing his list as a digital copy. He needs to know how much space it will take up when stored.

It is common in many programming languages to provide a way to escape special characters in strings.  For example, [C](https://en.wikipedia.org/wiki/Escape_sequences_in_C), [JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String), [Perl](http://perldoc.perl.org/perlop.html#Quote-and-Quote-like-Operators), [Python](https://docs.python.org/2.0/ref/strings.html), and even [PHP](http://php.net/manual/en/language.types.string.php#language.types.string.syntax.double) handle special characters in very similar ways.

However, it is important to realize the difference between the number of characters <em>in the code representation of the string literal</em> and the number of characters <em>in the in-memory string itself</em>.

For example:


 - <code>""</code> is <code>2</code> characters of code (the two double quotes), but the string contains zero characters.
 - <code>"abc"</code> is <code>5</code> characters of code, but <code>3</code> characters in the string data.
 - <code>"aaa\"aaa"</code> is <code>10</code> characters of code, but the string itself contains six "a" characters and a single, escaped quote character, for a total of <code>7</code> characters in the string data.
 - <code>"\x27"</code> is <code>6</code> characters of code, but the string itself contains just one - an apostrophe (<code>'</code>), escaped using hexadecimal notation.

Santa's list is a file that contains many double-quoted string literals, one on each line.  The only escape sequences used are <code>\\</code> (which represents a single backslash), <code>\"</code> (which represents a lone double-quote character), and <code>\x</code> plus two hexadecimal characters (which represents a single character with that ASCII code).

Disregarding the whitespace in the file, what is <em>the number of characters of code for string literals</em> minus <em>the number of characters in memory for the values of the strings</em> in total for the entire file?

For example, given the four strings above, the total number of characters of string code (<code>2 + 5 + 10 + 6 = 23</code>) minus the total number of characters in memory for string values (<code>0 + 3 + 7 + 1 = 11</code>) is <code>23 - 11 = 12</code>.


## --- Part Two ---
Now, let's go the other way.  In addition to finding the number of characters of code, you should now <em>encode each code representation as a new string</em> and find the number of characters of the new encoded representation, including the surrounding double quotes.

For example:


 - <code>""</code> encodes to <code>"\"\""</code>, an increase from <code>2</code> characters to <code>6</code>.
 - <code>"abc"</code> encodes to <code>"\"abc\""</code>, an increase from <code>5</code> characters to <code>9</code>.
 - <code>"aaa\"aaa"</code> encodes to <code>"\"aaa\\\"aaa\""</code>, an increase from <code>10</code> characters to <code>16</code>.
 - <code>"\x27"</code> encodes to <code>"\"\\x27\""</code>, an increase from <code>6</code> characters to <code>11</code>.

Your task is to find <em>the total number of characters to represent the newly encoded strings</em> minus <em>the number of characters of code in each original string literal</em>. For example, for the strings above, the total encoded length (<code>6 + 9 + 16 + 11 = 42</code>) minus the characters in the original code representation (<code>23</code>, just like in the first part of this puzzle) is <code>42 - 23 = 19</code>.


