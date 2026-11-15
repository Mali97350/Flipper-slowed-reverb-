using UnityEngine;

public class BumperBuild : MonoBehaviour
{
    private DragandDropManager manager;
    private bool placed;                // Peut pus être pickup une fois placé
    public ZoneNoBuild zone;
    private Vector3 startPos;
    public string Nomtype;
    public GameObject ResultatMerge;
    public Vector3 force;
    public float strength = 100;
    public Animation animation;
    public int pointsValue = 100;
    void Marquéplaced()
    {
        placed = true;
        zone.gameObject.tag = "NoBuild";
    }

    void Merge(BumperBuild other) ///J'ai du volé ce script de merge, jle comprend pas encore a 100% mais je suis crevé et j'ai une flemme monumental.
    {
        GameObject result = Instantiate(other.ResultatMerge, other.transform.position, other.ResultatMerge.transform.rotation);

        BumperBuild r = result.GetComponent<BumperBuild>();
        r.Init(manager);
        r.Marquéplaced();

        Destroy(other.gameObject);
        Destroy(gameObject);
        manager.BumperPlaced(result);
    }
    public void Init(DragandDropManager m)
    {
        manager = m;
    }

    void OnMouseDrag()                  // Call si tes sur le collider
    {
        if (manager.buildActif!=true) return;
        transform.position = GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        if (manager.buildActif != true) return; /// si build pas actif, exit 

        BumperBuild dessous = zone.BumperEnDessous();

        if (dessous == null)                          // riens dessous
        {
            if (placed)
            {
                transform.position = startPos;        // bumper placé peuvent pas être bouger
                return;
            }

            Marquéplaced();
            manager.BumperPlaced(gameObject);
            return;
        }

        if (dessous.Nomtype == Nomtype && dessous.ResultatMerge != null)
        {
            Merge(dessous);
        }
        else
        {
            transform.position = startPos;
            manager.MessagePopup("Trop Proche!");
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Camera cam = Camera.main;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-cam.transform.forward, transform.position);
        float distance;
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
    
    void OnMouseDown()
    {
        startPos = transform.position;}
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Boule")) return;   
        force = (collision.transform.position - transform.position).normalized * strength;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
        animation.Play("Bumper bump");
        Scoremanager.instance.GainPoint(pointsValue);
    }
}