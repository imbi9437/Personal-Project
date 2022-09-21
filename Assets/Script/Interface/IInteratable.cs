using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteratable
{
    public void Interaction(Player target);
    public void OnFoucus();
    public void OutFoucus();
}
