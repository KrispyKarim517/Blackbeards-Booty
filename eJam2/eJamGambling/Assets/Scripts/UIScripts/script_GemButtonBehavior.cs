using UnityEngine;
using UnityEngine.UI;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/7/2020
    DEPENDENT ON: script_SlotBehavior, script_EventButtonBehavior, script_DifficultyNotification
    
    This script controls the effects of pressing a gem-shaped button
*/
public class script_GemButtonBehavior: MonoBehaviour
{
    [SerializeField] private Transform transform_GemButtons = null; // Reference to the grid holding the buttons
    private float float_NumberOfButtons = 0; // Number of buttons
    
    // Gem sprites --> Each is connected to the button with the matching shape
    [SerializeField] private Sprite sprite_BlueGem = null;
    [SerializeField] private Sprite sprite_WhiteGem = null;
    [SerializeField] private Sprite sprite_GreenGem = null;
    [SerializeField] private Sprite sprite_RedGem = null;
    [SerializeField] private Sprite sprite_YellowGem = null;

    // Reference to the SlotBehavior script, whose functions will be called
    [SerializeField] private script_SlotBehavior ref_SlotBehavior = null;
    
    // Reference to the EventButtonBehavior script, whose functions will be called
    [SerializeField] private script_EventButtonBehavior ref_EventButtonBehavior = null;
    
    // Reference to the DifficultyNotification script, whose functions will be called 
    [SerializeField] private script_DifficultyNotification ref_DifficultyNotification = null;

    private void Start()
    {
        float_NumberOfButtons = transform_GemButtons.childCount;
    }

    // Add a blue gem 
    public void AddBlueGem()
    {
        AddGem(sprite_BlueGem);
    }
    
    // Add a white gem 
    public void AddWhiteGem()
    {
        AddGem(sprite_WhiteGem);
    }
    
    // Add a green gem 
    public void AddGreenGem()
    {
        AddGem(sprite_GreenGem);
    }
    
    // Add a red gem
    public void AddRedGem()
    {
        AddGem(sprite_RedGem);
    }
    
    // Add a yellow gem
    public void AddYellowGem()
    {
        AddGem(sprite_YellowGem);
    }
    
    // Updates the slots to display the gem and the correct slot state
    private void AddGem(Sprite sprite_var_NewSprite)
    {
        if (ref_SlotBehavior.CanAddImages())
        {
            ref_SlotBehavior.AddImageToSlot(sprite_var_NewSprite);
            ref_SlotBehavior.ChangeSlotSprite(ref_SlotBehavior.GetNumberOfImages(), true);
            ref_EventButtonBehavior.CheckActivity();
            ref_DifficultyNotification.UpdateDifficulty(ref_SlotBehavior.GetNumberOfImages());
            if (!ref_SlotBehavior.CanAddImages())
            {
                SetButtons(false);
            }
        }
    }
    
    // Enable or disable all of the buttons
    public void SetButtons(bool bool_var_Enable)
    {
        for (int i = 0; i < transform_GemButtons.childCount; i++)
        {
            GameObject gobj_temp_ButtonRef = transform_GemButtons.Find("Button #" + (i + 1).ToString()).gameObject;
            if (gobj_temp_ButtonRef != null)
            {
                gobj_temp_ButtonRef.GetComponent<Button>().interactable = bool_var_Enable;
            }
        }
    }
}
