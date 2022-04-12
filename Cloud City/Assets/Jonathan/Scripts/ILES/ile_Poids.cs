using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_Poids : MonoBehaviour
{
    [Space]
    [Header("Poids sur Axe")]
    [Space]
    public float f_monpoids;

    [Space]

    public float f_posX;
    public float f_posZ;

    public float f_OnX;
    public float f_OnZ;

    [Space,Header("Multiplicateur")]

    public float f_multiplucateur = 1f;
    //private float f_WeakHits = 100f;

    [Space]

    //public CameraScript sc_cam;
    public GameManager sc_gamemanager;
    Sc_Case_808 Sc_case;

    [Space]

    public bool b_applybomb = false;
    public bool b_applyrot = false;

    
    void Start()
    {
        Sc_case = gameObject.GetComponent<Sc_Case_808>();
        //Prendre les positions dans le monde 
        f_posX = transform.position.x;
        f_posZ = transform.position.z;

    }

    void Update()
    {
    }

    public void vd_Ratio(float x,float z,float poids)
    {
        //Faire un ratio de 100% (Position AxeX + Position AxeZ)

        float f_PoidsTotal = Mathf.Abs(x) + Mathf.Abs(z);
        
        //Répartir ces 100% sur l'axe X & Z.
        float f_moyx = Mathf.Abs(x) / f_PoidsTotal;
        float f_moyz = Mathf.Abs(z) / f_PoidsTotal;

        //print(f_moyz);
        //print(f_moyx);
        
        //Application de la charge des les axes.
        f_OnX = poids* f_moyx;
        f_OnZ = poids* f_moyz;

       //Debug.Log(("f_moyx:     ") + f_OnX);
       //Debug.Log(("f_moyz:     ") + f_OnZ);

    }
    
    public void vd_ApplyPoids(int x)
    {
        //Savoir combien de poids mettre en X & Z
        vd_Ratio(f_posX, f_posZ, f_monpoids);


        if (x>0)
        {
            //Savoir Si X & Z sont positif ou négatif
            vd_CheckSign(f_posX, f_posZ, false);
        }
        if (x < 0)
        {
            //Savoir Si X & Z sont positif ou négatif
            vd_CheckSign(f_posX, f_posZ, true);
        }



        //Pour corriger les erreurs d'axes étranges
        float f_tmp = -f_OnX;
        f_OnX = f_OnZ;
        f_OnZ = f_tmp;

        //La distance avec le centre s'il est plus loin ou non
        vd_CheckMultiplicateur(f_multiplucateur);

        GameManager.Instance.vd_MyRot(f_OnX, f_OnZ);

        b_applyrot = false;

    }

    void vd_CheckSign(float x, float z, bool destroy)
    {


        if (Mathf.Abs(x) <= .001f)
        {
            f_OnX = 0f;
            if (Mathf.Abs(z) > .001f)
                f_OnZ = f_monpoids;
        }
        if (Mathf.Abs(z) <= .001f)
        {
            f_OnZ = 0f;
            if (Mathf.Abs(x) > .001f)
                f_OnX = f_monpoids;
        }

        if (destroy)
        {
            f_OnX *= Mathf.Sign(-x);
            f_OnZ *= Mathf.Sign(-z);
        }
        else 
        { 
            f_OnX *= Mathf.Sign(x);
            f_OnZ *= Mathf.Sign(z);
        }
        //print("signe de x   :" + x);
        //print("signe de z   :" + z);
    }

    public void vd_CheckMultiplicateur(float f_multiplicateur)
    {
      // Faire des Raycasts sur les voisins
      // Prendre le résultats
      // Faire +1 ?
    
    }


}
