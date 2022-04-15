using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransition : MonoBehaviour
{
    public Vector2 Cameramax;
    public Vector2 Cameramin;
    public Vector3 Playerchange;
    private CameraMovement cam;
    public bool newUniqPlace;
    public string PlaceName;
    public GameObject Place;
    public AudioSource source;
    public Text PlaceText;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            cam.min = Cameramin;
            cam.max = Cameramax;
            col.transform.position += Playerchange;
            if(newUniqPlace)
            {
                StartCoroutine(PlaceCouroutine());
            }
            source.clip = clip;
            source.Play();
        }
    }

    private IEnumerator PlaceCouroutine()
    {
        Place.SetActive(true);
        PlaceText.text = PlaceName;
        yield return new WaitForSeconds(4f);
        Place.SetActive(false);
    }
}
