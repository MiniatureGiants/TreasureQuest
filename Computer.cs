using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite computerOnSprite;
    [SerializeField] Canvas computerCanvas;
    [SerializeField] PlayerController player;
    public bool computerOn = false;
    public bool isClicked = false;
    public PowerButton powerButton;

    public Texture2D interactableCursor;
    public Texture2D myCursor;

    void Start()
    {
        computerCanvas.enabled = false;
        player = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        powerButton = FindObjectOfType<PowerButton>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPower();
    
    }

    public void CheckForPower()
    {
        if (powerButton.powerIsOn == true)
        {
            spriteRenderer.sprite = computerOnSprite;
            computerOn = true;
        }
        else return;
    }

    private void OnMouseDown() 
    {
        isClicked = true;
        
    }

    public void OnTriggerEnter2D()
    {
        if(isClicked == true && computerOn == true )
        {
            isClicked = false;
            Debug.Log("Player is engaging with the Computer");
            computerCanvas.enabled = true;
        }
        else if (isClicked == true && !computerOn)
        {
            isClicked = false;
            player.DisplayText("Hmm. There's no power.");
        } 
    }

    public void OnTriggerStay2D(Collider2D other) 
    {
        if(isClicked == true && computerOn == true )
        {
            isClicked = false;
            Debug.Log("Player is engaging with the Computer");
            computerCanvas.enabled = true;
        }
        else if (isClicked == true && !computerOn)
        {
            player.DisplayText("Hmm. There's no power.");
        } 
       //I set this code up so I could get the isclicked bool back to false. What was happening was the canvas was NOT opening up if I was in the trigger collider. So
       //I needed to run the 'isClicked' check again, and if still in the collider, the canvas opens. This seems to work reliably well. 
    }

    public void OnTriggerExit2D(Collider2D other) 
    {
        isClicked = false;
    }

    public void OnMouseOver()
    {
        if (computerCanvas.enabled == false)
        {
        Cursor.SetCursor(interactableCursor, Vector2.zero, CursorMode.Auto);
        }
        else Cursor.SetCursor(myCursor, Vector2.zero, CursorMode.Auto);
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(myCursor, Vector2.zero, CursorMode.Auto);
    }



}
