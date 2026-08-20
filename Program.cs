// ==========================================================
// SNIPPET 01 - BASIC ASYNCHRONOUS PROGRAMMING
// Task + async + await
// ==========================================================

// Gives us access to basic C# features such as Console.
using System;

// Gives us access to Task, which is used for asynchronous work.
using System.Threading.Tasks;


// ==========================================================
// PROGRAM CLASS
// ==========================================================

class Program
{
    // ======================================================
    // MAIN METHOD
    // ======================================================
    //
    // Normally Main might look like:
    //
    // static void Main()
    //
    // But because we want to use "await" inside Main,
    // the method needs to be marked as "async".
    //
    // Task means:
    // "This method performs asynchronous work and will
    // finish at some point, but it does not return a value."
    //
    // ======================================================

    static async Task Main()
    {
        // This happens immediately when the program starts.
        Console.WriteLine("Starting...");


        // ==================================================
        // AWAIT
        // ==================================================
        //
        // DownloadDataAsync() represents some work that
        // takes time.
        //
        // "await" tells C#:
        //
        // "Wait for this asynchronous operation to finish
        // before continuing with the next line."
        //
        // ==================================================

        await DownloadDataAsync();


        // This line only runs once DownloadDataAsync()
        // has completed.
        Console.WriteLine("Finished.");
    }


    // ======================================================
    // ASYNCHRONOUS METHOD
    // ======================================================
    //
    // The method is called DownloadDataAsync.
    //
    // By convention, asynchronous method names normally
    // finish with "Async".
    //
    // async
    // -----
    // Allows us to use "await" inside this method.
    //
    // Task
    // ----
    // Represents an asynchronous operation that does not
    // return a value.
    //
    // ======================================================

    static async Task DownloadDataAsync()
    {
        Console.WriteLine("Downloading data...");


        // ==================================================
        // TASK.DELAY
        // ==================================================
        //
        // Task.Delay(3000) waits for approximately
        // 3000 milliseconds.
        //
        // 3000 milliseconds = 3 seconds.
        //
        // This is being used to SIMULATE a slow operation,
        // such as:
        //
        // - downloading information
        // - accessing a database
        // - calling an API
        // - reading a file
        //
        // Importantly, Task.Delay does not block the thread
        // in the same way that Thread.Sleep would.
        //
        // ==================================================

        await Task.Delay(3000);


        // After the three-second asynchronous delay finishes,
        // the method continues here.
        Console.WriteLine("Download complete.");
    }
}