using UnityEngine;
using UnityEngine.UI;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/3/2020
    
    This script detects whether the drop down menu has been activated
    and performs an effect.
*/
public class script_DetectDropDown : MonoBehaviour
{
    [SerializeField] private Transform transform_SlotTransform = null;
    [SerializeField] private Transform transform_Arrow = null;
    private bool bool_MenuActivated = false;
    
    private void Start()
    {
        
    }
    
    /*
        When the drop-down menu is activated, Unity adds a child to the 
        drop-down object (the child representing the drop-down list).
        To detect whether the drop down menu has been activated, the Update 
        function will check how many children are attached to the menu.
    */
    private void Update()
    {
        if (!bool_MenuActivated && transform_SlotTransform.childCount > 3)
        {
            transform_Arrow.rotation *= Quaternion.Euler(0f, 0f, 180f);
            bool_MenuActivated = true;
        }
    }
    
    public void FlipArrow()
    {
        transform_Arrow.rotation *= Quaternion.Euler(0f, 0f, 180f * 0f);
        bool_MenuActivated = false;
    }
}
