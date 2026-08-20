// ==========================================================
// SNIPPET 01 - BASIC ASYNCHRONOUS PROGRAMMING
// Task + async + await
// ==========================================================
//
// This snippet demonstrates the basic idea of asynchronous
// programming in C#.
//
// We will learn:
//
// - Task
// - async
// - await
// - Task.Delay()
//
// ==========================================================


// Gives us access to basic C# features such as Console.
using System;

// Gives us access to Task and asynchronous programming tools.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 01 CLASS
// ==========================================================
//
// Instead of creating another "Program" class with another
// Main method, each lesson will have its own class.
//
// This allows us to keep ALL of our snippets inside the
// same C# project.
//
// Later, Program.cs will act as our console menu and call:
//
// await Snippet01BasicAsyncAwait.RunAsync();
//
// ==========================================================

public static class Snippet01BasicAsyncAwait
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // In the example's original example, this code was
    // inside:
    //
    // static async Task Main()
    //
    // Because we are building several snippets inside one
    // project, we only want ONE Main method.
    //
    // Therefore, each snippet will have its own:
    //
    // RunAsync()
    //
    // method instead.
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // This happens immediately when the snippet starts.
        Console.WriteLine("Starting...");


        // ==================================================
        // AWAIT
        // ==================================================
        //
        // DownloadDataAsync() represents an operation
        // that takes some time to complete.
        //
        // The "await" keyword tells C#:
        //
        // "Wait until this asynchronous operation is
        // complete before continuing with the next line."
        //
        // ==================================================

        await DownloadDataAsync();


        // This line runs AFTER DownloadDataAsync()
        // has finished.
        Console.WriteLine("Finished.");
    }


    // ======================================================
    // DOWNLOAD DATA METHOD
    // ======================================================
    //
    // This is an asynchronous method.
    //
    // async
    // -----
    // Allows us to use the "await" keyword inside
    // this method.
    //
    // Task
    // ----
    // Represents an asynchronous operation that will
    // complete in the future.
    //
    // Because this is just "Task" and NOT "Task<T>",
    // this method does not return a value.
    //
    // ======================================================

    private static async Task DownloadDataAsync()
    {
        Console.WriteLine("Downloading data...");


        // ==================================================
        // TASK.DELAY
        // ==================================================
        //
        // Task.Delay(3000) creates an asynchronous delay.
        //
        // 3000 milliseconds = 3 seconds.
        //
        // Here it is being used to SIMULATE something slow.
        //
        // In a real application, this could represent:
        //
        // - downloading data from the internet
        // - calling an API
        // - accessing a database
        // - reading a file
        //
        // ==================================================

        await Task.Delay(3000);


        // Once the asynchronous delay has completed,
        // execution continues from here.
        Console.WriteLine("Download complete.");
    }
}