using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour {

    [SerializeField] private GameObject sparkleEffect;


    private void OnTriggerEnter(Collider target) {
        if (target.tag == "Ball") {
            Instantiate(sparkleEffect, transform.position, transform.rotation);
            GameplayController.instance.PlayCollectibeSound();
            gameObject.SetActive(false);

        }
    }







































}//Class
