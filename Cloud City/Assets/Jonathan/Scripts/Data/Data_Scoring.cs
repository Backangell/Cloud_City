using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Data_Scoring :MonoBehaviour
{
    Scene scene;

    bool b_exist;

    public static int   i_sendScore;
    public static string str_score;

    [Space,Header("Reference")]

    [SerializeField]public static Text txt_name;
    [SerializeField]public static string txt_score;

    [Space,Header("In Game Over Scene")]

    [SerializeField] public static TextMeshProUGUI txt_score_mesh;
    [SerializeField] public static TextMeshProUGUI txt_namePlayer_mesh;
    [SerializeField] public static TextMeshProUGUI txt_grade;

    [Space]

    bool b_setHUD = false;

    void Start()
    {
        
        #region Eviter les doublons + instance

        if (!b_exist)
        {
            b_exist = true;
            DontDestroyOnLoad(this);
        }
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        #endregion
    }

    public void Update()
    {
        //Valeur Temporaire du i_Score
        i_sendScore = Sc_GameManager_808.score;

        //Gestion des scenes
        scene = SceneManager.GetActiveScene();


        //scene de GameOver
        if (scene.name == "Game Over")
        {
            b_setHUD = true;

            //Recherches des Components - Name / i_Score Player 
            #region Set les References

            if(b_setHUD)
            {
                vd_setgrade(i_sendScore);
                vd_setscore(i_sendScore);
                vd_setname();
                b_setHUD = false;
            }
          
            #endregion
        }
        else
        {
            txt_score_mesh = null;
            txt_namePlayer_mesh = null;
        }


    }

    void vd_setname()
    {
        GameObject go_Name = GameObject.FindWithTag("PlayerName");
        txt_namePlayer_mesh = go_Name.GetComponent<TextMeshProUGUI>();

    }
    void vd_setscore(int score)
    {
        GameObject go_score = GameObject.FindWithTag("PlayerScore");
        txt_score_mesh = go_score.GetComponent<TextMeshProUGUI>();

        txt_score_mesh.text = i_sendScore.ToString();

    }
    void vd_setgrade(int score)
    {
        GameObject go_grade = GameObject.FindWithTag("btn_confirme");
        txt_grade = go_grade.GetComponent<TextMeshProUGUI>();

        if (i_sendScore < 1000)
            txt_grade.text = "Novice";
        else if (i_sendScore > 1000)
        { txt_grade.text = "Elite"; }
        else if (i_sendScore > 2000)
        { txt_grade.text = "PGM"; }
        else if (i_sendScore > 4000)
        { txt_grade.text = "God"; }
    }



    void vd_setTmp(string setname,int setscore)
    {
        setname = Data_tmp.i_getname;
        setscore = Data_tmp.i_getScore;
    }
}
