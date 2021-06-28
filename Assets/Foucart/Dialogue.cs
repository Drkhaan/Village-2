using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    

    [Header("Phrases de base du pnj")]
    public List<string> PhrasesdeBases=new List<string>();
    [Header("")]

    [Header("Phrases Choix1 du pnj")]
    public List<string> PhrasesChoix1=new List<string>();
    private bool Choix1;
    [Header("")]

    [Header("Phrases Choix2 du pnj")]
    public List<string> PhrasesChoix2=new List<string>();
    private bool Choix2;
    [Header("")]

    [Header("Phrases Choix3 du pnj")]
    public List<string> PhrasesChoix3=new List<string>();
    private bool Choix3;

    [Header("Choix Apres Dialog Ou pas")]

    public bool ChoixApresDialog;

    [Header("Repete en boucle ou nouvelle phrase")]

    public bool RepeteEnBoucle;

    [Header("Phrase si répète pas en boucle")]

    public string PhraseFinDialogueSiRepetePas;

    [Header("ListBouton")]
    public List<GameObject> lesChoix=new List<GameObject>();

    [Header("")]
    public bool QueteDonne;
    public Text textDialog;
    public Image SpritePerso;
    public Sprite monSprite;
    public Move move;
    public int TexteActuel;
    private bool UneFois;
    private bool JesuisDansLaZone;
    public Quest quest;
    [Header("")]
    [Header("Phrases Quetes Terminé")]
    public List<string> PhrasesQueteTermine=new List<string>();
    public bool QueteTermine;
    public string PhraseFinDialogueQueteTermine;
    [Header("Phrase d'intro quête terminée avant les choix quand on lui parle genre Yo mec quoi de neuf ?")]

    public List<string> PhraseFinDialogueQueteTermineSiChoix = new List<string>();
    [Header("")]

    
    [Header("Phrase après le merci pour le quete pour dire autre chose ? et remettre les choix")]
    public string PhraseAutreChoseApresMerciQueteTerminee;

    public bool QueteFinDialogue;
    public bool QueteFinChoix1;
    public bool QueteFinChoix2;
    public bool QueteFinChoix3;
    public int NumeroQuete;
    private bool DonneQueteUneFois;
    private Button buttonchoix1;
    private Button buttonchoix2;
    private Button buttonchoix3;
    public GameObject DialogBulle;
    private bool UnefoisAjoute;
    private bool ArreteMerci;
    private bool UneFoisArreteMerci;
    private bool SupprimeDialogUneFois;
    private bool QueteDonneUne;
    public GameObject AnimQueteObtenue;

    public float numSon;
    public bool StopMoveParle;
    public bool TermineQueteFinDialogueBase;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(TexteActuel>=PhrasesChoix1.Count-1&&JesuisDansLaZone&&QueteFinChoix1&&Choix1)
        {

            if(!QueteDonne)
            {
                DonneQueteUneFois=true;
            QueteDonneUne=true;
            QueteDonne=true;
             StartCoroutine(QueteDeverouilleCoroutine());
            }

            Debug.Log("Rat");
              Choix1=false;
              FermeDialogue();
        }
        if(TexteActuel>=PhrasesChoix2.Count-1&&JesuisDansLaZone&&QueteFinChoix2&&Choix2)
        {
           if(!QueteDonne)
            {
                Debug.Log("Renard");
                DonneQueteUneFois=true;
            QueteDonneUne=true;
            QueteDonne=true;
             StartCoroutine(QueteDeverouilleCoroutine());
            }
             Debug.Log("Rat");
              Choix2=false;
              FermeDialogue();
        }
        if(TexteActuel>=PhrasesChoix3.Count-1&&JesuisDansLaZone&&QueteFinChoix3&&Choix3)
        {
            if(!QueteDonne)
            {
                DonneQueteUneFois=true;
            QueteDonneUne=true;
            QueteDonne=true;
             StartCoroutine(QueteDeverouilleCoroutine());
            }
              Choix3=false;
              FermeDialogue();
        }

