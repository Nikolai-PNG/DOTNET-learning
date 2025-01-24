class Program
{

    static bool active = true;

    public static void Main(String[] args)
    {
        while (active) {run();}
    }

    static void run() {

        Console.WriteLine();
        Console.WriteLine("1. Gamble");
        Console.WriteLine("2. Task Manager");
        Console.WriteLine("3. Roack Paper Scissors");
        Console.WriteLine("4. Guess the number");
        Console.WriteLine("5. hypotenuse calc //hardcoded nums :(");
        Console.WriteLine("6. num analyzing //hardcoded list :(");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
        Console.WriteLine("");

        switch(getNum()){
            case 1: {Casino.play();} break;
            case 2: {TaskManager.Open();} break;
            case 3: {RPS.play();} break;
            case 4: {Guess.numGuess();} break;
            case 5: {double hypotenuse = HypotenuseCalc.Calc(3, 6.5); Console.WriteLine($"\nhypotenuse: {hypotenuse:F2}");} break;
            case 6: {NumAnalyze.numData([1, 2, 4, 5, 7, 8, 8, 12, 16, 1, 0, 5 ,6, 8]);} break;
            case 7: {active = false;} break;
            default: {Console.WriteLine("invalid, input 1-5 only");} break;
        }

    }

    static int getNum() {return Convert.ToInt32(Console.ReadLine());}

}
