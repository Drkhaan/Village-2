
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class save
{
    public static void SavePlayer (CharacterMovementPlatformer player)
{
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);


            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }   else 
        {
            Debug.Log("pas de sauvegarde bogosse"+path);
            return null;
        }
    }


    public static void SavePlayer2 (PlayerName player2)
{
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player2.namesaved";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player2);

        formatter.Serialize(stream, data);
        stream.Close();
    }

     public static PlayerData LoadPlayer2()
    {
        string path = Application.persistentDataPath + "/player2.namesaved";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);


            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }   else 
        {
            Debug.Log("pas de sauvegarde bogosse"+path);
            return null;
        }
    }

}

