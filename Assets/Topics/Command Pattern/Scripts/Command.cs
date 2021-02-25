using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Excecute();
    public abstract void Undo();
    public abstract Command Clone();
}
