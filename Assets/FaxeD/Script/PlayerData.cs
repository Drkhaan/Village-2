using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public float[] position;
    public string nomJoueur;

    public PlayerData (PlayerName nom)
    {
        nomJoueur = nom.saveName;
    }

    public PlayerData (CharacterMovementPlatformer pos)
    {
        position = new float[3];
        position[0] = pos.transform.position.x;
        position[1] = pos.transform.position.y;
        position[2] = pos.transform.position.z;
    }
    
}
