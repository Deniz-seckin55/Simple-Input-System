using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SIS
{
    public class CBOutputSystem
    {
        public string AllText;
        private string CurrentLine;
        private string CurrentText;
        public int Latency = 0;
        private Thread CurrentThread;
        public event EventHandler<char> WroteChar;
        public event EventHandler<string> WroteLine;
        public event EventHandler<string> OutputDone;
        public void WriteLine(string line)
        {
            CurrentThread = new Thread(new ThreadStart(() => {
                CurrentLine = "";
                CurrentText = "";
                foreach (char ch in line)
                {
                    AllText += ch + "";
                    CurrentText += ch + "";
                    CurrentLine += ch + "";
                    Console.Write(ch);
                    if (WroteChar is null){}else {
                        WroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(Latency);
                }
                if(WroteLine is null){}else {
                    WroteLine(this, CurrentLine);
                }
                CurrentLine = "";
                if (OutputDone is null){}else {
                    OutputDone(this, CurrentText);
                }
                CurrentText = "";

            }));
            CurrentThread.Start();
        }

        public void WriteLine(byte[] line, Encoding encoding)
        {
            CurrentThread = new Thread(new ThreadStart(() => {
                CurrentText = "";
                CurrentLine = "";
                foreach (char ch in encoding.GetChars(line))
                {
                    AllText += ch + "";
                    CurrentText += ch + "";
                    CurrentLine += ch + "";
                    Console.Write(ch);
                    if (WroteChar is null){}else {
                        WroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(Latency);
                }
                if (WroteLine is null){}else {
                    WroteLine(this, CurrentLine);
                }
                CurrentLine = "";
                if (OutputDone is null){}else {
                    OutputDone(this, CurrentText);
                }
                CurrentText = "";
            }));
            CurrentThread.Start();
        }

        public void WriteLine(char[] line)
        {
            CurrentThread = new Thread(new ThreadStart(() => {
                CurrentText = "";
                CurrentLine = "";
                foreach (char ch in line)
                {
                    AllText += ch + "";
                    CurrentText += ch + "";
                    CurrentLine += ch + "";
                    Console.Write(ch);
                    if (WroteChar is null){}else {
                        WroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(Latency);
                }
                if (WroteLine is null){}else {
                    WroteLine(this, CurrentLine);
                }
                CurrentLine = "";
                if (OutputDone is null){}else {
                    OutputDone(this, CurrentText);
                }
                CurrentText = "";
            }));
            CurrentThread.Start();
        }

        public void WriteLine(List<char> line)
        {
            CurrentThread = new Thread(new ThreadStart(() => {
                CurrentText = "";
                CurrentLine = "";
                foreach (char ch in line.ToArray())
                {
                    AllText += ch + "";
                    CurrentText += ch + "";
                    CurrentLine += ch + "";
                    Console.Write(ch);
                    if (WroteChar is null){}else {
                        WroteChar(this, ch);
                    }
                    System.Threading.Thread.Sleep(Latency);
                }
                if (WroteLine is null){}else {
                    WroteLine(this, CurrentLine);
                }
                CurrentLine = "";
                if (OutputDone is null){}else {
                    OutputDone(this, CurrentText);
                }
                CurrentText = "";
            }));
            CurrentThread.Start();
        }

        public void WriteLine(List<string> line, bool addSpaceAfterEachString)
        {
            CurrentThread = new Thread(new ThreadStart(() => {
                CurrentText = "";
                foreach (string part in line)
                {
                    CurrentLine = "";
                    foreach (char ch in part)
                    {
                        AllText += ch + "";
                        CurrentText += ch + "";
                        CurrentLine += ch + "";
                        Console.Write(ch);
                        if (WroteChar is null){}else {
                            WroteChar(this, ch);
                        }
                    }
                    if (WroteLine is null){}else {
                        WroteLine(this, CurrentLine);
                    }
                    if (addSpaceAfterEachString){CurrentText+=' ';CurrentLine+=' ';Console.Write(' ');}
                    System.Threading.Thread.Sleep(Latency);
                }
                CurrentLine = "";
                if (OutputDone is null){}else {
                    OutputDone(this, CurrentText);
                }
                CurrentText = "";
            }));
            CurrentThread.Start();
        }

        public void Write(char line)
        {
            Console.Write(line);
            if (WroteChar is null){}else {
                WroteChar(this, line);
            }
        }

        public void Write(int line)
        {
            Console.Write(line);
            if (WroteChar is null){} else {
                WroteChar(this, (char)line);
            }
        }

        public void Write(object line)
        {
            Console.Write(line);
            if (WroteChar is null) { }else {
                WroteChar(this, (char)line);
            }
        }

        public void ClearAll()
        {
            AllText = "";
            CurrentText = "";
            Console.Clear();
        }
    }
}
