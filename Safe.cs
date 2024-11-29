using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] Canvas safeCanvas;
    SpriteRenderer spriteRenderer;
    public bool safeIsClicked = false;
    public bool safeIsActivated = false;
    public bool safeIsUnlocked = false;
    public bool safeIsFull = true;
    public bool safepuzzleSolved = false;
    public Texture2D interactableCursor;
    public Texture2D myCursor;
    [SerializeField] Sprite safeFull;
    [SerializeField] Sprite safeEmpty;
    [SerializeField] AudioSource puzzleSolved;

    PlayerController player;

    void Start()
    {
        safeCanvas.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSafeIsOpen();   
    }

     private void OnMouseDown() 
    {
        safeIsClicked = true;
        
    }

    public void OnTriggerEnter2D()
    {
        if(safeIsClicked == true && !safeIsActivated)
        {
            safeIsClicked = false;
            safeCanvas.enabled = true;
            safeIsActivated = true;
        }
        else if (safeIsClicked == true && safeIsUnlocked == true && safepuzzleSolved == false)  
        {
            safepuzzleSolved = true;
            spriteRenderer.sprite = safeEmpty;
            puzzleSolved.Play();
            player.playerHasKey = true;
            player.AddToScore(30);
        }
    }

    public void OnTriggerStay2D()
    {
        if(safeIsClicked == true && !safeIsActivated)
        {
            safeIsClicked = false;
            safeCanvas.enabled = true;
            safeIsActivated = true;
        }
        else if (safeIsClicked == true && safeIsUnlocked == true && safepuzzleSolved == false) 
        {
            safepuzzleSolved = true;
            spriteRenderer.sprite = safeEmpty;
            puzzleSolved.Play();
            player.playerHasKey = true;
            player.AddToScore(30);
        } 

    }

    public void CloseSafeCanvas()
    {
        safeIsClicked = false;
        safeCanvas.enabled = false;
        safeIsActivated = false;
    }

    public void OnMouseOver()
    {
        if (safeCanvas.enabled == false)
        {
        Cursor.SetCursor(interactableCursor, Vector2.zero, CursorMode.Auto);
        }
        else Cursor.SetCursor(myCursor, Vector2.zero, CursorMode.Auto);
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(myCursor, Vector2.zero, CursorMode.Auto);
    }

    void CheckIfSafeIsOpen()
    {
        if (safeIsUnlocked == true && safeIsFull == true)
        {
            safeIsFull = false;
            spriteRenderer.sprite = safeFull;
        }
    }

}
