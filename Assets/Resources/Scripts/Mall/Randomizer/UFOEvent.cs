using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEvent : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 initialPos = new Vector3(40, 20, -10);

    public void Awake()
    {
        transform.parent.position = initialPos;
    }

    public void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 3, 0));
        transform.parent.Translate(Vector3.left * speed);

        if (transform.parent.position.x < -100)
            Destroy(transform.parent.gameObject);
    }
}
