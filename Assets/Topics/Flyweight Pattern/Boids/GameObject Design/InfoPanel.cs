using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public static InfoPanel Instance;

    public TextMeshProUGUI specieLabel;
    public TextMeshProUGUI endangeredLabel;
    public TextMeshProUGUI massLabel;
    public TextMeshProUGUI genderLabel;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
