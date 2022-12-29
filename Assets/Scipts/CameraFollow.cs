using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private float lerpRate; // This is the rate by which the camera will change its position to follow the ball.

    private Vector3 offset; // Distance between our camera and the ball.

    private bool isGameOver;

    private BallController ballController;

    // Start is called before the first frame update
    private void Start() {
        offset = ball.transform.position - transform.position;
        isGameOver = false;
        ballController = ball.GetComponent<BallController>();
    }

    // Update is called once per frame
    private void Update() {
        isGameOver = ballController.IsGameOver;
        if (!isGameOver) {
            Follow();
        }

    }

    private void Follow() {
        Vector3 sourcePosition = transform.position;
        Vector3 targetPosition = ball.transform.position - offset;
        Vector3 transitioningPosition = Vector3.Lerp(sourcePosition, targetPosition, lerpRate * Time.deltaTime);
        transform.position = transitioningPosition;
    }
}
