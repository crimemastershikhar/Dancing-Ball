using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotate : MonoBehaviour {

    [SerializeField] private float speed;

    private float angle;

    private void Update() {
        angle = (angle + speed) % 360f;
        transform.localRotation = Quaternion.Euler(new Vector3(45f, angle, 0f));

    }














}//Class
