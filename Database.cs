using Newtonsoft.Json;

namespace food_catalogue {
    public class FoodItem {
        public FoodItem(Int32 pid, Int32 pexpiration, Int16 pquantity, Int16 plocation) {
            id = pid;
            expiration = pexpiration;
            quantity = pquantity;
            location = plocation;
        }
        public Int32 id {get; set;}
        public Int32 expiration {get; set;}
        public Int16 quantity {get; set;}
        public Int16 location {get; set;}
    }

    public class Identifier {
        public Identifier(Int32 pid, string? pname) {
            id = pid;
            name = pname;
        }
        public Int32 id {get; set;}
        public string? name {get; set;}
    }

    public class Location {
        public Location(Int16 plocation, string? pname) {
            location = plocation;
            name = pname;
        }
        public Int16 location {get; set;}
        public string? name {get; set;}
    }

    public class Index {
        public Identifier[]? ids {get; set;}
        public Location[]? locations {get; set;}
    }

    public class Database {
        public static void ReadDatabase() {
            string fileContent = File.ReadAllText("database/data.json");
            foodItems = JsonConvert.DeserializeObject<FoodItem[]>(fileContent);
            fileContent = File.ReadAllText("database/index.json");
            index = JsonConvert.DeserializeObject<Index>(fileContent);
            if(foodItems == null) foodItems = new FoodItem[0];
            foodItems = foodItems.Append(new FoodItem(70, 788954, 4, 2)).ToArray();
            if(index == null) index = new Index();
            if(index.ids == null) index.ids = new Identifier[0];
            index.ids = index.ids.Append(new Identifier(70, "Hamburger")).ToArray();
        }

        public static void WriteDatabase() {
            File.WriteAllText("database/data.json", JsonConvert.SerializeObject(foodItems));
            File.WriteAllText("database/index.json", JsonConvert.SerializeObject(index));
        }

        public static FoodItem[]? foodItems;
        public static Index? index;
    }
}