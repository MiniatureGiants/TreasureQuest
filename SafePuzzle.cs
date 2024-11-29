using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    private Color[] colors = { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 0;
    private bool safeUnlocked = false;

    [SerializeField] AudioSource buttonPress;
    [SerializeField] AudioSource safeLock;
    [SerializeField] Canvas thisCanvas;

    [SerializeField] Safe safe;


    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    public void ChangeColor(Button button)
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        buttonPress.Play();
        button.GetComponent<Image>().color = colors[currentColorIndex];

        CheckSafeUnlocked();
    }

    private void CheckSafeUnlocked()
    {
        if (button1.GetComponent<Image>().color == Color.blue &&
            button2.GetComponent<Image>().color == Color.red &&
            button3.GetComponent<Image>().color == Color.green)
        {
            safeUnlocked = true;
            safe.safeIsUnlocked = true;
            safeLock.Play();
            thisCanvas.enabled = false;
            player.DisplayText("I'm in! Lets get the goods and get the hell out of here!.");
            Debug.Log("Safe unlocked!");
        }
    }
}
