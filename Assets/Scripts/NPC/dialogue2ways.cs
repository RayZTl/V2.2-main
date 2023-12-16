using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class dialogue2ways : MonoBehaviour
{
    [SerializeField] private GameObject Playercanvas;
    [SerializeField] private GameObject Dialoguecanvas;

    [SerializeField] private Text speakerText;
    [SerializeField] private Text DialogueText;
    [SerializeField] private Image PotraitSpeaker;

    [SerializeField] private string[] speakerName;
    [SerializeField] [TextArea] private string[] dialoguetext;
    [SerializeField] private Sprite[] potrait;

    private bool isranged;
    private int step;
    [SerializeField] private GameObject ButtonE;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isranged == true)
        {

            if (step >= speakerName.Length)
            {
                Time.timeScale = 1;
                Dialoguecanvas.SetActive(false);
                Playercanvas.SetActive(true);
                step = 0;
            }
            else
            {
                Time.timeScale = 0;
                Playercanvas.SetActive(false);
                Dialoguecanvas.SetActive(true);
                speakerText.text = speakerName[step];
                DialogueText.text = dialoguetext[step];
                PotraitSpeaker.sprite = potrait[step];
                step += 1;
            }
        }        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isranged = true;
            ButtonE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isranged = false;
            Dialoguecanvas.SetActive(false);
            Playercanvas.SetActive(true);
            step = 0;
            ButtonE.SetActive(false);
        }
    }
}
