original source: [https://adventofcode.com/2016/day/4](https://adventofcode.com/2016/day/4)
## --- Day 4: Security Through Obscurity ---
Finally, you come across an information kiosk with a list of rooms.  Of course, the list is encrypted and full of decoy data, but the instructions to decode the list are barely hidden nearby.  Better remove the decoy data first.

Each room consists of an encrypted name (lowercase letters separated by dashes) followed by a dash, a sector ID, and a checksum in square brackets.

A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, in order, with ties broken by alphabetization.  For example:


 - <code>aaaaa-bbb-z-y-x-123[abxyz]</code> is a real room because the most common letters are <code>a</code> (5), <code>b</code> (3), and then a tie between <code>x</code>, <code>y</code>, and <code>z</code>, which are listed alphabetically.
 - <code>a-b-c-d-e-f-g-h-987[abcde]</code> is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
 - <code>not-a-real-room-404[oarel]</code> is a real room.
 - <code>totally-real-room-200[decoy]</code> is not.

Of the real rooms from the list above, the sum of their sector IDs is <code>1514</code>.

What is the <em>sum of the sector IDs of the real rooms</em>?


## --- Part Two ---
With all the decoy data out of the way, it's time to decrypt this list and get moving.

The room names are encrypted by a state-of-the-art [shift cipher](https://en.wikipedia.org/wiki/Caesar_cipher), which is nearly unbreakable without the right software. However, the information kiosk designers at Easter Bunny HQ were not expecting to deal with a master cryptographer like yourself.

To decrypt a room name, rotate each letter forward through the alphabet a number of times equal to the room's sector ID.  <code>A</code> becomes <code>B</code>, <code>B</code> becomes <code>C</code>, <code>Z</code> becomes <code>A</code>, and so on. Dashes become spaces.

For example, the real name for <code>qzmt-zixmtkozy-ivhz-343</code> is <code>very encrypted name</code>.

<em>What is the sector ID</em> of the room where North Pole objects are stored?


