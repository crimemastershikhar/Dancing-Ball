using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    private AudioSource audioSource;
    private Rigidbody myBody;


    private void Awake() {
        myBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    IEnumerator TriggerFallingDown() {
        yield return new WaitForSeconds(0.3f);
        myBody.isKinematic = false;
        audioSource.Play();
        StartCoroutine(TurnOffGameObject());
    }

    //to de-ctivate gameObject
    IEnumerator TurnOffGameObject() {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }

    private void OnTriggerExit(Collider target) {
        if (target.tag == "Ball") {
            StartCoroutine(TriggerFallingDown());
        }

    }































































}//Class
