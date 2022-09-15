using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Player player;
    private float mouseX;
    private float mouseY;
    private float xRoration;

    private void Awake()
    {
        player = playerTransform.gameObject.GetComponent<Player>();
    }

    private void Update()
    {
        MouseMovement();
    }

    private void MouseMovement()
    {
        mouseX = player.playerInput.MouseX*player.MouseSensitive*Time.deltaTime;
        mouseY = player.playerInput.MouseY*player.MouseSensitive*Time.deltaTime;

        xRoration -= mouseY;
        xRoration = Mathf.Clamp(xRoration, -90, 70);

        transform.localRotation = Quaternion.Euler(xRoration, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
