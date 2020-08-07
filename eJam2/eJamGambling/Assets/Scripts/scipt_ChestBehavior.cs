using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class scipt_ChestBehavior : MonoBehaviour
{
    [SerializeField] static Sprite sprite_Red_Gem = null;
    [SerializeField] static Sprite sprite_Green_Gem = null;
    [SerializeField] static Sprite sprite_Blue_Gem = null;
    [SerializeField] static Sprite sprite_White_Gem = null;
    [SerializeField] static Sprite sprite_Yellow_Gem = null;


    Dictionary<Color, Sprite> dict_ColorSpriteMap;

    // Start is called before the first frame update
    void Start()
    {
      dict_ColorSpriteMap = new Dictionary<Color, Sprite>
            {
                { Color.red, sprite_Red_Gem},
                { Color.green, sprite_Green_Gem },
                { Color.blue, sprite_Blue_Gem },
                { Color.white, sprite_White_Gem },
                { Color.yellow, sprite_Yellow_Gem }
            };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
