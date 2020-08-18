using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle2 : MonoBehaviour
{
    public int moveDirection = 1;
    public float speed = 2;
    public Vector2 startingPosition;
    public Vector2 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveDirection * speed);

        if ((transform.position.x * moveDirection) > (endPosition.x * moveDirection))
        {
            transform.position = startingPosition;
        }
    }
}
