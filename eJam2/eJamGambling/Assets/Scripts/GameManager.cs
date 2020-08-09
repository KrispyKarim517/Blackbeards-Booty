using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance = null;

    

    [Header("Temporary Text box to print out winners")]
    [SerializeField] public TextMeshProUGUI display_winner_text_box = null;

    [Header("Event for Closing Treasure Chest")]
    public UnityEvent CloseChest = new UnityEvent();
    [Header("Event for Starting a New Round")]
    public UnityEvent NewRound = new UnityEvent();

    [Header("UI Elements to Display Past Combos")]
    [SerializeField] GameObject Row_to_insert = null;
    [SerializeField] GameObject Row_parent = null;

    [Header("Time for each Round")]
    [SerializeField] public float round_time = 10f;
    float time = 0f;

    private Sprite[] winning_set_cache = null;

    bool wait = false;

    [Header("Maximum number of visible previous Combos")]
    [SerializeField] private int max_prev_combos = 0;
    int num_prev_combos = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        NewRound.AddListener(WipeWinners);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > round_time)
        {
            if (!wait)
            {
                StartCoroutine(StartRoundAfterChestClose());
                wait = true;
            }
        }

    }

    public void CacheWinningSet(Sprite[] set)
    {
        winning_set_cache = set;
    }

    public void DisplayWinners(Color[] colors)
    {
        var winners = script_InputStorage.instance.CheckWins(colors);

        //var winners = new Dictionary<string, int> { { "Joe", 1 },
          //                                          { "Ryan", 2 },
            //                                        { "Karim", 3 },
              //                                      { "Lyndyn", 4},
                //                                    { "Nichole", 5} };

        display_winner_text_box.text = "";
        if (winners.Count != 0)
        {
            foreach (var winner in winners)
            {
                display_winner_text_box.text += winner.Key + " won a Tier " + winner.Value.ToString() + " prize!\n";
            }
        }
        else
        {
            display_winner_text_box.text = "No Winners";
        }
    }

    public void AddPastCombo()
    {
        if (num_prev_combos >= max_prev_combos)
        {
            Destroy(Row_parent.GetComponentsInChildren<script_PastComboBehavior>()[0].gameObject);
        }

        script_PastComboBehavior row = Instantiate(Row_to_insert, Row_parent.transform).GetComponent<script_PastComboBehavior>();

        row.SetSlotsGems(winning_set_cache);

        ++num_prev_combos;
    }

    public void WipeWinners()
    {
        display_winner_text_box.text = "";
    }

    private IEnumerator StartRoundAfterChestClose()
    {
        CloseChest.Invoke();
        yield return new WaitForSecondsRealtime(1f);
        AddPastCombo();
        NewRound.Invoke();
        time = 0f;
        wait = false;
        yield return null;
    }

}
