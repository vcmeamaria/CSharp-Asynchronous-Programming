// ==========================================================
// SNIPPET 07 - AVOID ASYNC VOID
// async void vs async Task
// ==========================================================
//
// This snippet demonstrates an important async best practice:
//
// AVOID:
//
// async void
//
// PREFER:
//
// async Task
//
// The professor explains that "async void" should normally
// only be used for event handlers, such as UI events.
//
// ==========================================================


// Gives us access to Console.
using System;

// Gives us access to Task and asynchronous programming.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 07 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet07AvoidAsyncVoid.RunAsync();
//
// ==========================================================

public static class Snippet07AvoidAsyncVoid
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // Our runnable example uses the RECOMMENDED version:
    //
    // async Task
    //
    // rather than:
    //
    // async void
    //
    // ======================================================

    public static async Task RunAsync()
    {
        Console.WriteLine("Running the recommended async Task version...");
        Console.WriteLine();

        await DoWorkAsync();

        Console.WriteLine("Work complete.");
    }


    // ======================================================
    // AVOID THIS - ASYNC VOID
    // ======================================================
    //
    // This is the pattern shown in the professor's PDF
    // as something we should normally AVOID:
    //
    // static async void DoWork()
    //
    // Why?
    //
    // A method returning void cannot normally be awaited
    // by the code that calls it.
    //
    // The professor notes that async void should mainly
    // be used for EVENT HANDLERS.
    //
    // We keep this method here for learning purposes,
    // but we do NOT use it in our console program.
    //
    // ======================================================

    private static async void DoWork()
    {
        await Task.Delay(1000);
    }


    // ======================================================
    // PREFER THIS - ASYNC TASK
    // ======================================================
    //
    // This is the recommended version from the PDF:
    //
    // async Task
    //
    // Because this method returns Task, the caller can:
    //
    // await DoWorkAsync();
    //
    // That allows the asynchronous operation to be tracked
    // and awaited properly.
    //
    // The "Async" suffix also follows normal C# naming
    // conventions for asynchronous methods.
    //
    // ======================================================

    private static async Task DoWorkAsync()
    {
        // Simulate approximately one second
        // of asynchronous work.

        await Task.Delay(1000);
    }
}