using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {
    public static GameplayController instance;

    [HideInInspector] public bool gamePlaying;

    [SerializeField] private GameObject tile;

    private Vector3 currentTilePosition;                     //store loc of curr spawn new tile

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        Singleton();
        /*        currentTilePosition = new Vector3(-2, 0, 3);*/
    }

    private void Start() {
        currentTilePosition = new Vector3(-2, 0, 2);

        for (int i = 0; i < 5; ++i) {
            CreateTiles();
        }

    }

    //precaution step to save memory if obj is destoryed. Might delete later
    private void OnDisable() {
        instance = null;
    }

    void Singleton() {
        if (instance == null)
            instance = this;

    }

    public void ActivateTileSpawner() {
        StartCoroutine(SpawnNewTiles());

    }

    void CreateTiles() {
        Vector3 newTilePosition = currentTilePosition;
        int rand = Random.Range(0, 100);

        if (rand < 50) {
            newTilePosition.x -= 1f;
        } else {
            newTilePosition.z += 1f;
        }

        currentTilePosition = newTilePosition;
        Instantiate(tile, currentTilePosition, transform.rotation);

    }

    IEnumerator SpawnNewTiles() {
        yield return new WaitForSeconds(0.3f);

        CreateTiles();

        if (gamePlaying)
            StartCoroutine(SpawnNewTiles());

    }

    public void PlayCollectibeSound() {
        audioSource.Play();
    }













































}//Class
