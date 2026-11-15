using UnityEngine;
using TMPro;
public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI bestText;

    void Start()
    {
        bestText.text = "Best round: " + PlayerPrefs.GetInt("PersonalBest", 0).ToString();
    }
}