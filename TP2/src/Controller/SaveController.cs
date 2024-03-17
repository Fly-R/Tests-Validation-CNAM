using MorpionApp.Models;

using Newtonsoft.Json;

namespace MorpionApp.Controller
{
    public static class SaveController
    {

        public static void SaveGame(Save save, string filePath)
        {
            string json = JsonConvert.SerializeObject(save);
            File.WriteAllText(filePath, json);
        }

        public static Save LoadGame(string filePath)
        {
            string json = File.ReadAllText(filePath);
            Save? save = JsonConvert.DeserializeObject<Save>(json);
            return save ?? throw new FileNotFoundException();
        }

    }
}
