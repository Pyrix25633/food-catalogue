using System;
using Terminal.Gui;

namespace food_catalogue {
    public class Program {
        static void Main(string[] args) {
            Application.Init();
            Toplevel top = Application.Top;
            View label = new Label("Label: ") {X = 3, Y = 2};
            top.Add(label);
            MenuBar menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_Quit", "", () => {top.Running = false;})
		    });
            top.Add(menu);
            Application.Run();
        }
    }
}