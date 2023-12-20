using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    [SerializeField] float duration = 1.0f;
    float speedMove;

    private void Start()
    {
        speedMove = 1 / duration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speedMove * Time.deltaTime, transform.position.y, transform.position.y);
        if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.y);
        }
    }
}
