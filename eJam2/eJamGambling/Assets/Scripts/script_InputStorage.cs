using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_InputStorage : MonoBehaviour
{
    //Dictionary of inputs
    Dictionary<string, Color[]> dict_inputs;

    //Adds an input for the given name and code, returns true if successfully added, false if name already exists or invalid name
    public bool AddInput(string name, Color[] code)
    {
        try
        {
            dict_inputs.Add(name, code);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //Returns true if successfully removed, false if name is not in input list
    public bool RemoveInput(string name)
    {
        return dict_inputs.Remove(name);
    }

    //Clears the list of inputs
    public void ClearInputs()
    {
        dict_inputs.Clear();
    }

    //returns a list of strings containing winning names for a given code, empty list means no winners
    public List<string> CheckWins(Color[] code)
    {
        List<string> winners = new List<string>();

        if(dict_inputs.ContainsValue(code))
        {
            foreach(var entry in dict_inputs)
            {
                if(entry.Value.Equals(code))
                {
                    winners.Add(entry.Key);
                }
            }
        }

        return winners;
    }
}
