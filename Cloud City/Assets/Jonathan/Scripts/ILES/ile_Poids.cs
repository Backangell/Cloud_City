using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_Poids : MonoBehaviour
{
    public GameManager sc_manager;

    [Space]
    [Header("Poids sur Axe")]
    [Space]
    public float f_monpoids;

    [Space]

    public float f_signX;
    public float f_signZ;

    [Space]

    public float f_posX;
    public float f_PosZ;
    public Vector3 v3rotate;

    public float f_OnX;
    public float f_OnZ;

    public GameObject go_RotX;
    public GameObject go_RotZ;

    public float f_multiplucateur = 1f;

    private float f_Degres = 45;
    private float f_Degres2 = 90;

    private float f_RangeHit = 0.5f;
    //private float f_WeakHits = 100f;

    [Space]


    public List<GameObject> gm_hitsvoisins = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
         f_posX = transform.position.x;
         f_PosZ = transform.position.z;

         go_RotX = GameObject.Find("RotX");
         go_RotZ = GameObject.Find("RotZ");

        sc_manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        f_monpoids = 4f;
    }

    // Update is called once per frame
    void Update()
    {
       if(sc_manager.b_ApplyRota)
       {
            vd_ApplyPoids();
       }
    }

    public void vd_Ratio(float x,float z,float poids)
    {
        //Faire un ratio de 100%
        float f_PodsTotal = Mathf.Abs(x) + Mathf.Abs(z);
        Debug.Log(("f_PodsTotal :       ")+f_PodsTotal);
        
        //Répartir ces 100% en fonction de la position en X et Z
        f_OnX = f_PodsTotal / Mathf.Abs(x);
        f_OnZ = f_PodsTotal / Mathf.Abs(z);
        

        //Repartir le poids sur les axes.
        float f_poidsX = f_OnX / poids;
        float f_poidsZ = f_OnZ / poids;

            //Debug.Log(("Poids en X") + f_OnX);
            //Debug.Log(("Poids en Z") + f_OnZ);

        //f_signX = Mathf.Sign(x);
        //f_signZ = Mathf.Sign(z);

    }

    public void vd_ApplyPoids()
    {
        vd_Ratio(f_posX,f_PosZ,f_monpoids);
        sc_manager.vd_MyRot(f_OnX, f_OnZ);
        sc_manager.b_ApplyRota = false;
    }



    public void vd_CheckMultiplicateur()
    {
        
    }
    
}
