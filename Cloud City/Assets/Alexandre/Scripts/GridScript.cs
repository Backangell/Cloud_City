using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{

    public bool Exist, overlap, BoolB;
    
    public List<Transform> positionVoisin;
    public GameObject Case, interior, model;

    

    // Start is called before the first frame update
    void Start()
    {
        Exist = false; //booléenne pour savoir si une case est occupé par une île
        overlap = false;//Quand la souris passe dessus
        BoolB = true; // supprime l'interaction des case déjà utilisés
    }
    


    // Update is called once per frame
    void Update()
    {
        if (Exist) 
        {
            spawnVoisin(); //fonction qui fait apparaitre le quadrillage non occupé par une île autour
            Destroy(interior);
            Exist = false;//Cette Booléenne sert à faire apparaitre des bâtiment
            BoolB = false; //cette Booléenne sert à empêcher l'interaction après qu'on ai mis un bâtiment.
        }
        
    }

    private void spawnVoisin()
    {   
        for (int a = 5; a >= 0; a--) //il y a 6 possibilité d'île
        {
            if (positionVoisin[a].GetComponent<Voisin>().disponible == true)//vérifie que les îles ne soient pas occupées
            {
                GameObject oe = Instantiate(Case); //fais apparaitre une case
                oe.GetComponent<GridScript>().Overlapping (false); // 
                oe.transform.position = positionVoisin[a].position; //place la case
            }
        }


        model.SetActive(true);
        model.GetComponent<Model3D>().modelselction(Random.Range(0f,1f));
    }
    public void Overlapping(bool a)
    {
        if(a & BoolB)
        { 
            interior.SetActive(true);
        }
        else if (!a & BoolB)
        {
            interior.SetActive(false);
        }
    }
    




}
