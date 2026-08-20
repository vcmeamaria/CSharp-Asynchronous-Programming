// ==========================================================
// SNIPPET 06 - HANDLING EXCEPTIONS WITH TASK.WHENALL
// Multiple Tasks + Task.WhenAll + Exceptions
// ==========================================================
//
// This snippet demonstrates what can happen when
// MULTIPLE asynchronous Tasks fail.
//
// In Snippet 05:
//
// One Task failed
//      ↓
// try-catch handled the exception
//
// In this snippet:
//
// Task 1 fails
// AND
// Task 2 fails
//
// Both Tasks are started before we use:
//
// await Task.WhenAll(task1, task2);
//
// ==========================================================


// Gives us access to basic C# features such as Console
// and Exception.
using System;

// Gives us access to Task and Task.WhenAll.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 06 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet06WhenAllExceptions.RunAsync();
//
// ==========================================================

public static class Snippet06WhenAllExceptions
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // START TASK 1
        // ==================================================
        //
        // FailingTaskOneAsync() begins running here.
        //
        // Notice:
        //
        // We do NOT immediately write:
        //
        // await FailingTaskOneAsync();
        //
        // Instead, we store the Task itself.
        //
        // ==================================================

        Task task1 = FailingTaskOneAsync();


        // ==================================================
        // START TASK 2
        // ==================================================
        //
        // The second asynchronous operation is also
        // started before we wait for either one.
        //
        // ==================================================

        Task task2 = FailingTaskTwoAsync();


        // ==================================================
        // TRY BLOCK
        // ==================================================
        //
        // Both Tasks could fail, so Task.WhenAll()
        // is placed inside a try block.
        //
        // ==================================================

        try
        {
            // ==============================================
            // TASK.WHENALL
            // ==============================================
            //
            // Wait until BOTH:
            //
            // task1
            // AND
            // task2
            //
            // have completed.
            //
            // In this example, both Tasks deliberately
            // throw exceptions.
            //
            // ==============================================

            await Task.WhenAll(task1, task2);
        }


        // ==================================================
        // CATCH BLOCK
        // ==================================================
        //
        // If one or more Tasks fail, execution reaches
        // this catch block.
        //
        // The example's example uses a catch without
        // declaring an Exception variable because we are
        // going to inspect each Task individually below.
        //
        // ==================================================

        catch
        {
            Console.WriteLine("One or more tasks failed.");


            // ==============================================
            // CHECK TASK 1
            // ==============================================
            //
            // task1.Exception will contain exception
            // information if task1 failed.
            //
            // We first check that it is not null.
            //
            // InnerException gives us the underlying
            // exception contained inside the Task.
            //
            // ?. means:
            //
            // "Only access Message if InnerException
            // actually exists."
            //
            // ==============================================

            if (task1.Exception != null)
            {
                Console.WriteLine(
                    task1.Exception.InnerException?.Message
                );
            }


            // ==============================================
            // CHECK TASK 2
            // ==============================================
            //
            // We do the same thing for the second Task.
            //
            // ==============================================

            if (task2.Exception != null)
            {
                Console.WriteLine(
                    task2.Exception.InnerException?.Message
                );
            }
        }
    }


    // ======================================================
    // FAILING TASK ONE
    // ======================================================
    //
    // This method deliberately fails.
    //
    // It waits approximately 500 milliseconds and then
    // throws an Exception.
    //
    // 500 milliseconds = 0.5 seconds.
    //
    // ======================================================

    private static async Task FailingTaskOneAsync()
    {
        await Task.Delay(500);

        throw new Exception("Task one failed.");
    }


    // ======================================================
    // FAILING TASK TWO
    // ======================================================
    //
    // This method also deliberately fails.
    //
    // It waits approximately 700 milliseconds and then
    // throws another Exception.
    //
    // 700 milliseconds = 0.7 seconds.
    //
    // ======================================================

    private static async Task FailingTaskTwoAsync()
    {
        await Task.Delay(700);

        throw new Exception("Task two failed.");
    }
}