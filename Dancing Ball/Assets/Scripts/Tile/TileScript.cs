using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    private AudioSource audioSource;
    private Rigidbody myBody;

    [SerializeField] private GameObject gem;
    [SerializeField] private float chanceForCollectible;

    private void Awake() {
        myBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    private void Start() {
        if (Random.value < chanceForCollectible) {
            Vector3 temp = transform.position;
            temp.y += 2f;
            Instantiate(gem, temp, transform.rotation);
        }

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

    }

    private void OnTriggerExit(Collider target) {
        if (target.tag == "Ball") {
            StartCoroutine(TriggerFallingDown());
        }

    }































































}//Class
