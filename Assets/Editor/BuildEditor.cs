using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEditor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEditor.PlayerSettings.WebGL.emscriptenArgs = "-s WASM_MEM_MAX=512MB";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
