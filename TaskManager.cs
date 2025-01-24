//Had to do a lot of searching to figure out the list Tuple stuff, but other than that >
//I completed on my own
using System.Collections.Immutable;

class TaskManager {

    static bool active = true;
    static List<(string name, bool completed)> tasks = new List<(string name, bool completed)>();
    public static void Open(){

        Console.WriteLine("Welcome to To-Do List Manager!\n");

        //main loop
        while(active) {
            options();
        }

        Console.WriteLine("\nGoodbye!");

    }

    static void options() {

        Console.WriteLine("1. Add a new task");
        Console.WriteLine("2. View tasks");
        Console.WriteLine("3. Mark task as completed");
        Console.WriteLine("4. Delete a task");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
        Console.WriteLine("");

        switch(getNum()){
            case 1: {add_remove(true);} break;
            case 2: {viewTasks();} break;
            case 3: {complete();} break;
            case 4: {add_remove(false);} break;
            case 5: {active = false;} break;
            default: {Console.WriteLine("invalid, input 1-5 only");} break;
        }

    }

    static void add_remove(bool add) {
        if (add) {
            Console.Write("Insert # of tasks: ");
            int count = getNum();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter name here: ");
                string name = getString();
                tasks.Add((name, false));
                Console.WriteLine($"Added {name}!\n");
            }
        } else {
            Console.Write("Insert # of removals: ");
            int count = getNum();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter #: ");
                int num = getNum();
                tasks.RemoveAt(num - 1);
                Console.WriteLine($"Removed task {num}");
            }
            
        }
    }

    static void viewTasks() {
        Console.WriteLine("\nTo-Do list:");
        for (int i = 0; i < tasks.Count; i++)
        {
            string completed = "[ ]";
            if (tasks[i].completed == true) {completed = "[X]";} else {completed = "[ ]";}
            Console.WriteLine($"{i + 1}. {completed} {tasks[i].name}");
        }
        Console.WriteLine("");
    }

    static void complete() {
        Console.Write("Enter #: ");
        int num = getNum();
        if (num > tasks.Count || num < 1) {Console.WriteLine("Invalid!");} else {
            tasks[num - 1] = (tasks[num - 1].name, true);
            Console.WriteLine($"{tasks[num - 1].name} marked as completed!\n");
        }
        
    }

    static int getNum() {return Convert.ToInt32(Console.ReadLine());}
    static string getString() {return Console.ReadLine();}

}  