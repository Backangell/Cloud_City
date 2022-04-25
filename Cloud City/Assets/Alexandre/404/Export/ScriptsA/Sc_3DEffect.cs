using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_3DEffect : MonoBehaviour
{
    public Animator anim;
    public GameObject FX, Case;
    public bool Bombe;

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

    public IEnumerator Explosion()
    {

        GetComponent<Animator>().SetTrigger("EXPLOSE");
        
        yield return new WaitForSeconds(0.5f);
        Case.GetComponent<Sc_Case_808>().Explosion();
    }

    public void detruireGo()
    {
        Destroy(gameObject);        
    }

    public void detruireConn()
    {
        if (!Bombe)
        {
            Case.GetComponent<Sc_Case_808>().réequilibre();
        }
       
        Case.GetComponent<Sc_Case_808>().destroyConnexion();
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
