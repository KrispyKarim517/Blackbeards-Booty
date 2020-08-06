using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_InputStorageUIBehavior : MonoBehaviour
{
    public script_InputStorage storage;
    public Text nameField;

    Color[] currCode;
    int currIndex;

    void Start()
    {
        ClearCode();
    }

    //Adds given color to the code
    public void AddColor(Color temp_color)
    {
        currCode[currIndex] = temp_color;
        ++currIndex;
    }

    public void ClearCode()
    {
        currCode = new Color[5];
        currIndex = 0;
    }

    public void EnterCode()
    {
        Color[] tempCode = new Color[currIndex];
        for(int count = 0; count < currIndex; ++count)
        {
            tempCode[0] = currCode[0];
        }

        storage.AddInput(nameField.text, tempCode);
        ClearCode();
    }
}
