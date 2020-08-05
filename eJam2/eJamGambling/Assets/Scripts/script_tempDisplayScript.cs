using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_tempDisplayScript : MonoBehaviour
{

    Text text;

    private void Start()
    {
        text = this.GetComponent<Text>();
    }

    public void Clear()
    {
        text.text = "Winners Go Here";
    }
}