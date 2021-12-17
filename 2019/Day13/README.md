original source: [https://adventofcode.com/2019/day/13](https://adventofcode.com/2019/day/13)
## --- Day 13: Care Package ---
As you ponder the solitude of space and the ever-increasing three-hour roundtrip for messages between you and Earth, you notice that the Space Mail Indicator Light is blinking.  To help keep you sane, the Elves have sent you a care package.

It's a new game for the ship's [arcade cabinet](https://en.wikipedia.org/wiki/Arcade_cabinet)! Unfortunately, the arcade is <em>all the way</em> on the other end of the ship. Surely, it won't be hard to build your own - the care package even comes with schematics.

The arcade cabinet runs [Intcode](9) software like the game the Elves sent (your puzzle input). It has a primitive screen capable of drawing square <em>tiles</em> on a grid.  The software draws tiles to the screen with output instructions: every three output instructions specify the <code>x</code> position (distance from the left), <code>y</code> position (distance from the top), and <code>tile id</code>. The <code>tile id</code> is interpreted as follows:


 - <code>0</code> is an <em>empty</em> tile.  No game object appears in this tile.
 - <code>1</code> is a <em>wall</em> tile.  Walls are indestructible barriers.
 - <code>2</code> is a <em>block</em> tile.  Blocks can be broken by the ball.
 - <code>3</code> is a <em>horizontal paddle</em> tile.  The paddle is indestructible.
 - <code>4</code> is a <em>ball</em> tile.  The ball moves diagonally and bounces off objects.

For example, a sequence of output values like <code>1,2,3,6,5,4</code> would draw a <em>horizontal paddle</em> tile (<code>1</code> tile from the left and <code>2</code> tiles from the top) and a <em>ball</em> tile (<code>6</code> tiles from the left and <code>5</code> tiles from the top).

Start the game. <em>How many block tiles are on the screen when the game exits?</em>


## --- Part Two ---
The game didn't run because you didn't put in any quarters. Unfortunately, you did not bring any quarters. Memory address <code>0</code> represents the number of quarters that have been inserted; set it to <code>2</code> to play for free.

The arcade cabinet has a [joystick](https://en.wikipedia.org/wiki/Joystick) that can move left and right.  The software reads the position of the joystick with input instructions:


 - If the joystick is in the <em>neutral position</em>, provide <code>0</code>.
 - If the joystick is <em>tilted to the left</em>, provide <code>-1</code>.
 - If the joystick is <em>tilted to the right</em>, provide <code>1</code>.

The arcade cabinet also has a [segment display](https://en.wikipedia.org/wiki/Display_device#Segment_displays) capable of showing a single number that represents the player's current score. When three output instructions specify <code>X=-1, Y=0</code>, the third output instruction is not a tile; the value instead specifies the new score to show in the segment display.  For example, a sequence of output values like <code>-1,0,12345</code> would show <code>12345</code> as the player's current score.

Beat the game by breaking all the blocks. <em>What is your score after the last block is broken?</em>


