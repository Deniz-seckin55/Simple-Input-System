using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SIS
{
    public class CBInputSystem
    {
        public string AllText;
        private string CurrentText;
        private Thread CurrentThread;
        private bool pIsInputOn = false;
        public event EventHandler<string> InputDone;
        public event EventHandler<int> InputKeyPress;
        public event EventHandler InputStart;
        public event EventHandler InputStop;
        public event EventHandler InputUpdate;
        public void GetInputLineAsync()
        {
            CurrentThread = new Thread(new ThreadStart(() => {
                if (InputStart is null){}else {
                    InputStart(this, null);
                }
                pIsInputOn = true;
                CurrentText = "";
                while (true)
                {
                    char input = (char)Console.Read();
                    if (InputKeyPress is null){}else {
                        InputKeyPress(this, input);
                    }
                    if (input == 13)
                    {
                        break;
                    }
                    else if(input == 8)
                    {
                        AllText = AllText.Substring(0, AllText.Length - 1);
                        CurrentText = CurrentText.Substring(0, CurrentText.Length - 1);
                        Console.Write($"\r{AllText}");
                    } else
                    {
                        AllText += input + "";
                        CurrentText += input + "";
                        //Console.Write(input);
                    }
                    if (InputUpdate is null){}else {
                        InputUpdate(this, null);
                    }
                }
                if (InputStop is null){}else {
                    InputStop(this, null);
                }
                pIsInputOn = false;
                if(InputDone is null){}else {
                    InputDone(this, CurrentText);
                }
                CurrentText = "";
            }));
            CurrentThread.Start();
        }
        public string GetInputLine()
        {
            if (InputStart is null) { }
            else
            {
                InputStart(this, null);
            }
            pIsInputOn = true;
            CurrentText = "";
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
                    AllText = AllText.Substring(0, AllText.Length - 1);
                    CurrentText = CurrentText.Substring(0, CurrentText.Length - 1);
                    Console.Write($"\r{AllText}");
                }
                else
                {
                    AllText += input + "";
                    CurrentText += input + "";
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
                InputDone(this, CurrentText);
            }
            return CurrentText;
            CurrentText = "";
        }

        public void ClearAll()
        {
            AllText = "";
            CurrentText = "";
        }
        public bool IsInputOn()
        {
            return pIsInputOn;
        }
        public void StopCurrentInputThread()
        {
            if (CurrentThread is null) { } else
            {
                if (CurrentThread.ThreadState != ThreadState.StopRequested && CurrentThread.ThreadState != ThreadState.Stopped && CurrentThread.ThreadState != ThreadState.Aborted && CurrentThread.ThreadState != ThreadState.AbortRequested)
                {
                    CurrentThread.Abort();
                }
            }
        }
    }
}
