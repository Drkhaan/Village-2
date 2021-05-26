using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject QueteSymbole;
    public float NumeroQuete;
    public GameObject Quete1;
    public GameObject Singe;
    public Text EtatdelaQuete;
    public Text DescriptionQuete;
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
            Quete1.SetActive(true);
            Singe.SetActive(true);
        }

        QueteSymbole.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        QueteSymbole.SetActive(false);
       
    }
    public void QueteTermine()
    {
        if(NumeroQuete==1)
        {
            EtatdelaQuete.color=Color.green;
            EtatdelaQuete.text="terminé ";
        }
    }
}
