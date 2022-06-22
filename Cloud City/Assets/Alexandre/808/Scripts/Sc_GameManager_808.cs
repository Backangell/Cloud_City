using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sc_GameManager_808 : MonoBehaviour
{
    public int linkNb; 
    public  int score;

    public float BombChance;

    public SC_Camembert Camembert;

    public AudioSource Audio;
    


    public GameObject Case, EndScreen, Game;
    public Sc_Mult Mult_Txt;
    public Sc_Overlay Overlay;
    public Light lumiere;

    public List<GameObject> lst_Modules;
    public List<GameObject> lst_undead;
    public List<GameObject> lst_Case;

    public List<GameObject> lst_comboDone;

    public bool combo, lost, play,azer;
    public int combo_Timer, combo_Mult;
    

    [Header("Module")]
    public  List<int> lst_Modules_Color;

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

        SetPlay(false);
        lost = false;
        score = 0;
        combo_Mult = 1;
        HoldEmpty = true;
        NextBat();
        BatActualToNext();
        StartCoroutine(Begin());
        
    }

    // Update is called once per frame
    void Update()
    {

        #region all frames
        //center_Shad.SetInt(x);
        #endregion


        if (Input.GetAxis("Mouse ScrollWheel") != 0 && Case != null) //fais toruner les cases
        {
            Case.GetComponent<Sc_Case_808>().RotationPièce(-Input.GetAxisRaw("Mouse ScrollWheel"));
            //switchcolor();
        }

        if (Input.GetMouseButtonDown(0) & Case!=null)
        {
            Case.GetComponent<Sc_Case_808>().OnClick();
        }
        /*
        if (Input.GetMouseButtonDown(2))
        {
            ReplaceNext();
        }
        */
        if (Input.GetMouseButtonDown(1))
        {
            #region HoldPiece

            HoldBat();
            if(Case!= null)
            {
                Case.GetComponent<Sc_Case_808>().OutOverlapping();
                Case.GetComponent<Sc_Case_808>().OnOverlap();
            }

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

        if (lost)
        {
            if (lst_Case.Count != 0 & azer)
            {
                int x = Random.Range(0, lst_Case.Count);
                lst_Case[x].GetComponent<Rigidbody>().useGravity = true;
                lst_Case[x].GetComponent<Rigidbody>().AddForce(Vector3.down* 100,ForceMode.Impulse);
                lst_Case.Remove(lst_Case[x]);
            }
            azer = !azer;
        } 
    }

    public void ComboRest ()
    {
        combo_Mult = 1;
        Mult_Txt.Mult_Txt(combo_Mult);
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(3);
        SetPlay(true);
    }


    void ReplaceNext()
    {
        NextBat();
    }

    

    public void NextBat()// créer la liste des connexion du prochain batiment à poser
    {
        #region definir la prochaine couleur
        ProchaineCouleur = Random.Range(1,5);//couleur aléatoire
        #endregion

        #region est une bombe? 

        float B = Random.Range(0f, 1f); //bombe aléatoire

        BombChance = (lst_Modules_Color[ProchaineCouleur] / 3) * 0.2f;


        if (B < BombChance)    //20%
        {
            prochainEstBombe = true;
        }
        else
        {
            prochainEstBombe = false;
        }
        #endregion

        #region definir les prochaines connexions

        if (prochainEstBombe)
        {
            linkNb = 1; //Nombre de connexions
        }
        if (!prochainEstBombe)
        {
            linkNb = (Random.Range(2, 5)); //Nombre de connexions
        }

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

        if (Go != null)            
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

    public void SetPlay(bool B)
    {
        play = B;
    }
    public void EndRoutine()
    {
        Game.GetComponent<Animator>().SetTrigger("End");
        
    }

    public void SwitchScene(int x)
    {
        if (x == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (x == 2)
        {
            SceneManager.LoadScene("Menu_retro");
        }

    }
    public void Endscreen()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Combo()
    {
        combo_Mult++;
        Mult_Txt.Mult_Txt(combo_Mult);        
        Camembert.LaunchTimer(); //reset le timer
    }

    public void Score(int x)
    {
        score += (x * combo_Mult);        
    }
    
    public void listintgModuleColors(bool Add , int color)
    {
        if (Add)
        {
            lst_Modules_Color[color] ++;
            lst_Modules_Color[0] ++ ;
        }
        else
        {
            lst_Modules_Color[color] --;
            lst_Modules_Color[0] -- ;
        }
    }







}
