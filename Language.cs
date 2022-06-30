using Newtonsoft.Json;

namespace food_catalogue {
    public class Language {
        public static string language = "en-us";
        public static Translation translation = new Translation();
        public static void ReadTranslation() {
            string fileContent = File.ReadAllText("translations/lang.json");
            Lang? lang = JsonConvert.DeserializeObject<Lang>(fileContent);
            if(lang != null && lang.language != null) language = lang.language;
            fileContent = File.ReadAllText("translations/" + language + ".json");
            Translation? temp = JsonConvert.DeserializeObject<Translation>(fileContent);
            if(temp != null) translation = temp;
        }
    }

    public class Translation {
        public string? quit {get; set;}
        public string? save {get; set;}
        public string? remove {get; set;}
        public string? expired {get; set;}
    }
    public class Lang {
        public string? language {get; set;}
    }
}