// ==========================================================
// SNIPPET 10 - ASYNC API / WEBSITE SERVICE
// HttpClient + Task<string> + await + exception handling
// ==========================================================
//
// This snippet demonstrates a more realistic use of
// asynchronous programming.
//
// Instead of using Task.Delay() to simulate slow work,
// this example performs a REAL network request.
//
// The application:
//
// 1. Sends a request to https://example.com
// 2. Waits asynchronously for the website response
// 3. Receives the HTML as a string
// 4. Displays how many characters were downloaded
//
// It also demonstrates exception handling for
// network-related errors.
//
// ==========================================================


// Gives us access to Console and general Exception types.
using System;

// Gives us access to HttpClient and HttpRequestException.
using System.Net.Http;

// Gives us access to Task and asynchronous programming.
using System.Threading.Tasks;


// ==========================================================
// SNIPPET 10 CLASS
// ==========================================================
//
// Program.cs will call:
//
// await Snippet10AsyncApiService.RunAsync();
//
// ==========================================================

public static class Snippet10AsyncApiService
{
    // ======================================================
    // RUNASYNC METHOD
    // ======================================================
    //
    // This contains the main logic from the professor's
    // Program.Main example.
    //
    // ======================================================

    public static async Task RunAsync()
    {
        // ==================================================
        // TRY BLOCK
        // ==================================================
        //
        // Network requests can fail for many reasons:
        //
        // - no internet connection
        // - website unavailable
        // - connection interrupted
        //
        // Therefore, the async website request is placed
        // inside a try block.
        //
        // ==================================================

        try
        {
            // ==============================================
            // GET WEBSITE ASYNCHRONOUSLY
            // ==============================================
            //
            // WebsiteService.GetWebsiteAsync(...)
            //
            // returns:
            //
            // Task<string>
            //
            // That means the operation will eventually
            // return a string containing the website HTML.
            //
            // "await" waits asynchronously for the network
            // operation to finish.
            //
            // ==============================================

            string html = await WebsiteService.GetWebsiteAsync(
                "https://example.com"
            );


            // ==============================================
            // DISPLAY THE RESULT
            // ==============================================
            //
            // html.Length tells us how many characters
            // exist inside the downloaded HTML string.
            //
            // For example, the output could look like:
            //
            // Downloaded 1256 characters.
            //
            // The exact number may vary depending on
            // the website response.
            //
            // ==============================================

            Console.WriteLine(
                $"Downloaded {html.Length} characters."
            );
        }


        // ==================================================
        // NETWORK ERROR
        // ==================================================
        //
        // HttpRequestException represents errors related
        // specifically to HTTP / network requests.
        //
        // By catching it separately, our application can
        // distinguish a network problem from other errors.
        //
        // ==================================================

        catch (HttpRequestException ex)
        {
            Console.WriteLine(
                $"Network error: {ex.Message}"
            );
        }


        // ==================================================
        // UNEXPECTED ERROR
        // ==================================================
        //
        // This catches other exception types that were
        // not handled by the HttpRequestException catch.
        //
        // ==================================================

        catch (Exception ex)
        {
            Console.WriteLine(
                $"Unexpected error: {ex.Message}"
            );
        }
    }


    // ======================================================
    // WEBSITE SERVICE
    // ======================================================
    //
    // The professor creates a separate WebsiteService
    // class for the HTTP request.
    //
    // We keep that same separation here, but place it
    // inside Snippet 10 so this lesson remains
    // self-contained inside one file.
    //
    // ======================================================

    private static class WebsiteService
    {
        // ==================================================
        // HTTPCLIENT
        // ==================================================
        //
        // HttpClient is used to send HTTP requests.
        //
        // The professor declares ONE reusable HttpClient
        // rather than creating a new one for every request.
        //
        // static
        // ------
        // Means the same HttpClient belongs to the class.
        //
        // readonly
        // --------
        // Means the field cannot later be replaced with
        // another HttpClient instance.
        //
        // ==================================================

        private static readonly HttpClient _httpClient = new();


        // ==================================================
        // GET WEBSITE ASYNCHRONOUSLY
        // ==================================================
        //
        // This method receives a website URL.
        //
        // It returns:
        //
        // Task<string>
        //
        // because the HTTP request is asynchronous and will
        // eventually produce a string containing the HTML.
        //
        // ==================================================

        public static async Task<string> GetWebsiteAsync(string url)
        {
            // ==============================================
            // GETSTRINGASYNC
            // ==============================================
            //
            // GetStringAsync(url) sends an HTTP GET request
            // to the supplied URL.
            //
            // It asynchronously waits for the response
            // and returns the response body as a string.
            //
            // ==============================================

            return await _httpClient.GetStringAsync(url);
        }
    }
}