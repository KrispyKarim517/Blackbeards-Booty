using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class script_BetRow : MonoBehaviour
{

    [SerializeField] Text text = null;

    public UnityEvent<Color[]> UpdateRowEvent = new UnityEvent<Color[]>();

    List<script_SlotDisplay> list_slots;

    void Start()
    {
        list_slots = this.GetComponentsInChildren<script_SlotDisplay>().ToList();    
    }

    public void UpdateRow(Tuple<string, Color[]> bet_data)
    {
        text.text = bet_data.Item1;
        UpdateRowEvent.Invoke(bet_data.Item2);
    }

    public void ClearRow()
    {
        Debug.Log(text.text);
        text.text = "Place a Bet";

        foreach(var slot in list_slots)
        {
            //slot.ClearColor();
        }
        Debug.Log("");
    }
}
