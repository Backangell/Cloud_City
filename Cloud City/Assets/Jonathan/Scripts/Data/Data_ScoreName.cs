using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Data_ScoreName : MonoBehaviour
{
    [Header("This Object")]
    public string strg_grade = "novice";
    public string strg_name;
    public int i_Score;

    [Space, Header("Check Value")]

    public Data_ScoreName go_Upper;
    public GameObject go_Lower;

    GameObject go_systemScoring;

    [Space,Header("Temp Values")]

    public GameObject go_tmp;
    bool b_tmp;


    // Start is called before the first frame update
    void Start()
    {
        go_systemScoring = GameObject.Find("SystemScoring");


       if(b_tmp)
       {
            print(go_systemScoring);
       }
    }

    // Update is called once per frame
    void Update()
    {
        Sc_GameManager_808.score = i_Score;

        if(go_Upper.GetComponent<Data_ScoreName>().i_Score >= this.i_Score && !b_tmp)
        {
            //Reset Scoring - Start

            GameObject getPlayerName = GameObject.FindWithTag("PlayerName");
            strg_name = getPlayerName.GetComponent<TextMeshProUGUI>().text;

            vd_LeaderBpardProfile(i_Score, strg_name);
        }
        else if(go_Upper == null){
            return;
        }



    }
    public void vd_LeaderBpardProfile(int score,string name)
    {
        #region SCORE
        //Récupération des values
        score.ToString();

        //Assignations
        print("SCORE:    " + score);

        #endregion

        #region NAME
        //Récupération des values
        
        name.ToString();

        //Assignations
        print("NAME:    " + name);

        #endregion

        #region GRADE

        if (score > 1000)
        { strg_grade = "Elite"; }

        else if (score > 2000)
        { strg_grade = "PGM"; }

        else if (score > 4000)
        { strg_grade = "Master"; }

        else if (score > 8000)
        { strg_grade = "God"; }

        print("GRADE:   " + strg_grade);

        #endregion

    }


    //Apply New Score - Name
    public void vd_SendScore( string name , int score)
    {
        print("Enter - vd_SendName  :" + strg_name + (" vd_SendScore ") + i_Score);

        strg_name = name;
        i_Score = score;

        print("Enter - vd_SendName  :" + strg_name + (" vd_SendScore ") + i_Score);

    }
}
