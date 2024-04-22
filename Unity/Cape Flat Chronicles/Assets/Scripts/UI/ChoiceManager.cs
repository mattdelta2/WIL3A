using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public GameObject choicePanel;
    public Button truthButton;
    public Button lieButton;

    public PlayerStats playerStats;
    

    private void Start()
    {
        //Listeners for the button
        truthButton.onClick.AddListener(OnTruthButtonClicked);
        lieButton.onClick.AddListener(OnLieButtonClicked);

        //hide the panel at start of game
        HideChoicePanel();

    }

    private void Update()
    {
        if(choicePanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnTruthButtonClicked();
            }
            else
            {
                 if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    OnLieButtonClicked();
                }
            }
        }
    }

    //method to show panel
    public void ShowChoicePanel()
    {
        choicePanel.SetActive(true);
        Time.timeScale = 0f;
        
    }

    //method to hide panel
    public void HideChoicePanel()
    {
        choicePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }


    private void OnTruthButtonClicked()
    {
        // Handle the truth choice (e.g., adjust player stats)
        playerStats.DecreaseGangStatus(1);
        playerStats.IncreaseEducation(1);

        // Hide the choice panel
        HideChoicePanel();
        

    }

    private void OnLieButtonClicked()
    {
        // Handle the lie choice (e.g., adjust player stats)
        playerStats.IncreaseGangStatus(1);
        playerStats.DecreaseEducation(1);

        // Hide the choice panel
        HideChoicePanel();
        
    }
}
