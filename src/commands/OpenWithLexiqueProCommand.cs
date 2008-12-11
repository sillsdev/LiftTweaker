using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Tweaker.commands;

namespace Tweaker
{
    public class OpenWithLexiqueProCommand : ICommand
    {
        private readonly TweakProcess _tweakProcess;

        public OpenWithLexiqueProCommand(TweakProcess tweakProcess)
        {
            _tweakProcess = tweakProcess;
            
        }

        public void Execute()
        {
            try
            {
                var key = Registry.ClassesRoot.OpenSubKey(@"Applications\LexiquePro.exe\shell\open\command");
                if (key == null)
                {
                    MessageBox.Show("Sorry, could not figure out where Lexique Pro is.");
                    return;
                }
                var cmd = key.GetValue("") as string;
                cmd = cmd.Replace("/f", "");
                cmd = cmd.Replace("\"%1\"", "");
                cmd = cmd.Replace("\"", "");

                System.Diagnostics.Process.Start(cmd, "/f "+ "\""+_tweakProcess.ApplyTweaksAndGivePathToTweakedLift()+"\"");
            }
            catch (Exception error)
            {
                MessageBox.Show("Sorry, couldn't open it.\r\n" + error.Message);
            }
        }
    }
}
