
using System;

namespace AdventOfCode._2018;

class SplashScreenImpl : ISplashScreen {

    public void Show() {

        var color = Console.ForegroundColor;
        Write(0xcc00, false, "           ▄█▄ ▄▄█ ▄ ▄ ▄▄▄ ▄▄ ▄█▄  ▄▄▄ ▄█  ▄▄ ▄▄▄ ▄▄█ ▄▄▄\n           █▄█ █ █ █ █ █▄█ █ █ █   █ █ █▄ ");
            Write(0xcc00, false, " █  █ █ █ █ █▄█\n           █ █ █▄█ ▀▄▀ █▄▄ █ █ █▄  █▄█ █   █▄ █▄█ █▄█ █▄▄  sub y{2018}\n            \n");
            Write(0xcc00, false, "                                                              ");
            Write(0xcccccc, false, "25 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "24 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "23 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "22 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "21 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "20 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "19 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "18 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "17 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "16 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "15 ");
            Write(0x666666, false, "**\n                                                              ");
            Write(0xcccccc, false, "14 ");
            Write(0xffff66, false, "*");
            Write(0x666666, false, "*\n                  -           -            - -      |         ");
            Write(0xcccccc, false, "13 ");
            Write(0x666666, false, "**\n              |                   |                        |  ");
            Write(0xcccccc, false, "12 ");
            Write(0x666666, false, "**\n                     |     |            |                     ");
            Write(0xcccccc, false, "11 ");
            Write(0xffff66, false, "**\n                                                              ");
            Write(0xcccccc, false, "10 ");
            Write(0x666666, false, "**\n                                              _               ");
            Write(0xcccccc, false, " 9 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "        .---_             _       |   _ /  )       ");
            Write(0xcccccc, false, " 8 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "       / / /\\|      __   ) )__      |     /        ");
            Write(0xcccccc, false, " 7 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "     / / | \\ *    / / \\ ( (      _       /         ");
            Write(0xcccccc, false, " 6 ");
            Write(0x666666, false, "**\n               /  /  \\ \\    | | \\/  \\_\\__ _ _______/          ");
            Write(0xcccccc, false, " 5 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "   / /  / \\  \\    \\_\\______X_____X_____X_,         ");
            Write(0xcccccc, false, " 4 ");
            Write(0x666666, false, "**\n            ./~~~~~~~~~~~\\.                                   ");
            Write(0xcccccc, false, " 3 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "( .\",^. -\". '.~ )                                  ");
            Write(0xcccccc, false, " 2 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "_'~~~~~~~~~~~~~'_________ ___ __ _  _   _    _     ");
            Write(0xcccccc, false, " 1 ");
            Write(0xffff66, false, "**\n           \n");
            
        Console.ForegroundColor = color;
        Console.WriteLine();
    }

   private static void Write(int rgb, bool bold, string text){
       Console.Write($"\u001b[38;2;{(rgb>>16)&255};{(rgb>>8)&255};{rgb&255}{(bold ? ";1" : "")}m{text}");
   }
}
