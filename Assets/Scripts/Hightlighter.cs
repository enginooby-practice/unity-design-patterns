using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

// TODO: create hightlight samples => clone it to the hightlighted object
public class Hightlighter : MonoBehaviour
{
    public static Hightlighter Instance;
    enum MODE { Single, Multiple }

    [Tooltip("Single mode: maximum one object is hightlighted at a time")]
    [SerializeField] private MODE mode = MODE.Single;
    private Outlinable previousOutlinable;

    public void Hightlight(GameObject target)
    {
        // add Outlinable to gameObject & Mesh gameobject to Outlightable
        var outlinable = target.AddComponent(typeof(Outlinable)) as Outlinable;
        outlinable.OutlineTargets.Add(new OutlineTarget(target.GetComponent<Renderer>()));

        if (mode == MODE.Single && previousOutlinable)
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
