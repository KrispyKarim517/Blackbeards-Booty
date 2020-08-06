using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/5/2020
    DEPENDENT ON: script_EventButtonBehavior
    
    This script controls the behavior of the input field depending on the following conditions:
        - Has the max number of characters been reached? -> Stop player from entering more characters
        - Has the input field been filled? -> Switch the input field box's sprite
*/
public class script_InputFieldSettings : MonoBehaviour
{
    // Variables for the character name limit behaviors
    [SerializeField] private InputField inputfield_InputBox = null; // Need this reference to set the character limit
    [SerializeField][MinAttribute(0)] private int int_NameCharacterLimit = 0;
    [SerializeField] private Text text_PlaceholderText = null;

    // Variables for changing sprites
    [SerializeField] private Sprite sprite_UnactiveSprite = null;
    [SerializeField] private Sprite sprite_ActiveSprite = null;
    
    // Reference to the script_EventButtonBehavior script
    [SerializeField] private script_EventButtonBehavior ref_EventButtonBehavior = null;
    
    // Set the name character limit to the desired setting and update the placeholder text to reflect this change 
    // Ensure that the input field's sprite is set to the unactive sprite
    private void Start()
    {
        inputfield_InputBox.characterLimit = int_NameCharacterLimit;
        text_PlaceholderText .text = "NAME (" + int_NameCharacterLimit.ToString() + " LETTERS)";
        inputfield_InputBox.GetComponent<Image>().sprite = sprite_UnactiveSprite;
    }
    
    /*
        Detect whether the player has entered in any characters,
        if yes, change the input field's sprite to the active state.
        Else, set the input field's sprite to the unactive state.
    */
    private void Update()
    {
        if (inputfield_InputBox.text.Length == 0)
        {
            SwitchSprites(false);
        }
        else
        {
            SwitchSprites(true);
        }
        ref_EventButtonBehavior.CheckActivity();
    }
    
    // Switches the input field's sprite
    private void SwitchSprites(bool bool_var_SetToActiveSprite)
    {
        if (bool_var_SetToActiveSprite)
        {
            inputfield_InputBox.GetComponent<Image>().sprite = sprite_ActiveSprite;
        }
        else
        {
            inputfield_InputBox.GetComponent<Image>().sprite = sprite_UnactiveSprite;
        }
    }
    
    // Public functions to be used when we trigger our event buttons (ENTER and CLEAR)
    // CLEAR should remove data from the input field.
    // ENTER should check that the input field has been filled.
    public void ClearInputField()
    {
        inputfield_InputBox.text = "";
    }
    
    // Returns true if characters have been entered in the field
    public bool IsInputFieldFilled()
    {
        return inputfield_InputBox.text.Length > 0;
    }
}
