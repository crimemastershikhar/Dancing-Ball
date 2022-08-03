using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayController : MonoBehaviour {
    public static GameplayController instance;

    [HideInInspector] public bool gamePlaying;

    /*    [SerializeField] private GameObject tile;*/

    private Vector3 currentTilePosition;                     //store loc of curr spawn new tile

    private AudioSource audioSource;


    //Setting up mood of game
    [SerializeField] private Material tileMat;
    [SerializeField] private Light dayLight;
    private Camera mainCamera;
    private bool camColorLerp;
    private Color cameraColor;
    private Color[] tileColor_Day;
    private int tileColor_Index;
    private Color tileColor_Night;
    private Color tileTrueColor;     //Store 1st tile color
    private float timer;
    [SerializeField] private float timerInterval;
    private float camLerpTimer;
    private float camLerpInterval = 5f;
    private int direction;


    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        Singleton();

        mainCamera = Camera.main;
        cameraColor = mainCamera.backgroundColor;

        tileTrueColor = tileMat.color;
        tileColor_Index = 0;
        tileColor_Day = new Color[3];
        tileColor_Day[0] = new Color(10 / 256f, 139 / 256f, 203 / 256f);
        tileColor_Day[1] = new Color(10 / 256f, 200 / 256f, 20 / 256f);
        tileColor_Day[2] = new Color(220 / 256f, 170 / 256f, 45 / 256f);

        tileColor_Night = new Color(0, 8 / 256f, 11 / 256f);
        tileMat.color = tileColor_Day[0];

    }

    private void Start() {
        currentTilePosition = new Vector3(-2, 0, 2);

        for (int i = 0; i < 15; ++i) {
            CreateTiles();
        }

    }

    private void Update() {
        /*        if (gamePlaying) {
                    CheckLerpTimer();
                }*/

        CheckLerpTimer();
    }

    //precaution step to save memory if obj is destoryed. Might delete later
    private void OnDisable() {
        instance = null;
        tileMat.color = tileTrueColor;
    }


    void Singleton() {
        if (instance == null)
            instance = this;

    }

    public void ActivateTileSpawner() {
        StartCoroutine(SpawnNewTiles());

    }

    #region SettingMoodLight

    void CheckLerpTimer() {
        timer += Time.deltaTime;

        if (timer > timerInterval) {
            timer -= timerInterval;
            camColorLerp = true;
            camLerpTimer = 0f;
        }

        if (camColorLerp) {
            camLerpTimer += Time.deltaTime;
            float percent = camLerpTimer / camLerpInterval;

            if (direction == 1) {
                mainCamera.backgroundColor = Color.Lerp(cameraColor, Color.black, percent);
                tileMat.color = Color.Lerp(tileColor_Day[tileColor_Index], tileColor_Night, percent);
                Debug.Log(nameof(tileMat.color));
                dayLight.intensity = .5f - percent;
            } else {
                mainCamera.backgroundColor = Color.Lerp(Color.black, cameraColor, percent);
                tileMat.color = Color.Lerp(tileColor_Night, tileColor_Day[tileColor_Index], percent);
                dayLight.intensity = percent;
                Debug.Log(nameof(tileMat.color));
            }

            if (percent > 0.98) {
                camLerpTimer = 1f;
                direction *= -1;
                camColorLerp = false;

                if (direction == -1) {
                    tileColor_Index = Random.Range(0, tileColor_Day.Length);
                }

            }

        }

    }

    #endregion

    void CreateTiles() {
        Vector3 newTilePosition = currentTilePosition;
        int rand = Random.Range(0, 100);

        if (rand < 50) {
            newTilePosition.x -= 1f;
        } else {
            newTilePosition.z += 1f;
        }

        currentTilePosition = newTilePosition;

        ObjectPooler.Instance.SpawnFromPool("Tile", currentTilePosition, Quaternion.identity);

        /*        Instantiate(tile, currentTilePosition, transform.rotation);*/

    }

    IEnumerator SpawnNewTiles() {
        yield return new WaitForSeconds(1f);

        CreateTiles();

        if (gamePlaying)
            StartCoroutine(SpawnNewTiles());

    }

    public void PlayCollectibeSound() {
        audioSource.Play();
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }













































}//Class
