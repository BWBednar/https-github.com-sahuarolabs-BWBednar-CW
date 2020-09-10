using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login200D
{
    public delegate void StateObs(State s);
    public delegate void InputHandler(State s, string str);
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CredentialD model = new CredentialD("Alice", "Wonderland");
            ControllerD controller = new ControllerD(model);
            Login200D view = new Login200D(controller.handleEvents);
            controller.registerObs(view.DisplayState);

            Application.Run(view);
        }
    }
}
