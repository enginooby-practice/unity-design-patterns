using UnityEngine;

public class Boid : BoidBase
{
    // shared data
    public string specieName;
    public EndangeredStatus endangeredStatus;

    protected override void UpdateInfoPanel()
    {
        base.UpdateInfoPanel();
        infoPanel.specieLabel.text = specieName;
        infoPanel.endangeredLabel.text = endangeredStatus.ToString();
    }
}
