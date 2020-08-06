using UnityEngine;
using UnityEngine.UI;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/5/2020
    
    This script controls how slots react to the following events:
        - Pressing one of the gem-shaped buttons
        - Pressing the clear button
*/
public class script_SlotBehavior : MonoBehaviour
{
    [SerializeField] private Transform transform_Slot = null; // Reference to the grid controlling the displayed slots, which is prepopulated with child Image objects
    [SerializeField] private Transform transform_SlotImages = null; // Reference to the grid controlling the gems displayed in the slots, which has no children
    [SerializeField] private Sprite sprite_UnactiveSprite = null;
    [SerializeField] private Sprite sprite_ActiveSprite = null;
    [SerializeField] private int int_MinNumberOfSlots = 0; // The min number of slots needed before the player can continue
    private int int_MaxNumberOfSlots = 0; // The max number of slots 

    private void Start()
    {
        int_MaxNumberOfSlots = transform_Slot.childCount; // Set the integer to the number of children under the Slot grid 
    }
    
    // Returns true if more images can be added to the SlotImages grid
    public bool CanAddImages()
    {
        return transform_SlotImages.childCount < int_MaxNumberOfSlots;
    }
    
    // Returns true if the min number of slots have been filled
    public bool MetMinNumberOfSlots()
    {
        return transform_SlotImages.childCount >= int_MinNumberOfSlots;
    }
    
    // Returns the number of gems currently displayed
    public int GetNumberOfImages()
    {
        return transform_SlotImages.childCount;
    }
    
    // Adds an image as a child of the slot images grid 
    public void AddImageToSlot(Sprite sprite_var_NewSprite)
    {
        GameObject gobj_temp_NewObject = new GameObject();
        Image image_temp_NewImage = gobj_temp_NewObject.AddComponent<Image>();
        image_temp_NewImage.sprite = sprite_var_NewSprite;
        gobj_temp_NewObject.GetComponent<RectTransform>().SetParent(transform_SlotImages);
        gobj_temp_NewObject.SetActive(true);
    }
    
    // Change the slot image to the active state
    public void ChangeSlotSprite(int int_var_SlotIndex, bool bool_var_SetSlotToActive)
    {
        GameObject gobj_temp_SlotRef = transform_Slot.Find("Slot #" + (int_var_SlotIndex).ToString()).gameObject;
        if (gobj_temp_SlotRef != null)
        {
            if (bool_var_SetSlotToActive)
            {
                gobj_temp_SlotRef.GetComponent<Image>().sprite = sprite_ActiveSprite;
            }
            else
            {
                gobj_temp_SlotRef.GetComponent<Image>().sprite = sprite_UnactiveSprite;
            }
        }
    }
    
    // Clear all sprites from the image slot grid and reset the slot images to the unactive state
    public void ResetSlots()
    {
        for (int i = transform_SlotImages.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform_SlotImages.GetChild(i).gameObject);
        }
        transform_SlotImages.DetachChildren();
        
        for (int i = transform_Slot.childCount - 1; i >= 0; i--)
        {
            ChangeSlotSprite(i + 1, false);
        }
    }
}
