original source: [https://adventofcode.com/2020/day/10](https://adventofcode.com/2020/day/10)
## --- Day 10: Adapter Array ---
Patched into the aircraft's data port, you discover weather forecasts of a massive tropical storm. Before you can figure out whether it will impact your vacation plans, however, your device suddenly turns off!

Its battery is dead.

You'll need to plug it in. There's only one problem: the charging outlet near your seat produces the wrong number of <em>jolts</em>. Always prepared, you make a list of all of the joltage adapters in your bag.

Each of your joltage adapters is rated for a specific <em>output joltage</em> (your puzzle input). Any given adapter can take an input <code>1</code>, <code>2</code>, or <code>3</code> jolts <em>lower</em> than its rating and still produce its rated output joltage.

In addition, your device has a built-in joltage adapter rated for <em><code>3</code> jolts higher</em> than the highest-rated adapter in your bag. (If your adapter list were <code>3</code>, <code>9</code>, and <code>6</code>, your device's built-in adapter would be rated for <code>12</code> jolts.)

Treat the charging outlet near your seat as having an effective joltage rating of <code>0</code>.

Since you have some time to kill, you might as well test all of your adapters. Wouldn't want to get to your resort and realize you can't even charge your device!

If you <em>use every adapter in your bag</em> at once, what is the distribution of joltage differences between the charging outlet, the adapters, and your device?

For example, suppose that in your bag, you have adapters with the following joltage ratings:

<pre>
<code>16
10
15
5
1
11
7
19
6
12
4
</code>
</pre>

With these adapters, your device's built-in joltage adapter would be rated for <code>19 + 3 = <em>22</em></code> jolts, 3 higher than the highest-rated adapter.

Because adapters can only connect to a source 1-3 jolts lower than its rating, in order to use every adapter, you'd need to choose them like this:


 - The charging outlet has an effective rating of <code>0</code> jolts, so the only adapters that could connect to it directly would need to have a joltage rating of <code>1</code>, <code>2</code>, or <code>3</code> jolts. Of these, only one you have is an adapter rated <code>1</code> jolt (difference of <em><code>1</code></em>).
 - From your <code>1</code>-jolt rated adapter, the only choice is your <code>4</code>-jolt rated adapter (difference of <em><code>3</code></em>).
 - From the <code>4</code>-jolt rated adapter, the adapters rated <code>5</code>, <code>6</code>, or <code>7</code> are valid choices. However, in order to not skip any adapters, you have to pick the adapter rated <code>5</code> jolts (difference of <em><code>1</code></em>).
 - Similarly, the next choices would need to be the adapter rated <code>6</code> and then the adapter rated <code>7</code> (with difference of <em><code>1</code></em> and <em><code>1</code></em>).
 - The only adapter that works with the <code>7</code>-jolt rated adapter is the one rated <code>10</code> jolts (difference of <em><code>3</code></em>).
 - From <code>10</code>, the choices are <code>11</code> or <code>12</code>; choose <code>11</code> (difference of <em><code>1</code></em>) and then <code>12</code> (difference of <em><code>1</code></em>).
 - After <code>12</code>, only valid adapter has a rating of <code>15</code> (difference of <em><code>3</code></em>), then <code>16</code> (difference of <em><code>1</code></em>), then <code>19</code> (difference of <em><code>3</code></em>).
 - Finally, your device's built-in adapter is always 3 higher than the highest adapter, so its rating is <code>22</code> jolts (always a difference of <em><code>3</code></em>).

In this example, when using every adapter, there are <em><code>7</code></em> differences of 1 jolt and <em><code>5</code></em> differences of 3 jolts.

Here is a larger example:

<pre>
<code>28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3
</code>
</pre>

In this larger example, in a chain that uses all of the adapters, there are <em><code>22</code></em> differences of 1 jolt and <em><code>10</code></em> differences of 3 jolts.

Find a chain that uses all of your adapters to connect the charging outlet to your device's built-in adapter and count the joltage differences between the charging outlet, the adapters, and your device. <em>What is the number of 1-jolt differences multiplied by the number of 3-jolt differences?</em>


