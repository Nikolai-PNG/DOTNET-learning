using System.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

//too many nesteds, should have used more methods to streamline main loop!
class RPS{

    public static void play(){

        bool playAgain = true;
        int plays = 0;

        Console.WriteLine("Choose (R, P, S) Rock, Paper, Scissors! -");

        while (playAgain) {

            Random random = new Random();
            int rps = 0; //0 rock, 1 paper, 2 scissors
            string rand = "";
            string response = Console.ReadLine().ToUpper();

            int r = random.Next(0,3);
            switch (response) {
                case "R": rps = 0; break;
                case "P": rps = 1; break;
                case "S": rps = 2; break;
            }
            switch (r) {
                case 0: rand = "R"; break;
                case 1: rand = "P"; break;
                case 2: rand = "S"; break;
            }

            Console.WriteLine($"{response} : {rand}");
            plays++;

            if (rps == r) {Console.WriteLine($"Draw! {response} : {response} Try again -");} else
            if ((rps == 0 && r == 2) || (rps == 1 && r == 0) || (rps == 2 && r == 1)) {
                Console.WriteLine($"YOU WIN, yay!\nPlays: {plays}");
                Console.WriteLine("Wanna play again? (Y/N) - ");
                if (Console.ReadLine().ToUpper().Equals("Y")) 
                {playAgain = true; Console.WriteLine("Choose (R, P, S) Rock, Paper, Scissors! -");
                plays = 0;}
                else {playAgain = false;}
            } else {
                Console.WriteLine($"YOU LOST, haha!\nPlays: {plays}");
                Console.WriteLine("Wanna play again? (Y/N) - ");
                if (Console.ReadLine().ToUpper().Equals("Y")) 
                {playAgain = true; Console.WriteLine("Choose (R, P, S) Rock, Paper, Scissors! -");
                plays = 0;}
                else {playAgain = false;}
            }

        }

    }

}