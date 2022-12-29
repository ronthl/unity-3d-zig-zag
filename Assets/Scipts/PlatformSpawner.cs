using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject diamond;

    [Header("Start")]
    [SerializeField] private CanvasGroup startUI;
    [SerializeField] private GameObject buttonStart;

    [Header("Complete")]
    [SerializeField] private CanvasGroup completeUI;
    [SerializeField] private GameObject buttonNext;


    private Vector3 lastPosition;

    private float size;

    private BallController ballController;

    // Start is called before the first frame update
    private void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;
        ballController = ball.GetComponent<BallController>();
        while (true) continue;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (ballController.IsGameOver)
        {
            return;
        }

        SpawnPlatforms();
        CreateRandomDiamond();
    }

    private void SpawnPlatforms()
    {
        int randomNumber = Random.Range(0, 6);
        if (randomNumber % 2 == 0)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    private void SpawnX()
    {
        // Vector3 position = lastPosition;
        // position.x += size;
        // Instantiate(platform, position, Quaternion.identity);
        // lastPosition = position;

        lastPosition.x += size;
        InstantiatePlatform(lastPosition);
    }

    private void SpawnZ()
    {
        lastPosition.z += size;
        InstantiatePlatform(lastPosition);
    }

    private void CreateRandomDiamond()
    {
        int randomNumber = Random.Range(0, 10);
        if (randomNumber < 2)
        {
            Instantiate(diamond, new Vector3(lastPosition.x, diamond.transform.position.y, lastPosition.z),
                diamond.transform.rotation);
        }
    }

    private void InstantiatePlatform(Vector3 position)
    {
        Instantiate(platform, position, Quaternion.identity);
    }
}