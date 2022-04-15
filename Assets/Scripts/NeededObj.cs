using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeededObj : MonoBehaviour
{
    public GameObject DialogBox;
    public PlayerMovement player;
    public Text DialogText;
    public string dialog;
    public bool InRange;
    public string nameObj;

    /*
     * ЗАПУСКАЕМ
░ГУСЯ░▄▀▀▀▄░РАБОТЯГИ░░
▄███▀░◐░░░▌░░░░░░░
░░░░▌░░░░░▐░░░░░░░
░░░░▐░░░░░▐░░░░░░░
░░░░▌░░░░░▐▄▄░░░░░
░░░░▌░░░░▄▀▒▒▀▀▀▀▄
░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄
░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄
░░░░░░░░░░░▌▌▌▌░░░░░
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░▄▄▌▌▄▌▌░░░░░
    */

    void Update()
    {
        if ((Input.GetButtonDown("Interract")) && InRange)
        {
            Debug.Log("Pressed");
            if (DialogBox.activeInHierarchy)
            {
                switch(nameObj)
                {
                    case "chasi":
                        player.chasi = true;
                        break;
                    case "girl":
                        player.girl = true;
                        break;
                    case "upa":
                        player.upa = true;
                        break;
                }
               
                DialogBox.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                DialogBox.SetActive(true);
                DialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InRange = false;
            DialogBox.SetActive(false);
        }
    }
}
