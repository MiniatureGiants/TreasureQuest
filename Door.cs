using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    

    bool isClicked = false;
    PlayerController player;

    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] Sprite doorOpen;
    [SerializeField] AudioSource doorOpenSound;
    [SerializeField] AudioSource puzzleSolved;
    bool doorPuzzleSolved = false;

    public Texture2D interactableCursor;
    public Texture2D myCursor;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
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
        if(isClicked == true && player.playerHasKey == true )
        {
            isClicked = false;
            spriteRenderer.sprite = doorOpen;
            doorOpenSound.Play();
            player.playerHasKey = false;
            doorPuzzleSolved = true;
            player.GameOver();
            StartCoroutine(EndTheGame());
            
        }
        else if (isClicked == true && !player.playerHasKey && !doorPuzzleSolved)
        {
            isClicked = false;
            player.DisplayText("The door is locked. I need to find a key.");
        } 
    }

    public void OnTriggerStay2D(Collider2D other) 
    {
        if(isClicked == true && player.playerHasKey == true )
        {
            isClicked = false;
            spriteRenderer.sprite = doorOpen;
            doorOpenSound.Play();
            player.playerHasKey = false;
            doorPuzzleSolved = true;
            player.GameOver();
            StartCoroutine(EndTheGame());
        }
        else if (isClicked == true && !player.playerHasKey && !doorPuzzleSolved)
        {
            //player.DisplayText("The door is locked. I need to find the key.");
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
        Cursor.SetCursor(interactableCursor, Vector2.zero, CursorMode.Auto);      
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(myCursor, Vector2.zero, CursorMode.Auto);
    }

    IEnumerator EndTheGame()
    {
        player.AddToScore(25);
        puzzleSolved.Play();
        gameManager.GameOver();
        player.DisplayText("I should do this robbing houses thing more often! Time to scram.");
        yield return new WaitForSeconds (3f);
        animator.SetBool("FadeOut", true);
        yield return new WaitForSeconds (2f);
         SceneManager.LoadScene("EndScene");
        

    }

}
