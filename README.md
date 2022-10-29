# Simple-Input&Output-System
Simple Input System(SIS) is a easy-to-use tool for C#. A more detailed Console with Input and Output systems.

It is as fast and easy to control and manage.

Some advantages of using SIS are:
  1. Use Input and Output seperately or as one class
  2. Use Events like ``InputKeyPress``,  ``InputDone``, ``OutputWroteChar``, ``OutputWroteLine``, ``OutputDone`` and more...
  3. You can set a duration of waiting time after writing each characther ( Like a Typewriter )
  4. Print multiple lines at once
  5. Automatically convert byte arrays to string and print them
  6. Detect every change in input/output
  7. You can cancel abort the Input thread by using ``StopCurrentInputThread()`` which means you can add a ``timeout``.

<h3>SIS.CBInputSystem</h3>
<h4>Variables</h4>

    -> AllText
     << Gets or sets the current Input ( Yes, you can modify the input in runtime ) >> 

<h4>Events</h4>

    -> InputDone<string>
     << Occurs when the user has pressed the ``enter`` key (string is the inputted text) >> 
     
    -> InputKeyPress<int>
     << Occurs everytime when the user presses a key (char is returned as an int) >> 
     
    -> InputStart
     << Occurs when the user is allowed to input (Used when ``GetInputLineAsync()``) >> 
    
    -> InputStop
     << Occurs when the user is no longer allowed to input >>
     
    -> InputUpdate
     << Occurs every time a lapse passes while the user is inputting >>
<h4>Functions</h4>

    -> GetInputLineAsync() [Void]
     <<  Allows user to start inputting, does it with a thread >>
     
    -> GetInputLine() [String]
     <<  Gets and returns the input from the user >> 
     
    -> ClearAll() [Void]
     <<  Clears ``AllText`` and ``CurrentText`` (Doesn't clear the screen) >> 
     
    -> IsInputOn() [Bool]
     <<  Returns whether the input is on (true) or off (false) (If you are using this immadiately after ``GetInputLineAsync`` at least wait a couple milliseconds so the thread can start) >> 
     
    -> StopCurrentInputThread() [Void]
     <<  Aborts the input thread >>
    
<h3>SIS.CBOutputSystem</h3>
<h4>Variables</h4>

    -> AllText
     << Gets or sets the current Input ( Yes, you can modify the input in runtime for this too ) >>
     
    -> OutputLatency
     << The amount of time to wait after every character >>
     

<h4>Events</h4>

    -> WroteChar<char>
     << Occurs everytime the System has wrote one character of a line (char is the characther that has been written) >> 
     
    -> WroteLine<string>
     << Occurs when a line has been written (string is the written line) >>
     
    -> OutputDone<string>
     << Occurs when the writing thread is done (string is the full output) >>
     
<h4>Functions</h4>

    -> WriteLine(String / byte[] / char[] / List<char> / List<string>, Bool) [Void]
     <<  Writes the text with a pause of ``OutputLatency`` after every character >>
     
     -> Write(Char / Int / Object) [Void]
     << Writes a single object to the console >>
     
     -> ClearAll() [Void]
     << Resets ``AllText`` and ``CurrentText`` variables and clears the console >>

<h3>SIS.CBSystem</h3>
-> Contains both ``SIS.CBInputSystem`` and ``SIS.CBOutputSystem`` combined together in a class.

<h3>Example Code</h3>
```
namespace SISTest
{
    internal class Program
    {
        static SIS.CBSystem Console = new SIS.CBSystem();
        static void Main(string[] args)
        {
            Console.OutputLatency = 100;
            Console.WriteLine("What is your name?");
            string input = Console.GetInputLine();
            Console.WriteLine("Hello " + input + "!");
        }
    }
}
```
-> Input: Cat
-> Output: Hello Cat!



```
namespace SISTest
{
    internal class Program
    {
        static SIS.CBSystem Console = new SIS.CBSystem();
        static void Main(string[] args)
        {
            Console.InputStart += Console_InputStart;
            Console.InputDone += Console_InputDone;
            Console.InputStop += Console_InputStop;
            Console.GetInputLineAsync();
        }

        private static void Console_InputStop(object sender, System.EventArgs e)
        {
            Console.WriteLine("Input has stopped.");
        }

        private static void Console_InputDone(object sender, string e)
        {
            Console.WriteLine("You have typed: "+e);
        }

        private static void Console_InputStart(object sender, System.EventArgs e)
        {
            Console.WriteLine("Start Writing.");
        }
    }
}
```
> Start Writing.
> "Hello!!!"
> Input has stopped.
> You have typed: Hello!!!


✓
