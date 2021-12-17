original source: [https://adventofcode.com/2017/day/4](https://adventofcode.com/2017/day/4)
## --- Day 4: High-Entropy Passphrases ---
A new system policy has been put in place that requires all accounts to use a <em>passphrase</em> instead of simply a pass<em>word</em>. A passphrase consists of a series of words (lowercase letters) separated by spaces.

To ensure security, a valid passphrase must contain no duplicate words.

For example:


 - <code>aa bb cc dd ee</code> is valid.
 - <code>aa bb cc dd aa</code> is not valid - the word <code>aa</code> appears more than once.
 - <code>aa bb cc dd aaa</code> is valid - <code>aa</code> and <code>aaa</code> count as different words.

The system's full passphrase list is available as your puzzle input. <em>How many passphrases are valid?</em>


## --- Part Two ---
For added security, yet another system policy has been put in place.  Now, a valid passphrase must contain no two words that are anagrams of each other - that is, a passphrase is invalid if any word's letters can be rearranged to form any other word in the passphrase.

For example:


 - <code>abcde fghij</code> is a valid passphrase.
 - <code>abcde xyz ecdab</code> is not valid - the letters from the third word can be rearranged to form the first word.
 - <code>a ab abc abd abf abj</code> is a valid passphrase, because <em>all</em> letters need to be used when forming another word.
 - <code>iiii oiii ooii oooi oooo</code> is valid.
 - <code>oiii ioii iioi iiio</code> is not valid - any of these words can be rearranged to form any other word.

Under this new system policy, <em>how many passphrases are valid?</em>


