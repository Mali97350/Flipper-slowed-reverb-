using UnityEngine;

public class Conneries : MonoBehaviour


{
    public GameObject Boulleprefab;
    void Update()
    {
        Instantiate(Boulleprefab);
    }
}
