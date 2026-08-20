// ==========================================================
// SNIPPET 08 - AVOID BLOCKING ASYNC CODE
// .Result + .Wait() vs await
// ==========================================================
//
// This snippet demonstrates an important async rule:
//
// AVOID BLOCKING asynchronous code.
//
// The professor gives two examples to avoid:
//
// GetDataAsync().Result
//
// and:
//
// GetDataAsync().Wait()
//
// The preferred approach is:
//
// await GetDataAsync();
//
// ==========================================================


// Gives us access to basic C# features such as Console.
using System;

// Gives us access to Task and asynchronous programming.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 08 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet08BlockingAsyncCode.RunAsync();
//
// ==========================================================

public static class Snippet08BlockingAsyncCode
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // This method demonstrates the RECOMMENDED approach.
    //
    // We will keep the professor's .Result and .Wait()
    // examples below for learning purposes, but we will
    // NOT execute them.
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // AVOID: .RESULT
        // ==================================================
        //
        // The professor says to avoid:
        //
        // var result = GetDataAsync().Result;
        //
        // .Result forces the calling code to synchronously
        // wait for an asynchronous Task to finish.
        //
        // This is sometimes called:
        //
        // "sync-over-async"
        //
        // The professor notes that this can contribute
        // to deadlocks and reduce scalability.
        //
        // We are therefore NOT executing this line:
        //
        // var blockedResult = GetDataAsync().Result;
        //
        // ==================================================


        // ==================================================
        // ALSO AVOID: .WAIT()
        // ==================================================
        //
        // The professor also says to avoid:
        //
        // GetDataAsync().Wait();
        //
        // .Wait() also blocks while waiting for the
        // asynchronous operation to complete.
        //
        // We are therefore NOT executing:
        //
        // GetDataAsync().Wait();
        //
        // ==================================================


        // ==================================================
        // PREFER: AWAIT
        // ==================================================
        //
        // The preferred version from the PDF is:
        //
        // var result = await GetDataAsync();
        //
        // "await" allows us to asynchronously wait for
        // the Task to complete.
        //
        // Once GetDataAsync() finishes, its returned
        // string is stored inside "result".
        //
        // ==================================================

        var result = await GetDataAsync();


        // Display the value returned by GetDataAsync().
        Console.WriteLine(result);
    }


    // ======================================================
    // GET DATA ASYNCHRONOUSLY
    // ======================================================
    //
    // The professor's section shows GetDataAsync()
    // being called, but does not provide the full method
    // implementation in this particular section.
    //
    // This small method is OUR wrapper so that we can
    // actually run and observe the preferred await pattern.
    //
    // ======================================================

    private static async Task<string> GetDataAsync()
    {
        // Simulate an asynchronous operation.

        await Task.Delay(1000);


        // Return some example data.

        return "Data retrieved successfully.";
    }
}