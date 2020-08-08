using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class script_WinGenerator : MonoBehaviour
{
    [SerializeField] Sprite sprite_Red_Gem = null;
    [SerializeField] Sprite sprite_Green_Gem = null;
    [SerializeField] Sprite sprite_Blue_Gem = null;
    [SerializeField] Sprite sprite_White_Gem = null;
    [SerializeField] Sprite sprite_Yellow_Gem = null;
    Dictionary<Color, Sprite> dict_ColorSpriteMap;

    [SerializeField] bool disable_automatic_guess = false;

    [SerializeField] GameObject spawnPosition;

    static System.Random rand = new System.Random();
    readonly Color[] colors_arr = {
                            Color.white,
                            Color.green,
                            Color.blue,
                            Color.red,
                            Color.yellow
                        };


    public UnityEvent<Sprite[]> WinningSetPicked = new UnityEvent<Sprite[]>();

    public Color[] most_recent_bet = { };

    bool made_bet = false;
    float time = 0f;
    
    [Header("Time until a roll")]
    public float wait_time = 5f;

    // Start is called before the first frame update
    void Start()
    {
        wait_time += 1f;
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
        if (((time += Time.deltaTime) > wait_time) && !disable_automatic_guess)
        {
            if (!made_bet)
            {
                MakeBet();
                made_bet = true;
            }
        }
    }

    public void MakeBet()
    {
        Color[] bet = { colors_arr[rand.Next(0, 5)],
                        colors_arr[rand.Next(0, 5)],
                        colors_arr[rand.Next(0, 5)],
                        colors_arr[rand.Next(0, 5)],
                        colors_arr[rand.Next(0, 5)] };

        most_recent_bet = bet;

        WinningSetPicked.Invoke(ConvertColorToSprite(bet));

        GameManager.instance.DisplayWinners(bet);
    }

    public void NewRound()
    {
        made_bet = false;
        time = 0f;
    }

    private Sprite[] ConvertColorToSprite(Color[] colors)
    {
        return new Sprite[] { dict_ColorSpriteMap[colors[0]],
                              dict_ColorSpriteMap[colors[1]],
                              dict_ColorSpriteMap[colors[2]],
                              dict_ColorSpriteMap[colors[3]],
                              dict_ColorSpriteMap[colors[4]] };
    }
}
