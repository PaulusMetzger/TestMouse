using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProbe : MonoBehaviour
{
    Transform imageT;
    float x = -4.5f;
    float z = -4.5f;
    public Vector3[] dots=new Vector3[100];
    public Color[] colors = new Color[100];
    int s = 0;
    int p = 0;
    int k = 0;
    public GameObject cube;
    bool a;
    bool b;
    public static bool Tracking = false;
    public GameObject Mouse;
    // Start is called before the first frame update
    void Start()
    {
        Mouse.SetActive(false);
        imageT = GetComponent<Transform>();
        a = false;
        b = true;
        s = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                dots[s] = new Vector3(x, 0, z);
                s++;
                x++;
            }
            z++;
            x = -4.5f;
        }
    }
    void Color()
    {
        p = 0;
        var tex = ScreenCapture.CaptureScreenshotAsTexture();
        for (int i = 0; i <100; i++)
        {
           
            Vector2 pos = Camera.main.WorldToScreenPoint(dots[p]);
            Color color = tex.GetPixel((int)pos.x, (int)pos.y);
            colors[p] = color;
            p++;
            //Debug.Log("Color");
           //Object.Destroy(tex);
        }
    }
    public void Labirint()
    {
        k = 0;
        for (int i = 0; i < 100; i++)
        {
            GameObject c = Instantiate(cube);
            c.transform.position = dots[k];
            c.GetComponent<Renderer>().material.color = colors[k];
            
            if (c.GetComponent<Renderer>().material.color.maxColorComponent >= 0.5f)
            {
                c.transform.localScale = new Vector3(1f, 0.1f, 1f);
                c.GetComponent<Renderer>().material.color = new Color(1f,1f,1f,1f);
                if (Mouse.activeSelf == false)
                {
                    Mouse.transform.SetParent(imageT);
                    Mouse.transform.rotation = Quaternion.identity;
                    Mouse.transform.position = c.transform.position + new Vector3(0f, 1f, 0f);
                    Mouse.SetActive(true);
                }
            }
            else c.transform.localScale = new Vector3(1f, 5f, 1f);
            c.transform.SetParent(imageT);
            k++;
        }
    }
    public void DelLab()
    {
        Mouse.SetActive(false);
        Mouse.transform.SetParent(null);
        if (imageT.GetChild(4) != null)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                Debug.Log(dots.Length);
                Destroy(imageT.GetChild(i+4).gameObject); }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Tracking)
        {
            Color();
           Tracking = false;
        }
    }
   
}
