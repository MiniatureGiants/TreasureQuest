using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D mouseCursor;
    public Texture2D lookAtThisCursor;

    public int finalScore = 0;

    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource endingMusic;
    [SerializeField] Canvas startingCanvas;

    PlayerController playerController;
    
    private void Awake()
    { 
        int gameStatusCount = FindObjectsOfType<GameManager>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("Destroyed the active game object");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }      
    }
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
    
        CheckForInteractables();
    }

    public void CheckForInteractables() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            GameObject hoveredObject = EventSystem.current.currentSelectedGameObject;
            if (hoveredObject != null && hoveredObject.CompareTag("Interactable"))
            {
                Cursor.SetCursor(lookAtThisCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        backgroundMusic.Stop();
        endingMusic.Play();
        finalScore = playerController.score;
        
    
    }

    public void StartGame()
    {
        startingCanvas.enabled = false;
        
    }

}
