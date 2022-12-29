using System;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject particle;

    private Rigidbody rb;

    private bool isStarted;

    public bool IsGameOver { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        isStarted = false;
        IsGameOver = false;
    }

    // Update is called once per frame
    private void Update()
    {
        bool isCollidingFloor = Physics.Raycast(transform.position, Vector3.down, 1f);
        if (!isCollidingFloor)
        {
            IsGameOver = true;
            rb.useGravity = true; // Make the Ball falls down
        }


        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (!isStarted)
        {
            rb.velocity = new Vector3(speed, 0, 0);
            isStarted = true;
        }
        else if (!IsGameOver)
        {
            SwitchDirection();
        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Diamond"))
        {
            Transform diamondTransform = collider.gameObject.transform;
            GameObject tempParticle = Instantiate(particle, diamondTransform.position, diamondTransform.rotation);
            Destroy(collider.gameObject); // Destroy diamond
            Destroy(tempParticle, 2f); // Destroy particle effect
        }
    }
}