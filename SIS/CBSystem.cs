using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SIS
{
    public class CBSystem
    {
        public string InputAllText;
        private string InputCurrentText;
        private Thread InputCurrentThread;
        private bool pIsInputOn = false;
        public event EventHandler<string> InputDone;
        public event EventHandler<int> InputKeyPress;
        public event EventHandler InputStart;
        public event EventHandler InputStop;
        public event EventHandler InputUpdate;
        public void GetInputLineAsync()
        {
            InputCurrentThread = new Thread(new ThreadStart(() => {
                if (InputStart is null) { }
                else
                {
                    InputStart(this, null);
                }
                pIsInputOn = true;
                InputCurrentText = "";
                while (true)
                {
                    char input = (char)Console.Read();
                    if (InputKeyPress is null) { }
                    else
                    {
                        InputKeyPress(this, input);
                    }
                    if (input == 13)
                    {
                        break;
                    }
                    else if (input == 8)
                    {
                        InputAllText = InputAllText.Substring(0, InputAllText.Length - 1);
                        InputCurrentText = InputCurrentText.Substring(0, InputCurrentText.Length - 1);
                        Console.Write($"\r{InputAllText}");
                    }
                    else
                    {
                        InputAllText += input + "";
                        InputCurrentText += input + "";
                        //Console.Write(input);
                    }
                    if (InputUpdate is null) { }
                    else
                    {
                        InputUpdate(this, null);
                    }
                }
                if (InputStop is null) { }
                else
                {
                    InputStop(this, null);
                }
                pIsInputOn = false;
                if (InputDone is null) { }
                else
                {
                    InputDone(this, InputCurrentText);
                }
                InputCurrentText = "";
            }));
            InputCurrentThread.Start();
        }
        public string GetInputLine()
        {
            if (InputStart is null) { }
            else
            {
                InputStart(this, null);
            }
            pIsInputOn = true;
            InputCurrentText = "";
            while (true)
            {
                char input = (char)Console.Read();
                if (InputKeyPress is null) { }
                else
                {
                    InputKeyPress(this, input);
                }
                if (input == 13)
                {
                    break;
                }
                else if (input == 8)
                {
                    InputAllText = InputAllText.Substring(0, InputAllText.Length - 1);
                    InputCurrentText = InputCurrentText.Substring(0, InputCurrentText.Length - 1);
                    Console.Write($"\r{InputAllText}");
                }
                else
                {
                    InputAllText += input + "";
                    InputCurrentText += input + "";
                    //Console.Write(input);
                }
                if (InputUpdate is null) { }
                else
                {
                    InputUpdate(this, null);
                }
            }
            if (InputStop is null) { }
            else
            {
                InputStop(this, null);
            }
            pIsInputOn = false;
            if (InputDone is null) { }
            else
            {
                InputDone(this, InputCurrentText);
            }
            return InputCurrentText;
            InputCurrentText = "";
        }

        public void InputClearAll()
        {
            InputAllText = "";
            InputCurrentText = "";
        }
        public bool IsInputOn()
        {
            return pIsInputOn;
        }
        public void StopCurrentInputThread()
        {
            InputCurrentThread.Abort();
        }
        public string OutputAllText;
        private string OutputCurrentLine;
        private string OutputCurrentText;
        public int OutputLatency = 0;
        private Thread OutputCurrentThread;
        public event EventHandler<char> OutputWroteChar;
        public event EventHandler<string> OutputWroteLine;
        public event EventHandler<string> OutputDone;
        public void WriteLine(string line)
        {
            OutputCurrentThread = new Thread(new ThreadStart(() => {
                OutputCurrentLine = "";
                OutputCurrentText = "";
                foreach (char ch in line)
                {
                    OutputAllText += ch + "";
                    OutputCurrentText += ch + "";
                    OutputCurrentLine += ch + "";
                    Console.Write(ch);
                    if (OutputWroteChar is null) { }
                    else
                    {
                        OutputWroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(OutputLatency);
                }
                if (OutputWroteLine is null) { }
                else
                {
                    OutputWroteLine(this, OutputCurrentLine);
                }
                OutputCurrentLine = "";
                if (OutputDone is null) { }
                else
                {
                    OutputDone(this, OutputCurrentText);
                }
                OutputCurrentText = "";

            }));
            OutputCurrentThread.Start();
        }

        public void WriteLine(byte[] line, Encoding encoding)
        {
            OutputCurrentThread = new Thread(new ThreadStart(() => {
                OutputCurrentText = "";
                OutputCurrentLine = "";
                foreach (char ch in encoding.GetChars(line))
                {
                    OutputAllText += ch + "";
                    OutputCurrentText += ch + "";
                    OutputCurrentLine += ch + "";
                    Console.Write(ch);
                    if (OutputWroteChar is null) { }
                    else
                    {
                        OutputWroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(OutputLatency);
                }
                if (OutputWroteLine is null) { }
                else
                {
                    OutputWroteLine(this, OutputCurrentLine);
                }
                OutputCurrentLine = "";
                if (OutputDone is null) { }
                else
                {
                    OutputDone(this, OutputCurrentText);
                }
                OutputCurrentText = "";
            }));
            OutputCurrentThread.Start();
        }

        public void WriteLine(char[] line)
        {
            OutputCurrentThread = new Thread(new ThreadStart(() => {
                OutputCurrentText = "";
                OutputCurrentLine = "";
                foreach (char ch in line)
                {
                    OutputAllText += ch + "";
                    OutputCurrentText += ch + "";
                    OutputCurrentLine += ch + "";
                    Console.Write(ch);
                    if (OutputWroteChar is null) { }
                    else
                    {
                        OutputWroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(OutputLatency);
                }
                if (OutputWroteLine is null) { }
                else
                {
                    OutputWroteLine(this, OutputCurrentLine);
                }
                OutputCurrentLine = "";
                if (OutputDone is null) { }
                else
                {
                    OutputDone(this, OutputCurrentText);
                }
                OutputCurrentText = "";
            }));
            OutputCurrentThread.Start();
        }

        public void WriteLine(List<char> line)
        {
            OutputCurrentThread = new Thread(new ThreadStart(() => {
                OutputCurrentText = "";
                OutputCurrentLine = "";
                foreach (char ch in line.ToArray())
                {
                    OutputAllText += ch + "";
                    OutputCurrentText += ch + "";
                    OutputCurrentLine += ch + "";
                    Console.Write(ch);
                    if (OutputWroteChar is null) { }
                    else
                    {
                        OutputWroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(OutputLatency);
                }
                if (OutputWroteLine is null) { }
                else
                {
                    OutputWroteLine(this, OutputCurrentLine);
                }
                OutputCurrentLine = "";
                if (OutputDone is null) { }
                else
                {
                    OutputDone(this, OutputCurrentText);
                }
                OutputCurrentText = "";
            }));
            OutputCurrentThread.Start();
        }

        public void WriteLine(List<string> line, bool addSpaceAfterEachString)
        {
            OutputCurrentThread = new Thread(new ThreadStart(() => {
                OutputCurrentText = "";
                foreach (string part in line)
                {
                    OutputCurrentLine = "";
                    foreach (char ch in part)
                    {
                        OutputAllText += ch + "";
                        OutputCurrentText += ch + "";
                        OutputCurrentLine += ch + "";
                        Console.Write(ch);
                        if (OutputWroteChar is null) { }
                        else
                        {
                            OutputWroteChar(this, ch);
                        }
                    }
                    if (OutputWroteLine is null) { }
                    else
                    {
                        OutputWroteLine(this, OutputCurrentLine);
                    }
                    if (addSpaceAfterEachString) { OutputCurrentText += ' '; OutputCurrentLine += ' '; Console.Write(' '); }
                    System.Threading.Thread.Sleep(OutputLatency);
                }
                OutputCurrentLine = "";
                if (OutputDone is null) { }
                else
                {
                    OutputDone(this, OutputCurrentText);
                }
                OutputCurrentText = "";
            }));
            OutputCurrentThread.Start();
        }

        public void Write(char line)
        {
            Console.Write(line);
            if (OutputWroteChar is null) { }
            else
            {
                OutputWroteChar(this, line);
            }
        }

        public void Write(int line)
        {
            Console.Write(line);
            if (OutputWroteChar is null) { }
            else
            {
                OutputWroteChar(this, (char)line);
            }
        }

        public void Write(object line)
        {
            Console.Write(line);
            if (OutputWroteChar is null) { }
            else
            {
                OutputWroteChar(this, (char)line);
            }
        }

        public void OutputClearAll()
        {
            OutputAllText = "";
            OutputCurrentText = "";
            Console.Clear();
        }
    }
}
