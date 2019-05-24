using Terminal.Gui;
using System.Runtime;
using Mono.Terminal;

namespace PhotoRename.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
          Application.Init();
          var n = MessageBox.Query(50, 10, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
          //Application.Run ();          
        }
    }
}
