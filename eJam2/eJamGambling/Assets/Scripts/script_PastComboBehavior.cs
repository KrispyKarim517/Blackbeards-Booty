using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_PastComboBehavior : MonoBehaviour
{
    [SerializeField] Sprite RedGem = null;
    [SerializeField] Sprite BlueGem = null;
    [SerializeField] Sprite GreenGem = null;
    [SerializeField] Sprite PurpleGem = null;
    [SerializeField] Sprite WhiteGem = null;

    [SerializeField] Image Slot_1 = null;
    [SerializeField] Image Slot_2 = null;
    [SerializeField] Image Slot_3 = null;
    [SerializeField] Image Slot_4 = null;
    [SerializeField] Image Slot_5 = null;
    Image[] Slots = null;

    // Start is called before the first frame update
    void Awake()
    {
        Slots = new Image[] { Slot_1, Slot_2, Slot_3, Slot_4, Slot_5 };
    }

    public void SetSlotsGems(Sprite[] gems)
    {
        for (int i = 0; i < gems.Length; ++i)
        {
            Slots[i].sprite = gems[i];
        }
    }

}
