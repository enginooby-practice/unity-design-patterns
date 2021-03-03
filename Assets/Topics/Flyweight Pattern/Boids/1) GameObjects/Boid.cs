﻿using UnityEngine;

public enum EndangeredStatus { CR, EN, VU }
public enum Gender { MALE, FEMALE }
public class Boid : MonoBehaviour
{
    // shared data
    public string specieName;
    public EndangeredStatus endangeredStatus;

    // unique data
    private int mass;
    private Gender gender;

    private EPOOutline.Outlinable outline;
    private BoidsController controller;
    private InfoPanel infoPanel;

    private Vector3 separationForce;
    private Vector3 cohesionForce;
    private Vector3 alignmentForce;
    private Vector3 avoidWallsForce;

    private void Start()
    {
        outline = GetComponent<EPOOutline.Outlinable>();
        controller = BoidsController.Instance;
        infoPanel = InfoPanel.Instance;
        InitUniqueData();
    }

    private void OnMouseDown()
    {
        if(controller.previousOutline) controller.previousOutline.enabled = false;
        outline.enabled = true;
        controller.previousOutline = outline;
        UpdateInfoPanel();
    }

    private void UpdateInfoPanel()
    {
        infoPanel.specieLabel.text = specieName;
        infoPanel.endangeredLabel.text = endangeredStatus.ToString();
        infoPanel.massLabel.text = mass.ToString() + "g";
        infoPanel.genderLabel.text = gender.ToString().ToLower();
    }

    private void InitUniqueData()
    {
        mass = Random.Range(50, 100);
        gender = (Random.Range(0f, 1f) < 0.5f) ? Gender.MALE : Gender.FEMALE;
    }

    private void Update()
    {
        calculateForces();
        moveForward();
    }

    private void calculateForces()
    {

        Vector3 seperationSum = Vector3.zero;
        Vector3 positionSum = Vector3.zero;
        Vector3 headingSum = Vector3.zero;

        int boidsNearby = 0;

        for (int i = 0; i < controller.boids.Count; i++)
        {

            if (this != controller.boids[i])
            {

                Vector3 otherBoidPosition = controller.boids[i].transform.position;
                float distToOtherBoid = (transform.position - otherBoidPosition).magnitude;

                if (distToOtherBoid < controller.boidPerceptionRadius)
                {

                    seperationSum += -(otherBoidPosition - transform.position) * (1f / Mathf.Max(distToOtherBoid, .0001f));
                    positionSum += otherBoidPosition;
                    headingSum += controller.boids[i].transform.forward;

                    boidsNearby++;
                }
            }
        }

        if (boidsNearby > 0)
        {
            separationForce = seperationSum / boidsNearby;
            cohesionForce = (positionSum / boidsNearby) - transform.position;
            alignmentForce = headingSum / boidsNearby;
        }
        else
        {
            separationForce = Vector3.zero;
            cohesionForce = Vector3.zero;
            alignmentForce = Vector3.zero;
        }

        if (minDistToBorder(transform.position, controller.cageSize) < controller.avoidWallsTurnDist)
        {
            // Back to center of cage
            avoidWallsForce = -transform.position.normalized;
        }
        else
        {
            avoidWallsForce = Vector3.zero;
        }
    }

    private void moveForward()
    {
        Vector3 force =
            separationForce * controller.separationWeight +
            cohesionForce * controller.cohesionWeight +
            alignmentForce * controller.alignmentWeight +
            avoidWallsForce * controller.avoidWallsWeight;

        Vector3 velocity = transform.forward * controller.boidSpeed;
        velocity += force * Time.deltaTime;
        velocity = velocity.normalized * controller.boidSpeed;

        transform.position += velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    private float minDistToBorder(Vector3 pos, float cageSize)
    {
        float halfCageSize = cageSize / 2f;
        return Mathf.Min(Mathf.Min(
            halfCageSize - Mathf.Abs(pos.x),
            halfCageSize - Mathf.Abs(pos.y)),
            halfCageSize - Mathf.Abs(pos.z)
        );
    }
}
