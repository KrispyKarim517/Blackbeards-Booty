using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_BetAcceptor : MonoBehaviour
{

    List<script_BetRow> ChildRows = new List<script_BetRow>();
    int next_available = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            var child = transform.GetChild(i);
            if (child.tag == "Row")
                ChildRows.Add(child.GetComponent<script_BetRow>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveBet(Tuple<string, Color[]> bet_data)
    {
        ChildRows[next_available++].UpdateRow(bet_data);

        if (next_available == ChildRows.Count)
            next_available = 0;
    }
}
