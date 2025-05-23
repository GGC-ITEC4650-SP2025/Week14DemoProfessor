using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieController : MonoBehaviour
{
    Rigidbody myBod;
    Text pipsTxt;
    AudioSource myAudio;

    public AudioClip clip1;
    public AudioClip clip2;
    private bool stopSoundPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(clip1);
        //myAudio.PlayOneShot(clip2);
        pipsTxt = GameObject.Find("PipsTxt").GetComponent<Text>();
        myBod = GetComponent<Rigidbody>();
        Vector3 kick = new Vector3(
            0,
            Random.Range(5, 10),
            Random.Range(5, 10)
        );
        Vector3 offCenter = new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f),
            -0.5f
        );
        myBod.AddForceAtPosition(
            kick, 
            transform.position + offCenter,
            ForceMode.Impulse
        );
    }

    // Update is called once per frame
    void Update()
    {
        float maxY = float.MinValue; // or 0
        for(int i = 0; i < transform.childCount; i++) {
            Transform spot = transform.GetChild(i);
            float spotY = spot.position.y;
            if(spotY > maxY) {
                maxY = spotY;
                pipsTxt.text = "Showing " + spot.name;
            }
        }
        if(myBod.velocity == Vector3.zero && stopSoundPlayed == false) {
            myAudio.PlayOneShot(clip2);
            stopSoundPlayed = true;
        }
    }
}
