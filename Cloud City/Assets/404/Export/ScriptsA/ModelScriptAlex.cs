using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScriptAlex : MonoBehaviour
{
    public GameManagerAlex GM;

    public GameObject Rouge, Bleu, Vert, Jaune, module, BombeBleue,BombeVerte,BombeJaune,BombeRouge;
    
    public List<GameObject> allConnections;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GM = Camera.main.GetComponent<GameManagerAlex>();
    }

    public void SetModel(int couleur , List<int> connexion)
    {
        if (!GM.Bombe)
        {

            if (couleur == 1)
            {
                module = Bleu;
            }
            else if (couleur == 2)
            {
                module = Vert;
            }
            else if (couleur == 3)
            {
                module = Jaune;
            }
            else if (couleur == 4)
            {
                module = Rouge;
            }
        }
        else
        {
            if (couleur == 1)
            {
                module = BombeBleue;
            }
            else if (couleur == 2)
            {
                module = BombeVerte;
            }
            else if (couleur == 3)
            {
                module = BombeJaune;
            }
            else if (couleur == 4)
            {
                module = BombeRouge;
            }
        }

        module = Instantiate(module, transform);

        foreach (int i in connexion)
        {
            GameObject Go = allConnections[i];
            Go.SetActive(true);            
        }
        
        
    }

    public void disableModel()
    {
        Destroy(module);

        foreach (GameObject Go in allConnections)
        {
            Go.SetActive(false);
        }
    }

}
