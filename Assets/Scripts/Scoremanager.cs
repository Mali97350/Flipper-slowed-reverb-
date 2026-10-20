using TMPro;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{
 public static Scoremanager instance;
 public TextMeshProUGUI scoretext;
 public int score;

 void Awake()
 {
  instance = this;
 }
 
 public void GainPoint(int points)
 {
  score = score + points;
  scoretext.text ="Score: " + score.ToString();
  Debug.Log(score);
 }
}
