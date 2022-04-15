using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dimi : MonoBehaviour
{
    public GameObject DialogBox, cutscene;
    public Text DialogText;
    public string dialog;
    public bool InRange;
    public bool first = true;
    private CameraMovement cam;
    public GameObject player, dodikshoot, fe1, fe2, fe3, fe4, fe5;
    public AudioClip clip, clip2;
    public AudioSource source;


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
                    first = false;
                    fe1.SetActive(true);
                    fe2.SetActive(true);
                    fe3.SetActive(true);
                    fe4.SetActive(true);
                    fe5.SetActive(true);
                    source.clip = clip;
                    source.Play();
                }
                else
                {
                    player = GameObject.FindWithTag("Player");
                    dodikshoot.transform.position = player.transform.position;
                    player.SetActive(false);
                    dodikshoot.SetActive(true);
                    cam = Camera.main.GetComponent<CameraMovement>();
                    cam.target = dodikshoot.transform;
                    DialogBox.SetActive(true);
                    DialogText.text = dialog;
                }
            }
            else if (!fe1.activeSelf && !fe2.activeSelf && !fe3.activeSelf && !fe4.activeSelf && !fe5.activeSelf)
            {
                if (DialogBox.activeInHierarchy)
                {
                    DialogBox.SetActive(false);
                    cutscene.SetActive(true);
                }
                else
                {
                    DialogBox.SetActive(true);
                    DialogText.text = "Ты молодец, можешь возвращаться к своей работе с бумагами.";
                    source.clip = clip2;
                    source.Play();
                }
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
