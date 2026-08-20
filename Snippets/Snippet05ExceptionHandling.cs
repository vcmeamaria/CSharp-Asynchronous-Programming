// ==========================================================
// SNIPPET 05 - EXCEPTION HANDLING IN ASYNC CODE
// try + catch + await + exceptions
// ==========================================================
//
// This snippet demonstrates how exceptions can be handled
// when working with asynchronous methods.
//
// The important idea is:
//
// - We can use normal try-catch blocks with async code.
// - If an awaited async method throws an exception,
//   the exception can be caught by the surrounding catch.
//
// In this example:
//
// GetDataAsync()
//
// deliberately throws an InvalidOperationException.
//
// The exception is then caught inside RunAsync().
//
// ==========================================================


// Gives us access to basic C# features such as Console
// and Exception types.
using System;

// Gives us access to Task and asynchronous programming.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 05 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet05ExceptionHandling.RunAsync();
//
// ==========================================================

public static class Snippet05ExceptionHandling
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // This method contains our try-catch block.
    //
    // Because we want to use "await" inside this method,
    // it is marked as async.
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // TRY BLOCK
        // ==================================================
        //
        // Code that could potentially fail is placed
        // inside the try block.
        //
        // Here we call GetDataAsync().
        //
        // If the method completes successfully,
        // its returned string is stored inside "data".
        //
        // If it throws an exception, execution moves
        // directly to the catch block.
        //
        // ==================================================

        try
        {
            string data = await GetDataAsync();

            Console.WriteLine(data);
        }


        // ==================================================
        // CATCH BLOCK
        // ==================================================
        //
        // catch (Exception ex)
        //
        // means:
        //
        // "If an exception happens inside the try block,
        // catch it and store information about it in 'ex'."
        //
        // Exception is the base type used for many
        // different C# exceptions.
        //
        // ex.Message gives us the message associated
        // with the exception.
        //
        // ==================================================

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    // ======================================================
    // GET DATA ASYNCHRONOUSLY
    // ======================================================
    //
    // This method returns:
    //
    // Task<string>
    //
    // which normally means:
    //
    // "An asynchronous operation that will eventually
    // return a string."
    //
    // However, in this example the method deliberately
    // FAILS before returning a string.
    //
    // ======================================================

    private static async Task<string> GetDataAsync()
    {
        // ==================================================
        // SIMULATE ASYNCHRONOUS WORK
        // ==================================================
        //
        // Wait approximately one second.
        //
        // This could represent something like:
        //
        // - retrieving data from a database
        // - calling an API
        // - reading a file
        // - waiting for a network response
        //
        // ==================================================

        await Task.Delay(1000);


        // ==================================================
        // THROW AN EXCEPTION
        // ==================================================
        //
        // "throw" is used to create an exception.
        //
        // Here we deliberately create:
        //
        // InvalidOperationException
        //
        // with the message:
        //
        // "Unable to retrieve data."
        //
        // Because this exception happens while the
        // method is being awaited, it travels back to
        // the try-catch block inside RunAsync().
        //
        // ==================================================

        throw new InvalidOperationException(
            "Unable to retrieve data."
        );
    }
}