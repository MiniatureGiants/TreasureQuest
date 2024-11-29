using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerbox : MonoBehaviour
{
    [SerializeField] Canvas powerCanvas;
    public SpriteRenderer spriteRenderer;
    public bool isClicked = false;
    public bool isActivated = false;
    public bool isSolved = false;
    public Texture2D interactableCursor;
    public Texture2D myCursor;

    public GameObject player;

    void Start()
    {
        powerCanvas.enabled = false;
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown() 
    {
        isClicked = true;
        
    }

    public void OnTriggerEnter2D()
    {
        if(isClicked == true && !isActivated && !isSolved)
        {
            isClicked = false;
            Debug.Log("Player is engaging with the Power Box");
            powerCanvas.enabled = true;
            isActivated = true;
        }
        else return; 
    }

    public void OnTriggerStay2D(Collider2D other) 
    {
        if(isClicked == true && !isActivated && !isSolved)
        {
            isClicked = false;
            Debug.Log("Player is engaging with the Power Box");
            powerCanvas.enabled = true;
            isActivated = true;
        }
        else return; 
    }

    public void OnMouseOver()
    { 
       if (!isSolved)
       {
       Cursor.SetCursor(interactableCursor, Vector2.zero, CursorMode.Auto);  
       }    
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(myCursor, Vector2.zero, CursorMode.Auto);
    }

}
