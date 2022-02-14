using System.Collections.Generic;
using UnityEngine;

public class Sc_CaseAlex : MonoBehaviour
{
    public GameManagerAlex GM;

    public bool Dead, IsOverlap, Posable, OQP, Rot_Bool, Rot_Horaire , Bomb; //si la souris est sur l'objet, si il y a un module, si on peut poser un objet, si la case est morte

    public List<GameObject> list_Connexion, list_Voisin, list_connected;

    public List<int> Y_Rot;

    public GameObject Case, interior, model;

    public ModelScriptAlex Modele;
    
    public int rot_Value, couleur;

    // Start is called before the first frame update
    void Start()
    {
        if (!Dead)
        {
            interior.SetActive(true);
        }

        GM = GameObject.Find("Main Camera Alexandre").GetComponent<GameManagerAlex>();

        IsOverlap = false; //booléenne pour savoir si une case est occupé par une île
    }

   
    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            interior.SetActive(true);
        }

        if (IsOverlap)
        {
            //Rot_verification();            
        }

    }

    #region apparition des connexions
    public void DefinirConnectionsON(List<int> xList)
    {
        GameObject G; //on recupère un gameObject

        //fait apparaitre les connexions
        if (IsOverlap == true)
        {
            Modele.SetModel(GM.couleurActuelle, GM.Connexion);
               
            for (int i = (xList.Count) - 1; i >= 0; i--)
            {
                G = list_Connexion[xList[i]].gameObject;
                G.SetActive(true);
                G.GetComponent<VoisinAlex>().GetVoisin();
                G.GetComponent<VoisinAlex>().dead = false;
            }
        }
    }

    void DefinirConnexionsOFF()
    {

        Modele.disableModel();    
        
        GameObject G;     

        for (int x = list_Connexion.Count - 1; x >= 0; x--)
        {
            G = list_Connexion[x];
            G.GetComponent<VoisinAlex>().dead = true;
            G.SetActive(false);
            
        }
    }
    #endregion

    #region liste des voisins
    public void addVoisin(GameObject voisin)
    {
        list_Voisin.Add(voisin);
    }
    
    public void RemoveVoisin() //retire les voisins quand elle n'est plus la case principale
    {
        for (int x = list_Voisin.Count - 1; x >= 0; x--)
        {
            list_Voisin.Remove(list_Voisin[x]);
        }
    }

    void Maj_voisin()
    {
        
        foreach (int x in GM.Connexion)
        {
            list_Voisin.Add(list_Connexion[x].GetComponent<VoisinAlex>().voisin);
        }
    }


    #endregion

    #region Overlapping
    public void OnOverlapEnter()
    {
        if (!Dead && !OQP)
        {
            IsOverlap = true;

            DefinirConnectionsON(GM.Connexion);

            if (!Posable)
            {
                rotationPièce(1);
            }
        }
    }

    public void OnOverlapExit()
    {
        if (!OQP)
        {
            DefinirConnexionsOFF();
            RemoveVoisin();
        }
        IsOverlap = false;
    }
   
    #endregion

    public void OnClick()
    {
        couleur = GM.couleurActuelle;

        if (Posable)
        {
            GM.list_Case_Alive.Remove(gameObject);
            
            OQP = true;
            
            for (int x = list_Voisin.Count - 1; x >= 0; x--)
            {
                list_Connexion[GM.Connexion[x]].GetComponent<VoisinAlex>().MakeDisponible();
            }
            
            if (GM.Bombe)
            {
                Bomb = true;
            }

            GM.BatActualToNext();
        }       
    }

    public void AddConexion(GameObject Go)
    {
        list_connected.Add(Go);
    }

    public void rotationPièce(float x)
    {
        Rot_Bool = false;
        #region Valeur de rotation
        if (x > 0)
        {
            Rot_Horaire = false;
            rot_Value++;

            if (rot_Value > 5)
            {
                rot_Value = 0;
            }
        }
        if (x < 0)
        {
            Rot_Horaire = true;
            rot_Value--;
            if (rot_Value < 0)
            {
                rot_Value = 5;
            }
        }
        #endregion

        #region rotation de l'objet
        Vector3 V3;
        V3 = new Vector3(90, 0, rot_Value * 60);
        Quaternion Zrot = Quaternion.Euler(V3);
        transform.rotation = Zrot;
        #endregion

        Rot_verification();

        if (!Posable)
        {
            rotationPièce(x);
        }

    }

    public void Rot_verification()// vérifie si les voisin on un connecteur vers cette case
    {

        list_Voisin.Clear();
        
        Posable = false;
        
        foreach (GameObject Go in list_Connexion)
        {
            
            if (!Go.GetComponent<VoisinAlex>().dead) 
            {
                
                Go.GetComponent<VoisinAlex>().GetVoisin();

                if (list_connected.Contains(Go.GetComponent<VoisinAlex>().voisin))
                {
                    Posable = true;
                }
            }                    
        }        
    }

    public void Undead()
    {
        Dead = false;
        if(!GM.list_Case_Alive.Contains(gameObject))
        {
            GM.list_Case_Alive.Add(gameObject);
        }        
    }
    
   

}

