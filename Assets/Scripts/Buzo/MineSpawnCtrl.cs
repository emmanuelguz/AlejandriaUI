using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawnCtrl : MonoBehaviour
{
    public GameObject mine;
        
    int aux = 0;
    Vector2 spwnPos;
    Vector2 oldpos;
    private float tChange = 0;

    // Start is called before the first frame update
    void Start()
    {
        spwnPos = this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= tChange)
        {
            oldpos = spwnPos;
            spwnPos.x = Random.Range(-5f, 5f);
            if (oldpos.x + 3<= spwnPos.x)
            {
                spwnPos.x += 3;
            }
            if (oldpos.x - 3 >= spwnPos.x)
            {
                spwnPos.x -= 3;
            }
            GameObject obst = Instantiate(mine, spwnPos, Quaternion.identity);            
            tChange = Time.time + Random.Range(0.5f, 1.5f);

            
        }
        
        

    }

    
}
