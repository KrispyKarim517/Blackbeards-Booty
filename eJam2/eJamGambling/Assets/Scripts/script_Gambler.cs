using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class script_Gambler : MonoBehaviour
{
    [SerializeField] static Sprite sprite_Red_Gem = null;
    [SerializeField] static Sprite sprite_Green_Gem = null;
    [SerializeField] static Sprite sprite_Blue_Gem = null;
    [SerializeField] static Sprite sprite_White_Gem = null;
    [SerializeField] static Sprite sprite_Yellow_Gem = null;
    Dictionary<Color, Sprite> dict_ColorSpriteMap;

    [SerializeField] bool disable_automatic_guess = false;

    static System.Random rand = new System.Random();
    readonly Color[] colors_arr = {
                            Color.white,
                            Color.green,
                            Color.blue,
                            Color.red,
                            Color.yellow
                        };


    public UnityEvent<Tuple<string, Color[]>> BetMadeEvent = new UnityEvent<Tuple<string, Color[]>>();
    //public UnityEvent<Color[]> ClearBoardEvent = new UnityEvent<Color[]>();

    public Color[] most_recent_bet = { };

    public string gambler_name = "";
    bool made_bet = false;
    float time = 0f;
    float wait_time;

    // Start is called before the first frame update
    void Start()
    {
        wait_time = rand.Next(1, 3);

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
        Color[] bet = { colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)] };

        for (int gem = 0; gem < bet.Length; gem++)
        {
            //if dict.containskey(bet[gem])
            //instantiate dict(bet[gem]).value
        }

        most_recent_bet = bet;

        BetMadeEvent.Invoke(new Tuple<string, Color[]>(gambler_name, bet));
    }

    public void NewRound()
    {
        made_bet = false;
        wait_time = rand.Next(1, 3);
    }
}
