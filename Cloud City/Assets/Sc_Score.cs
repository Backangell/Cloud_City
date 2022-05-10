using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sc_Score : MonoBehaviour
{

    public Sc_GameManager_808 GM;
    public TextMeshProUGUI Txt_Score;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score < GM.score)
        {
            score += GM.score-score;
        }

        Txt_Score.text = score.ToString();
    }
}
