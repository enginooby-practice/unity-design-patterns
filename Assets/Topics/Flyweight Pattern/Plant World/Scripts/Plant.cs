using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class Plant : MonoBehaviour
{
    [SerializeField] PlantData info;
    Outlinable outliner;
    PlantInfoPanel infoPanel;

    // Start is called before the first frame update
    void Start()
    {
        infoPanel = FindObjectOfType<PlantInfoPanel>();
        outliner = GetComponent<Outlinable>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseEnter()
    {
        if (outliner) outliner.enabled = true;
    }

    private void OnMouseExit()
    {
        if (outliner) outliner.enabled = false;
    }
    private void OnMouseDown()
    {
        infoPanel.SetPlantData(info);
        infoPanel.OpenPlantPanel();
    }
}
