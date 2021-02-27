using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantInfoPanel : MonoBehaviour
{
    public GameObject plantInfoPanel;
    public RawImage plantIcon;
    public Text planeName;
    public Text threatLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPlantPanel()
    {
        plantInfoPanel.SetActive(true);
    }

    public void ClosePlantPanel()
    {
        plantInfoPanel.SetActive(false);
    }

    public void SetPlantData(PlantData plantData)
    {
        planeName.text = plantData.planName;
        plantIcon.texture = plantData.icon;
        threatLevel.text = plantData.plantThreat.ToString();
    }
}
