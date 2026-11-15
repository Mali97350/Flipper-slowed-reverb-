using UnityEngine;
using TMPro;
public class TextFade : MonoBehaviour
{
    public TMP_Text texte; 
    public float fadeDelay = 0.4f;    // secondes avant que sa fade
    public float fadeDuration = 0.6f; // durée du fade
    private bool fading;
    private float fadeTimer;
    public void clické() /// c'est sa qui summon tout zeubi le rename pas pitié
    {
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
        Color c = texte.color;
        c.a = 1-t;                           
        texte.color = c;
        if (t >= 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
