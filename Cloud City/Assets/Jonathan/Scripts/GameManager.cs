using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float f_duration;

    #region Singleton
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }
    #endregion

    public GameObject Starter;

    [Header("List")]

    public List<GameObject> lst_iles = new List<GameObject>();
    public GameObject gm_iles;

    [Space]

    public List<GameObject> lst_Grid = new List<GameObject>();
    public GameObject gm_grid;

    [Space]
    [Header("Bool")]


    public bool b_DoOnce = true;

    [Space]
    [Header("Rotation")]

    public int i_difficulty = 1;
    public bool b_ApplyRota = false;
    public bool b_bomber = false;

    [Space]
    [Header("Tableau Hit")]
    
    public List<GameObject> hit_voisins = new List<GameObject>();

    [Space,Space]

    public GameObject go_start;
    float f_startX;
    float f_startZ;

    [Space, Space]

    private float f_applyonX;
    private float f_applyonZ;

    [Space, Space]



    [Space, Space]

    Quaternion qt_start;
    Quaternion qt_target;

    [Space]

    Vector3 v3_start;
    Vector3 v3_target;

    [Space]

    float f_previousElapseTime;
    float f_alpha;

    [Space, Space]
    public bool b_NewRotSystem;
    public bool b_GetinfoRotationONCE;


    float f_previousSmoothTime;



    private Coroutine crt_Coroutine;

    void Start()
    {
        Starter = GameObject.Find(name);

    }

    void Update()
    {
        f_startX = go_start.transform.rotation.eulerAngles.x;
        f_startZ = go_start.transform.rotation.eulerAngles.z;


        if(b_DoOnce)
        {
            vd_refreshList();
        }

    }

    public void vd_MyRot(float x, float z)
    {
        if (Mathf.Abs(x) <= i_difficulty)
            x = 0f;

        if (Mathf.Abs(z) <= i_difficulty)
            z = 0f;

       

        //Remettre le bon sens de rotations des Axes.
        //Modulo est là pour délimiter que la rotation soirs compris entre 
        float f_finalonX = (f_startX + x) % 360f;
        float f_finalonZ = (f_startZ + z) % 360f;


        v3_start = new Vector3(f_startX, 0, f_startZ);
        v3_target = new Vector3(f_finalonX, 0, f_finalonZ);


        if(b_NewRotSystem && v3_target != v3_start)
        {

            //Application du System de rotation ! 

            if(crt_Coroutine != null)
                StopCoroutine(crt_Coroutine);

            //Applique la nouvelle rotation
           crt_Coroutine = StartCoroutine(nm_smoothrot(Quaternion.Euler(v3_start), Quaternion.Euler(v3_target), f_duration));

            //Ecrase l'ancienne destination 
        }

    }

    void vd_refreshList()
    {
        lst_Grid.Clear();
        lst_iles.Clear();


        GameObject.FindWithTag("Ile");
        foreach (GameObject iles in lst_iles)
        {
            lst_iles.Add(iles);
        }

        GameObject.FindWithTag("case");
        foreach (GameObject grid in lst_Grid)
        {
            lst_iles.Add(grid);
        }
        b_DoOnce = false;
    }

    public void vd_retirerpoids( float x, float z)
    {
        float f_finalonZ = (f_startZ + x + 180f) % 360f - 180f;
        float f_finalonX = (f_startX - z + 180f) % 360f - 180f;

        if (Mathf.Abs(f_finalonX) <= i_difficulty)
            f_finalonX = 0f;
        if (Mathf.Abs(f_finalonZ) <= i_difficulty)
            f_finalonZ = 0f;

        go_start.transform.eulerAngles = new Vector3(f_finalonX, 0, f_finalonZ);

    }

    IEnumerator nm_smoothrot(Quaternion start, Quaternion target, float timeDuration)
    {
        
        float f_elapsedTime = 0f;

        while(f_elapsedTime <= timeDuration)
        {
            f_elapsedTime += Time.deltaTime;
            if (!Mathf.Approximately(f_previousElapseTime, 1) && !Mathf.Approximately(f_previousElapseTime, 0) &&  f_elapsedTime < f_previousElapseTime)
            {
                f_alpha = f_elapsedTime * f_previousSmoothTime / f_previousElapseTime;
            }
            else
            {
                f_alpha = Mathf.SmoothStep(0, 1, f_elapsedTime / timeDuration);
                f_previousElapseTime = f_elapsedTime;
                f_previousSmoothTime = f_alpha;
            }
            go_start.transform.rotation = Quaternion.Lerp(start, target, f_alpha);
            yield return null;
        }

        go_start.transform.rotation = target;
        f_previousElapseTime = 0f;
        f_previousSmoothTime = 0f;
    }

    IEnumerator nm_newRot(Quaternion start, Quaternion target, float DurationTime)
    {

        float f_elapsedTime = 0f;

        while (f_elapsedTime < DurationTime)
        {
            f_elapsedTime += Time.deltaTime;

            float f_smoothTime = Mathf.SmoothStep(0, 1, f_elapsedTime / DurationTime);

            Quaternion v3_smoothRot = Quaternion.Lerp(start, target, f_smoothTime);

            go_start.transform.rotation = v3_smoothRot;

            yield return null;
            

        }
    }
}
