using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    private float speed = 5f;

    private void Start()
    {
        offset = new Vector3(0, 0, -10);
    }

    private void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
    }
}
