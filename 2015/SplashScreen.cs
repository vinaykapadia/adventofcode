
using System;

namespace AdventOfCode._2015;

class SplashScreenImpl : SplashScreen {

    public void Show() {

        var color = Console.ForegroundColor;
        Write(0xcc00, false, "           ▄█▄ ▄▄█ ▄ ▄ ▄▄▄ ▄▄ ▄█▄  ▄▄▄ ▄█  ▄▄ ▄▄▄ ▄▄█ ▄▄▄\n           █▄█ █ █ █ █ █▄█ █ █ █   █ █ █▄ ");
            Write(0xcc00, false, " █  █ █ █ █ █▄█\n           █ █ █▄█ ▀▄▀ █▄▄ █ █ █▄  █▄█ █   █▄ █▄█ █▄█ █▄▄  λy.2015\n            \n    ");
            Write(0xcc00, false, "       ");
            Write(0x666666, false, "                        *                          ");
            Write(0xcccccc, false, "25 ");
            Write(0x666666, false, "**\n                                  >o<                         ");
            Write(0xcccccc, false, "24 ");
            Write(0x666666, false, "**\n                                 >o<<<                        ");
            Write(0xcccccc, false, "23 ");
            Write(0x666666, false, "**\n                                >>O<<<<                       ");
            Write(0xcccccc, false, "22 ");
            Write(0x666666, false, "**\n                               >>O>>>@<<                      ");
            Write(0xcccccc, false, "21 ");
            Write(0x666666, false, "**\n                              >*>O>>>@<<<                     ");
            Write(0xcccccc, false, "20 ");
            Write(0x666666, false, "**\n                             >@>o>>O<<<@<<                    ");
            Write(0xcccccc, false, "19 ");
            Write(0x666666, false, "**\n                            >>o<o>>@<O<O<<<                   ");
            Write(0xcccccc, false, "18 ");
            Write(0x666666, false, "**\n                           >*<<o>>O<<<O>O<<<                  ");
            Write(0xcccccc, false, "17 ");
            Write(0x666666, false, "**\n                          >@>>o<<O>@>>>*>*>O<                 ");
            Write(0xcccccc, false, "16 ");
            Write(0x666666, false, "**\n                         >>o<@<<<o<*>>O<<@>*<<                ");
            Write(0xcccccc, false, "15 ");
            Write(0x666666, false, "**\n                        >>@<*>>>O>>*<<<@>>>o>@<               ");
            Write(0xcccccc, false, "14 ");
            Write(0x666666, false, "**\n                       >>*>*>>O>>O<<<O<<@>>o<*<<              ");
            Write(0xcccccc, false, "13 ");
            Write(0x666666, false, "**\n                      >@<o<<@<O>*<<<*<<@>>>*>>>O<             ");
            Write(0xcccccc, false, "12 ");
            Write(0x666666, false, "**\n                     >@>*>>@>o>@>@>>>o<<@<O>>O<@<<            ");
            Write(0xcccccc, false, "11 ");
            Write(0x666666, false, "**\n                    >>*<<<O>>>@>>>*>>@>O<<<*<<<o<<<           ");
            Write(0xcccccc, false, "10 ");
            Write(0x666666, false, "**\n                   >o>>O>@<O>>*<<<@>>@>>o>*<O>>O<<@<          ");
            Write(0xcccccc, false, " 9 ");
            Write(0x666666, false, "**\n                  >>O<<o<<*>>>@<<o<<<O<<O>>O>>>*<<<@<         ");
            Write(0xcccccc, false, " 8 ");
            Write(0x666666, false, "**\n                 >@<<O<<<o<<<o<@>>o>O>>>@>*>>>O>>*<<<<        ");
            Write(0xcccccc, false, " 7 ");
            Write(0x666666, false, "**\n                >>*>>o<*<@<<O<<*<<o>>>@>>*>>@<<<*>>>@<<       ");
            Write(0xcccccc, false, " 6 ");
            Write(0x666666, false, "**\n               >>o>>O>>>*<<*>>*<o<<<@<<<o>>>O<<<@<<*<<<<      ");
            Write(0xcccccc, false, " 5 ");
            Write(0x666666, false, "**\n              >>@>@<O>@>>@<<<O<o>>>o>>>@>>>o>>o>>@>O<<<O<     ");
            Write(0xcccccc, false, " 4 ");
            Write(0x666666, false, "**\n             >@<*<O>>>@>>O>>>O>O<O<<*>>>*>>O>@>o>>o<<<*<<<    ");
            Write(0xcccccc, false, " 3 ");
            Write(0x666666, false, "**\n            >*<<<*>>>@>O>o<<O>>O>>@>>O>>>O<<<o<<<@>@<<<@<@<   ");
            Write(0xcccccc, false, " 2 ");
            Write(0x666666, false, "**\n           >O>>*<O<o<<<*>o>>>*<o>>O>>>o>>O>>>o<<O<<<o>>>*<<<  ");
            Write(0xcccccc, false, " 1 ");
            Write(0x666666, false, "**\n           ");
            Write(0xcccccc, false, "                      |   |                             \n                                 |   |     ");
            Write(0xcccccc, false, "                        \n                      _  _ __ ___|___|___ __ _  _                  \n       ");
            Write(0xcccccc, false, "    \n");
            
        Console.ForegroundColor = color;
        Console.WriteLine();
    }

   private static void Write(int rgb, bool bold, string text){
       Console.Write($"\u001b[38;2;{(rgb>>16)&255};{(rgb>>8)&255};{rgb&255}{(bold ? ";1" : "")}m{text}");
   }
}
