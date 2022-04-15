using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Мукыефл : MonoBehaviour
{
    public BoxCollider2D roomtrans;
    public GameObject DialogBox, Craft;
    public Text DialogText;
    public bool second = false;
    public bool InRange = false;

    private void Update()
    {
        if (Input.GetButtonDown("Interract") && second)
        {
                if (DialogBox.activeInHierarchy)
                {
                    DialogBox.SetActive(false);
                    Craft.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    DialogBox.SetActive(true);
                    Craft.SetActive(true);
                    DialogText.text = "А что, получилась очень даже неплохо)";
                }
                roomtrans.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.GetComponent<PlayerMovement>().chasi && col.GetComponent<PlayerMovement>().girl && col.GetComponent<PlayerMovement>().upa)
            {
            second = true;
            }
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
