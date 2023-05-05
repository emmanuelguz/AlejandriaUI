using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    bool isoverColl;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
            if (gameObject != null && gameObject.transform.position.y < -5)
            {
            
                Destroy(gameObject);
            }
        
    }

    void OnMouseEnter()
    {
        LoseOxy();
        
    }
   

    public void LoseOxy()
    {
        Player.currentOxygen -= 50f;

        if (Player.currentOxygen < 0)
        {
            Player.Lives--;
            Player.currentOxygen = 100;
        }
        //Player.OxyBar.setOxy(Player.currentOxygen);
    }
    public void GainOxy()
    {
        Player.currentOxygen += 0.5f;
        if (Player.currentOxygen > 100)
        {
            Player.currentOxygen = 100;
        }
        //Player.OxyBar.setOxy(Player.currentOxygen);
    }
}
