using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragandDropManager : MonoBehaviour
{
    public TurnManager turnManager;
     public GameObject[] bumperPossibles;     // Listes des 3 bumper possibles
    public Transform[] spawnPoints;        // 3 empty qui servent a indiqué la pos des prefab
    public bool buildActif;
    private List<GameObject> créecetour = new List<GameObject>();   

    public void StartBuildPhase()
    {
        buildActif = true;
        for (int i = 0; i < bumperPossibles.Length; i++)
        {
            GameObject b = Instantiate(bumperPossibles[i], spawnPoints[i].position, bumperPossibles[i].transform.rotation);/// trop biens j'ai du refaire la ligne 15 fois 
            b.GetComponent<BumperBuild>().Init(this);   // ref le bumper
            créecetour.Add(b);
        }
    }

    public void BumperPlaced(GameObject placed)
    {
        buildActif = false;
        foreach (GameObject b in créecetour)
        {
            if (b != placed)
            {
                Destroy(b);       // si bumper pas choisi, il ce suicide
            }
        }
        créecetour.Clear();
        turnManager.StartTour();
    }
    
    public TMP_Text messageText;

    public void MessagePopup(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        Invoke("MessageDepop", 2f);
    }

    void MessageDepop()
    {
        messageText.gameObject.SetActive(false);
    }
}