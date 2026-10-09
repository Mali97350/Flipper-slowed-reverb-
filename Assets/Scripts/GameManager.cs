using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lifecount = 3;
    public GameObject BoullePrefab;
    public TextMeshProUGUI LifecountText;
    void Start()
    {
        SpawnBall();
        RefreshLifeCountText();
    }
    public void LoseLife()
       
    {
            Debug.Log("Lose life");
            lifecount = lifecount-1;
            Debug.Log(lifecount);
            SpawnBall();
    }

        void SpawnBall()
        {
            if (lifecount>0)
            {
                Instantiate(BoullePrefab);
            }
        }

        void RefreshLifeCountText()
        {
            LifecountText.text = lifecount.ToString();
        }
}
