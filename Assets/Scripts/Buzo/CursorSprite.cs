using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSprite : MonoBehaviour
{
    public Vector2 spritepos;
    public bool _menu;
    
    void Start()
    {
        Cursor.visible = false;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spritepos = transform.position;
        spritepos.x = pos.x - 1.4f;
        spritepos.y = pos.y - 0.5f;
        transform.position = spritepos;
        _menu = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spritepos = transform.position;
        spritepos.x = pos.x - 1.4f;
        spritepos.y = pos.y - 0.5f;
        transform.position = spritepos;
        if (UIDisplayer.gamePaused)
        {
            transform.position = new Vector2(0, 0);
        }
        else
        {
            transform.position = spritepos;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menu = !_menu;
            //Debug.Log("JOTO");
          //  if (_menu) { GameObject.Find("UIDocument").SetActive(_menu); }
        }
    }
}
