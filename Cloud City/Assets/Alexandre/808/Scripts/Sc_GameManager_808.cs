using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameManager_808 : MonoBehaviour
{
    public int linkNb;

    public float BombChance;

    public GameObject Case;

    public List<GameObject> lst_Modules;
    public List<GameObject> lst_undead;
    public List<GameObject> lst_Case;

    public List<GameObject> lst_comboDone;

    public bool Combo;



    [Header("ExplosionEnChaîne")]
    
    public List<GameObject> lst_fall;
    public List<GameObject> lst_comboToDo;
    
    [Header("ActualBat")]

    public List<int> Connexion;
    public int couleurActuelle;
    public bool Bombe;

    [Header("NextBat")]

    public List<int> ProchaineConnexion;
    public int ProchaineCouleur;
    public bool prochainEstBombe;

    // Start is called before the first frame update
    void Start()
    {

        



        NextBat();
        BatActualToNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && Case != null) //fais toruner les cases
        {
            Case.GetComponent<Sc_Case_808>().RotationPièce(-Input.GetAxisRaw("Mouse ScrollWheel"));
            //switchcolor();
        }

        if (Input.GetMouseButtonDown(0) & Case!=null)
        {
            Case.GetComponent<Sc_Case_808>().OnClick();
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Bombe == true)
            {
                Bombe = false;
            }
            else if (Bombe == false)
            {
                Bombe = true;
            }
        }
    }

    public void NextBat()// créer la liste des connexion du prochain batiment à poser
    {
        #region couleur?
        couleurActuelle = Random.Range(1, 5);//couleur aléatoire
        #endregion

        #region est une bombe? 

        float B = Random.Range(0f, 1f); //bombe aléatoire
        
        if (B < BombChance) //20%
        {
            prochainEstBombe = true;
        }
        else
        {
            prochainEstBombe = false;
        }
        #endregion

        #region definir les connexions
        
        linkNb = (Random.Range(1, 7)); //Nombre de connexions

        List<int> Xlist = new List<int>(); //génére la list des connexions

        for (int l = linkNb; l > 0; l--) //pour chaque connexion
        {
            int x = Random.Range(0, 6); //une connexion aléatoire

            for (int z = x; Xlist.Contains(z); z = x) // si il y a 2 fois la même connexion
            {
                x = Random.Range(0, 6); // une connexion aléatoire
            }

            Xlist.Add(x); // rajoute la connexion à la liste de la connexion
        }

        ProchaineConnexion = Xlist; // la liste est fini

        #endregion
    }

    public void BatActualToNext() // remplace le 
    {
        couleurActuelle = ProchaineCouleur;

        Connexion = ProchaineConnexion;
        
        Bombe = prochainEstBombe;

        NextBat();
    }
    
    public void Selection(GameObject Go)
    {
        if (Case != null) //retire l'ancienne case
        {
            Case.GetComponent<Sc_Case_808>().OutOverlapping();
        }

        Case = Go;

        if (Go != null) //on active la nouvelle
        {
            Go.GetComponent<Sc_Case_808>().OnOverlap();
        }
    }

    /*
    public IEnumerator  verif_Combo()
    {
        yield return new WaitForSeconds(0.1f);

        
        foreach(GameObject Go in lst_comboToDo)
        {
            Go_Sc.Explosion();
        }
    }
    
    void switchcolor()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            couleurActuelle++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            couleurActuelle--;
        }
    }*/
}
