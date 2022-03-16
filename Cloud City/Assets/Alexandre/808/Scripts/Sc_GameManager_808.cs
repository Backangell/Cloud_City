using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameManager_808 : MonoBehaviour
{
    public int linkNb;

    public float BombChance;

    public GameObject Case;

    public Sc_Overlay Overlay;

    public List<GameObject> lst_Modules;
    public List<GameObject> lst_undead;
    public List<GameObject> lst_Case;

    public List<GameObject> lst_comboDone;

    public bool Combo;
    
    [Header("ActualBat")]

    public List<int> Connexion;
    public int couleurActuelle;
    public bool Bombe;

    [Header("NextBat")]

    public List<int> ProchaineConnexion;
    public int ProchaineCouleur;
    public bool prochainEstBombe;

    [Header("HoldBat")]

    public List<int> ConnexionHold;
    public int couleurHold;
    public bool BombeHold , HoldEmpty;

    // Start is called before the first frame update
    void Start()
    {
        HoldEmpty = true;
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
            #region HoldPiece

            HoldBat();

            #endregion

            #region create Bomb
            /*
            if (Bombe == true)
            {
                Bombe = false;
            }
            else if (Bombe == false)
            {
                Bombe = true;
            }
            */
            #endregion
        }
    }

    public void NextBat()// créer la liste des connexion du prochain batiment à poser
    {
        #region definir la prochaine couleur
        ProchaineCouleur = Random.Range(1, 5);//couleur aléatoire
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

        #region definir les prochaines connexions
        
        linkNb = (Random.Range(2, 7)); //Nombre de connexions

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

        Overlay.Actuel(Connexion, couleurActuelle, Bombe);
        Overlay.Next(ProchaineConnexion, ProchaineCouleur, prochainEstBombe);


    }

    public void BatActualToNext() // remplace le 
    {

        Connexion = ProchaineConnexion;

        couleurActuelle = ProchaineCouleur;
        
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

    public void HoldBat()
    {
        List<int> A = Connexion;
        int C = couleurActuelle;
        bool B = Bombe;

        if (HoldEmpty)
        {
            ConnexionHold = A;
            couleurHold =  C;            
            BombeHold = B;

            BatActualToNext();

            HoldEmpty = false;
        }

        else
        {
            #region actuel to hold
            Connexion = ConnexionHold;
            couleurActuelle = couleurHold;
            Bombe = BombeHold;
            #endregion

            #region hold to actuel
            ConnexionHold = A;
            couleurHold = C;
            BombeHold = B;
            #endregion
        }

        Overlay.Actuel(Connexion, couleurActuelle, Bombe);
        Overlay.Hold(ConnexionHold, couleurHold, BombeHold);
    }    
}
