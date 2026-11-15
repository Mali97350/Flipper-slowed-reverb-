using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Framechangesprite : MonoBehaviour
{
     public Image spritedefault;          // met le sprite de base
    public Sprite spriteaprés;      // le verre cassé
    public float fadeDelay = 0.4f;    // secondes avant que sa fade
    public float fadeDuration = 0.6f; // durée du fade

    private bool fading;
    private float fadeTimer;

    public void clické() /// c'est sa qui summon tout zeubi le rename pas pitié
    {
        spritedefault.sprite = spriteaprés;               
        Invoke("Fade", fadeDelay);              
    }
    void Fade()
    {
        fading = true;
    }

    void Update()
    { if (!fading) return;
        fadeTimer += Time.deltaTime; 
        float t = fadeTimer / fadeDuration;       
        Color c = spritedefault.color;
        c.a = 1-t;                           
        spritedefault.color = c;
        if (t >= 1f)
        {
            gameObject.SetActive(false);
        }
    }
}