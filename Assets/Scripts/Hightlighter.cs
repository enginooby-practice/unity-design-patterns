using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

enum Mode { SINGLE, MULTIPLE }
public class Hightlighter : MonoBehaviour
{
    public static Hightlighter Instance;

    [Tooltip("Single mode: maximum one object is hightlighted at a time")]
    [SerializeField] private Mode mode = Mode.SINGLE;
    private Outlinable previousOutlinable;

    public void Hightlight(GameObject target)
    {
        // add Outlinable to gameObject & Mesh gameobject to Outlightable
        var outlinable = target.AddComponent(typeof(Outlinable)) as Outlinable;
        outlinable.OutlineTargets.Add(new OutlineTarget(target.GetComponent<Renderer>()));

        if (mode == Mode.SINGLE && previousOutlinable)
        {
            Destroy(previousOutlinable);
        }
        previousOutlinable = outlinable;
    }

    private void Awake()
    {
        Instance = this;
    }
}
