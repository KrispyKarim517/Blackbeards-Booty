using UnityEngine;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/7/2020
    
    This script controls the notification that appears above the slots that display gems.
*/

public class script_DifficultyNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI_DifficultyText = null;
    
    private void Start()
    {
        UpdateDifficulty(0);
    }
    
    public void UpdateDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 3:
                TextMeshProUGUI_DifficultyText.text = "RISK LEVEL: AVERAGE";
                break;
            case 4:
                TextMeshProUGUI_DifficultyText.text = "RISK LEVEL: CHANCY";
                break;
            case 5:
                TextMeshProUGUI_DifficultyText.text = "RISK LEVEL: DANGEROUS";
                break;
            default:
                TextMeshProUGUI_DifficultyText.text = "RISK LEVEL: UNKNOWN";
                break;
        }
    }
}
