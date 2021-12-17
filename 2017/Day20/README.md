original source: [https://adventofcode.com/2017/day/20](https://adventofcode.com/2017/day/20)
## --- Day 20: Particle Swarm ---
Suddenly, the GPU contacts you, asking for help. Someone has asked it to simulate <em>too many particles</em>, and it won't be able to finish them all in time to render the next frame at this rate.

It transmits to you a buffer (your puzzle input) listing each particle in order (starting with particle <code>0</code>, then particle <code>1</code>, particle <code>2</code>, and so on). For each particle, it provides the <code>X</code>, <code>Y</code>, and <code>Z</code> coordinates for the particle's position (<code>p</code>), velocity (<code>v</code>), and acceleration (<code>a</code>), each in the format <code><X,Y,Z></code>.

Each tick, all particles are updated simultaneously. A particle's properties are updated in the following order:


 - Increase the <code>X</code> velocity by the <code>X</code> acceleration.
 - Increase the <code>Y</code> velocity by the <code>Y</code> acceleration.
 - Increase the <code>Z</code> velocity by the <code>Z</code> acceleration.
 - Increase the <code>X</code> position by the <code>X</code> velocity.
 - Increase the <code>Y</code> position by the <code>Y</code> velocity.
 - Increase the <code>Z</code> position by the <code>Z</code> velocity.

Because of seemingly tenuous rationale involving [z-buffering](https://en.wikipedia.org/wiki/Z-buffering), the GPU would like to know which particle will stay closest to position <code><0,0,0></code> in the long term. Measure this using the [Manhattan distance](https://en.wikipedia.org/wiki/Taxicab_geometry), which in this situation is simply the sum of the absolute values of a particle's <code>X</code>, <code>Y</code>, and <code>Z</code> position.

For example, suppose you are only given two particles, both of which stay entirely on the X-axis (for simplicity). Drawing the current states of particles <code>0</code> and <code>1</code> (in that order) with an adjacent a number line and diagram of current <code>X</code> positions (marked in parentheses), the following would take place:

<pre>
<code>p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>    -4 -3 -2 -1  0  1  2  3  4
p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>                         (0)(1)

p=< 4,0,0>, v=< 1,0,0>, a=<-1,0,0>    -4 -3 -2 -1  0  1  2  3  4
p=< 2,0,0>, v=<-2,0,0>, a=<-2,0,0>                      (1)   (0)

p=< 4,0,0>, v=< 0,0,0>, a=<-1,0,0>    -4 -3 -2 -1  0  1  2  3  4
p=<-2,0,0>, v=<-4,0,0>, a=<-2,0,0>          (1)               (0)

p=< 3,0,0>, v=<-1,0,0>, a=<-1,0,0>    -4 -3 -2 -1  0  1  2  3  4
p=<-8,0,0>, v=<-6,0,0>, a=<-2,0,0>                         (0)   
</code>
</pre>

At this point, particle <code>1</code> will never be closer to <code><0,0,0></code> than particle <code>0</code>, and so, in the long run, particle <code>0</code> will stay closest.

<em>Which particle will stay closest to position <code><0,0,0></code></em> in the long term?


