# ServiceConsoleApp

Simple sample of console service application that runs for 5 seconds and every second logs to file.

## Reason of creating sample
The reason for creating this is a want of creating own background service that backups selected databases.
(Future plan to create project)

## Running service
We can run service in 2 options:

### Run as console app and stop service whenever you want
Change one line of code in main function:

```csharp
// main section
...
Console.ReadKey();
...
```
Instead of:
```csharp
// main section
...
await Task.Delay(5000);
...
```
### Run service in Windows Task Scheduler
The easiest way of running this service would be creating new windows scheduler task that runs this exe file, like every day or every hour (depends what you need).

## Project references
Project is made using:
- Microsoft docs as template for using timer.
- https://github.com/faisal5170/WindowsService (I got below method from the repo and refactored it)

```csharp
static Task WriteToFile(string message)
{
 // code...
}
```
