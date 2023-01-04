using UnityEngine;
using System.IO; // Va permitir trabajar con archivos
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveManger
{
    public static void SavePlayerData(Player player)
    {
        PlayerData playerData = new PlayerData(player);

        // Ruta de guardado
        string dataPath = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();

    }

    public static PlayerData LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath + "/player.save";

        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("No se encontro el archivo de guardado");
            return null;
        }
    }
}

