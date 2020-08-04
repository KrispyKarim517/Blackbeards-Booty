using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class script_BetRow : MonoBehaviour
{

    [SerializeField] Text text = null;

    public UnityEvent<Color[]> UpdateRowEvent = new UnityEvent<Color[]>();
    public UnityEvent ClearRowEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateRow(Tuple<string, Color[]> bet_data)
    {
        text.text = bet_data.Item1;
        UpdateRowEvent.Invoke(bet_data.Item2);
    }

    public void ClearRow()
    {
        text.text = "Place a Bet";
        ClearRowEvent.Invoke();
    }
}
