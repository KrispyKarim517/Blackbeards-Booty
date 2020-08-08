using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] script_InputStorage ref_BetHolder = null;

    [SerializeField] Text display_winner_text_box = null;


    [SerializeField] script_Gambler ref_Winner = null;
    [SerializeField] script_Gambler ref_g1 = null;
    [SerializeField] script_Gambler ref_g2 = null;
    [SerializeField] script_Gambler ref_g3 = null;
    List<script_Gambler> list_gamblers = new List<script_Gambler>();

    public UnityEvent NewRound = new UnityEvent();


    [SerializeField] GameObject Row_to_insert = null;
    [SerializeField] GameObject Row_parent = null;

    [SerializeField] Sprite TEMP = null;

    float time = 0f;
    bool bool_wait = false;

    void Start()
    {
        //list_gamblers.Add(ref_g1);
        //list_gamblers.Add(ref_g2);
        //list_gamblers.Add(ref_g3);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 8f)
        {
            //NewRound.Invoke();
            //time = 0f;
            //bool_wait = false;
        }

        else if (time > 5f)
        {
            if (!bool_wait)
            {
                //ref_Winner.MakeBet();
                //DisplayWinners(ref_BetHolder.CheckWins(ref_Winner.most_recent_bet));
                bool_wait = true;
            }
        }
    }


    void DisplayWinners(Dictionary<string, int> winners)
    {
        foreach(var winner in winners)
        {
            display_winner_text_box.text = "";
            display_winner_text_box.text += winner.Key + "won a Tier " + winner.Value.ToString() + " prize!\n";
        }
    }

    void AddPastCombo()
    {
        script_PastComboBehavior row = Instantiate(Row_to_insert, Row_parent.transform).GetComponent<script_PastComboBehavior>();

        if (row == null)
            Debug.Log("Row is null");
        else
            row.SetSlotsGems(new Sprite[] { TEMP, TEMP, TEMP, TEMP, TEMP });
    }
}
