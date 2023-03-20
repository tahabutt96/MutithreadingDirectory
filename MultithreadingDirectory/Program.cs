using System.Diagnostics;
using System.IO;

long totalSize = 0;
long totalFiles = 0;
object lockObj = new object();
var stopwatch = new Stopwatch();
string rootDirectory = "D:\\SourceCodes\\frontend-angular-app-v2"; // Replace with the root directory of your directory tree
Parallel.ForEach(Directory.EnumerateFiles(rootDirectory, "*", SearchOption.AllDirectories), file =>
{
    try
    {
        
        stopwatch.Start();
        Console.WriteLine($"Processing file: {file}");
        var fileInfo = new FileInfo(file);
        Interlocked.Add(ref totalSize, fileInfo.Length);
        Interlocked.Increment(ref totalFiles);
        stopwatch.Stop();
    }
    catch (UnauthorizedAccessException)
    {
        // Handle any files that can't be accessed
    }
});

Console.WriteLine($"Total Size: {totalSize} bytes");
Console.WriteLine($"Total Files: {totalFiles}");
Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
Console.ReadLine();


//Parallel.ForEach(Directory.EnumerateFiles(rootDirectory, "*", SearchOption.AllDirectories), file =>
//{
//    // Perform any action you want on each file here
//    Console.WriteLine($"Processing file: {file}");
//});
