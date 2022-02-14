using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAlex : MonoBehaviour
{
    public int linkNb, batType;

    public GameObject Case;

    [Header("Global Gestion")]

    public List<GameObject> list_Case_Alive;

    [Header("ActualBat")]

    public List<int> Connexion;
    public int couleurActuelle;
    public bool Bombe;

    [Header("NextBat")]

    public List<int> ProchaineConnexion;
    public int ProchaineCouleur;
    public bool prochainEstBombe;

    [Header ("Rotation")]
    public int pièceRotation;

    // Start is called before the first frame update
    void Start()
    {
        NextBat();
        BatActualToNext();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") !=0 && Case != null) //fais toruner les cases
        {
            Case.GetComponent<Sc_CaseAlex>().rotationPièce(-Input.GetAxisRaw("Mouse ScrollWheel"));
        }
        
        if (Input.GetMouseButtonDown(0))//click gauche
        {
            if (Case != null)
            {
                Case.GetComponent<Sc_CaseAlex>().OnClick();
            }
           
        }

        if (Input.GetMouseButtonDown(1))//click droit
        {
            //Case.GetComponent<Sc_Case>().Rot_verification();
        }

    }
    public void NextBat()// créer la liste des connexion du prochain batiment à poser
    {
        couleurActuelle = Random.Range(1,5);


        float i = Random.Range(0f, 1f);
        
        
        if (i < 0.2)
        {
            prochainEstBombe = true;
        }
        else
        {
            prochainEstBombe = false;
        }
        linkNb = (Random.Range(1, 7));

        List<int> Xlist = new List<int>();

        for (int l = linkNb; l > 0; l--)
        {
            int x = Random.Range(0, 6);
            
            for (int z = x; Xlist.Contains(z); z = x)
            {
                x = Random.Range(0, 5);
            }

            Xlist.Add(x);
        }

        ProchaineConnexion = Xlist;
       
    }
   
    public void BatActualToNext() // remplace le 
    {
        Connexion = ProchaineConnexion;
        couleurActuelle = ProchaineCouleur;
        Bombe = prochainEstBombe;
        NextBat();
    }

    void selection_Case(float x)
    {
        Debug.Log(x);

        if(x > 0)
        {
            Case = list_Case_Alive[+1];
        }
        else if (x < 0)
        {
            Case = list_Case_Alive[-1];
        }

        Case.GetComponent<Sc_CaseAlex>().OnOverlapEnter();
    }

    public void Selection(GameObject Go)
    {
        if (Case != null)
        {
            Case.GetComponent<Sc_CaseAlex>().OnOverlapExit();
        }

        Case = Go;

        if (Go != null)
        {
            
            Case.GetComponent<Sc_CaseAlex>().OnOverlapEnter();
        }
    }




}


