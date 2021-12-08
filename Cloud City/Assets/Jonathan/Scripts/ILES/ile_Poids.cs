using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_Poids : MonoBehaviour
{
    public GameManager sc_manager;

    public float i_poids = 1f;

    public Vector3 v3rotate;

    public bool b_ApplyRotation;

    public GameObject gm_Start;

    // Start is called before the first frame update
    void Start()
    {
        v3rotate = new Vector3(i_poids,0,0);

        gm_Start = GameObject.Find("Ville_centrale");
        sc_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_ApplyRotation)
        {
            gm_Start.transform.eulerAngles += v3rotate;
            Debug.Log(this.gameObject.transform.localEulerAngles);
            b_ApplyRotation = false;
        }
    }
}
