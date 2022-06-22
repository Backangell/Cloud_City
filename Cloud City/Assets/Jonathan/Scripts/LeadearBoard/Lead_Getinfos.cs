using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lead_Getinfos : MonoBehaviour
{
    public int i_score;
    public string str_name;
    public string str_rang;

    [Space, Space]
    [Header("SetUp Rank")]
    
    public Sc_GameManager_808 GM_808;
    public int i_rankGod;  
    public int i_rankMaster;
    public int i_rankPGM;
    public int i_rankElite;


    [Space, Space]
    [Header("TextMeshPro references")]

    public TextMeshProUGUI txtpro_name;
    public TextMeshProUGUI txtpro_grade;
    public TextMeshProUGUI txtpro_score;

    private Scene scene;

    bool b_Exist;


    [Space, Space]
    [Header("Scene Game Over")]

    public GameObject go_GameOver;
    public GameObject go_Highscore;

    [Space]

    public bool b_DoOnce = true;
    public bool b_Reset;

    [Space]

    public TextMeshProUGUI txtpro_ProfileName;
    public TextMeshProUGUI txtpro_ProfilScore;
    public TextMeshProUGUI txtpro_ProfilRang;

    [Space, Header("Check Rang")]

    public GameObject go_Score_1;
    public GameObject go_Score_2;
    public GameObject go_Score_3;
    public GameObject go_Score_4;
    public GameObject go_Score_5;
    public GameObject go_Score_6;
    public GameObject go_Score_7;
    public GameObject go_Score_8;
    public GameObject go_Score_9;
    public GameObject go_Score_10;

    [Space]

    public int i_tmpScore;

    // Start is called before the first frame update
    void Start()
    {


        #region Un Score Manager
        if (!b_Exist)
        {
            DontDestroyOnLoad(this.gameObject);
            b_Exist = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion    



        if(scene.name == "Game Over" && go_Highscore.activeInHierarchy)
        {
            print("Score - CheckScore");
            CheckScore(go_Score_1.GetComponent<TextMeshProUGUI>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        scene = SceneManager.GetActiveScene();

        #region Get & Set Informations player

        //Ne pas toucher
        if (scene.name == "Game Over")
       {

            gameObject.GetComponent<ManagerScore>();
            go_GameOver = GameObject.Find("GameOver");
            go_Highscore = GameObject.Find("Highscores");

            //ne pas toucher
            if(go_Highscore != null && b_DoOnce)
            {               
                txtpro_ProfileName = GameObject.Find("Name_new").GetComponent<TextMeshProUGUI>();
                txtpro_ProfilScore = GameObject.Find("Score_new").GetComponent<TextMeshProUGUI>();
                txtpro_ProfilRang = GameObject.Find("Grade_new").GetComponent<TextMeshProUGUI>();

                StartCoroutine(nm_NewPlayer(i_score,str_name,str_rang));
            }

            //Ne pas toucher
            if(go_GameOver != null)
            {
                #region Assignation des références
                txtpro_score = GameObject.Find("PlayerScore_Value").GetComponent<TextMeshProUGUI>();
                txtpro_grade = GameObject.Find("PlayerGrade_Value").GetComponent<TextMeshProUGUI>();
                txtpro_name = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();

                #endregion

                #region Assignation des Ranks

                txtpro_score.text = i_score.ToString();
                txtpro_grade.text = str_rang.ToString();

                if (i_score <= i_rankElite)
                {
                    str_rang = "Novice";
                }
                else
                {
                    str_rang = "Elite";                    
                }

                if (i_score >= i_rankPGM)
                {
                    str_rang = "PGM";
                }

                if (i_score >= i_rankMaster)
                {
                    str_rang = "Master";
                }

                if (i_score >= i_rankGod)
                {
                    str_rang = "God";
                }


                #endregion

                #region Assignation du nom

                str_name = txtpro_name.text;

                #endregion

            }
            else
            {
                txtpro_score = null;
                txtpro_grade = null;
                txtpro_name = null;
            }  
       }

       //Ne pas changer
        if(scene.name != "Game Over" && b_DoOnce && b_Reset)
        {
            nm_Reset(i_score, str_name, str_rang);
        }

        //ne pas changer
        if(scene.name != "Game Over" )
        {
            print("Score - Current Score    :" + i_score);
            i_score = GM_808.score;
        }
        #endregion


        #region Triage des scores

        /*if(scene.name == "Game Over" && go_Highscore.name != null)
        {
            go_Score_1 = GameObject.Find("Score_1");
            go_Score_2 = GameObject.Find("Score_2");
            go_Score_3 = GameObject.Find("Score_3");
            go_Score_4 = GameObject.Find("Score_4");
            go_Score_5 = GameObject.Find("Score_5");
            go_Score_6 = GameObject.Find("Score_6");
            go_Score_7 = GameObject.Find("Score_7");
            go_Score_8 = GameObject.Find("Score_8");
            go_Score_9 = GameObject.Find("Score_9");
            go_Score_10 = GameObject.Find("Score_10");

        }*/

        #endregion
    }

    //Get & Set informations - Ne pas toucher
    IEnumerator nm_Reset(int score, string name, string rang)
    {
        print("Enter Reset");
        score = GM_808.score;
        name = null;
        rang = null;

        b_Reset = false;
        b_DoOnce = false;

        print("Quit Reset" + "Name :" + name + "Score  :" + score + "Rang"+rang );
        yield return null;
    }

    //Get& Set informations - Ne pas toucher
    IEnumerator nm_NewPlayer(int score,string name,string rang)
    {
        print("Score    :" + score + "Name  :" + name + "Rang   :" + rang);

        #region Préparation des variables

        txtpro_ProfileName.text = name;
        txtpro_ProfilScore.text = score.ToString();
        txtpro_ProfilRang.text = rang;
        #endregion

        b_DoOnce = false;
        yield return null;
    }

    public void vd_Refresh()
    {
        print("Score - reset lolilol");
        b_DoOnce = true;
        b_Reset = true;
    }

    IEnumerator nm_CheckScore(GameObject NumRang,int score,int tmpScore)
    {
        //Check Score actuelle avec le leaderBoard
       /* for(int i = 0; tmpScore < score; i++)
        {
            if(i == 1)
            {
                ;
            }

            if(i == 2)
            {

            }

            if(i == 3)
            {

            }

            if(i == 4)
            {

            }

            if(i == 5)
            {

            }

            if (i == 6)
            {

            }

            if (i == 7)
            {

            }

            if (i == 8)
            {

            }

            if (i == 9)
            {

            }

            if(i == 10)
            {

            }
        }
       */
        yield return null;
    }

    private void CheckScore(TextMeshProUGUI txt_score)
    {
        //Brainstorming
        TextMeshProUGUI txtpro_Score1 = go_Score_1.GetComponent<TextMeshProUGUI>();
        int i_score1 = 0;

        if (int.TryParse(txtpro_Score1.text, out i_score1))
        {
            Debug.Log(i_score1);
        }

        TextMeshProUGUI txtpro_Score2 = go_Score_2.GetComponent<TextMeshProUGUI>();
        int i_score2 = 0;

        if (int.TryParse(txtpro_Score2.text, out i_score2))
        {
            Debug.Log(i_score2);
        }

        TextMeshProUGUI txtpro_Score3 = go_Score_3.GetComponent<TextMeshProUGUI>();
        int i_score3 = 0;

        if (int.TryParse(txtpro_Score3.text, out i_score3))
        {
            Debug.Log(i_score3);
        }

        TextMeshProUGUI txtpro_Score4 = go_Score_4.GetComponent<TextMeshProUGUI>();
        int i_score4 = 0;

        if (int.TryParse(txtpro_Score3.text, out i_score4))
        {
            Debug.Log(i_score4);
        }
    }
}
