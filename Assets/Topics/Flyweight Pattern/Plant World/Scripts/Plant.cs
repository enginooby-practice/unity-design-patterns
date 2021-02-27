using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] PlantData info;
    PlantInfoPanel infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        infoPanel = FindObjectOfType<PlantInfoPanel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        infoPanel.SetPlantData(info);
        infoPanel.OpenPlantPanel();
    }
}
