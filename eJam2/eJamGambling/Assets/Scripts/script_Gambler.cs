using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class script_Gambler : MonoBehaviour
{
    [SerializeField] bool disable_automatic_guess = false;

    static System.Random rand = new System.Random();
    readonly Color[] colors_arr = {
                            new Color(255f, 255f, 255f, 1f),
                            new Color(0f, 255f, 0f, 1f),
                            new Color(0f, 0f, 255f, 1f),
                            new Color(255f, 0f, 255f, 1f),
                            new Color(219f, 170f, 9f, 1f)
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

        most_recent_bet = bet;

        BetMadeEvent.Invoke(new Tuple<string, Color[]>(gambler_name, bet));
    }

    public void NewRound()
    {
        made_bet = false;
        wait_time = rand.Next(1, 3);
        //ClearBoard();
    }
    //public void ClearBoard()
    //{
    //    Color[] result =
    //        {
    //            new Color(0f, 0f, 0f, 1f),
    //            new Color(0f, 0f, 0f, 1f),
    //            new Color(0f, 0f, 0f, 1f),
    //            new Color(0f, 0f, 0f, 1f),
    //            new Color(0f, 0f, 0f, 1f),
    //        };

    //    ClearBoardEvent.Invoke(result);
    //}
}
