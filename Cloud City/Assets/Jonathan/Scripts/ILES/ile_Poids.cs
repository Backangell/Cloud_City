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
    public Vector3 v3rotate;

    public float f_OnX;
    public float f_OnZ;

    public float f_multiplucateur = 1f;

    //private float f_RangeHit = 0.5f;
    //private float f_WeakHits = 100f;

    [Space]

    public CameraScript sc_cam;

    [Space]

    public bool b_applyrot = false;

    [Space]
    public List<GameObject> gm_hitsvoisins = new List<GameObject>();


    void Start()
    {
        f_posX = transform.position.x;
        f_posZ = transform.position.z;

        f_monpoids = 10f;
    }

    void Update()
    {
       if(b_applyrot)
       {
            vd_ApplyPoids();
       }
    }

    public void vd_Ratio(float x,float z,float poids)
    {
        //Faire un ratio de 100% (Position AxeX + Position AxeZ

        float f_PoidsTotal = Mathf.Abs(x) + Mathf.Abs(z);
        
        //R�partir ces 100% sur l'axe X & Z.
        float f_moyx = Mathf.Abs(x) / f_PoidsTotal;
        float f_moyz = Mathf.Abs(z) / f_PoidsTotal;
             
        //Application de la charge des les axes.
        f_OnX = poids* f_moyx;
        f_OnZ = poids* f_moyz;

       //Debug.Log(("f_moyx:     ") + f_OnX);
       //Debug.Log(("f_moyz:     ") + f_OnZ);
    }

    public void vd_ApplyPoids()
    {
        vd_Ratio(f_posX, f_posZ, f_monpoids);
        vd_CheckSign(f_posX, f_posZ);
        GameManager.Instance.vd_MyRot(f_OnX, f_OnZ);
        b_applyrot = false;
    }

    void vd_CheckSign(float x, float z)
    {
        if (Mathf.Approximately(f_OnX, 0f))
        {
            f_OnX = 0f;
            f_OnZ = f_monpoids;
        }
        if (Mathf.Approximately(f_OnZ, 0f))
        {
            f_OnZ = 0f;
            f_OnX = f_monpoids;
        }

        f_OnX *= Mathf.Sign(x);
        f_OnZ *= Mathf.Sign(z);
    }

    public void vd_CheckMultiplicateur()
    {
        
    }
    
}
