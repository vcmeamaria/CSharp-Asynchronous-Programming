// ==========================================================
// SNIPPET 11 - MINI EXERCISE
// Combining async / await concepts
// ==========================================================
//
// The example's exercise asks us to:
//
// 1. Get a user profile asynchronously.
// 2. Get the user's order list asynchronously.
// 3. Run both operations in parallel.
// 4. Handle exceptions using try-catch.
// 5. Use Task<T> first.
// 6. Then refactor one cached method to ValueTask<T>.
//
// This final snippet combines several concepts from the
// previous lessons.
//
// ==========================================================


// Gives us access to Console and Exception.
using System;

// Gives us access to Dictionary for our simple cache.
using System.Collections.Generic;

// Gives us access to Task, Task<T>, Task.WhenAll
// and ValueTask<T>.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 11 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet11MiniExercise.RunAsync();
//
// ==========================================================

public static class Snippet11MiniExercise
{
    // ======================================================
    // SIMPLE PROFILE CACHE
    // ======================================================
    //
    // The example asks us to refactor one cached method
    // to use ValueTask<T>.
    //
    // The PDF does not provide the exact cache implementation
    // for the exercise, so we are creating a simple one
    // based on the ValueTask cache example from Snippet 09.
    //
    // User ID 1 already has a cached profile.
    //
    // ======================================================

    private static readonly Dictionary<int, string> _profileCache = new()
    {
        { 1, "Profile loaded from cache" }
    };


    // ======================================================
    // RUNASYNC METHOD
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // TRY-CATCH
        // ==================================================
        //
        // The example specifically asks us to handle
        // exceptions using try-catch.
        //
        // Therefore, our asynchronous operations are
        // placed inside this try block.
        //
        // ==================================================

        try
        {
            // ==============================================
            // PART 1 - TASK<T>
            // ==============================================
            //
            // First, we use Task<T> exactly as requested.
            //
            // Both methods return:
            //
            // Task<string>
            //
            // IMPORTANT:
            //
            // We do NOT await them immediately.
            //
            // We start BOTH Tasks first so they can run
            // at the same time.
            //
            // ==============================================

            Task<string> profileTask = GetProfileAsync();

            Task<string> ordersTask = GetOrdersAsync();


            // ==============================================
            // TASK.WHENALL
            // ==============================================
            //
            // Wait until BOTH asynchronous operations
            // have completed.
            //
            // Because both Tasks were started first,
            // they can run concurrently.
            //
            // Each Task takes approximately one second,
            // so together they should take roughly
            // one second rather than two.
            //
            // ==============================================

            await Task.WhenAll(profileTask, ordersTask);


            // ==============================================
            // DISPLAY TASK<T> RESULTS
            // ==============================================
            //
            // These two lines follow the final-call pattern
            // supplied by the example in the PDF.
            //
            // ==============================================

            Console.WriteLine(await profileTask);

            Console.WriteLine(await ordersTask);


            // ==============================================
            // PART 2 - VALUETASK<T> CACHE REFACTOR
            // ==============================================
            //
            // The exercise then asks us to refactor one
            // cached method to use ValueTask<T>.
            //
            // We use our profile cache for this section.
            //
            // User ID 1 already exists inside the cache,
            // so the result can be returned immediately.
            //
            // ==============================================

            Console.WriteLine();

            string cachedProfile =
                await GetCachedProfileAsync(1);

            Console.WriteLine(cachedProfile);
        }


        // ==================================================
        // EXCEPTION HANDLING
        // ==================================================
        //
        // If any operation inside the try block throws
        // an exception, execution moves here.
        //
        // ex.Message gives us the error message.
        //
        // ==================================================

        catch (Exception ex)
        {
            Console.WriteLine(
                $"Error: {ex.Message}"
            );
        }
    }


    // ======================================================
    // GET PROFILE ASYNCHRONOUSLY
    // ======================================================
    //
    // This method comes from the starter provided
    // by the example.
    //
    // Task<string> means:
    //
    // "An asynchronous operation that will eventually
    // return a string."
    //
    // ======================================================

    private static async Task<string> GetProfileAsync()
    {
        // Simulate approximately one second of
        // asynchronous work.

        await Task.Delay(1000);


        // Return the profile result.

        return "Profile loaded";
    }


    // ======================================================
    // GET ORDERS ASYNCHRONOUSLY
    // ======================================================
    //
    // This is also based directly on the example's
    // starter code.
    //
    // ======================================================

    private static async Task<string> GetOrdersAsync()
    {
        // Simulate approximately one second of
        // asynchronous work.

        await Task.Delay(1000);


        // Return the order result.

        return "Orders loaded";
    }


    // ======================================================
    // CACHED PROFILE USING VALUETASK<T>
    // ======================================================
    //
    // This is our implementation of requirement 6:
    //
    // "Then refactor one cached method to use ValueTask<T>."
    //
    // ValueTask<string> is useful here because the result
    // may already be available immediately from the cache.
    //
    // ======================================================

    private static ValueTask<string> GetCachedProfileAsync(int userId)
    {
        // ==================================================
        // CHECK THE CACHE
        // ==================================================
        //
        // TryGetValue checks whether the requested user ID
        // already exists inside the Dictionary.
        //
        // If found:
        //
        // - the method returns true
        // - the stored profile is placed inside "profile"
        //
        // ==================================================

        if (_profileCache.TryGetValue(
            userId,
            out string? profile))
        {
            // ==============================================
            // PROFILE ALREADY AVAILABLE
            // ==============================================
            //
            // No asynchronous work is necessary.
            //
            // ValueTask.FromResult(profile)
            //
            // returns an already-completed ValueTask
            // containing the cached result.
            //
            // ==============================================

            return ValueTask.FromResult(profile);
        }


        // ==================================================
        // PROFILE NOT CACHED
        // ==================================================
        //
        // If the profile is not already available,
        // we fall back to our asynchronous Task method.
        //
        // GetProfileAsync() returns Task<string>.
        //
        // We wrap that Task inside ValueTask<string>.
        //
        // ==================================================

        return new ValueTask<string>(
            GetProfileAsync()
        );
    }
}