original source: [https://adventofcode.com/2018/day/14](https://adventofcode.com/2018/day/14)
## --- Day 14: Chocolate Charts ---
You finally have a chance to look at all of the produce moving around. Chocolate, cinnamon, mint, chili peppers, nutmeg, vanilla... the Elves must be growing these plants to make <em>hot chocolate</em>! As you realize this, you hear a conversation in the distance. When you go to investigate, you discover two Elves in what appears to be a makeshift underground kitchen/laboratory.

The Elves are trying to come up with the ultimate hot chocolate recipe; they're even maintaining a scoreboard which tracks the quality <em>score</em> (<code>0</code>-<code>9</code>) of each recipe.

Only two recipes are on the board: the first recipe got a score of <code>3</code>, the second, <code>7</code>. Each of the two Elves has a <em>current recipe</em>: the first Elf starts with the first recipe, and the second Elf starts with the second recipe.

To create new recipes, the two Elves combine their current recipes.  This creates new recipes from the <em>digits of the sum</em> of the current recipes' scores.  With the current recipes' scores of <code>3</code> and <code>7</code>, their sum is <code>10</code>, and so two new recipes would be created: the first with score <code>1</code> and the second with score <code>0</code>. If the current recipes' scores were <code>2</code> and <code>3</code>, the sum, <code>5</code>, would only create one recipe (with a score of <code>5</code>) with its single digit.

The new recipes are added to the end of the scoreboard in the order they are created.  So, after the first round, the scoreboard is <code>3, 7, 1, 0</code>.

After all new recipes are added to the scoreboard, each Elf picks a new current recipe.  To do this, the Elf steps forward through the scoreboard a number of recipes equal to <em>1 plus the score of their current recipe</em>. So, after the first round, the first Elf moves forward <code>1 + 3 = 4</code> times, while the second Elf moves forward <code>1 + 7 = 8</code> times. If they run out of recipes, they loop back around to the beginning. After the first round, both Elves happen to loop around until they land on the same recipe that they had in the beginning; in general, they will move to different recipes.

Drawing the first Elf as parentheses and the second Elf as square brackets, they continue this process:

<pre>
<code>(3)[7]
(3)[7] 1  0 
 3  7  1 [0](1) 0 
 3  7  1  0 [1] 0 (1)
(3) 7  1  0  1  0 [1] 2 
 3  7  1  0 (1) 0  1  2 [4]
 3  7  1 [0] 1  0 (1) 2  4  5 
 3  7  1  0 [1] 0  1  2 (4) 5  1 
 3 (7) 1  0  1  0 [1] 2  4  5  1  5 
 3  7  1  0  1  0  1  2 [4](5) 1  5  8 
 3 (7) 1  0  1  0  1  2  4  5  1  5  8 [9]
 3  7  1  0  1  0  1 [2] 4 (5) 1  5  8  9  1  6 
 3  7  1  0  1  0  1  2  4  5 [1] 5  8  9  1 (6) 7 
 3  7  1  0 (1) 0  1  2  4  5  1  5 [8] 9  1  6  7  7 
 3  7 [1] 0  1  0 (1) 2  4  5  1  5  8  9  1  6  7  7  9 
 3  7  1  0 [1] 0  1  2 (4) <em>5  1  5  8  9  1  6  7  7  9</em>  2 
</code>
</pre>

The Elves think their skill will improve after making a few recipes (your puzzle input). However, that could take ages; you can speed this up considerably by identifying <em>the scores of the ten recipes</em> after that.  For example:


 - If the Elves think their skill will improve after making <code>9</code> recipes, the scores of the ten recipes <em>after</em> the first nine on the scoreboard would be <code>5158916779</code> (highlighted in the last line of the diagram).
 - After <code>5</code> recipes, the scores of the next ten would be <code>0124515891</code>.
 - After <code>18</code> recipes, the scores of the next ten would be <code>9251071085</code>.
 - After <code>2018</code> recipes, the scores of the next ten would be <code>5941429882</code>.

<em>What are the scores of the ten recipes immediately after the number of recipes in your puzzle input?</em>


