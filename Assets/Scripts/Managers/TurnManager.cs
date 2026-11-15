using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnManager : MonoBehaviour
{
    public float DuréeTour = 30f;
    private float TempRestant;
    private bool Touractif;
    public GameManager gameManager;
    public GameObject buildPanel;
    public DragandDropManager dragandDropManager;
    public GameObject defeatPanel;
    
    void Start()
    {
        StartTour();
    }

    public void StartTour()
    {
        TempRestant = DuréeTour;
        Touractif = true;
        buildPanel.SetActive(false);
        Debug.Log("Start tour, jeu");
        gameManager.SpawnBall();
        Scoremanager.instance.ResetPoints();
    }
    public void FinTour()
    { if (!Touractif) return;    
        Touractif = false;
        gameManager.Despawnball();
        if (Scoremanager.instance.score<Scoremanager.instance.pointtarget)/// b score < target
        {
            Defaite();
            return;    /// stop, pas de phase build 
        }
        Scoremanager.instance.rounds++;
        Scoremanager.instance.pointtarget = Mathf.RoundToInt(Scoremanager.instance.pointtarget * 1.5f);
        buildPanel.SetActive(true);
        dragandDropManager.StartBuildPhase();
        Debug.Log("Fin de tour, phase build");
        Debug.Log("FinTour called. Time left: " + TempRestant + " / Score: " + Scoremanager.instance.score);
    }
    void Update()
    {
        if (Touractif)
        { TempRestant = TempRestant - Time.deltaTime;
            if (TempRestant < 0)
            { FinTour();
            }
        }
    }
    
    void Defaite()
    {
        if (Scoremanager.instance.rounds > PlayerPrefs.GetInt("PersonalBest", 0))
        {
            PlayerPrefs.SetInt("PersonalBest",Scoremanager.instance.rounds );
        }
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
    }
}