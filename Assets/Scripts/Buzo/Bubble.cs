using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    
    
    bool isoverColl;
    public OxygenBar OxyBar;
    
    public LayerMask obstaclesLayer;
    

    // Start is called before the first frame update
    void Start()
    {
       
        Player.currentOxygen = Player.maxOxygen;
        OxyBar.setMaxOxy(Player.maxOxygen);
        
        //SetCursor(  );
        
    }

    // Update is called once per frame
    void Update()
    {
        

        OxyBar.setOxy(Player.currentOxygen);
        if (isoverColl)
        {
            GainOxy();
            //Debug.Log("siii");

        }
        else
        {
            //Debug.Log("nooo");
            LoseOxy();
        }
       /* if (Lives == 0)
        {
            Destroy(gameObject);
        }*/

    }
    public void LoseOxy()
    {
        Player.currentOxygen -= 0.1f;
        
        if (Player.currentOxygen < 0)
        {
            Player.Lives--;
            Player.currentOxygen = 100;
        }
        //OxyBar.setOxy(Player.currentOxygen);
    }
    public void GainOxy()
    {
        Player.currentOxygen += 0.5f;
        if (Player.currentOxygen > 100)
        {
            Player.currentOxygen = 100;
        }
        //OxyBar.setOxy(Player.currentOxygen);
    }

    void OnMouseEnter()
    {
        isoverColl = true;
    }
    private void OnMouseExit()
    {
        isoverColl = false;
    }


}
