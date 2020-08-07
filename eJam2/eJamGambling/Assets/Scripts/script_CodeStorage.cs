using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_CodeStorage : MonoBehaviour
{
    public int StorageSize = 3;
    List<Color[]> codes = new List<Color[]>();

    public void AddCode(Color[] newCode)
    {
        if(codes.Count == StorageSize)
        {
            codes.RemoveAt(0);
        }
        codes.Add(newCode);
    }

    public List<Color[]> GetCodes()
    {
        return codes;
    }
}
