using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_3DEffect : MonoBehaviour
{
    public Animator anim;
    public GameObject FX;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        
    }

    public void spawn()
    {
        GetComponent<Animator>().SetTrigger("POSE");
    }

    public void DestructionFX()
    {
        FX.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
