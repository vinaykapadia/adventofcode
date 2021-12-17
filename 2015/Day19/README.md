original source: [https://adventofcode.com/2015/day/19](https://adventofcode.com/2015/day/19)
## --- Day 19: Medicine for Rudolph ---
Rudolph the Red-Nosed Reindeer is sick!  His nose isn't shining very brightly, and he needs medicine.

Red-Nosed Reindeer biology isn't similar to regular reindeer biology; Rudolph is going to need custom-made medicine.  Unfortunately, Red-Nosed Reindeer chemistry isn't similar to regular reindeer chemistry, either.

The North Pole is equipped with a Red-Nosed Reindeer nuclear fusion/fission plant, capable of constructing any Red-Nosed Reindeer molecule you need.  It works by starting with some input molecule and then doing a series of <em>replacements</em>, one per step, until it has the right molecule.

However, the machine has to be calibrated before it can be used.  Calibration involves determining the number of molecules that can be generated in one step from a given starting point.

For example, imagine a simpler machine that supports only the following replacements:

<pre>
<code>H => HO
H => OH
O => HH
</code>
</pre>

Given the replacements above and starting with <code>HOH</code>, the following molecules could be generated:


 - <code>HOOH</code> (via <code>H => HO</code> on the first <code>H</code>).
 - <code>HOHO</code> (via <code>H => HO</code> on the second <code>H</code>).
 - <code>OHOH</code> (via <code>H => OH</code> on the first <code>H</code>).
 - <code>HOOH</code> (via <code>H => OH</code> on the second <code>H</code>).
 - <code>HHHH</code> (via <code>O => HH</code>).

So, in the example above, there are <code>4</code> <em>distinct</em> molecules (not five, because <code>HOOH</code> appears twice) after one replacement from <code>HOH</code>. Santa's favorite molecule, <code>HOHOHO</code>, can become <code>7</code> <em>distinct</em> molecules (over nine replacements: six from <code>H</code>, and three from <code>O</code>).

The machine replaces without regard for the surrounding characters.  For example, given the string <code>H2O</code>, the transition <code>H => OO</code> would result in <code>OO2O</code>.

Your puzzle input describes all of the possible replacements and, at the bottom, the medicine molecule for which you need to calibrate the machine.  <em>How many distinct molecules can be created</em> after all the different ways you can do one replacement on the medicine molecule?


## --- Part Two ---
Now that the machine is calibrated, you're ready to begin molecule fabrication.

Molecule fabrication always begins with just a single electron, <code>e</code>, and applying replacements one at a time, just like the ones during calibration.

For example, suppose you have the following replacements:

<pre>
<code>e => H
e => O
H => HO
H => OH
O => HH
</code>
</pre>

If you'd like to make <code>HOH</code>, you start with <code>e</code>, and then make the following replacements:


 - <code>e => O</code> to get <code>O</code>
 - <code>O => HH</code> to get <code>HH</code>
 - <code>H => OH</code> (on the second <code>H</code>) to get <code>HOH</code>

So, you could make <code>HOH</code> after <em><code>3</code> steps</em>.  Santa's favorite molecule, <code>HOHOHO</code>, can be made in <em><code>6</code> steps</em>.

How long will it take to make the medicine?  Given the available <em>replacements</em> and the <em>medicine molecule</em> in your puzzle input, what is the <em>fewest number of steps</em> to go from <code>e</code> to the medicine molecule?


