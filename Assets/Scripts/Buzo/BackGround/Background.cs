using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Background : MonoBehaviour
{
    public Texture2D[] frames; 
    int fps = 10;
    public Renderer render;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        int index1 = (int)(Time.time * fps) % frames.Length;
        //render = GetComponent<Renderer>();
        //render.material.mainTexture = frames[(int)index];
        GetComponent<RawImage>().texture = frames[index1];
    }
}
