using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {
    public static GameplayController instance;

    [HideInInspector] public bool gamePlaying;

    private void Awake() {
        Singleton();

    }

    //precaution step to save memory if obj is destoryed. Might delete later
    private void OnDisable() {
        instance = null;
    }

    void Singleton() {
        if (instance == null)
            instance = this;

    }













































}//Class
