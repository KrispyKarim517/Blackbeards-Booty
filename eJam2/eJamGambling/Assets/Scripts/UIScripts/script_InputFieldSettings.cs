using UnityEngine;
using UnityEngine.UI;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/3/2020
    
    This script controls the following settings for the UI input field:
        - Input character limit
        - Input confirmation button behavior
*/
public class script_InputFieldSettings : MonoBehaviour
{
    [SerializeField] private InputField inputfield_InputBox = null;
    /*
        We chose to enforce a character limit for the following reasons:
            - Helps prevent trolling (by people who want to flood the screen with 
               overly long player names)
            - Encourages people to choose shorter, memorable names. 
    
        When the InputField's width is set to 600 characters, only 15 characters 
        can fit within the box.
    */
    [SerializeField][MinAttribute(0)] private int int_NameCharacterLimit = 0;
    [SerializeField] private Button button_confirmationButton = null;

    // Set the name character limit to the desired setting.
    private void Start()
    {
            inputfield_InputBox.characterLimit = int_NameCharacterLimit;
            
    }
    
    /*
       The Update() function is used to detect whether the player has 
       entered in a name. If yes, allow the player to continue. 
    */
    private void Update()
    {
        if (inputfield_InputBox.text.Length == 0) button_confirmationButton.interactable = false;
        else button_confirmationButton.interactable = true;
    }
}
