using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoffeeTable : MonoBehaviour
{
    
    [SerializeField] Canvas coffeeTableCanvas;

    public bool isClicked = false;
    public bool isActivated = false;
    public Texture2D interactableCursor;
    public Texture2D myCursor;
    public GameObject player;


    void Start()
    {
        coffeeTableCanvas.enabled = false;
        player = GameObject.FindWithTag("Player");
    }

    private void OnMouseDown() 
    {
        isClicked = true;
                
    }

    public void OnTriggerEnter2D()
    {
        if(isClicked == true && !isActivated)
        {
            isClicked = false;
            Debug.Log("Player is engaging with the Coffee Table");
            coffeeTableCanvas.enabled = true;
            isActivated = true;
        }
        else return; 
    }

    public void OnTriggerStay2D()
    {
        if(isClicked == true && !isActivated)
        {
            isClicked = false;
            Debug.Log("Player is engaging with the Coffee Table");
            coffeeTableCanvas.enabled = true;
            isActivated = true;
        }
        else return; 

    }

    public void CloseCoffeeTable()
    {
        isClicked = false;
        coffeeTableCanvas.enabled = false;
        isActivated = false;
    }

    public void OnMouseOver()
    {
        if (coffeeTableCanvas.enabled == false)
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
