using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenWife : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject backOfPainting;
    [SerializeField] GameObject safe;
    [SerializeField] AudioSource puzzleSolved;

    public bool wifeIsClicked = false;
    public bool hasReadEmail = false;
    public bool paintingIsGone = false;
    public Texture2D interactableCursor;
    public Texture2D myCursor;
    PlayerController player;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backOfPainting.SetActive(false);
        safe.SetActive(false);
        player = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnMouseDown() 
    {
        wifeIsClicked = true;
        
    }

    public void OnTriggerEnter2D()
    {
        if(wifeIsClicked == true && paintingIsGone == false && hasReadEmail == true)
        {
            wifeIsClicked = false;
            player.DisplayText("Look's like this is where the old man hid his safe.");
            Debug.Log("Player is engaging with the Wife Picture");
            paintingIsGone = true;
            spriteRenderer.enabled = false;
            backOfPainting.SetActive(true);
            safe.SetActive(true);
            puzzleSolved.Play();
            Destroy(gameObject);
        }
        else if (wifeIsClicked == true && paintingIsGone == false && hasReadEmail == false) 
        {
            player.DisplayText("That's a weird looking painting.");
        }
    }

        public void OnTriggerStay2D()
    {
        if(wifeIsClicked == true && paintingIsGone == false && hasReadEmail == true)
        {
            wifeIsClicked = false;
            player.DisplayText("Look's like this is where the old man hid his safe.");
            Debug.Log("Player is engaging with the Wife Picture");
            paintingIsGone = true;
            spriteRenderer.enabled = false;
            backOfPainting.SetActive(true);
            safe.SetActive(true);
            puzzleSolved.Play();
        }
        else if (wifeIsClicked == true && paintingIsGone == false && hasReadEmail == false) 
        {
            player.DisplayText("That's a weird looking painting.");
        }
    }

        public void OnMouseOver()
    {
        if (paintingIsGone == false)
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
