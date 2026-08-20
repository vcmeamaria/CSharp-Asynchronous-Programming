# C# Asynchronous Programming

A C# console project for practising asynchronous programming concepts including `Task`, `async`, `await`, `Task.WhenAll`, exception handling, `ValueTask`, and asynchronous HTTP requests.

Each topic is stored in its own snippet and can be launched from the main console menu.

---

## 📂 Project Structure

```text
CSharp-Asynchronous-Programming
│
├── Program.cs
├── CSharpAsynchronousProgramming.csproj
├── CSharp-Asynchronous-Programming.slnx
│
└── Snippets
    ├── Snippet01BasicAsyncAwait.cs
    ├── Snippet02TaskReturningValues.cs
    ├── Snippet03SequentialAsync.cs
    ├── Snippet04TaskWhenAll.cs
    ├── Snippet05ExceptionHandling.cs
    ├── Snippet06WhenAllExceptions.cs
    ├── Snippet07AvoidAsyncVoid.cs
    ├── Snippet08BlockingAsyncCode.cs
    ├── Snippet09ValueTaskCache.cs
    ├── Snippet10AsyncApiService.cs
    └── Snippet11MiniExercise.cs
```

---

# Snippets

## 01 — Basic `Task` + `async / await`

```text
Program starts
      │
      ▼
"Starting..."
      │
      ▼
DownloadDataAsync()
      │
      ▼
Task.Delay(3000)
      │
      │  wait ~3 seconds
      ▼
"Download complete."
      │
      ▼
"Finished."
```

---

## 02 — `Task<T>`: Returning Values

```text
CalculateTotalAsync()
        │
        ▼
Task.Delay(1000)
        │
        │  wait ~1 second
        ▼
return 50 + 25
        │
        ▼
       75
        │
        ▼
int result = 75
        │
        ▼
"Total: 75"
```

---

## 03 — Sequential Async Operations

```text
GetUserAsync()
      │
      │  wait ~1 second
      ▼
User returned
      │
      ▼
GetOrdersAsync()
      │
      │  wait ~1 second
      ▼
Orders returned

Total ≈ 2 seconds
```

---

## 04 — Parallel Tasks with `Task.WhenAll`

```text
             ┌── GetUserAsync() ──────┐
             │      ~1 second          │
Start ───────┤                         ├── Task.WhenAll()
             │      ~1 second          │
             └── GetOrdersAsync() ────┘
                         │
                         ▼
                  Both complete

Total ≈ 1 second
```

---

## 05 — Exception Handling in Async Code

```text
try
 │
 ▼
await GetDataAsync()
 │
 ▼
Task.Delay(1000)
 │
 ▼
throw InvalidOperationException
 │
 ▼
catch (Exception ex)
 │
 ▼
"Error: Unable to retrieve data."
```

---

## 06 — Exceptions with `Task.WhenAll`

```text
           ┌── Task 1 ── 0.5s ── ❌
Start ─────┤
           └── Task 2 ── 0.7s ── ❌
                     │
                     ▼
              Task.WhenAll()
                     │
                     ▼
                   catch
                     │
           ┌─────────┴─────────┐
           ▼                   ▼
   Task one failed.    Task two failed.
```

---

## 07 — Avoid `async void`

```text
❌ Avoid

async void DoWork()
        │
        └── cannot normally be awaited


✅ Prefer

async Task DoWorkAsync()
        │
        ▼
await DoWorkAsync()
```

---

## 08 — Avoid Blocking Async Code

```text
❌ Blocking

GetDataAsync().Result

GetDataAsync().Wait()


✅ Preferred

await GetDataAsync()
        │
        ▼
asynchronous wait
        │
        ▼
result returned
```

---

## 09 — `ValueTask<T>` and Cached Results

```text
              GetUserNameAsync(id)
                       │
                       ▼
                 Is it cached?
                  /          \
                YES           NO
                 │             │
                 ▼             ▼
      ValueTask.FromResult   Load from database
                 │             │
                 │          wait ~1 sec
                 │             │
                 └──────┬──────┘
                        ▼
                      Result
```

---

## 10 — Async API Service

```text
https://example.com
        │
        ▼
GetWebsiteAsync()
        │
        ▼
HttpClient.GetStringAsync()
        │
        │  waiting for internet response...
        ▼
HTML string received
        │
        ▼
html.Length
        │
        ▼
Downloaded XXXX characters.
```

---

## 11 — Async / Await Mini Exercise

```text
           ┌── GetProfileAsync() ──┐
           │                        │
Start ─────┤                        ├── Task.WhenAll()
           │                        │
           └── GetOrdersAsync() ───┘
                        │
                        ▼
                  Results returned
                        │
                        ▼
                    try / catch
                        │
                        ▼
              GetCachedProfileAsync()
                        │
                        ▼
               ValueTask<string>
                        │
                        ▼
                   Cached result
```

---

# ▶️ Running the Project

Open the solution in Visual Studio:

```text
CSharp-Asynchronous-Programming.slnx
```

Run the project and choose a snippet from the console menu:

```text
==================================================
        C# ASYNCHRONOUS PROGRAMMING
==================================================

Choose a snippet to run:

1  - Basic Task + async / await
2  - Task<T>: Returning Values Asynchronously
3  - Sequential Async Operations
4  - Running Tasks in Parallel with Task.WhenAll
5  - Exception Handling in Async Code
6  - Handling Exceptions with Task.WhenAll
7  - Avoid async void
8  - Avoid Blocking Async Code
9  - ValueTask and Cached Results
10 - Async API Service
11 - Mini Exercise

0  - Exit
```

---
