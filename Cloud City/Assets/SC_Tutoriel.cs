using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SC_Tutoriel : MonoBehaviour
{
    public GameObject CurrentPage, ButtonNext, ButtonPrevious;
    public List<GameObject> PageNumber;
    public List<string> Lst_titre, Lst_Instruction;
    string instruction, title;
    [SerializeField] int CurrentNumber;
    public TextMeshProUGUI titre, Instruction;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        CurrentNumber = 0;
        ChangePage(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePage(int x)
    {
        if (CurrentNumber>=0 && CurrentNumber <= PageNumber.Count-1)
        {
            if (x > 0)
            {
                CurrentPage.SetActive(false);
                CurrentNumber += x;     
                
            }
            else if (x < 0)
            {
                CurrentPage.SetActive(false);
                CurrentNumber += x;                
            }
            else if(x == 0)
            {
                CurrentNumber = 0;               
            }
        }

        CurrentPage = PageNumber[CurrentNumber];
        title = Lst_titre[CurrentNumber];
        titre.text = title;

        instruction = Lst_Instruction[CurrentNumber];
        Instruction.text = instruction; 

        CurrentPage.SetActive(true);

        if (CurrentNumber == 0)
        {
            ButtonPrevious.SetActive(false);
        }

        else if (CurrentNumber == PageNumber.Count-1)
        {
            ButtonNext.SetActive(false);
        }

        else
        {
            ButtonNext.SetActive(true);
            ButtonPrevious.SetActive(true);
        }
    }

}
