using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lifecount = 3; /// A changer vu que le lifecount este obsoléte
    public GameObject BoullePrefab;
    public TextMeshProUGUI LifecountText;
    public TurnManager turnManager;
    private int Ballesenjeu;
    void Start()
    {
        
        RefreshLifeCountText();
    }
    public void Ballesperdu()
    {
        Ballesenjeu--;                      

        if (Ballesenjeu <= 0)            
        {
            turnManager.FinTour();             
        }
    }

       public void SpawnBall()
        {
            if (lifecount>0)
            {
               Balleactive = Instantiate(BoullePrefab);
            }
        }

        void RefreshLifeCountText()
        {
            LifecountText.text = lifecount.ToString();
        }

        private GameObject Balleactive;

        public void Despawnball()
        {
            GameObject[] Boule = GameObject.FindGameObjectsWithTag("Boule");
            foreach (GameObject obj in Boule)
            {
                Destroy(obj);               // blank: the method you used before to remove an object
            }

            Ballesenjeu = 0;             
        }
}
        
           
        

