using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoisinAlex : MonoBehaviour
{
    public bool disponible, setVoisin, dead; //disponibe, vérifie si le voisin est une case libre ou occ

    public  GameObject voisin, Case, model;
    public Collider[] Col;


    int listposition;    

    // Start is called before the first frame update
    void Start()
    {
        
        disponible = false;
        setVoisin = true;
        
        SetVoisin();

        dead = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    
    public void MakeDisponible()
    {
        disponible = true;

        if (voisin != null)
        {
            voisin.GetComponent<Sc_CaseAlex>().Undead();
            voisin.GetComponent<Sc_CaseAlex>().AddConexion(Case);
        }
    }

    public void ModelOn()
    {
        model.SetActive(true);
    }
    public void ModelOff()
    {
        model.SetActive(false);
    }

    public void GetVoisin()
    {
        SetVoisin();
            
        if (!Case.GetComponent<Sc_CaseAlex>().list_Voisin.Contains(voisin))
        {
            Case.GetComponent<Sc_CaseAlex>().addVoisin(voisin);
        }

    }

    private void SetVoisin()
    {
        Col = Physics.OverlapBox(transform.position, transform.localScale);
        
        if (Col.Length > 0)
        {
            voisin = Col[0].gameObject;
        }

    }


    public void Bomb()
    {

    }
}
