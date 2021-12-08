using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_Poids : MonoBehaviour
{
    public GameManager sc_manager;

    public float i_poids = 1f;

    public Vector3 v3rotate = new Vector3(4f,0,0);

    // Start is called before the first frame update
    void Start()
    {
        sc_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
       this.gameObject.transform.eulerAngles += v3rotate;
       Debug.Log(this.gameObject.transform.localEulerAngles);
       
    }
}
