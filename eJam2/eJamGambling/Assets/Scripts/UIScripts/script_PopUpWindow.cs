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

    private void Update() 
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
        Color[] c = new Color[5] {Color.blue, Color.green, Color.red, Color.yellow, Color.white};

        GameManager.instance.DisplayWinners(c);
        yield return new WaitForSecondsRealtime(5f);
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

        ref_Timer.RestartTimer();
        isExpanded = false;
        Destroy(imageClone);
        Destroy(displayClone);
        StopCoroutine(minimizeRoutine);
    }
}
