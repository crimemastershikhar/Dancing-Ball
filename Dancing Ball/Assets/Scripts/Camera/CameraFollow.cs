using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary: this is responsible for camera to follow the ball


public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform ballTarget;

    private Vector3 oldPosition;

    private void Awake() {
        //getting pos from ball
        oldPosition = ballTarget.position;

    }

    private void FixedUpdate() {
        if (ballTarget) {
            Vector3 newPosition = ballTarget.position;      //Curr pos
            Vector3 delta = oldPosition - newPosition;
            delta.y = 0f;                                   // cam height const.
            transform.position -= delta;
            oldPosition = newPosition;

        }

    }































































}//Class

