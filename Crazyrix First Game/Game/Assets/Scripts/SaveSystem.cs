using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerdata.jil";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerdata.jil";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Error" + path);
            return null;
        }
    }

}

