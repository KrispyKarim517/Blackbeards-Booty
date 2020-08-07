using System.Collections;
using UnityEngine;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/7/2020
    EDIT BY: Karim Najib
    
    This script controls the behavior of timer and displays the time on the display
*/
public class script_Timer : MonoBehaviour
{
    [SerializeField] private float float_NumberOfSeconds = 1800f; // The number of time in seconds. 1800f = 30 minutes.
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI_TimerText = null;
    
    private void Start()
    {
        StartCoroutine(StartTimer());
    }
    
    // Start the timer.
    public IEnumerator StartTimer()
    {
        while (true)
        {
            while (float_NumberOfSeconds > 0)
            {
                float_NumberOfSeconds -= Time.deltaTime;
                UpdateTimer(float_NumberOfSeconds);
                yield return null;
            }
            float_NumberOfSeconds = 1800f;
        }
    }
    
    // Update the timer to display the correct time
    private void UpdateTimer(float float_var_Time)
    {
        float float_temp_Minutes = Mathf.FloorToInt(float_var_Time / 60);
        float float_temp_Seconds = Mathf.FloorToInt(float_var_Time % 60);
        TextMeshProUGUI_TimerText.text = string.Format("{0:00}:{1:00}", float_temp_Minutes, float_temp_Seconds);
    }
}
