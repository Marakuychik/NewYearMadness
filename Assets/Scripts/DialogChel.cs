using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChel : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public string dialog;
    public bool InRange;
    public bool first = true;
    public BoxCollider2D roomtrans;


    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Interract")) && InRange)
        {
            if (first)
            {
                if (DialogBox.activeInHierarchy)
                {
                    DialogBox.SetActive(false);
                }
                else
                {
                    DialogBox.SetActive(true);
                    DialogText.text = dialog;
                }
            }
            else
            {
                if (DialogBox.activeInHierarchy)
                {
                    DialogBox.SetActive(false);
                }
                else
                {
                    DialogBox.SetActive(true);
                    DialogText.text = "Отлично, ты сделал это! Быстрее беги к верстаку, собери подарок и дуй в тронный зал, уже все туда идут!";
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InRange = true;
            if (col.GetComponent<PlayerMovement>().chasi && col.GetComponent<PlayerMovement>().girl && col.GetComponent<PlayerMovement>().upa)
            {
                first = false;
            }
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
