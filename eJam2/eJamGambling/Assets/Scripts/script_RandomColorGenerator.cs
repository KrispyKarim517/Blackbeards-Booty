using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class script_RandomColorGenerator : MonoBehaviour 
{
    static System.Random rand;
    readonly Color[] colors_arr = 
                                {
                                    new Color(255f, 255f, 255f, 1f),
                                    new Color(0f, 255f, 0f, 1f),
                                    new Color(0f, 0f, 255f, 1f),
                                    new Color(255f, 0f, 255f, 1f),
                                    new Color(219f, 170f, 9f, 1f)
                                };

    public UnityEvent<Color[]> WinnerGeneratedEvent = new UnityEvent<Color[]>();
    public UnityEvent<Color[]> ClearBoardEvent = new UnityEvent<Color[]>();

    Color[] winning_set;
    [SerializeField] Text display_winner_text_box = null;

    [SerializeField] script_Gambler g1 = null;
    [SerializeField] script_Gambler g2 = null;
    [SerializeField] script_Gambler g3 = null;

    List<script_Gambler> gamblers = new List<script_Gambler>();

    List<script_Gambler> winners = new List<script_Gambler>();

    float time = 0f;
    bool can_clear = false;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        gamblers.Add(g1);
        gamblers.Add(g2);
        gamblers.Add(g3);
    }

    void Update()
    {
        if ((time += Time.deltaTime) > 3f)
        {
            GenerateWinnngSet();
            time = 0f;
            can_clear = true;

            HashSet<Color> unordered_winner = new HashSet<Color>(winning_set);

            foreach(script_Gambler gambler in gamblers)
            {
                if (unordered_winner.Equals(new HashSet<Color>(gambler.most_recent_bet)))
                {
                    if (winning_set.Equals(gambler.most_recent_bet))
                    {
                        display_winner_text_box.text += "JACKPOT WINNER: " + gambler.gambler_name + "\n";
                    }
                    else
                    {
                        display_winner_text_box.text += "WINNER: " + gambler.gambler_name + "\n";
                    }

                    winners.Add(gambler);
                }
            }
            if (winners.Count == 0)
            {
                display_winner_text_box.text = "No winners";
            }
        }
        else if ((time += Time.deltaTime) > 2.5f)
        {
            if (can_clear)
            {
                ClearBoard();
                can_clear = false;
            }
        }
    }


    public void GenerateWinnngSet()
    {
        Color[] result = { colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)], colors_arr[rand.Next(0, 5)] };

        winning_set = result;

        WinnerGeneratedEvent.Invoke(result);
    }

    public void ClearBoard()
    {
        Color[] result =
            {
                new Color(0f, 0f, 0f, 1f),
                new Color(0f, 0f, 0f, 1f),
                new Color(0f, 0f, 0f, 1f),
                new Color(0f, 0f, 0f, 1f),
                new Color(0f, 0f, 0f, 1f),
            };

        display_winner_text_box.text = "Winners Go Here";
        winners.Clear();
        ClearBoardEvent.Invoke(result);
    }
}
