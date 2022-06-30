using System;
using System.Data;
using Terminal.Gui;
using NStack;

namespace food_catalogue {
    public class Program {
        static void Main(string[] args) {
            Language.ReadTranslation();
            Database.ReadDatabase();
            Application.Init();
            Toplevel top = Application.Top;
            MenuBar menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem(Language.translation.quit, "", () => {Database.WriteDatabase(); top.Running = false;}),
                new MenuBarItem(Language.translation.save, "", () => {Database.WriteDatabase();})
		    });
            top.Add(menu);
            Window win = new Window("Window") {
                X = 0, Y = 1,
                Width = Dim.Fill(), Height = Dim.Fill()
            };
            top.Add(win);
            DataTable dataTable = new DataTable(Language.translation.list);
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Language.translation.id;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);
            TableView tableView = new TableView(dataTable);
            Button remove = new Button(0, 10, (ustring)Language.translation.remove);
            remove.Clicked += RemoveItem;
            void RemoveItem() {
            }
            win.Add(
                new Label(0, 0, Language.translation.list),
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