//        Debug.Log(TexteActuel);
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel<PhrasesdeBases.Count-1&&!UneFois&&TexteActuel!=100&&!QueteTermine&&!Choix1&&!Choix2&&!Choix3&&JesuisDansLaZone)
        {
            UneFois=true;
            Debug.Log("Suivant");
            PhraseSuivanteBase();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel<PhrasesQueteTermine.Count-1&&!UneFois&&TexteActuel!=100&&QueteTermine&&JesuisDansLaZone)
        {
            UneFois=true;
            Debug.Log("Suivant");
            PhraseSuivanteQueteTermine();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel<PhrasesChoix1.Count-1&&!UneFois&&Choix1==true&&JesuisDansLaZone)
        {
            UneFois=true;
            Debug.Log("Suivant");
            PhraseSuivanteChoix1();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel<PhrasesChoix2.Count-1&&!UneFois&&Choix2==true&&JesuisDansLaZone)
        {
            UneFois=true;
            Debug.Log("Suivant");
            PhraseSuivanteChoix2();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel<PhrasesChoix3.Count-1&&!UneFois&&Choix3==true&&JesuisDansLaZone)
        {
            UneFois=true;
            Debug.Log("Suivant");
            PhraseSuivanteChoix3();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel>=PhrasesdeBases.Count-1&&TexteActuel!=100&&TexteActuel!=600&&JesuisDansLaZone&&!Choix2)
        {
             Debug.Log("Le problème est là");
            FermeDialogue();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel>=PhrasesQueteTermine.Count-1&&TexteActuel!=100&&QueteTermine&&JesuisDansLaZone)
        {
            Debug.Log("Peut être");
            quest.QueteTermine();
             Debug.Log("Ferme");
            FermeDialogue();
        }
         if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel==100&&JesuisDansLaZone)
        {
            FermeDialogue();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel==600&&JesuisDansLaZone)
        {
            ArreteTout();
        }
        if(move.Entraindeparler==true&&Input.GetKey(KeyCode.Return)&&TexteActuel==200&&JesuisDansLaZone)
        {
            FermeDialogue();
        }
    }
    public void AppliqueTexteImage()
    {
        SpritePerso.sprite=monSprite;

        
    }
    public void PhraseSuivanteBase()
    {
        StartCoroutine(Base());
    }
    public void PhraseSuivanteQueteTermine()
    {
        Debug.Log("Lance corou");
        StartCoroutine(QuetePhraseSuivante());
    }
    public void PhraseSuivanteChoix1()
    {
        Debug.Log("Lance corou");
        StartCoroutine(Choix1PhraseSuivante());
    }
    public void PhraseSuivanteChoix2()
    {
        Debug.Log("Lance corou");
        StartCoroutine(Choix2PhraseSuivante());
    }
    public void PhraseSuivanteChoix3()
    {
        Debug.Log("Lance corou");
        StartCoroutine(Choix3PhraseSuivante());
    }
    public void FermeDialogue()
    {
        if(TermineQueteFinDialogueBase)
        {
            quest.QueteTermine();
        }

        if(QueteFinDialogue&&!QueteDonneUne)
        {
            QueteDonneUne=true;
            QueteDonne=true;
            StartCoroutine(QueteDeverouilleCoroutine());
        }
        if(ChoixApresDialog==false&&QueteFinDialogue==false&&JesuisDansLaZone)
        {
            Debug.Log("Ferme");
        move.DialogueCanvas.SetActive(false);
        move.Entraindeparler=false;
        if(RepeteEnBoucle==true&&JesuisDansLaZone)
        {
            TexteActuel=0;
        }
        if(RepeteEnBoucle==false&&JesuisDansLaZone)
        {
            TexteActuel=100;
        }
        move.canMove=true;
        }


        if(ChoixApresDialog==false&&QueteFinDialogue==true&&JesuisDansLaZone)
        {
            Debug.Log("Ferme");
        move.DialogueCanvas.SetActive(false);
        move.Entraindeparler=false;
        if(RepeteEnBoucle==true)
        {
            TexteActuel=0;
        }
        if(RepeteEnBoucle==false&&!QueteTermine&&JesuisDansLaZone)
        {
            TexteActuel=100;
        }
        move.canMove=true;
        if(DonneQueteUneFois==false&&JesuisDansLaZone)
        {
            DonneQueteUneFois=true;
            quest.NumeroQuete=NumeroQuete;
        quest.Quete();
        }
        if(RepeteEnBoucle==false&&QueteTermine&&JesuisDansLaZone)
        {
            TexteActuel=200;
            Debug.Log("WTFFF");
            quest.QueteTermine();
        }
        move.canMove=true;
        }


        if(ChoixApresDialog==true&&TexteActuel!=600&&JesuisDansLaZone)
        {
            Debug.Log("Choix apres dialogue donc relance bouton");
                     foreach (GameObject obj in lesChoix)
             {
                    obj.SetActive(true);
             }
        }
        Choix1=false;
        Choix2=false;
        Choix3=false;
        Debug.Log("Pas de probleme choix apres dialog");
        
    }
    public void ArreteTout()
    {
        move.Entraindeparler=false;
        move.canMove=true;
         DialogBulle.SetActive(false);

        if(ArreteMerci==true&&!UneFoisArreteMerci&&PhrasesQueteTermine.Count==2&&JesuisDansLaZone)
         {
             UneFoisArreteMerci=true;
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
         }

         if(ArreteMerci==true&&!UneFoisArreteMerci&&PhrasesQueteTermine.Count==3&&JesuisDansLaZone)
         {
             UneFoisArreteMerci=true;
             PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
         }
         if(ArreteMerci==true&&!UneFoisArreteMerci&&PhrasesQueteTermine.Count==4&&JesuisDansLaZone)
         {
             UneFoisArreteMerci=true;
             PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
              PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
         }
         if(ArreteMerci==true&&!UneFoisArreteMerci&&PhrasesQueteTermine.Count==5&&JesuisDansLaZone)
         {
             UneFoisArreteMerci=true;
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
         }

         if(ChoixApresDialog==true&&UnefoisAjoute==true&&PhrasesQueteTermine.Count>=1&&JesuisDansLaZone)
         {
             PhrasesQueteTermine[0]=PhraseFinDialogueQueteTermineSiChoix[Random.Range(0,PhraseFinDialogueQueteTermineSiChoix.Count)];
         }
          
    }

    public void Choix1Fonction()
    {
       /* if(QueteFinChoix1&&!QueteDonneUne)
        {
            QueteDonneUne=true;
            QueteDonne=true;
        }*/
        
         if(QueteTermine==true&&PhrasesQueteTermine.Count==1&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==2&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==3&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==4&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        lesChoix[0].GetComponent<Image>().color=Color.grey;
        TexteActuel=0;
        Choix1=true;
        textDialog.text=PhrasesChoix1[TexteActuel];

         foreach (GameObject obj in lesChoix)
             {
                    obj.SetActive(false);
             }


    }
    public void Choix2Fonction()
    {
       /* if(QueteFinChoix2&&!QueteDonneUne)
        {
            QueteDonneUne=true;
            QueteDonne=true;
        }*/
        if(QueteTermine==true&&PhrasesQueteTermine.Count==1&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==2&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==3&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==4&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        lesChoix[1].GetComponent<Image>().color=Color.grey;
        TexteActuel=0;
        Choix2=true;
        textDialog.text=PhrasesChoix2[TexteActuel];

         foreach (GameObject obj in lesChoix)
             {
                    obj.SetActive(false);
             }
    }
    public void Choix3Fonction()
    {
         /*if(QueteFinChoix3&&!QueteDonneUne)
        {
            QueteDonneUne=true;
            QueteDonne=true;
        }*/

       if(QueteTermine==true&&PhrasesQueteTermine.Count==1&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==2&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==3&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        if(QueteTermine==true&&PhrasesQueteTermine.Count==4&&JesuisDansLaZone)
        {
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
            PhrasesQueteTermine.Remove(PhrasesQueteTermine[0]);
        }
        lesChoix[2].GetComponent<Image>().color=Color.grey;
        TexteActuel=0;
        Choix3=true;
        textDialog.text=PhrasesChoix3[TexteActuel];

         foreach (GameObject obj in lesChoix)
             {
                    obj.SetActive(false);
             }
    }
     public void Choix4Fonction()
    {
        TexteActuel=600;
        Choix3=false;
        Choix2=false;
        Choix1=false;
         foreach (GameObject obj in lesChoix)
             {
                    obj.SetActive(false);
             }

        textDialog.text=" A la prochaine !";
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&StopMoveParle)
        {
            this.GetComponentInParent<Patroll>().PeutBouger=false;
            this.GetComponentInParent<Rigidbody2D>().velocity=new Vector2(0,0);
        }
        if(other.tag=="Player")
        {
            quest.NumeroQuete=NumeroQuete;
            JesuisDansLaZone=true;

            move.numeroPNJ = numSon;
        }
        if(other.tag=="Player"&&TexteActuel!=100)
        {
            AppliqueTexteImage();
        }
        if(other.tag=="Player"&&TexteActuel==100&&QueteTermine==false)
        {
            Debug.Log("SingoBulle");
            textDialog.text=PhraseFinDialogueSiRepetePas;
        }
        if(other.tag=="Player"&&TexteActuel==200&&QueteTermine==true)
        {
            Debug.Log("Met texte finfin");
            textDialog.text=PhraseFinDialogueQueteTermine;
        }
        if(other.tag=="Player"&&QueteTermine==true&&TexteActuel!=200&&PhrasesQueteTermine.Count>=1)
        {
            Debug.Log("Cochon dingue");
            TexteActuel=0;
            textDialog.text=PhrasesQueteTermine[TexteActuel];
        }
        if(other.tag=="Player"&&TexteActuel==600&&QueteTermine==false)
        {
            Debug.Log("Parle pendanr quete ");
            TexteActuel=0;
            textDialog.text=PhrasesdeBases[TexteActuel];
        }
        if(other.tag=="Player"&&TexteActuel==600&&QueteTermine==true&&PhrasesQueteTermine.Count<1)
        {
            TexteActuel=0;
            PhrasesQueteTermine.Add(PhraseAutreChoseApresMerciQueteTerminee);
            PhraseAutreChoseApresMerciQueteTerminee=PhraseFinDialogueQueteTermineSiChoix[Random.Range(0,PhraseFinDialogueQueteTermineSiChoix.Count)];
            textDialog.text=PhrasesQueteTermine[TexteActuel];
        }
        if(other.tag=="Player"&&TexteActuel==600&&QueteTermine==true&&PhrasesQueteTermine.Count==1)
        {
            TexteActuel=0;
            PhraseAutreChoseApresMerciQueteTerminee=PhraseFinDialogueQueteTermineSiChoix[Random.Range(0,PhraseFinDialogueQueteTermineSiChoix.Count)];
            textDialog.text=PhrasesQueteTermine[TexteActuel];
        }
        if(other.tag=="Player"&&TexteActuel==0&&QueteTermine==false)
        {
             TexteActuel=0;
            textDialog.text=PhrasesdeBases[TexteActuel];
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player")
        {
            JesuisDansLaZone=false;
        }
        if(other.tag=="Player"&&StopMoveParle)
        {
            this.GetComponentInParent<Patroll>().PeutBouger=true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag=="Player")
        {
            JesuisDansLaZone=true;
        }
    }

    IEnumerator Base()
    {
        yield return new WaitForSeconds(0.15f);
        TexteActuel+=1;
        textDialog.text=PhrasesdeBases[TexteActuel];
        UneFois=false;
    }
    IEnumerator QuetePhraseSuivante()
    {
        if(ChoixApresDialog==true&&!UnefoisAjoute&&JesuisDansLaZone)
        {
            UnefoisAjoute=true;
            PhrasesQueteTermine.Add(PhraseAutreChoseApresMerciQueteTerminee);
            ArreteMerci=true;
        }
        Debug.Log("Coroutine quete");
        yield return new WaitForSeconds(0.15f);
        TexteActuel+=1;
        textDialog.text=PhrasesQueteTermine[TexteActuel];
        UneFois=false;
    }
    IEnumerator Choix1PhraseSuivante()
    {
        Debug.Log("Coroutine choix 1");
        yield return new WaitForSeconds(0.15f);
        TexteActuel+=1;
        textDialog.text=PhrasesChoix1[TexteActuel];
        UneFois=false;
    }
    IEnumerator Choix2PhraseSuivante()
    {
        Debug.Log("Coroutine choix 2");
        yield return new WaitForSeconds(0.15f);
        TexteActuel+=1;
        Choix2=true;
        textDialog.text=PhrasesChoix2[TexteActuel];
        UneFois=false;
    }
    IEnumerator Choix3PhraseSuivante()
    {
        Debug.Log("Coroutine choix 3");
        yield return new WaitForSeconds(0.15f);
        TexteActuel+=1;
        textDialog.text=PhrasesChoix3[TexteActuel];
        UneFois=false;
    }

    IEnumerator QueteDeverouilleCoroutine()
    {
        //AnimQueteObtenue.SetActive(true);
        quest.NumeroQuete=NumeroQuete;
        quest.Quete();
        yield return new WaitForSeconds(2.0f);
       // AnimQueteObtenue.SetActive(false);
       
    }

}
