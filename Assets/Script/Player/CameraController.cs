using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject cameraGameObject;
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
        mouseX = player.PlayerInput.MouseX*player.MouseSensitive*Time.deltaTime;
        mouseY = player.PlayerInput.MouseY*player.MouseSensitive*Time.deltaTime;

        xRoration -= mouseY;
        xRoration = Mathf.Clamp(xRoration, -70, 70);

        cameraGameObject.transform.localRotation = Quaternion.Euler(xRoration, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
