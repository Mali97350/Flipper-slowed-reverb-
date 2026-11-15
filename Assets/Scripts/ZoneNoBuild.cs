using UnityEngine;
using UnityEngine.Serialization;

public class ZoneNoBuild : MonoBehaviour
{
    [FormerlySerializedAs("radius")] public float taille = 1.5f;     // Taille de la zone <3

    public BumperBuild BumperEnDessous()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, taille);
        foreach (Collider c in hits)
        {
            if (c.transform.root == transform.root) continue;   // Ignore son propre bumper sinon sa merde
            if (c.CompareTag("NoBuild"))
            { return c.GetComponentInParent<BumperBuild>();
            }
        }

        return null;    // ya rien dessous
    }

    void OnDrawGizmosSelected()     // crée une zone dans la scéne quand sélectionné
    {
        Gizmos.DrawWireSphere(transform.position, taille);
    }
}