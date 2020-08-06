using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/5/2020
    DEPENDENT ON: script_SlotBehavior, script_InputFieldSettings, script_GemButtonBehavior
    
    This script controls the effects of pressing one of the event buttons (ENTER and CLEAR)
*/
public class script_EventButtonBehavior: MonoBehaviour
{
    [SerializeField] private Button button_EnterButton = null; // Reference to the Enter button
    [SerializeField] private script_SlotBehavior ref_SlotBehavior = null; // Reference to the script_SlotBehavior script 
    [SerializeField] private script_InputFieldSettings ref_InputFieldSettings = null; // Reference to the script_InputFieldSettings script 
    [SerializeField] private script_GemButtonBehavior ref_GemButtonBehavior = null; // Reference to the script_GemButtonBehavior script
    [SerializeField] private string string_NextSceneName = "KarimScene"; // The name of the scene to transition to. Would ideally be an integer, but the UI is currently a prototype.
    
    // Alpha values used to make the text part of a button match its button's state
    [SerializeField][MinAttribute(0)] private float float_UnactiveAlphaValue = .2f;
    [SerializeField][MinAttribute(0)] private float float_ActiveAlphaValue = 1f;
     
    // Reference to the TMPro component of the button
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI_EnterButtonText = null;
     
    // Disable the enter button at the start of the game
    private void Start()
    {
        ResetEnterButton();
    }
    
    // Enable the enter button if the minimum number of slots have been filled and the input field has been filled
    public void CheckActivity()
    {
        if (ref_SlotBehavior.MetMinNumberOfSlots() && ref_InputFieldSettings.IsInputFieldFilled())
        {
            TextMeshProUGUI_EnterButtonText.color = ChangeAlpha(TextMeshProUGUI_EnterButtonText.color, float_ActiveAlphaValue);
            button_EnterButton.interactable = true;
        }
        else
        {
            ResetEnterButton();
        }
    }
    
    // Allow the player to move to the next scene if all the conditions have been met
    public void Enter()
    {
        if (button_EnterButton.interactable)
        {
            SceneManager.LoadScene(string_NextSceneName);
        }
    }
    
    // Clear the info form of all data and set the enter button to the unactive state
    public void Clear()
    {
        ref_InputFieldSettings.ClearInputField();
        ref_SlotBehavior.ResetSlots();
        ref_GemButtonBehavior.SetButtons(true);
        ResetEnterButton();
    }
    
    // Set the enter button to the unactive state
    private void ResetEnterButton()
    {
        button_EnterButton.interactable = false;
        TextMeshProUGUI_EnterButtonText.color = ChangeAlpha(TextMeshProUGUI_EnterButtonText.color, float_UnactiveAlphaValue);
    }
    
    // Change the button's alpha
    private Color ChangeAlpha(Color color_var_oldColor, float float_var_newAlpha)
    {
        color_var_oldColor.a = float_var_newAlpha;
        return color_var_oldColor;
    }
}
