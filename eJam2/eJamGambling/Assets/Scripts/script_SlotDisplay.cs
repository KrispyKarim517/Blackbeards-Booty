using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_SlotDisplay : MonoBehaviour
{
    [SerializeField] int SlotNumber = 0;
    Image imgComponent;

    void Start()
    {
        imgComponent = this.GetComponent<Image>();
    }

    public void UpdateColor(Color[] args)
    {
        imgComponent.color = args[SlotNumber - 1];
    }

    public void ClearColor()
    {
        Debug.Log(imgComponent.color);
        imgComponent.color = new Color(0f, 0f, 0f, 1f);
        Debug.Log(imgComponent.color);
    }
}
