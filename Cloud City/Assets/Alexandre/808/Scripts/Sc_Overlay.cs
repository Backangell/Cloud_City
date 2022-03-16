using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Overlay : MonoBehaviour
{
    public List<GameObject>  lst_Module;
    public Sc_GameManager_808 GM;


    [Header("Next")]
    public List<GameObject> lst_Connexion_Next;
    public GameObject next_model, next_module ;


    [Header("Actuel")]
    public List<GameObject> lst_Connexion_Actuel;
    public GameObject actuel_model, actuel_module;


    [Header("Hold")]
    public List<GameObject> lst_Connexion_Hold;
    public GameObject hold_model, hold_module;

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Next(List<int> xList, int color, bool Bomb)
    {
        GameObject G;
        
        foreach (GameObject Con in lst_Connexion_Next)
        {
            Con.SetActive(false);
        }

        foreach (int X in xList)
        {
            G = lst_Connexion_Next[X];

            G.SetActive(true);
        }

        Destroy(next_model);

        #region moduleselection
        if (!Bomb)
        {
            if (color == 1)
            {
                next_model = Instantiate(lst_Module[0], next_module.transform);
            }
            if (color == 2)
            {
                next_model = Instantiate(lst_Module[1], next_module.transform);
            }
            if (color == 3)
            {
                next_model = Instantiate(lst_Module[2], next_module.transform);
            }
            if (color == 4)
            {
                next_model = Instantiate(lst_Module[3], next_module.transform);
            }
        }

        else
        {
            if (color == 1)
            {
                next_model = Instantiate(lst_Module[4], next_module.transform);
            }
            if (color == 2)
            {
                next_model = Instantiate(lst_Module[5], next_module.transform);
            }
            if (color == 3)
            {
                next_model = Instantiate(lst_Module[6], next_module.transform);
            }
            if (color == 4)
            {
                next_model = Instantiate(lst_Module[7], next_module.transform);
            }

        }
#endregion

    }


    public void Actuel(List<int> xList, int color, bool Bomb)
    {
        GameObject G;

        foreach (GameObject Con in lst_Connexion_Actuel)
        {
            Con.SetActive(false);
        }

        foreach (int X in xList)
        {
            G = lst_Connexion_Actuel[X];

            G.SetActive(true);
        }

        Destroy(actuel_model);

        #region moduleselection
        if (!Bomb)
        {
            if (color == 1)
            {
                actuel_model = Instantiate(lst_Module[0], actuel_module.transform);
            }
            if (color == 2)
            {
                actuel_model = Instantiate(lst_Module[1], actuel_module.transform);
            }
            if (color == 3)
            {
                actuel_model = Instantiate(lst_Module[2], actuel_module.transform);
            }
            if (color == 4)
            {
                actuel_model = Instantiate(lst_Module[3], actuel_module.transform);
            }
        }

        else
        {
            if (color == 1)
            {
                actuel_model = Instantiate(lst_Module[4], actuel_module.transform);
            }
            if (color == 2)
            {
                actuel_model = Instantiate(lst_Module[5], actuel_module.transform);
            }
            if (color == 3)
            {
                actuel_model = Instantiate(lst_Module[6], actuel_module.transform);
            }
            if (color == 4)
            {
                actuel_model = Instantiate(lst_Module[7], actuel_module.transform);
            }

        }
        #endregion

    }


    public void Hold(List<int> xList, int color, bool Bomb)
    {
        GameObject G;

        foreach (GameObject Con in lst_Connexion_Hold)
        {
            Con.SetActive(false);
        }

        foreach (int X in xList)
        {
            G = lst_Connexion_Hold[X];

            G.SetActive(true);
        }

        Destroy(hold_model);

        #region moduleselection
        if (!Bomb)
        {
            if (color == 1)
            {
                hold_model = Instantiate(lst_Module[0], hold_module.transform);
            }
            if (color == 2)
            {
                hold_model = Instantiate(lst_Module[1], hold_module.transform);
            }
            if (color == 3)
            {
                hold_model = Instantiate(lst_Module[2], hold_module.transform);
            }
            if (color == 4)
            {
                hold_model = Instantiate(lst_Module[3], hold_module.transform);
            }
        }

        else
        {
            if (color == 1)
            {
                hold_model = Instantiate(lst_Module[4], hold_module.transform);
            }
            if (color == 2)
            {
                hold_model = Instantiate(lst_Module[5], hold_module.transform);
            }
            if (color == 3)
            {
                hold_model = Instantiate(lst_Module[6], hold_module.transform);
            }
            if (color == 4)
            {
                hold_model = Instantiate(lst_Module[7], hold_module.transform);
            }

        }
        #endregion

    }
}
