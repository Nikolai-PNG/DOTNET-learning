using System.Runtime.CompilerServices;

class Guess{

    public static void numGuess(){

        Random random = new Random();
        bool playAgain = true;
        int min = 1;
        int max = 100;
        int guess;
        int number;
        int guesses;

        while(playAgain) {
            guess = 0;
            guesses = 0;
            number = random.Next(min, max + 1);

            while(guess != number){
                Console.WriteLine($"Guess a num {min}-{max}: ");
                guess = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine($"Guess: {guess}");
                guesses++;

                if (guess > number) {Console.WriteLine("Nope, lower!");}
                else if (guess < number) {Console.WriteLine("Not quite, try higher!");}

            }

            Console.WriteLine($"YOU WIN, yay!\nGuesses: {guesses}");
            Console.WriteLine("Wanna play again? (Y/N) - ");
            if (Console.ReadLine().ToUpper().Equals("Y")) {playAgain = true;} else {playAgain = false;}

        }

    }

}