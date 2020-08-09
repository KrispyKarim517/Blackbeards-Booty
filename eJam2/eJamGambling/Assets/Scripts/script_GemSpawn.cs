using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class script_GemSpawn : MonoBehaviour
{
    [Header("Slots To Spawn Gems")]
    [SerializeField] SpriteRenderer slot1;
    [SerializeField] SpriteRenderer slot2;
    [SerializeField] SpriteRenderer slot3;
    [SerializeField] SpriteRenderer slot4;
    [SerializeField] SpriteRenderer slot5;

    SpriteRenderer[] slotArray;

    WaitForSecondsRealtime pause = new WaitForSecondsRealtime(0.25f);

    [Header("Event for after gems display")]
    public UnityEvent<Sprite[]> ChestOpened = new UnityEvent<Sprite[]>();

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

    public void ClearGems()
    {
        foreach(var slot in slotArray)
        {
            slot.sprite = null;
        }
    }

    public void SpawnGems(Sprite[] arrSprites)
    {

        StartCoroutine(SequentialSpawn(arrSprites));        
    }

    private IEnumerator SequentialSpawn(Sprite[] arrSprites)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        for (int i = 0; i < slotArray.Length; i++)
        {
            slotArray[i].sprite = arrSprites[i];
            yield return new WaitForSecondsRealtime(0.5f);
        }
        ChestOpened.Invoke(arrSprites);
    }
}
