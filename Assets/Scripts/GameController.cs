using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;

    public GameObject player;
    public GameObject[] pickups;
    public TextMeshProUGUI distanceToPickup;
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        pickups = GameObject.FindGameObjectsWithTag("PickUp");

    }

    // Update is called once per frame
    void Update()
    {
        UpdateClosestPickup();
    }

    void UpdateClosestPickup()
    {
        GameObject closestPickup = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject pickup in pickups)
        {
            if (pickup.activeSelf)
            {
                float distance = Vector3.Distance(player.transform.position, pickup.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickup = pickup;
                }
                pickup.GetComponent<Renderer>().material.color = Color.white;

            }
        }
        if (closestPickup != null)
        {

            closestPickup.GetComponent<Renderer>().material.color = Color.red;
            distanceToPickup.text = "Distance to next pickup: " + closestDistance.ToString();
            DrawLineToPickup(closestPickup.transform.position);
        }
    }

    void DrawLineToPickup(Vector3 pickupPosition)
    {
        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, pickupPosition);

    }
}
