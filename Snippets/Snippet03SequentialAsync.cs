// ==========================================================
// SNIPPET 03 - SEQUENTIAL ASYNC OPERATIONS
// Running asynchronous operations one after another
// ==========================================================
//
// This snippet demonstrates SEQUENTIAL asynchronous work.
//
// Sequential means:
//
// Operation 1 runs
//        ↓
// We wait for it to finish
//        ↓
// Operation 2 runs
//        ↓
// We wait for it to finish
//
// The example's example uses two operations:
//
// 1. GetUserAsync()
// 2. GetOrdersAsync()
//
// Each operation takes approximately 1 second.
//
// Because they run one AFTER the other,
// the total time is approximately 2 seconds.
//
// ==========================================================


// Gives us access to basic C# features such as Console.
using System;

// Gives us access to Task and asynchronous programming tools.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 03 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet03SequentialAsync.RunAsync();
//
// ==========================================================

public static class Snippet03SequentialAsync
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // This is the main method for this snippet.
    //
    // It calls two asynchronous methods sequentially.
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // FIRST ASYNCHRONOUS OPERATION
        // ==================================================
        //
        // GetUserAsync() returns a:
        //
        // Task<string>
        //
        // This means:
        //
        // "This asynchronous operation will eventually
        // return a string."
        //
        // Because we use "await", the program waits for
        // GetUserAsync() to finish before moving on.
        //
        // The returned string is stored in "user".
        //
        // ==================================================

        string user = await GetUserAsync();


        // ==================================================
        // SECOND ASYNCHRONOUS OPERATION
        // ==================================================
        //
        // IMPORTANT:
        //
        // This line does NOT start until GetUserAsync()
        // has completely finished.
        //
        // This is what makes the operations SEQUENTIAL.
        //
        // GetOrdersAsync() also returns a Task<string>.
        //
        // The returned value is stored in "orders".
        //
        // ==================================================

        string orders = await GetOrdersAsync();


        // ==================================================
        // DISPLAY THE RESULTS
        // ==================================================
        //
        // At this point BOTH asynchronous operations
        // have completed.
        //
        // ==================================================

        Console.WriteLine(user);
        Console.WriteLine(orders);
    }


    // ======================================================
    // GET USER ASYNCHRONOUSLY
    // ======================================================
    //
    // Task<string>
    //
    // means that this asynchronous method will eventually
    // return a string.
    //
    // ======================================================

    private static async Task<string> GetUserAsync()
    {
        // Simulate an operation that takes approximately
        // one second.
        //
        // In a real application this could represent
        // retrieving a user from:
        //
        // - a database
        // - an API
        // - a file
        // - another service

        await Task.Delay(1000);


        // Because this method is Task<string>,
        // we return a string.

        return "User: John";
    }


    // ======================================================
    // GET ORDERS ASYNCHRONOUSLY
    // ======================================================
    //
    // This is another asynchronous method that eventually
    // returns a string.
    //
    // ======================================================

    private static async Task<string> GetOrdersAsync()
    {
        // Again, simulate approximately one second
        // of asynchronous work.

        await Task.Delay(1000);


        // Return the simulated order information.

        return "Orders: 5";
    }
}