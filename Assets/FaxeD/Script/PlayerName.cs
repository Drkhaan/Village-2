using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public string nameOfPlayer;
    public string saveName;

    public Text inputText;
    public Text loadedName;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        nameOfPlayer = PlayerPrefs.GetString("name" , "none");
        loadedName.text = nameOfPlayer;
    }

    public void SetName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
    }
<<<<<<< HEAD

    public void SavePlayer2()
    {
        save.SavePlayer2(this);
    }

    public void LoadPlayer2()
    {
       PlayerData data = save.LoadPlayer2();

       string nomJoueur = saveName;
        
    }
=======
>>>>>>> fc34c23e94f0fdd4be8a021fe6532c00ee9ac49e
}
