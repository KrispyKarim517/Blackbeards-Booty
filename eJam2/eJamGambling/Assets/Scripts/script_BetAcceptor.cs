using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_BetAcceptor : MonoBehaviour
{
    [SerializeField] script_BetRow gobj_row1 = null;
    [SerializeField] script_BetRow gobj_row2 = null;
    [SerializeField] script_BetRow gobj_row3 = null;

    [SerializeField] script_InputStorage ref_BetStoarge = null;
    List<script_BetRow> ChildRows = new List<script_BetRow>();
    int next_available = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChildRows.Add(gobj_row1);
        ChildRows.Add(gobj_row2);
        ChildRows.Add(gobj_row3);

    }

    public void RecieveBet(Tuple<string, Color[]> bet_data)
    {
        ChildRows[next_available++].UpdateRow(bet_data);

        ref_BetStoarge.AddInput(bet_data.Item1, bet_data.Item2);

        if (next_available == ChildRows.Count)
            next_available = 0;
    }
}
