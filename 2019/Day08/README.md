original source: [https://adventofcode.com/2019/day/8](https://adventofcode.com/2019/day/8)
## --- Day 8: Space Image Format ---
The Elves' spirits are lifted when they realize you have an opportunity to reboot one of their Mars rovers, and so they are curious if you would spend a brief sojourn on Mars. You land your ship near the rover.

When you reach the rover, you discover that it's already in the process of rebooting! It's just waiting for someone to enter a [BIOS](https://en.wikipedia.org/wiki/BIOS) password. The Elf responsible for the rover takes a picture of the password (your puzzle input) and sends it to you via the Digital Sending Network.

Unfortunately, images sent via the Digital Sending Network aren't encoded with any normal encoding; instead, they're encoded in a special Space Image Format.  None of the Elves seem to remember why this is the case. They send you the instructions to decode it.

Images are sent as a series of digits that each represent the color of a single pixel.  The digits fill each row of the image left-to-right, then move downward to the next row, filling rows top-to-bottom until every pixel of the image is filled.

Each image actually consists of a series of identically-sized <em>layers</em> that are filled in this way. So, the first digit corresponds to the top-left pixel of the first layer, the second digit corresponds to the pixel to the right of that on the same layer, and so on until the last digit, which corresponds to the bottom-right pixel of the last layer.

For example, given an image <code>3</code> pixels wide and <code>2</code> pixels tall, the image data <code>123456789012</code> corresponds to the following image layers:

<pre>
<code>Layer 1: 123
         456

Layer 2: 789
         012
</code>
</pre>

The image you received is <em><code>25</code> pixels wide and <code>6</code> pixels tall</em>.

To make sure the image wasn't corrupted during transmission, the Elves would like you to find the layer that contains the <em>fewest <code>0</code> digits</em>.  On that layer, what is <em>the number of <code>1</code> digits multiplied by the number of <code>2</code> digits?</em>


## --- Part Two ---
Now you're ready to decode the image. The image is rendered by stacking the layers and aligning the pixels with the same positions in each layer. The digits indicate the color of the corresponding pixel: <code>0</code> is black, <code>1</code> is white, and <code>2</code> is transparent.

The layers are rendered with the first layer in front and the last layer in back. So, if a given position has a transparent pixel in the first and second layers, a black pixel in the third layer, and a white pixel in the fourth layer, the final image would have a <em>black</em> pixel at that position.

For example, given an image <code>2</code> pixels wide and <code>2</code> pixels tall, the image data <code>0222112222120000</code> corresponds to the following image layers:

<pre>
<code>Layer 1: <em>0</em>2
         22

Layer 2: 1<em>1</em>
         22

Layer 3: 22
         <em>1</em>2

Layer 4: 00
         0<em>0</em>
</code>
</pre>

Then, the full image can be found by determining the top visible pixel in each position:


 - The top-left pixel is <em>black</em> because the top layer is <code>0</code>.
 - The top-right pixel is <em>white</em> because the top layer is <code>2</code> (transparent), but the second layer is <code>1</code>.
 - The bottom-left pixel is <em>white</em> because the top two layers are <code>2</code>, but the third layer is <code>1</code>.
 - The bottom-right pixel is <em>black</em> because the only visible pixel in that position is <code>0</code> (from layer 4).

So, the final image looks like this:

<pre>
<code>01
10
</code>
</pre>

<em>What message is produced after decoding your image?</em>


