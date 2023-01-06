using UnityEngine;
using System.IO; // Va permitir trabajar con archivos
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveManger
{
    public static void SavePlayerData(Player player)
    {
        GameData gameData = new GameData(player);

        // Ruta de guardado
        string dataPath = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();

    }

    public static GameData LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath + "/player.save";

        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            
                GameData gameData = (GameData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return gameData;
        }
        else
        {
            Debug.LogError("No se encontro el archivo de guardado");
            return null;
        }
    }
}

