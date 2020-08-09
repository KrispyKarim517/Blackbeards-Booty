using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_InputStorage : MonoBehaviour
{
    public static script_InputStorage instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }


    }


    //Dictionary of inputs
    Dictionary<string, Color[]> dict_inputs = new Dictionary<string, Color[]>();

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

    //returns a dict with keys being strings containing winning names for a given code and values of the tier of prize they won (1-6), empty list means no winners
    public Dictionary<string, int> CheckWins(Color[] code)
    {
        Dictionary<string, int> winners = new Dictionary<string, int>();

        foreach(var entry in dict_inputs)
        {
            int score = CheckWinForGivenCode(entry.Value, code);
            if(score != 0)
            {
                winners.Add(entry.Key, score);
            }
        }

        return winners;
    }

    private int CheckWinForGivenCode(Color[] entry, Color[] code)
    {
        int score = 0;
        int correctColors = 0;

        for(int count = 0; count < entry.Length; ++count)
        {
            if(entry[count].Equals(code[count]))
            {
                ++correctColors;
            }
        }
        if(correctColors == entry.Length)
        {
            if(entry.Length == 3)
                score = 2;
            else if(entry.Length == 4)
                score = 4;
            else if(entry.Length == 5)
                score = 6;
            
            return score;
        }

        correctColors = 0;
        List<int> indexBlacklist = new List<int>();
        for(int count = 0; count < entry.Length; ++count)
        {
            for(int i = 0; i < entry.Length; ++i)
            {
                if(!indexBlacklist.Contains(i) && entry[count].Equals(code[i]))
                {
                    indexBlacklist.Add(i);
                    ++correctColors;
                    break;
                }
            }
        }
        if(correctColors == entry.Length)
        {
            if(entry.Length == 3)
                score = 1;
            else if(entry.Length == 4)
                score = 3;
            else if(entry.Length == 5)
                score = 5;
            
            return score;
        }

        return score;
    }


    //Temp Function for being Cheeky
    public Dictionary<string, Color[]> GetBets()
    {
        return dict_inputs;
    }
}
