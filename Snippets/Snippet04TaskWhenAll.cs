// ==========================================================
// SNIPPET 04 - RUNNING TASKS IN PARALLEL WITH TASK.WHENALL
// Starting multiple asynchronous operations together
// ==========================================================
//
// This snippet demonstrates how independent asynchronous
// operations can run at the SAME TIME.
//
// In Snippet 03 we did this:
//
// string user = await GetUserAsync();
// string orders = await GetOrdersAsync();
//
// That meant:
//
// Get user
//    ↓
// wait ~1 second
//    ↓
// Get orders
//    ↓
// wait ~1 second
//
// TOTAL ≈ 2 seconds
//
//
// In this snippet, we START both Tasks first:
//
// Task<string> userTask = GetUserAsync();
// Task<string> ordersTask = GetOrdersAsync();
//
// Then we wait for BOTH using:
//
// await Task.WhenAll(userTask, ordersTask);
//
// Because both operations take approximately 1 second,
// the total time is approximately 1 second.
//
// ==========================================================


// Gives us access to basic C# features such as Console.
using System;

// Gives us access to Task, Task<T>, Task.WhenAll,
// and asynchronous programming tools.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 04 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet04TaskWhenAll.RunAsync();
//
// ==========================================================

public static class Snippet04TaskWhenAll
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // START THE FIRST TASK
        // ==================================================
        //
        // IMPORTANT:
        //
        // Notice that we do NOT write:
        //
        // string user = await GetUserAsync();
        //
        // Instead, we call GetUserAsync() and store the
        // Task itself inside "userTask".
        //
        // The asynchronous operation starts,
        // but we do NOT immediately wait for it here.
        //
        // Task<string> means:
        //
        // "An asynchronous operation that will eventually
        // return a string."
        //
        // ==================================================

        Task<string> userTask = GetUserAsync();


        // ==================================================
        // START THE SECOND TASK
        // ==================================================
        //
        // Because we have not awaited userTask yet,
        // the program can now start GetOrdersAsync()
        // as well.
        //
        // So at this point BOTH asynchronous operations
        // have been started.
        //
        // ==================================================

        Task<string> ordersTask = GetOrdersAsync();


        // ==================================================
        // TASK.WHENALL
        // ==================================================
        //
        // Task.WhenAll() allows us to wait for multiple
        // Tasks together.
        //
        // Here we tell C#:
        //
        // "Wait until BOTH userTask AND ordersTask
        // have completed."
        //
        // Because the two operations are independent,
        // they can run concurrently.
        //
        // ==================================================

        await Task.WhenAll(userTask, ordersTask);


        // ==================================================
        // GET THE RESULTS
        // ==================================================
        //
        // At this point Task.WhenAll has completed.
        //
        // This means BOTH:
        //
        // userTask
        //
        // AND
        //
        // ordersTask
        //
        // have finished.
        //
        // The example's example uses .Result here
        // to access the value stored inside each Task.
        //
        // userTask.Result
        //
        // gives us:
        //
        // "User: John"
        //
        // ordersTask.Result
        //
        // gives us:
        //
        // "Orders: 5"
        //
        // ==================================================

        Console.WriteLine(userTask.Result);
        Console.WriteLine(ordersTask.Result);
    }


    // ======================================================
    // GET USER ASYNCHRONOUSLY
    // ======================================================
    //
    // This is the same type of method we used
    // in Snippet 03.
    //
    // Task<string> means that the asynchronous operation
    // eventually returns a string.
    //
    // ======================================================

    private static async Task<string> GetUserAsync()
    {
        // Simulate approximately one second
        // of asynchronous work.

        await Task.Delay(1000);


        // Return the simulated user information.

        return "User: John";
    }


    // ======================================================
    // GET ORDERS ASYNCHRONOUSLY
    // ======================================================

    private static async Task<string> GetOrdersAsync()
    {
        // Simulate approximately one second
        // of asynchronous work.

        await Task.Delay(1000);


        // Return the simulated order information.

        return "Orders: 5";
    }
}