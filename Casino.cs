using System.ComponentModel;

class Casino {
    
    //get input
    static int getNum() {return Convert.ToInt32(Console.ReadLine());}
    static string getString() {return Console.ReadLine();}

    //base
    static int creds = 0;
    static int plays = 0;
    //game on or ended
    static bool active = true;
    static bool hasPlayed = false;
    //stats
    static int cashOut = 0;
    static int rolls = 0;

    //settings
    static int showAbove = 0;
    static int rollCost = 3;

    //main loop
    public static void play() {

        Console.WriteLine("Welcome to !Unc's Casino! ROLL!!!");
        Console.WriteLine($"({rollCost})Creds a roll!! You might just be one roll from winning big!!");

        while(active) {

            if (hasPlayed != true) {insert();} else {credCheck(rollCost, true);}
            if(active != true) {break;}
            Console.Write("How many rolls you doin: ");
            int times = getNum(); if (times == 0) {break;}
            roll(times);


            Console.WriteLine();

        }
    }

    //takes int -> rate exchange -> creds
    static void insert() {
        if (plays == 0) {Console.WriteLine("$26 minimum!");}
        Console.Write("Insert Cash here: $");
        //$0.83 = 1C
        int inserted = getNum();
        cashOut -= inserted;
        if (inserted >= 26) {
            creds += (int)(inserted * 0.83);
            Console.WriteLine($"You now have {creds}C!");
        } else {
            Console.WriteLine("Please insert more, $26 minimum!");
            insert();
        }
    }

    //takes param for num rolls -> checks balance -> rolls times
    static void roll(int times) {
        hasPlayed = true;
        int winnings = 0;
        Random random = new Random();
        //checks + reduces balance
        if (times * rollCost <= creds) {
            creds -= times * rollCost;

            //add to total rolls + plays
            rolls += times;
            plays++;

            //rolling logic
            Console.WriteLine("Ready, SET, rollllll!!!");
            for(int i = 0; i < times; i++) {
                int roll = random.Next(100001); //rerolls random each time
                int reward = 0;
                //determining reward / reward set
                if (roll == 1) reward = 100000;
                else if (roll <= 2) reward = 50000;
                else if (roll <= 8) reward = 10000;
                else if (roll <= 16) reward = 5000;
                else if (roll <= 57) reward = 1000;
                else if (roll <= 111) reward = 500;
                else if (roll <= 290) reward = 250;
                else if (roll <= 577) reward = 100;
                else if (roll <= 1201) reward = 50;
                else if (roll <= 3800) reward = 25;
                else if (roll <= 9300) reward = 15;
                else if (roll <= 23000) reward = 5;
                else if (roll <= 50000) reward = 0;

                winnings += reward;
                if (reward > showAbove) {Console.WriteLine($"You won ${reward}!!!");}
            }

            //Finalize
            Console.WriteLine($"YOU TOTALED ${winnings}!!! -might as well role another!\n");
            Console.WriteLine($"You have {creds}C left || {creds / rollCost} rolls.");
            cashOut += winnings;

        } else {credCheck(rollCost, false);}
    }

    //small text ad
    static void purchase() {
        string t = "";
        if (plays == 0) {t = "just 1";} else {t = "1 more";}
        Console.WriteLine($"Improve your ODDS !BIG TIME! of going home RICH today! It may be {t} roll!");
        Console.WriteLine("$1000 ---> 830C | $525 --> 435C | $333 --> 276C | $95 --> 78C | $26 --> 21C");
    }

    //checks required creds {count}
    static void credCheck(int count, bool initial) {
        if (creds <= count) {
            Console.Write("Not enough creds! (N) - Quit | (Y) - ONE MoRe roll can win HUGE! ");
            string input = getString().ToUpper();
            if (input.Equals("Y")) {purchase(); insert();} else {endGame();}
        } else if(!initial) {
            Console.WriteLine($"Bit off more than your creds could chew! Try less, you have {creds}C");
        }
    }

    static void endGame() {
        Console.WriteLine("\nSo close... :[ you could have gone home BIG!!!");
        //end loop
        active = false;
        //print stats
        Console.WriteLine($"\nYou played a total of {plays} times, and netted a total of ${cashOut}, over {rolls} rolls!");

    }

}