using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Case_808 : MonoBehaviour
{
    [Header("case statut")]

    public bool Dead;       //ne peut pas etre sélectionner
    public bool IsOverlap;  //est déja selectionné
    public bool OQP;        //il y a un module
    public bool Posable;    //les connexions sont bien relié
    public bool Bomb,BombO;
    public bool VerifAncrage;
    

    ile_Poids Sc_pds;

    Sc_AudioScript SD;

    public int color, rang;

    public GameObject verif, interior, module, Model, Point;
    public Sc_GameManager_808 GM;

    public List<GameObject> lst_enfant;

    public List<GameObject> vérifiés;

    [Header("3D")]
    public List<GameObject> lst_Connexion;
    public List<GameObject> lst_Module, lst_Module_Ov;

    Animator anim;


    [Header("Voisin")]
    public List<Vector3> lst_voisinPositions;
    public List<GameObject> lst_Voisin;

    [Header("VoisinConnexion")]
    public List<GameObject> lst_seConnect;
    public List<GameObject> lst_connecté;
    public List<GameObject> lst_DoubleCo;


    // Start is called before the first frame update
    void Start()
    {
        
        GM.lst_Case.Add(gameObject);
        SD = GetComponent<Sc_AudioScript>();

        Sc_pds = GetComponent<ile_Poids>();
        anim = GetComponent<Animator>();
        Dead = true;
        SetVoisin();        
    }

    // Update is called once per
    void Update()
    {
        

    }
    public void SpawnModel()
    {
        Destroy(Model);

        if (!GM.Bombe)
        {
            if (GM.couleurActuelle == 1)
            {
                color = 1;
                Model = Instantiate(lst_Module[0], module.transform);

            }
            if (GM.couleurActuelle == 2)
            {
                color = 2;
                Model = Instantiate(lst_Module[1], module.transform);
            }
            if (GM.couleurActuelle == 3)
            {
                color = 3;
                Model = Instantiate(lst_Module[2], module.transform);
            }
            if (GM.couleurActuelle == 4)
            {
                color = 4;
                Model = Instantiate(lst_Module[3], module.transform);
            }
        }

        else
        {
            if (GM.couleurActuelle == 1)
            {
                color = 1;
                Model = Instantiate(lst_Module[4], module.transform);
            }
            if (GM.couleurActuelle == 2)
            {
                color = 2;
                Model = Instantiate(lst_Module[5], module.transform);
            }
            if (GM.couleurActuelle == 3)
            {
                color = 3;
                Model = Instantiate(lst_Module[6], module.transform);
            }
            if (GM.couleurActuelle == 4)
            {
                color = 4;
                Model = Instantiate(lst_Module[7], module.transform);
            }
        }
    }

    #region Overlapping
    public void OnOverlap()
    {
        #region prévisualisation
        if (!OQP)
        {
            if (!GM.Bombe)
            {
                if (GM.couleurActuelle == 1)
                {
                    color = 1;
                    Model = Instantiate(lst_Module_Ov[0], module.transform);

                }
                if (GM.couleurActuelle == 2)
                {
                    color = 2;
                    Model = Instantiate(lst_Module_Ov[1], module.transform);
                }
                if (GM.couleurActuelle == 3)
                {
                    color = 3;
                    Model = Instantiate(lst_Module_Ov[2], module.transform);
                }
                if (GM.couleurActuelle == 4)
                {
                    color = 4;
                    Model = Instantiate(lst_Module_Ov[3], module.transform);
                }
            }

            else
            {
                if (GM.couleurActuelle == 1)
                {
                    color = 1;
                    Model = Instantiate(lst_Module_Ov[4], module.transform);
                }
                if (GM.couleurActuelle == 2)
                {
                    color = 2;
                    Model = Instantiate(lst_Module_Ov[5], module.transform);
                }
                if (GM.couleurActuelle == 3)
                {
                    color = 3;
                    Model = Instantiate(lst_Module_Ov[6], module.transform);
                }
                if (GM.couleurActuelle == 4)
                {
                    color = 4;
                    Model = Instantiate(lst_Module_Ov[7], module.transform);
                }
            }


            IsOverlap = true;

            

            PrévisualisationOn(GM.Connexion);

            Rot_Verif();

            if (!Posable)           //si la rotation ne permet pas de poser le module
            {
                RotationPièce(1);   //on refait tourner la pièce
            }


        }
        #endregion


        #region sound

        SD.PlaySoundFunction(0);

        #endregion
    }

    public void OutOverlapping()
    {
        Destroy(Model);

        if (!OQP)
        {
            PrévisualisationOff();
        }
        IsOverlap = false;
        Posable = false;
    }
    #endregion

    #region 3DModel_Connexions

    void PrévisualisationOn(List<int> xList)
    {
        GameObject G;

        foreach (int X in xList)
        {
            G = lst_Connexion[X];

            G.SetActive(true);
        }
    }

    void PrévisualisationOff()
    {
        foreach (GameObject G in lst_Connexion)
        {
            G.SetActive(false);
        }
    }
    #endregion

    #region rotation
    public void RotationPièce(float x)
    {
        Posable = false;

        #region Valeur de rotation
        if (x > 0)
        {
            transform.RotateAround(transform.position, transform.up, 60);
        }
        if (x < 0)
        {
            transform.RotateAround(transform.position, transform.up, -60);
        }
        #endregion

        lst_Voisin.Clear();     //on vide la liste des voisin

        SetVoisin();            //on rerempli la liste des voisin pour faire correspondre les voisin à la rotation

        Rot_Verif();            //on verifie que la rotation permet de poser le module

        if (!Posable)           //si la rotation ne permet pasde poser le module
        {
            RotationPièce(x);   //on refait tourner la pièce
        }

        #region sound
        
            SD.PlaySoundFunction(1);
        #endregion

    }
    void Rot_Verif()
    {
        foreach (int x in GM.Connexion)
        {
            if (lst_seConnect.Contains(lst_Voisin[x]))
            {
                Posable = true;
            }
        }
    }

    #endregion

    #region Onclick
    public void OnClick()
    {
        SpawnModel();

        Sc_Case_808 Sc_Voisin;

        GM.lst_Modules.Add(gameObject);
        OQP = true; IsOverlap = false;

        GM.listintgModuleColors(true, color);

        if (!GM.Bombe)
        {
            Sc_pds.vd_ApplyPoids(1);                        
            Point.GetComponent<Sc_Case_Point>().AddPoint(15 * rang, color,BombO);
        }

        else
        {
            Model.GetComponent<Sc_3DEffect>().Bombe = true;
        }

        foreach (int x in GM.Connexion)
        {
            if (lst_Voisin[x] != null)
            {

                if (lst_Voisin[x].CompareTag ( "Case" ))
                {

                    Sc_Voisin = lst_Voisin[x].GetComponent<Sc_Case_808>();

                    if (Sc_Voisin.Dead)
                    {
                        Sc_Voisin.SetAlive(false);
                        if (!GM.lst_undead.Contains(lst_Voisin[x]))
                        {
                            GM.lst_undead.Add(lst_Voisin[x]);
                        }
                    }

                    if (!lst_seConnect.Contains(gameObject))
                    {
                        Sc_Voisin.lst_seConnect.Add(gameObject);
                    }

                    if (lst_Voisin[x].GetComponent<Sc_Case_808>().lst_connecté.Contains(gameObject))
                    {
                        lst_DoubleCo.Add(lst_Voisin[x]);
                        lst_Voisin[x].GetComponent<Sc_Case_808>().lst_DoubleCo.Add(gameObject);
                        
                        if (lst_Voisin[x].GetComponent<Sc_Case_808>().color == color)
                        {
                            lst_Connexion[x].GetComponent<Sc_connexion>().function(true, color);
                            int i = lst_Voisin[x].GetComponent<Sc_Case_808>().lst_Voisin.IndexOf(gameObject);
                            lst_Voisin[x].GetComponent<Sc_Case_808>().lst_Connexion[i].GetComponent<Sc_connexion>().function(true, color);
                        }
                    }

                }

                if (lst_Voisin[x].CompareTag ("Center"))
                {
                    lst_DoubleCo.Add(lst_Voisin[x]);
                }

                lst_connecté.Add(lst_Voisin[x]);
            }
        }
        
        Bomb = GM.Bombe;
        BombO = Bomb;
        Model.GetComponent<Sc_3DEffect>().Case = gameObject;

        SD.PlaySoundFunction(2);

        anim.ResetTrigger("Fall");
        anim.ResetTrigger("Explode");
        anim.SetTrigger("Bool");

        interior.SetActive(false);

        GM.BatActualToNext();
        GM.Case = null;
    }
    #endregion

    #region voisin_lst_gestion
    void SetVoisin()
    {
        foreach (Vector3 V3 in lst_voisinPositions) // pour chaque position dans la liste des positions
        {
            #region récupèrer l'objet
            verif.transform.localPosition = V3; // on bouge le vérificateur pour récupérer son transform.pos

            Collider[] Col; // on créer un collider

            Col = Physics.OverlapBox(verif.transform.position, transform.localScale); //on déplace notre collider
            #endregion

            #region le rajoute la liste des voisin
            if (Col.Length > 0 && !lst_Voisin.Contains(Col[0].gameObject))
            {
                lst_Voisin.Add(Col[0].gameObject); 

                if (Col[0].CompareTag ("Center") && !lst_seConnect.Contains(Col[0].gameObject))
                {
                    
                    lst_seConnect.Add(Col[0].gameObject);

                    if (Dead)
                    {
                        SetAlive(false);                        
                    }
                }
            }

            else if (Col.Length <= 0)
            {
                lst_Voisin.Add(null);
            }
            #endregion
        }
    }
    #endregion

    void SetAlive(bool x)
    {
        Dead = x;

        if (Dead == true)
        {
            interior.SetActive(false);
        }

        if (Dead == false)
        {
            interior.SetActive(true);
        }
    }


    public void Detonation()
    {
        if (Bomb)
        {
            //print(gameObject + "détonation");

            StartCoroutine(Model.GetComponent<Sc_3DEffect>().Explosion());

            SD.PlaySoundFunction(3);
        }
    }
   

    public void Explosion()
    {
        //print(gameObject + "explose");
        #region variables
        List<GameObject> ColorChain = new List<GameObject>() ;
        List<GameObject> Tofall = new List<GameObject>();
        #endregion


        #region Score
        if (!BombO)
        {
            GM.Combo();
            Point.GetComponent<Sc_Case_Point>().AddPoint(100, color, BombO);
        }
        #endregion


        foreach (GameObject Go in lst_DoubleCo)
        {
            //print(gameObject + "vérifie la couleur de " + Go);

            if (!vérifiés.Contains(Go) & Go.tag == "Case")
            {
                //print(Go + "n'as pas encore vérifier" + Go + " et le peut");

                Sc_Case_808 Go_Sc = Go.GetComponent<Sc_Case_808>();

                Go_Sc.vérifiés.Add(gameObject); //éviter les boucles infinies
                
                if (Bomb && Go_Sc.color == color)
                {
                    GM.lst_comboDone.Clear();

                    ColorChain.Add(Go);
                    //print(gameObject + "added "+ Go + " in Colorchain");
                }

                else if (Bomb && Go_Sc.color != color)
                {
                    //print(Go +"a une couleur différente");
                    GM.lst_comboDone.Clear();                    

                    if (Go_Sc.Ancrée(true, null,Go) == false)
                    {
                        Tofall.Add(Go);
                    }
                }


            }
        }

        foreach (GameObject Go in ColorChain)
        {
            Sc_Case_808 Go_Sc = Go.GetComponent<Sc_Case_808>();
            Go_Sc.Bomb = true;
            Go_Sc.Detonation();
            //int(gameObject + "lance la détonation de" + Go);
        }

        foreach (GameObject Go in Tofall)
        {

        }


        vérifiés.Clear();
        Destrouir();

    }
 
    public void réequilibre()
    {        
        Sc_pds.vd_ApplyPoids(-1);
    }
    

    public bool Ancrée(bool original, GameObject parent, GameObject First)
    {
        VerifAncrage = true;

        if (parent !=null)
        {
        parent.GetComponent<Sc_Case_808>().vérifiés.Add(gameObject);
        }

        GM.lst_comboDone.Add(gameObject);

        bool ancrée = false;

        lst_enfant.Add(gameObject);

        #region verification des enfant

        if (lst_DoubleCo.Count > 0)
        {
            foreach (GameObject Go in lst_DoubleCo)
            {
               
                   //print(gameObject + "récupère : " + Go);
                   if (Go == First)
                   {
                       lst_enfant.Add(Go);
                       parent.GetComponent<Sc_Case_808>().lst_enfant.Add(Go);
                   }

                   else if (Go.CompareTag("Case") && !vérifiés.Contains(Go) & !GM.lst_comboDone.Contains(Go) && !Go.GetComponent<Sc_Case_808>().Bomb)
                   {
                        if (!Go.GetComponent<Sc_Case_808>().VerifAncrage)
                        {
                           // print(gameObject + "vérifie : " + Go);
                           vérifiés.Add(Go);

                           Sc_Case_808 Go_Sc = Go.GetComponent<Sc_Case_808>();

                           lst_enfant.Add(Go);


                           Go_Sc.vérifiés.Add(gameObject);

                            if (Go_Sc.Ancrée(false, gameObject, First) == true)
                            {
                                ancrée = true;

                                foreach (GameObject go in lst_DoubleCo)
                                {
                                    if (parent != null && !parent.GetComponent<Sc_Case_808>().lst_enfant.Contains(go))
                                    {
                                        parent.GetComponent<Sc_Case_808>().lst_enfant.Add(go);
                                    }
                                }
                                GM.lst_comboDone.Clear();
                                vérifiés.Clear();
                                //print("vérifié :" + vérifiés.Count);

                                VerifAncrage = false;
                                return ancrée;

                            }    
                        }
                   }

                   else if (Go.CompareTag("Center"))
                   {
                       ancrée = true;

                       foreach (GameObject go in lst_enfant)
                       {
                           if (parent != null && !parent.GetComponent<Sc_Case_808>().lst_enfant.Contains(go))
                           {
                               parent.GetComponent<Sc_Case_808>().lst_enfant.Add(go);
                           }
                       }

                       GM.lst_comboDone.Clear();
                       vérifiés.Clear();
                       //print("vérifié :" + vérifiés.Count);
                       VerifAncrage = false;
                       return ancrée;
                   }
                
            }

        }
        #endregion

        if (!ancrée)
        {
            anim.SetTrigger("Fall");       
        }

        GM.lst_comboDone.Clear();

        vérifiés.Clear();
        //print("vérifié :" + vérifiés.Count);
        VerifAncrage = false;
        return ancrée;
    }


    public void destroyConnexion()
    {
        foreach (GameObject Go in lst_Connexion)
        {
            Go.GetComponent<Sc_connexion>().function(false,1);
            Go.SetActive(false);            
        }
    }


    public void Destrouir()
    {
        GM.listintgModuleColors(false, color);

        #region disparition modèle
        OQP = false; Bomb = false;  color = 0; BombO = false;

        destroyConnexion();

        if (Model != null)
        {
            Model.GetComponent<Sc_3DEffect>().detruireGo();
        }

        resetfunction();
        #endregion

        foreach(GameObject Go in lst_connecté)
        {            
            if (Go.CompareTag("Case"))
            {
                Go.GetComponent<Sc_Case_808>().lst_seConnect.Remove(gameObject);
                Go.GetComponent<Sc_Case_808>().resetfunction();
            }            
        }

        lst_connecté.Clear();
        lst_DoubleCo.Clear();
        lst_enfant.Clear();
        vérifiés.Clear();
        //print("vérifié :" + vérifiés.Count);

        anim.SetTrigger("Reset");        
    }


    private void resetfunction()
    {
        if (lst_seConnect.Count <= 0)
        {
            Dead = true;
            interior.SetActive(false);
        }

        else if (lst_seConnect.Count > 0 && !OQP)
        {
            interior.SetActive(true);
        }

        Posable = false;
    }

}
