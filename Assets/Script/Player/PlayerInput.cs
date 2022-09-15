using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    private float horizontal;
    public float Horizontal { get { return horizontal; } }
    private float vertical;
    public float Vertical { get { return vertical; } }
    private float mouseX;
    public float MouseX { get { return mouseX; } }
    private float mouseY;
    public float MouseY { get { return mouseY; } }
    private bool jump;
    public bool Jump { get { return jump; } }
    private bool run;
    public bool Run { get { return run; } }
    private bool kneel;
    public bool Kneel { get { return kneel; } }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        jump = Input.GetButtonDown("Jump");
        run = Input.GetButton("Run");
        //Kneel = Input.GetButton("Kneel");
    }
}
