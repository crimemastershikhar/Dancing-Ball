using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHover : MonoBehaviour {

    private float startY;

    [SerializeField] private float hoverSpeed;

    private void Start() {
        startY = transform.position.y;

    }

    private void Update() {
        Vector3 position = transform.position;   //curr pos

        //Time: How many seconds in game
        position = new Vector3(position.x, startY + Mathf.Sin(Time.time * hoverSpeed) * 0.1f, position.z);
        //        Debug.Log(startY + Mathf.Sin(Time.time * hoverSpeed) * 0.1f);
        transform.position = position;

    }












































}//Class
