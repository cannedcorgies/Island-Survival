using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class userInput : MonoBehaviour
{
    [Header("The value we got from the input field")]
    [SerializeField] private string inputText;

    [Header("Showing the reaction to the player")]
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;
    
    public void inputFieldData(string input){
        inputText = input;
        DisplayReactionToInput();
    }

    private void DisplayReactionToInput(){
        reactionTextBox.text = "Welcome to the game, " + inputText + "!";
        reactionGroup.SetActive(true);
    }
}
