using System;
using System.Windows.Forms;
using Tweaker.commands;

namespace Tweaker
{
    public class OpenLiftCommand : ICommand
    {
        public OpenLiftCommand()
        {
        }

        public void Execute()
        {
            try
            {
            }
            catch (Exception error)
            {
                MessageBox.Show("Sorry, couldn't open it.\r\n" + error.Message);
            }
        }
    }
}
