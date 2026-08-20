// ==========================================================
// SNIPPET 09 - VALUETASK<T> AND CACHED RESULTS
// ValueTask<T> + caching + Task<T>
// ==========================================================
//
// This snippet introduces ValueTask<T>.
//
// The professor explains that ValueTask<T> can be useful
// when an asynchronous method is called very frequently
// AND its result is often already available synchronously.
//
// In this example:
//
// User ID 1
//     ↓
// Already exists in the cache
//     ↓
// Return immediately
//
// User ID 2
//     ↓
// Not inside the cache
//     ↓
// Load asynchronously
//     ↓
// Wait approximately 1 second
//
// ==========================================================


// Gives us access to Console.
using System;

// Gives us access to Dictionary<TKey, TValue>.
using System.Collections.Generic;

// Gives us access to Task and ValueTask.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 09 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet09ValueTaskCache.RunAsync();
//
// ==========================================================

public static class Snippet09ValueTaskCache
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // This is our entry point for Snippet 09.
    //
    // We create a CacheService and request two users:
    //
    // ID 1 -> already cached
    // ID 2 -> not cached
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // Create an instance of our CacheService.
        //
        // Unlike our snippet classes, CacheService is
        // not static because it contains its own cache.

        var service = new CacheService();


        // ==================================================
        // USER 1 - CACHED RESULT
        // ==================================================
        //
        // User ID 1 already exists inside the Dictionary.
        //
        // Therefore GetUserNameAsync(1) can return the
        // result immediately.
        //
        // ==================================================

        string name1 = await service.GetUserNameAsync(1);


        // ==================================================
        // USER 2 - NOT CACHED
        // ==================================================
        //
        // User ID 2 does NOT exist inside the cache.
        //
        // Therefore the method needs to call:
        //
        // LoadUserFromDatabaseAsync(2)
        //
        // which waits asynchronously for approximately
        // one second.
        //
        // ==================================================

        string name2 = await service.GetUserNameAsync(2);


        // Display both results.

        Console.WriteLine(name1);
        Console.WriteLine(name2);
    }


    // ======================================================
    // CACHE SERVICE
    // ======================================================
    //
    // This class represents a simple service that can
    // retrieve user names.
    //
    // First it checks whether the result already exists
    // inside a cache.
    //
    // If it does:
    //
    //     return immediately
    //
    // If it does not:
    //
    //     load it asynchronously
    //
    // ======================================================

    private class CacheService
    {
        // ==================================================
        // CACHE
        // ==================================================
        //
        // Dictionary<int, string>
        //
        // means that each entry contains:
        //
        // int    -> user ID
        // string -> user name
        //
        // Our cache currently contains one user:
        //
        // ID:   1
        // Name: "Cached User"
        //
        // ==================================================

        private readonly Dictionary<int, string> _cache = new()
        {
            { 1, "Cached User" }
        };


        // ==================================================
        // GET USER NAME ASYNCHRONOUSLY
        // ==================================================
        //
        // IMPORTANT:
        //
        // Notice the return type:
        //
        // ValueTask<string>
        //
        // rather than:
        //
        // Task<string>
        //
        // ValueTask<string> means this operation can
        // represent either:
        //
        // - a string result that is already available
        //
        // OR
        //
        // - an asynchronous Task<string>
        //
        // ==================================================

        public ValueTask<string> GetUserNameAsync(int id)
        {
            // ==============================================
            // CHECK THE CACHE
            // ==============================================
            //
            // TryGetValue checks whether the Dictionary
            // contains the requested user ID.
            //
            // If it finds the ID:
            //
            // - it returns true
            // - the user's name is stored in "name"
            //
            // ==============================================

            if (_cache.TryGetValue(id, out string? name))
            {
                // ==========================================
                // RESULT ALREADY AVAILABLE
                // ==========================================
                //
                // Because the user's name is already in
                // memory, we do not need to perform an
                // asynchronous database operation.
                //
                // ValueTask.FromResult(name)
                //
                // creates a completed ValueTask containing
                // the result we already have.
                //
                // ==========================================

                return ValueTask.FromResult(name);
            }


            // ==============================================
            // RESULT NOT CACHED
            // ==============================================
            //
            // If the user wasn't found in the cache,
            // we need to perform asynchronous work.
            //
            // LoadUserFromDatabaseAsync(id)
            //
            // returns:
            //
            // Task<string>
            //
            // We wrap that Task inside:
            //
            // ValueTask<string>
            //
            // ==============================================

            return new ValueTask<string>(
                LoadUserFromDatabaseAsync(id)
            );
        }


        // ==================================================
        // LOAD USER FROM DATABASE
        // ==================================================
        //
        // This represents the slower path.
        //
        // The professor calls this:
        //
        // LoadUserFromDatabaseAsync
        //
        // There isn't a real database here.
        //
        // Task.Delay(1000) simply simulates the time
        // that a database operation might take.
        //
        // ==================================================

        private async Task<string> LoadUserFromDatabaseAsync(int id)
        {
            // Simulate approximately one second
            // of asynchronous database work.

            await Task.Delay(1000);


            // Return a simulated user name.
            //
            // If id = 2:
            //
            // this returns "User 2".

            return $"User {id}";
        }
    }
}