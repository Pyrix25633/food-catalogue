using System;
using Terminal.Gui;
using NStack;

namespace food_catalogue {
    public class Program {
        static void Main(string[] args) {
            Language.ReadTranslation();
            Application.Init();
            Toplevel top = Application.Top;
            MenuBar menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("Quit", "", () => {top.Running = false;})
		    });
            top.Add(menu);
            Window win = new Window("Window") {
                X = 0, Y = 1,
                Width = Dim.Fill(), Height = Dim.Fill()
            };
            top.Add(win);
            //ListView expired = new ListView();
            Button remove = new Button(0, 10, (ustring)Language.translation.remove);
            remove.Clicked += RemoveItem;
            void RemoveItem() {
                //if(expired.Source.Length > 0)
                    //expired.Source = Functions.RemoveAt(expired.Source, expired.SelectedItem);
            }
            win.Add(
                new Label(0, 0, Language.translation.expired),
                //expired,
                remove
            );
            Application.Run();
            Application.Shutdown();
        }
    }

    public class Functions {
        public static ustring[] RemoveAt(ustring[] source, Int32 index) {
            Int32 lenght = source.Length;
            ustring[] dest = new ustring[lenght - 1];
            if( index > 0 )
                Array.Copy(source, 0, dest, 0, index);

            if( index < lenght - 1 )
                Array.Copy(source, index + 1, dest, index, lenght - index - 1);

            return dest;
        }
    }
}