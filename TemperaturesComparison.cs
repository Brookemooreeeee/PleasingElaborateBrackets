using System;

class Program 
{
  static void Main (string[] args) 
  {
    //Constants for the number of days recorded and valid temp. range
    const int NumDays = 5;
    const int MinTemp = -30;
    const int MaxTemp = 130;

    //Array to store the temperatures
    int[] temps = new int[NumDays];

    //Loop to validate temp. within range and store
    for (int i = 0; i < NumDays; i++)
    {
      int temp;
      Console.Write($"Enter temperature {i + 1} (between {MinTemp} and {MaxTemp}): ");
      while (!int.TryParse(Console.ReadLine(), out temp) || temp < MinTemp || temp > MaxTemp)  
      {
        Console.Write($"\nTemperature {temp} is invalid. Please enter a valid temperature between {MinTemp} and {MaxTemp}: ");
      }
      temps[i] = temp;
    }

    //Check trends of temp.
    bool isGettingWarmer = true;
    bool isGettingCooler = true;

    //Loop to compare temp. through the days
    for (int i = 1; i < NumDays; i++)
    {
      if (temps[i] <= temps[i - 1])
      {
        isGettingWarmer = false;
      }
      if (temps[i] >= temps[i - 1])
      {
        isGettingCooler = false;
      }
    }

    //Determine and display temp trend based on comparison
    if (isGettingWarmer)
    {
      Console.WriteLine ("\nGetting warmer.");
    }
    else if (isGettingCooler)
    {
      Console.WriteLine ("\nGetting cooler.");
    }
    else
    {
      Console.WriteLine ("\nIt's a mixed bag.");
    }

    //Display the temps in the order entered
    Console.WriteLine("Temperatures entered: " + string.Join(", ", temps));

    //Calculate and display average temp. for recorded days
    double allTemp = 0;
    for (int i = 0; i < NumDays; i++)
    {
      allTemp += temps[i];
    }
    double averageTemp = allTemp / NumDays;
    Console.WriteLine($"Average temperature: {averageTemp}");
  }
}