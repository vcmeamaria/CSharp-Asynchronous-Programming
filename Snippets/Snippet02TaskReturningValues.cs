// ==========================================================
// SNIPPET 02 - TASK<T>: RETURNING VALUES ASYNCHRONOUSLY
// Task<int> + async + await + return
// ==========================================================
//
// This snippet demonstrates how an asynchronous method
// can return a VALUE.
//
// In Snippet 01 we used:
//
// Task
//
// That meant:
// "This asynchronous operation will eventually finish."
//
// In this snippet we use:
//
// Task<int>
//
// That means:
// "This asynchronous operation will eventually finish
// AND return an integer."
//
// ==========================================================


// Gives us access to basic C# features such as Console.
using System;

// Gives us access to Task and asynchronous programming tools.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 02 CLASS
// ==========================================================
//
// Just like Snippet 01, this lesson has its own class.
//
// Program.cs will eventually call:
//
// await Snippet02TaskReturningValues.RunAsync();
//
// ==========================================================

public static class Snippet02TaskReturningValues
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // This is the method that Program.cs will call.
    //
    // It uses "async" because we want to use "await"
    // inside the method.
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // CALL AN ASYNC METHOD THAT RETURNS A VALUE
        // ==================================================
        //
        // CalculateTotalAsync() returns:
        //
        // Task<int>
        //
        // This means that the method will eventually
        // produce an integer.
        //
        // "await" waits for that operation to finish.
        //
        // Once it finishes, the integer that was returned
        // is stored inside the variable called "result".
        //
        // ==================================================

        int result = await CalculateTotalAsync();


        // ==================================================
        // DISPLAY THE RESULT
        // ==================================================
        //
        // $"..." is called string interpolation.
        //
        // It allows us to insert variables directly
        // inside a string using:
        //
        // {variableName}
        //
        // If result = 75, this prints:
        //
        // Total: 75
        //
        // ==================================================

        Console.WriteLine($"Total: {result}");
    }


    // ======================================================
    // CALCULATE TOTAL ASYNCHRONOUSLY
    // ======================================================
    //
    // This is the important new part:
    //
    // Task<int>
    //
    // Let's break that down:
    //
    // Task
    // ----
    // Represents asynchronous work.
    //
    // <int>
    // -----
    // Tells C# that this Task will eventually return
    // an integer.
    //
    // Therefore:
    //
    // Task<int>
    //
    // means:
    //
    // "An asynchronous operation that will eventually
    // return an integer."
    //
    // ======================================================

    private static async Task<int> CalculateTotalAsync()
    {
        // ==================================================
        // SIMULATE A SLOW OPERATION
        // ==================================================
        //
        // Task.Delay(1000) waits asynchronously for
        // approximately 1000 milliseconds.
        //
        // 1000 milliseconds = 1 second.
        //
        // In a real application, this could represent:
        //
        // - retrieving values from a database
        // - calling an API
        // - reading information from a file
        // - waiting for network data
        //
        // ==================================================

        await Task.Delay(1000);


        // ==================================================
        // RETURN A VALUE
        // ==================================================
        //
        // Because this method is:
        //
        // Task<int>
        //
        // it needs to return an integer.
        //
        // 50 + 25 = 75
        //
        // So the value returned from this method is:
        //
        // 75
        //
        // ==================================================

        return 50 + 25;
    }
}