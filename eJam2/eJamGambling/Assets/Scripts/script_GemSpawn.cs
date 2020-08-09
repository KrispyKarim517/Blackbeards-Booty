using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_GemSpawn : MonoBehaviour
{

    [SerializeField] SpriteRenderer slot1;
    [SerializeField] SpriteRenderer slot2;
    [SerializeField] SpriteRenderer slot3;
    [SerializeField] SpriteRenderer slot4;
    [SerializeField] SpriteRenderer slot5;

    SpriteRenderer[] slotArray;

    // Start is called before the first frame update
    void Start()
    {
        slotArray = new SpriteRenderer[]
            { slot1,
              slot2,
              slot3,
              slot4,
              slot5 };
    }

    public void SpriteArray(Sprite[] arrSprites)
    {
        for (int i = 0; i < slotArray.Length; i++)
        {
            slotArray[i].sprite = arrSprites[i];
        }
    }
}
