using System.IO.Pipelines;

class NumAnalyze{

    public static void numData(List<int> numbers) {

        int largest = numbers[0];
        int smallest = numbers[0];
        int sum = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > largest) {largest = numbers[i];}

            if (numbers[i] < smallest) {smallest = numbers[i];}

            sum += numbers[i];
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine("\nResults:");
        Console.WriteLine($"Largest number: {largest}");
        Console.WriteLine($"Smallest number: {smallest}");
        Console.WriteLine($"Average: {average:F2}");
    }

}