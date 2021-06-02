using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NouveauDialog : MonoBehaviour
{
     private int Nombrephrase;

    [Header("Phrases de base du pnj")]
    public List<string> PhrasesdeBases=new List<string>();
    [Header("")]

    [Header("Phrases Choix1 du pnj")]
    public List<string> PhrasesChoix1=new List<string>();
    [Header("")]

    [Header("Phrases Choix2 du pnj")]
    public List<string> PhrasesChoix2=new List<string>();
    [Header("")]

    [Header("Phrases Choix3 du pnj")]
    public List<string> PhrasesChoix3=new List<string>();

    [Header("Choix Apres Dialog Ou pas")]

    public bool ChoixApresDialog;

    [Header("Repete en boucle ou nouvelle phrase")]

    public bool RepeteEnBoucle;

    [Header("Phrase si répète pas en boucle")]

    public string PhraseFinDialogueSiRepetePas;

    [Header("ListBouton")]
    public List<GameObject> lesChoix=new List<GameObject>();

    [Header("")]
    public Text textDialog;
    public Image SpritePerso;
    public Sprite monSprite;
    public Move move;
    private int TexteActuel;
    private bool UneFois;
    public Quest quest;
    [Header("")]

    public bool QueteFinDialogue;
    public bool QueteFinChoix1;
    public bool QueteFinChoix2;
    public bool QueteFinChoix3;
    public int NumeroQuete;
    private bool DonneQueteUneFois;
    // Start is called before the first frame update
    void Start()
    {
        Nombrephrase=PhrasesdeBases.Count;
        Debug.Log(Nombrephrase);
        TexteActuel=0;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(TexteActuel);
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel<Nombrephrase-1&&!UneFois&&TexteActuel!=100)
        {
            UneFois=true;
            Debug.Log("Suivant");
            AppliqueTexte();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel>=Nombrephrase-1&&TexteActuel!=100)
        {
             Debug.Log("Ferme");
            FermeDialogue();
        }
         if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel==100)
        {
            FermeDialogue();
        }
    }
    public void AppliqueTexteImage()
    {
        textDialog.text=PhrasesdeBases[TexteActuel];
        SpritePerso.sprite=monSprite;
    }
    public void AppliqueTexte()
    {
        StartCoroutine(AttendUnPeu());
    }
    public void FermeDialogue()
    {
        if(ChoixApresDialog==false&&QueteFinDialogue==false)
        {
            Debug.Log("Ferme");
        move.DialogueCanvas.SetActive(false);
        move.Entraindeparler=false;
        if(RepeteEnBoucle==true)
        {
            TexteActuel=0;
        }
        if(RepeteEnBoucle==false)
        {
            TexteActuel=100;
        }
        
        move.canMove=true;
        }

        if(ChoixApresDialog==false&&QueteFinDialogue==true)
        {
            Debug.Log("Ferme");
        move.DialogueCanvas.SetActive(false);
        move.Entraindeparler=false;
        if(RepeteEnBoucle==true)
        {
            TexteActuel=0;
        }
        if(RepeteEnBoucle==false)
        {
            TexteActuel=100;
        }
        move.canMove=true;
        if(DonneQueteUneFois==false)
        {
            DonneQueteUneFois=true;
            quest.NumeroQuete=NumeroQuete;
        quest.Quete();
        }
        
        }


        if(ChoixApresDialog==true)
        {
                     foreach (GameObject obj in lesChoix)
             {
                    obj.SetActive(true);
             }
        }
        
    }

    public void Choix1()
    {

    }
    public void Choix2()
    {
        
    }
    public void Choix3()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&TexteActuel==100)
        {
            textDialog.text=PhraseFinDialogueSiRepetePas;
        }
    }

    IEnumerator AttendUnPeu()
    {
        yield return new WaitForSeconds(0.15f);
        TexteActuel+=1;
        textDialog.text=PhrasesdeBases[TexteActuel];
        UneFois=false;
    }

}
