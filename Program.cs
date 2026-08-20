// ==========================================================
// C# ASYNCHRONOUS PROGRAMMING
// MAIN CONSOLE MENU
// ==========================================================
//
// This file is the ENTRY POINT of the application.
//
// Each lesson from the example's Async / Await PDF
// will have its own separate class inside the
// "Snippets" folder.
//
// Program.cs acts as a launcher:
//
// 1. Display all available snippets.
// 2. Ask the user which one they want to run.
// 3. Run the selected snippet.
// 4. Return to the menu afterwards.
//
// ==========================================================


// ==========================================================
// MAIN MENU LOOP
// ==========================================================
//
// while (true)
//
// This keeps the application running until the user
// explicitly chooses the Exit option.
//
// After running a snippet, the program comes back here
// and displays the menu again.
//
// ==========================================================

while (true)
{
    // Clear old console output before displaying the menu.
    Console.Clear();


    // ======================================================
    // MENU TITLE
    // ======================================================

    Console.WriteLine("==================================================");
    Console.WriteLine("        C# ASYNCHRONOUS PROGRAMMING");
    Console.WriteLine("==================================================");
    Console.WriteLine();

    Console.WriteLine("Choose a snippet to run:");
    Console.WriteLine();


    // ======================================================
    // example'S ASYNC / AWAIT SNIPPETS
    // ======================================================

    Console.WriteLine("1  - Basic Task + async / await");
    Console.WriteLine("2  - Task<T>: Returning Values Asynchronously");
    Console.WriteLine("3  - Sequential Async Operations");
    Console.WriteLine("4  - Running Tasks in Parallel with Task.WhenAll");
    Console.WriteLine("5  - Exception Handling in Async Code");
    Console.WriteLine("6  - Handling Exceptions with Task.WhenAll");
    Console.WriteLine("7  - Avoid async void");
    Console.WriteLine("8  - Avoid Blocking Async Code");
    Console.WriteLine("9  - ValueTask and Cached Results");
    Console.WriteLine("10 - Async API Service");
    Console.WriteLine("11 - Mini Exercise");

    Console.WriteLine();

    Console.WriteLine("0  - Exit");

    Console.WriteLine();


    // ======================================================
    // READ THE USER'S CHOICE
    // ======================================================
    //
    // Console.ReadLine() waits for the user to type
    // something and press Enter.
    //
    // The value is stored inside the variable "choice".
    //
    // The ? in string? means the value is allowed
    // to be null.
    //
    // ======================================================

    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();


    // ======================================================
    // SWITCH STATEMENT
    // ======================================================
    //
    // The switch checks what the user typed.
    //
    // Example:
    //
    // If choice == "1"
    //      -> Run Snippet 01
    //
    // If choice == "2"
    //      -> Run Snippet 02
    //
    // etc.
    //
    // ======================================================

    switch (choice)
    {
        // ==================================================
        // SNIPPET 01
        // Basic Task + async / await
        // ==================================================

        case "1":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 01",
                "BASIC TASK + ASYNC / AWAIT"
            );

            await Snippet01BasicAsyncAwait.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 02
        // Task<T>: Returning Values Asynchronously
        // ==================================================

        case "2":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 02",
                "TASK<T>: RETURNING VALUES ASYNCHRONOUSLY"
            );

            await Snippet02TaskReturningValues.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 03
        // Sequential Async Operations
        // ==================================================

        case "3":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 03",
                "SEQUENTIAL ASYNC OPERATIONS"
            );

            await Snippet03SequentialAsync.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 04
        // Task.WhenAll
        // ==================================================

        case "4":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 04",
                "RUNNING TASKS IN PARALLEL WITH TASK.WHENALL"
            );


            await Snippet04TaskWhenAll.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 05
        // Exception Handling
        // ==================================================

        case "5":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 05",
                "EXCEPTION HANDLING IN ASYNC CODE"
            );


            await Snippet05ExceptionHandling.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 06
        // Task.WhenAll Exceptions
        // ==================================================

        case "6":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 06",
                "HANDLING EXCEPTIONS WITH TASK.WHENALL"
            );


            await Snippet06WhenAllExceptions.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 07
        // Avoid async void
        // ==================================================

        case "7":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 07",
                "AVOID ASYNC VOID"
            );


            await Snippet07AvoidAsyncVoid.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 08
        // Avoid Blocking Async Code
        // ==================================================

        case "8":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 08",
                "AVOID BLOCKING ASYNC CODE"
            );


            await Snippet08BlockingAsyncCode.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 09
        // ValueTask and Cached Results
        // ==================================================

        case "9":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 09",
                "VALUETASK AND CACHED RESULTS"
            );


            await Snippet09ValueTaskCache.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 10
        // Async API Service
        // ==================================================

        case "10":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 10",
                "ASYNC API SERVICE"
            );


            await Snippet10AsyncApiService.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // SNIPPET 11
        // Mini Exercise
        // ==================================================

        case "11":

            Console.Clear();

            ShowSnippetTitle(
                "SNIPPET 11",
                "ASYNC / AWAIT MINI EXERCISE"
            );

            await Snippet11MiniExercise.RunAsync();


            WaitForMenu();

            break;


        // ==================================================
        // EXIT
        // ==================================================

        case "0":

            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("        C# ASYNCHRONOUS PROGRAMMING");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Goodbye!");

            Console.WriteLine();


            // return exits Program.cs and therefore
            // ends the entire application.

            return;


        // ==================================================
        // INVALID OPTION
        // ==================================================
        //
        // default runs if the user enters something that
        // does not match any of the options above.
        //
        // Examples:
        //
        // 15
        // hello
        // abc
        //
        // ==================================================

        default:

            Console.WriteLine();
            Console.WriteLine("Invalid option.");
            Console.WriteLine();
            Console.WriteLine("Please choose one of the menu options.");

            Console.WriteLine();
            Console.WriteLine("Press any key to try again...");

            Console.ReadKey();

            break;
    }
}


// ==========================================================
// HELPER METHOD - SHOW SNIPPET TITLE
// ==========================================================
//
// Instead of repeating the same title formatting inside
// every menu option, we put it inside one reusable method.
//
// The method receives:
//
// number -> for example "SNIPPET 01"
//
// title  -> for example "BASIC TASK + ASYNC / AWAIT"
//
// ==========================================================

static void ShowSnippetTitle(string number, string title)
{
    Console.WriteLine("==================================================");
    Console.WriteLine($" {number}");
    Console.WriteLine($" {title}");
    Console.WriteLine("==================================================");
    Console.WriteLine();
}


// ==========================================================
// HELPER METHOD - COMING SOON
// ==========================================================
//
// We have already created the complete menu.
//
// However, we haven't created every snippet class yet.
//
// Until a snippet exists, this message allows the menu
// option to work WITHOUT causing compiler errors.
//
// As we build each snippet, we will replace this with:
//
// await SnippetXXSomething.RunAsync();
//
// ==========================================================

static void ShowComingSoonMessage()
{
    Console.WriteLine("This snippet has not been added yet.");
    Console.WriteLine();
    Console.WriteLine("We will build it as part of the next lesson.");
}


// ==========================================================
// HELPER METHOD - RETURN TO MENU
// ==========================================================
//
// Every snippet needs the same behaviour:
//
// 1. Finish running.
// 2. Give us time to read the output.
// 3. Wait for a key.
// 4. Return to the main menu.
//
// Rather than repeating all of that code eleven times,
// we put it inside this reusable method.
//
// ==========================================================

static void WaitForMenu()
{
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine();

    Console.WriteLine("Press any key to return to the menu...");

    Console.ReadKey();
}