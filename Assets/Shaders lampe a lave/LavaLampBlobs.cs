using UnityEngine;
using UnityEngine.UI;
public class LavaLampBlobs : MonoBehaviour
{
    public int count = 24;                  // max 32 (the shader's array size)
    public float speed = 0.15f;

    private Material mat;
    private Vector4[] blobs = new Vector4[32];    // x, y = position, z = radius
    private Vector4[] colors = new Vector4[32];
    private float[] phaseX = new float[32];
    private float[] phaseY = new float[32];
    private float[] rate = new float[32];

    void Start()
    {
        mat = GetComponent<RawImage>().material;

        for (int i = 0; i < 32; i++)
        {
            phaseX[i] = Random.Range(0f, 10f);
            phaseY[i] = Random.Range(0f, 10f);
            rate[i] = Random.Range(0.5f, 1.5f);
            blobs[i].z = Random.Range(0.1f, 0.5f);                              // radius
            colors[i] = Color.HSVToRGB(Random.value, 0.8f, 1f);                   // random hue
        }
    }

    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            float t = Time.time * speed * rate[i];
            blobs[i].x = 0.5f + 0.4f * Mathf.Sin(t + phaseX[i]);
            blobs[i].y = 0.5f + 0.45f * Mathf.Sin(t * 0.7f + phaseY[i]);
        }

        mat.SetVectorArray("_Blobs", blobs);       // send positions to the shader
        mat.SetVectorArray("_Colors", colors);
        mat.SetInt("_Count", count);
        mat.SetFloat("_Aspect", (float)Screen.width / Screen.height);
    }
}