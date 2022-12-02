The master branch is empty, you can fork my repo and work there.
The vkapadia branch contains my solutions, avoid if you don't want spoilers.

You can work in vs or vscode, in the terminal right in the ide just use `dotnet run <arguments>` to run it. Arguments are provided in the readme.

Don't listen to the instructions about the session variable, instead you can just add it to session.txt (might want to run `git update-index --assume-unchanged session.txt` so that you don't commit your own session variable).

To run in debug mode within Visual Studio, click on the small down arrow next to the AdventOfCode play button (that you'd use to debug) and select "AdventOfCode Debug Properties".
Set the Working Directory to your base repo directory (the one containing the .sln file).
Add your arguments in the Command Line Arguments box (without the 'dotnet run' part).
Then you can click the play button to debug.