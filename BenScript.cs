using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenScript : MonoBehaviour
{
    [SerializeField] Canvas benCanvas;
    public bool benIsClicked = false;
    public bool benIsActivated = false;
    public Texture2D interactableCursor;
    public Texture2D myCursor;
    
    public GameObject player;

    void Start()
    {
        benCanvas.enabled = false;
        player = GameObject.FindWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown() 
    {
        benIsClicked = true;
        
    }

    public void OnTriggerEnter2D()
    {
        if(benIsClicked == true && !benIsActivated)
        {
            benIsClicked = false;
            Debug.Log("Player is engaging with the Ben Franklin Picture");
            benCanvas.enabled = true;
            benIsActivated = true;
        }
        else return; 
    }

    public void OnTriggerStay2D()
    {
        if(benIsClicked == true && !benIsActivated)
        {
            benIsClicked = false;
            Debug.Log("Player is engaging with the Ben Franklin Picture");
            benCanvas.enabled = true;
            benIsActivated = true;
        }
        else return; 

    }

    public void CloseBenPainting()
    {
        benIsClicked = false;
        benCanvas.enabled = false;
        benIsActivated = false;
    }

    public void OnMouseOver()
    {
        if (benCanvas.enabled == false)
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
