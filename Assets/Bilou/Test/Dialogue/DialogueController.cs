using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    public Text dialogueTxt;

    public string[] Sentences;

    private int Index = 0;

    public float dialogueSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.Space ))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if ( Index <= Sentences.Length - 1)
        {
            dialogueTxt.text = "";
            StartCoroutine(timeToWrite());
        }
    }
    IEnumerator timeToWrite()
    {
        foreach ( char Character in Sentences[Index].ToCharArray ())
        {
            dialogueTxt.text += Character;
            yield return new WaitForSeconds ( dialogueSpeed );
        }
        Index ++;
    }
}
