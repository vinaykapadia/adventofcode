original source: [https://adventofcode.com/2017/day/6](https://adventofcode.com/2017/day/6)
## --- Day 6: Memory Reallocation ---
A debugger program here is having an issue: it is trying to repair a memory reallocation routine, but it keeps getting stuck in an infinite loop.

In this area, there are sixteen memory banks; each memory bank can hold any number of <em>blocks</em>. The goal of the reallocation routine is to balance the blocks between the memory banks.

The reallocation routine operates in cycles. In each cycle, it finds the memory bank with the most blocks (ties won by the lowest-numbered memory bank) and redistributes those blocks among the banks. To do this, it removes all of the blocks from the selected bank, then moves to the next (by index) memory bank and inserts one of the blocks. It continues doing this until it runs out of blocks; if it reaches the last memory bank, it wraps around to the first one.

The debugger would like to know how many redistributions can be done before a blocks-in-banks configuration is produced that <em>has been seen before</em>.

For example, imagine a scenario with only four memory banks:


 - The banks start with <code>0</code>, <code>2</code>, <code>7</code>, and <code>0</code> blocks. The third bank has the most blocks, so it is chosen for redistribution.
 - Starting with the next bank (the fourth bank) and then continuing to the first bank, the second bank, and so on, the <code>7</code> blocks are spread out over the memory banks. The fourth, first, and second banks get two blocks each, and the third bank gets one back. The final result looks like this: <code>2 4 1 2</code>.
 - Next, the second bank is chosen because it contains the most blocks (four). Because there are four memory banks, each gets one block. The result is: <code>3 1 2 3</code>.
 - Now, there is a tie between the first and fourth memory banks, both of which have three blocks. The first bank wins the tie, and its three blocks are distributed evenly over the other three banks, leaving it with none: <code>0 2 3 4</code>.
 - The fourth bank is chosen, and its four blocks are distributed such that each of the four banks receives one: <code>1 3 4 1</code>.
 - The third bank is chosen, and the same thing happens: <code>2 4 1 2</code>.

At this point, we've reached a state we've seen before: <code>2 4 1 2</code> was already seen. The infinite loop is detected after the fifth block redistribution cycle, and so the answer in this example is <code>5</code>.

Given the initial block counts in your puzzle input, <em>how many redistribution cycles</em> must be completed before a configuration is produced that has been seen before?


## --- Part Two ---
Out of curiosity, the debugger would also like to know the size of the loop: starting from a state that has already been seen, how many block redistribution cycles must be performed before that same state is seen again?

In the example above, <code>2 4 1 2</code> is seen again after four cycles, and so the answer in that example would be <code>4</code>.

<em>How many cycles</em> are in the infinite loop that arises from the configuration in your puzzle input?


