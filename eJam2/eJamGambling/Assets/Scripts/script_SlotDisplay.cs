using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_SlotDisplay : MonoBehaviour
{
    Image img;

    private void Awake()
    {
        img = this.GetComponent<Image>();
    }

    public void UpdateSprite(Sprite sprite)
    {
        img.sprite = sprite;
    }

}
