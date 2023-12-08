using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalEntry : MonoBehaviour
{
    [Header("The value we got from the input field")]
    [SerializeField] private string inputText;

    [Header("Showing the reaction to the player")]
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;

    public void inputTextField(string input){
        inputText = input;
        DisplayReactionToInput();
    }

    private void DisplayReactionToInput(){
        reactionTextBox.text = "your journal entry, has been completed";
        reactionGroup.SetActive(true);
    }
    
    public void HandOverInputValue(){
        
    }
}
