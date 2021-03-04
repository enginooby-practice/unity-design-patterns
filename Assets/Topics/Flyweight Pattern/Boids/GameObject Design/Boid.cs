using UnityEngine;

public class Boid : BoidBase
{
    // shared data
    public string specieName;
    public ENDANGERED_STATUS endangeredStatus;

    protected override void UpdateInfoPanel()
    {
        base.UpdateInfoPanel();
        infoPanel.specieLabel.text = specieName;
        infoPanel.endangeredLabel.text = endangeredStatus.ToString();
    }
}
