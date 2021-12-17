original source: [https://adventofcode.com/2019/day/25](https://adventofcode.com/2019/day/25)
## --- Day 25: Cryostasis ---
As you approach Santa's ship, your sensors report two important details:

First, that you might be too late: the internal temperature is <code>-40</code> degrees.

Second, that one faint life signature is somewhere on the ship.

The airlock door is locked with a code; your best option is to send in a small droid to investigate the situation.  You attach your ship to Santa's, break a small hole in the hull, and let the droid run in before you seal it up again. Before your ship starts freezing, you detach your ship and set it to automatically stay within range of Santa's ship.

This droid can follow basic instructions and report on its surroundings; you can communicate with it through an [Intcode](9) program (your puzzle input) running on an [ASCII-capable](17) computer.

As the droid moves through its environment, it will describe what it encounters.  When it says <code>Command?</code>, you can give it a single instruction terminated with a newline (ASCII code <code>10</code>). Possible instructions are:


 - <em>Movement</em> via <code>north</code>, <code>south</code>, <code>east</code>, or <code>west</code>.
 - To <em>take</em> an item the droid sees in the environment, use the command <code>take <name of item></code>. For example, if the droid reports seeing a <code>red ball</code>, you can pick it up with <code>take red ball</code>.
 - To <em>drop</em> an item the droid is carrying, use the command <code>drop <name of item></code>. For example, if the droid is carrying a <code>green ball</code>, you can drop it with <code>drop green ball</code>.
 - To get a <em>list of all of the items</em> the droid is currently carrying, use the command <code>inv</code> (for "inventory").

Extra spaces or other characters aren't allowed - instructions must be provided precisely.

Santa's ship is a <em>Reindeer-class starship</em>; these ships use pressure-sensitive floors to determine the identity of droids and crew members.  The standard configuration for these starships is for all droids to weigh exactly the same amount to make them easier to detect.  If you need to get past such a sensor, you might be able to reach the correct weight by carrying items from the environment.

Look around the ship and see if you can find the <em>password for the main airlock</em>.


