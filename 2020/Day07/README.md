original source: [https://adventofcode.com/2020/day/7](https://adventofcode.com/2020/day/7)
## --- Day 7: Handy Haversacks ---
You land at the regional airport in time for your next flight. In fact, it looks like you'll even have time to grab some food: all flights are currently delayed due to <em>issues in luggage processing</em>.

Due to recent aviation regulations, many rules (your puzzle input) are being enforced about bags and their contents; bags must be color-coded and must contain specific quantities of other color-coded bags. Apparently, nobody responsible for these regulations considered how long they would take to enforce!

For example, consider the following rules:

<pre>
<code>light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.
</code>
</pre>

These rules specify the required contents for 9 bag types. In this example, every <code>faded blue</code> bag is empty, every <code>vibrant plum</code> bag contains 11 bags (5 <code>faded blue</code> and 6 <code>dotted black</code>), and so on.

You have a <code><em>shiny gold</em></code> bag. If you wanted to carry it in at least one other bag, how many different bag colors would be valid for the outermost bag? (In other words: how many colors can, eventually, contain at least one <code>shiny gold</code> bag?)

In the above rules, the following options would be available to you:


 - A <code>bright white</code> bag, which can hold your <code>shiny gold</code> bag directly.
 - A <code>muted yellow</code> bag, which can hold your <code>shiny gold</code> bag directly, plus some other bags.
 - A <code>dark orange</code> bag, which can hold <code>bright white</code> and <code>muted yellow</code> bags, either of which could then hold your <code>shiny gold</code> bag.
 - A <code>light red</code> bag, which can hold <code>bright white</code> and <code>muted yellow</code> bags, either of which could then hold your <code>shiny gold</code> bag.

So, in this example, the number of bag colors that can eventually contain at least one <code>shiny gold</code> bag is <code><em>4</em></code>.

<em>How many bag colors can eventually contain at least one <code>shiny gold</code> bag?</em> (The list of rules is quite long; make sure you get all of it.)


