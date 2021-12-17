original source: [https://adventofcode.com/2015/day/12](https://adventofcode.com/2015/day/12)
## --- Day 12: JSAbacusFramework.io ---
Santa's Accounting-Elves need help balancing the books after a recent order.  Unfortunately, their accounting software uses a peculiar storage format.  That's where you come in.

They have a [JSON](http://json.org/) document which contains a variety of things: arrays (<code>[1,2,3]</code>), objects (<code>{"a":1, "b":2}</code>), numbers, and strings.  Your first job is to simply find all of the <em>numbers</em> throughout the document and add them together.

For example:


 - <code>[1,2,3]</code> and <code>{"a":2,"b":4}</code> both have a sum of <code>6</code>.
 - <code>[[[3]]]</code> and <code>{"a":{"b":4},"c":-1}</code> both have a sum of <code>3</code>.
 - <code>{"a":[-1,1]}</code> and <code>[-1,{"a":1}]</code> both have a sum of <code>0</code>.
 - <code>[]</code> and <code>{}</code> both have a sum of <code>0</code>.

You will not encounter any strings containing numbers.

What is the <em>sum of all numbers</em> in the document?


## --- Part Two ---
Uh oh - the Accounting-Elves have realized that they double-counted everything <em>red</em>.

Ignore any object (and all of its children) which has any property with the value <code>"red"</code>.  Do this only for objects (<code>{...}</code>), not arrays (<code>[...]</code>).


 - <code>[1,2,3]</code> still has a sum of <code>6</code>.
 - <code>[1,{"c":"red","b":2},3]</code> now has a sum of <code>4</code>, because the middle object is ignored.
 - <code>{"d":"red","e":[1,2,3,4],"f":5}</code> now has a sum of <code>0</code>, because the entire structure is ignored.
 - <code>[1,"red",5]</code> has a sum of <code>6</code>, because <code>"red"</code> in an array has no effect.


