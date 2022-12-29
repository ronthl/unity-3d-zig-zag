using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerExit(Collider col) {
        if (col.gameObject.CompareTag("Ball")) {
            Invoke(nameof(FallDown), .5f);
        }
    }

    private void FallDown() {
        gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject, 2);
    }
}
