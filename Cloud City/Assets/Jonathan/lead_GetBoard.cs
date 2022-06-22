using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lead_GetBoard
{ 
    [System.Serializable] 
    public class lead_GestionnerLeaderBoard
    {
        public int i_score;
        public string str_name;
        public string str_grade;
    }

    public List<lead_GestionnerLeaderBoard> lst_AllProfil = new List<lead_GestionnerLeaderBoard>();

    private void Start()
    {

    }

    public void vd_newplayer(List<lead_GestionnerLeaderBoard> gestionner)
    { 
    
    
    }
}
