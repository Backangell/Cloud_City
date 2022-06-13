using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Case_Point : MonoBehaviour
{
    TextMeshPro Point;
    bool Is;
    Sc_GameManager_808 GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = Camera.main.GetComponent<Sc_GameManager_808>();
        Point = gameObject.GetComponent<TextMeshPro>();
        Is = false;
    }

    public void AddPoint(int X, int Col,bool Bomb)
    {
        if (!Bomb)
        {
            if (X == 15)
            {
                Point.fontSize = 25 + GM.combo_Mult;
            }
            else if (X == 30)
            {
                Point.fontSize = 30 + GM.combo_Mult;
            }
            else if (X == 45)
            {
                Point.fontSize = 35 + GM.combo_Mult;
            }
            else
            {
                Point.fontSize = 40 + GM.combo_Mult * 2;
            }

            Point.text = "+" + (X * GM.combo_Mult).ToString();
            GM.Score(X);
            gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            StartCoroutine(PointFunction());
        }
    }

    private void ResetText()
    {
        Is = false;
        gameObject.transform.localPosition = Vector3.zero;
        Point.text = null;
    }

    IEnumerator PointFunction()
    {
        Is = true;
        yield return new WaitForSeconds(0.5f);
        ResetText();
    }


    // Update is called once per frame
    void Update()
    {
        if(Is)
        {
            gameObject.transform.position = new Vector3(transform.position.x, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
        }
    }
}
