using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
    AUTHOR: Lyndon de la Torre
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/8/2020
    
    This script creates a pop up windows to display winnings
*/

// inital window is 0.5 x 3.5 by scale
public class script_PopUpWindow : MonoBehaviour
{
    // The timer in scene
    [SerializeField] public script_Timer ref_Timer = null;
    // GameObject ResultsDisplay
    [SerializeField] public Canvas ref_resultsDisplay;
    
    // Gameobject Window in Prefab folder
    [SerializeField] public Image ref_window = null;
    // GameObject DisplayWinnerText in Prefab folder (it's just a TMPro text)
    [SerializeField] public TextMeshProUGUI display_winner_text_box = null;

    private Coroutine minimizeRoutine;
    private Coroutine expandRoutine;
    private bool isExpanded = false;

    // imageClone prefab is 
    private Image imageClone = null;
    private TextMeshProUGUI displayClone = null;
    


    [Header("Sprites")]
    [SerializeField] Sprite sprite_Red_Gem = null;
    [SerializeField] Sprite sprite_Green_Gem = null;
    [SerializeField] Sprite sprite_Blue_Gem = null;
    [SerializeField] Sprite sprite_White_Gem = null;
    [SerializeField] Sprite sprite_Yellow_Gem = null;
    Dictionary<Sprite, Color> dict_SpriteColorMap;
    readonly Color[] colors_arr = {
                            Color.white,
                            Color.green,
                            Color.blue,
                            Color.red,
                            Color.yellow
                        };
    // 
    private Color[] winningSequence = null;

    private void Start()
    {
        dict_SpriteColorMap = new Dictionary<Sprite, Color>
            {
                { sprite_Red_Gem, Color.red},
                { sprite_Green_Gem, Color.green },
                { sprite_Blue_Gem, Color.blue },
                { sprite_White_Gem, Color.white },
                { sprite_Yellow_Gem, Color.yellow }
            };
    }

    public void CacheWinners(Sprite[] sprites)
    {
        winningSequence = ConvertSpriteToColor(sprites);
    }


    public void DisplayPopUp() 
    {
        // This instantiates 
        if (ref_Timer.time == 0f && !isExpanded) 
        {
            isExpanded = true;
            imageClone = Instantiate(ref_window, Vector3.zero, Quaternion.identity);
            displayClone = Instantiate(display_winner_text_box, Vector3.zero, Quaternion.identity);

            imageClone.gameObject.transform.parent = ref_resultsDisplay.gameObject.transform;
            displayClone.gameObject.transform.parent = ref_resultsDisplay.gameObject.transform;

            imageClone.gameObject.transform.localPosition = new Vector3(-268.5f, 25f);
            displayClone.gameObject.transform.localPosition = new Vector3(-268.5f, 25f);;

            imageClone.gameObject.transform.localScale = new Vector3(0.5f, 3.5f);
            displayClone.gameObject.transform.localScale = new Vector3(1, 1, 1);

            displayClone.text = "";

            GameManager.instance.display_winner_text_box = displayClone;
            expandRoutine = StartCoroutine(ExpandWindow());
        }
    }
    private IEnumerator ExpandWindow() 
    {
        while(imageClone.transform.localScale.x < 7.5f) 
        {
            imageClone.transform.localScale += new Vector3(1, 0, 0);
            yield return new WaitForSecondsRealtime(0.00000005f);
        }

        // Change this in the final game
        // I only added this to make it work on my test scene
        //Color[] c = new Color[5] {Color.blue, Color.green, Color.red, Color.yellow, Color.white};

        GameManager.instance.DisplayWinners(winningSequence);
        yield return new WaitForSecondsRealtime(3f);
        minimizeRoutine = StartCoroutine(MinimizeWindow());
        StopCoroutine(ExpandWindow());
    }

    private IEnumerator MinimizeWindow()
    {
        while(imageClone.transform.localScale.x > 0.5f) 
        {
            imageClone.transform.localScale -= new Vector3(1, 0, 0);
            yield return new WaitForSecondsRealtime(0.00000005f);
        }

        //ref_Timer.RestartTimer();
        isExpanded = false;
        Destroy(imageClone);
        Destroy(displayClone);
        StopCoroutine(minimizeRoutine);
    }


    private Color[] ConvertSpriteToColor(Sprite[] sprites)
    {
        return new Color[] { dict_SpriteColorMap[sprites[0]],
                              dict_SpriteColorMap[sprites[1]],
                              dict_SpriteColorMap[sprites[2]],
                              dict_SpriteColorMap[sprites[3]],
                              dict_SpriteColorMap[sprites[4]] };
    }
}
