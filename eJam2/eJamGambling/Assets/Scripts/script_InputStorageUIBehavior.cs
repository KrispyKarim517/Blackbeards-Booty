using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class script_InputStorageUIBehavior : MonoBehaviour
{
    public GameObject GemsParent;
    public script_InputStorage storage;
    public Text nameField;

    [Header("Sprite Images")]
    [SerializeField] Sprite sprite_Red_Gem = null;
    [SerializeField] Sprite sprite_Green_Gem = null;
    [SerializeField] Sprite sprite_Blue_Gem = null;
    [SerializeField] Sprite sprite_White_Gem = null;
    [SerializeField] Sprite sprite_Yellow_Gem = null;
    Dictionary<Sprite, Color> dict_SpriteColorMap;

    Color[] currCode;
    int currIndex;

    void Start()
    {
        ClearCode();
        dict_SpriteColorMap = new Dictionary<Sprite, Color>
            {
                { sprite_Red_Gem, Color.red},
                { sprite_Green_Gem, Color.green },
                { sprite_Blue_Gem, Color.blue },
                { sprite_White_Gem, Color.white },
                { sprite_Yellow_Gem, Color.yellow }
            };
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
            tempCode[count] = currCode[count];
        }

        storage.AddInput(nameField.text, tempCode);
        ClearCode();
    }

    public void GrabCode()
    {
        foreach(var gem in GemsParent.GetComponentsInChildren<Image>().Where(go => go.gameObject.name != "Slot Images"))
        {
            AddColor(dict_SpriteColorMap[gem.sprite]);
        }
        EnterCode();
    }
}
