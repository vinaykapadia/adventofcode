original source: [https://adventofcode.com/2019/day/7](https://adventofcode.com/2019/day/7)
## --- Day 7: Amplification Circuit ---
Based on the navigational maps, you're going to need to send more power to your ship's thrusters to reach Santa in time. To do this, you'll need to configure a series of [amplifiers](https://en.wikipedia.org/wiki/Amplifier) already installed on the ship.

There are five amplifiers connected in series; each one receives an input signal and produces an output signal.  They are connected such that the first amplifier's output leads to the second amplifier's input, the second amplifier's output leads to the third amplifier's input, and so on.  The first amplifier's input value is <code>0</code>, and the last amplifier's output leads to your ship's thrusters.

<pre>
<code>    O-------O  O-------O  O-------O  O-------O  O-------O
0 ->| Amp A |->| Amp B |->| Amp C |->| Amp D |->| Amp E |-> (to thrusters)
    O-------O  O-------O  O-------O  O-------O  O-------O
</code>
</pre>

The Elves have sent you some <em>Amplifier Controller Software</em> (your puzzle input), a program that should run on your [existing Intcode computer](5). Each amplifier will need to run a copy of the program.

When a copy of the program starts running on an amplifier, it will first use an input instruction to ask the amplifier for its current <em>phase setting</em> (an integer from <code>0</code> to <code>4</code>). Each phase setting is used <em>exactly once</em>, but the Elves can't remember which amplifier needs which phase setting.

The program will then call another input instruction to get the amplifier's input signal, compute the correct output signal, and supply it back to the amplifier with an output instruction. (If the amplifier has not yet received an input signal, it waits until one arrives.)

Your job is to <em>find the largest output signal that can be sent to the thrusters</em> by trying every possible combination of phase settings on the amplifiers. Make sure that memory is not shared or reused between copies of the program.

For example, suppose you want to try the phase setting sequence <code>3,1,2,4,0</code>, which would mean setting amplifier <code>A</code> to phase setting <code>3</code>, amplifier <code>B</code> to setting <code>1</code>, <code>C</code> to <code>2</code>, <code>D</code> to <code>4</code>, and <code>E</code> to <code>0</code>. Then, you could determine the output signal that gets sent from amplifier <code>E</code> to the thrusters with the following steps:


 - Start the copy of the amplifier controller software that will run on amplifier <code>A</code>. At its first input instruction, provide it the amplifier's phase setting, <code>3</code>.  At its second input instruction, provide it the input signal, <code>0</code>.  After some calculations, it will use an output instruction to indicate the amplifier's output signal.
 - Start the software for amplifier <code>B</code>. Provide it the phase setting (<code>1</code>) and then whatever output signal was produced from amplifier <code>A</code>. It will then produce a new output signal destined for amplifier <code>C</code>.
 - Start the software for amplifier <code>C</code>, provide the phase setting (<code>2</code>) and the value from amplifier <code>B</code>, then collect its output signal.
 - Run amplifier <code>D</code>'s software, provide the phase setting (<code>4</code>) and input value, and collect its output signal.
 - Run amplifier <code>E</code>'s software, provide the phase setting (<code>0</code>) and input value, and collect its output signal.

The final output signal from amplifier <code>E</code> would be sent to the thrusters. However, this phase setting sequence may not have been the best one; another sequence might have sent a higher signal to the thrusters.

Here are some example programs:


 - Max thruster signal <em><code>43210</code></em> (from phase setting sequence <code>4,3,2,1,0</code>):
<pre>
<code>3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0</code>
</pre>

 - Max thruster signal <em><code>54321</code></em> (from phase setting sequence <code>0,1,2,3,4</code>):
<pre>
<code>3,23,3,24,1002,24,10,24,1002,23,-1,23,
101,5,23,23,1,24,23,23,4,23,99,0,0</code>
</pre>

 - Max thruster signal <em><code>65210</code></em> (from phase setting sequence <code>1,0,4,3,2</code>):
<pre>
<code>3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0</code>
</pre>


Try every combination of phase settings on the amplifiers.  <em>What is the highest signal that can be sent to the thrusters?</em>


## --- Part Two ---
It's no good - in this configuration, the amplifiers can't generate a large enough output signal to produce the thrust you'll need.  The Elves quickly talk you through rewiring the amplifiers into a <em>feedback loop</em>:

<pre>
<code>      O-------O  O-------O  O-------O  O-------O  O-------O
0 -+->| Amp A |->| Amp B |->| Amp C |->| Amp D |->| Amp E |-.
   |  O-------O  O-------O  O-------O  O-------O  O-------O |
   |                                                        |
   '--------------------------------------------------------+
                                                            |
                                                            v
                                                     (to thrusters)
</code>
</pre>

Most of the amplifiers are connected as they were before; amplifier <code>A</code>'s output is connected to amplifier <code>B</code>'s input, and so on. <em>However,</em> the output from amplifier <code>E</code> is now connected into amplifier <code>A</code>'s input. This creates the feedback loop: the signal will be sent through the amplifiers <em>many times</em>.

In feedback loop mode, the amplifiers need <em>totally different phase settings</em>: integers from <code>5</code> to <code>9</code>, again each used exactly once. These settings will cause the Amplifier Controller Software to repeatedly take input and produce output many times before halting. Provide each amplifier its phase setting at its first input instruction; all further input/output instructions are for signals.

Don't restart the Amplifier Controller Software on any amplifier during this process. Each one should continue receiving and sending signals until it halts.

All signals sent or received in this process will be between pairs of amplifiers except the very first signal and the very last signal. To start the process, a <code>0</code> signal is sent to amplifier <code>A</code>'s input <em>exactly once</em>.

Eventually, the software on the amplifiers will halt after they have processed the final loop. When this happens, the last output signal from amplifier <code>E</code> is sent to the thrusters. Your job is to <em>find the largest output signal that can be sent to the thrusters</em> using the new phase settings and feedback loop arrangement.

Here are some example programs:


 - Max thruster signal <em><code>139629729</code></em> (from phase setting sequence <code>9,8,7,6,5</code>):
<pre>
<code>3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,
27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5</code>
</pre>

 - Max thruster signal <em><code>18216</code></em> (from phase setting sequence <code>9,7,8,5,6</code>):
<pre>
<code>3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,
-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,
53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10</code>
</pre>


Try every combination of the new phase settings on the amplifier feedback loop.  <em>What is the highest signal that can be sent to the thrusters?</em>


