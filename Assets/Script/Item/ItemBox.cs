using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteratable
{
    private ParticleSystem particle;
    public void Interaction(Player player)
    {

    }

    public void OnFoucus()
    {
        particle.Play();
    }

    public void OutFoucus()
    {
        particle.Stop();
    }
}
