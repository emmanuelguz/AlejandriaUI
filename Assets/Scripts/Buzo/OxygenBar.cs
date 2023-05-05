using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider bar;
    public void setMaxOxy(float val)
    {
        bar.maxValue = val;
        bar.value = val;
    }
    public void setOxy(float val) { bar.value = val; }
    
}
