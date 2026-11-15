using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Scoremanager : MonoBehaviour
{
 public static Scoremanager instance;
 public TextMeshProUGUI scoretext;
 public TextMeshProUGUI scoretarget;
 public TextMeshProUGUI roundtext;
 public int score;
public int pointtarget;
 public int rounds;
 public float climbspeed = 300f;
 private float displayedscore;
 void Awake()
 {
  instance = this;
 }
 
 public void GainPoint(int points)
 {
  score = score + points;
  Debug.Log(score);
 }
 
 public void ResetPoints()
 {
  score = 0;
  RefreshUI();
  displayedscore = 0;
 }
 public void RefreshUI()
 {
  scoretarget.text = "Target: " + pointtarget.ToString();
  roundtext.text = "Rounds: " + rounds.ToString();
 }

 private void Update()///utilisé pour le text ballatro style
 {
  float gap = score - displayedscore;
  float speed = Mathf.Max(climbspeed, gap * 3f);
  displayedscore = Mathf.MoveTowards(displayedscore, score, speed * Time.unscaledDeltaTime);
  scoretext.text = "Score: " + Mathf.RoundToInt(displayedscore).ToString();
 }
}
