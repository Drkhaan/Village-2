using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject QueteSymbole;
    public float NumeroQuete;
    public GameObject Quete1;
    public GameObject PnJForet;
    public GameObject PnJDonneQuete1;
    public GameObject LesPoules;
    public GameObject Player;
    public Text EtatdelaQuete;
    public Text DescriptionQuete;
    public GameObject FadeDisparait;
    public AudioSource Transi;
    public AudioSource QueteObtenueSOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quete()
    {
        StartCoroutine(QueteAnim());
    }


     IEnumerator QueteAnim()
    {
        if(NumeroQuete==1)
        {
            Debug.Log("Allez");
            Quete1.SetActive(true);
            PnJForet.SetActive(true);
        }

        QueteObtenueSOn.Play();
        QueteSymbole.GetComponent<Animator>().SetBool("Go", true);
        yield return new WaitForSeconds(5.0f);
        QueteSymbole.GetComponent<Animator>().SetBool("Go", false);
       
    }
    public void QueteTermine()
    {
        if(NumeroQuete==1)
        {
            EtatdelaQuete.color=Color.green;
            EtatdelaQuete.text="terminé ";
            LesPoules.SetActive(false);
            PnJDonneQuete1.SetActive(false);
            StartCoroutine(QueteTermineCorou());
        }
    }

    IEnumerator QueteTermineCorou()
    {
        if(NumeroQuete==1)
        {
            yield return new WaitForSeconds(1f);
            FadeDisparait.SetActive(true);
            Transi.Play();
            yield return new WaitForSeconds(0.5f);
            PnJForet.SetActive(false);
            FadeDisparait.SetActive(false);
        }
       
    }
}
