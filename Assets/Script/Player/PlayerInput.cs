using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    private float horizontal;
    public float Horizontal { get { return horizontal; } set { horizontal = value; } }
    private float vertical;
    public float Vertical { get { return vertical; } set { vertical = value; } }
    private bool jump;
    public bool Jump { get { return jump; } set { jump = value; } }
    private bool run;
    public bool Run { get { return run; } set { run = value; } }
    private bool kneel;
    public bool Kneel { get { return kneel; } set { kneel = value; } }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Jump = Input.GetButtonDown("Jump");
        Run = Input.GetButton("Run");
        Kneel = Input.GetButton("Kneel");
    }
}
