using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

[SerializeField] float moveSpeed = 1f;
[SerializeField] Canvas[] CanvasArray;
[SerializeField]  TMP_Text speechBubble;
[SerializeField]  TMP_Text scoreText;
[SerializeField] GameObject speechBackground;
public bool speechBubbleActive = false;
public bool canvasOpened;
public int score = 0;
public bool playerHasKey;
public bool gameOver = false;
private PlayerControls playerControls;
private Vector2 movement;
private Vector2 targetPosition;
private Rigidbody2D rb;
private Animator myAnimator;
private SpriteRenderer mySpriteRenderer;
public float minY, maxY;
public float textOutlineWidth = 1f;

private void Awake() {
    playerControls = new PlayerControls();
    rb = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
    mySpriteRenderer = GetComponent<SpriteRenderer>();
    speechBackground.SetActive(false);
    scoreText.text = "Score: 0 of 100";
}

private void OnEnable() {
    playerControls.Enable();
}

private void Update() {
    
    PlayerMouseInput();
    CanvasChecker();

    
}

private void FixedUpdate() {
    AdjustPlayerFacingDirection();
    Move();
}

private void Move()
{
    rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
}

private void AdjustPlayerFacingDirection()
{
    Vector3 mousePos = Input.mousePosition;
    Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

    if (mousePos.x < playerScreenPoint.x)
    {
        mySpriteRenderer.flipX = true;
    }
    else
    {
        mySpriteRenderer.flipX = false;
    }
}

private void PlayerMouseInput()
{
        if ((Input.GetMouseButtonDown(0)) && (canvasOpened == false) && (!gameOver))
        {
            // Get the world position of the mouse click
            Camera mainCamera = Camera.main;
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = mousePosition;
        }

        // Move towards the target position
        if (targetPosition != Vector2.zero)
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            Vector3 movement = direction * moveSpeed * Time.deltaTime;
            transform.position += new Vector3(movement.x, movement.y, transform.position.z);
            //movement = playerControls.Movement.Move.ReadValue<Vector2>();
            myAnimator.SetBool("isWalking", true);
            

            // Check if we've reached the target
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = Vector2.zero;
                myAnimator.SetBool("isWalking", false);
            }
        }
}

private void OnCollisionEnter2D(Collision2D other) 
{
    if((other.gameObject.CompareTag("Boundry")) || (other.gameObject.CompareTag("Interactable")))
    {
        //Debug.Log("Can't go there");
        targetPosition = Vector2.zero;
        myAnimator.SetBool("isWalking", false);

    }
}

//private void OnCollisionStay2D(Collision2D other) 
//{
    //if(other.gameObject.tag == "Boundry")
    //{
        //Debug.Log("Shit man wtf");
        //targetPosition = Vector2.zero;
        //myAnimator.SetBool("isWalking", false);

    //}
//}

public void DisplayText(string message)
{
    speechBackground.SetActive(true);
    speechBubble.text= message;
    speechBubble.outlineWidth = textOutlineWidth;
    speechBubble.outlineColor = Color.black;
    StartCoroutine(ClearText());
}

IEnumerator ClearText()
{
    yield return new WaitForSeconds(5f);
    speechBubble.text = "";
    speechBackground.SetActive(false);
    Debug.Log("Text box cleared");

}

public void AddToScore(int points)
{
    score = score + points;
    scoreText.text = "Score: " + score + " of 100";
}

public void CanvasChecker()
{
    canvasOpened = false;

    foreach (Canvas canvas in CanvasArray)
    {
        if (canvas.isActiveAndEnabled)
        {
            canvasOpened = true;
            Debug.Log("A Canvas is Open");
            targetPosition = Vector2.zero;
            myAnimator.SetBool("isWalking", false);
            break;
        }
    } 
}  
    

public void GameOver()
    {
        gameOver = true;
    }


}


