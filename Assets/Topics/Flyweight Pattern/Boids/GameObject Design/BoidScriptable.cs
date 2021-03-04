public class BoidScriptable : BoidBase
{
    public BoidSharedData boidSharedData;
    protected override void UpdateInfoPanel()
    {
        base.UpdateInfoPanel();
        infoPanel.specieLabel.text = boidSharedData.SpecieName;
        infoPanel.endangeredLabel.text = boidSharedData.EndangeredStatus.ToString();
    }
}
