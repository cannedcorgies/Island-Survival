using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDecreaseRate = 1f;
    public float hungerIncreaseAmount = 20f;

    public Slider hungerSlider;

    public KeyCode eatKey = KeyCode.E; // The key to press for eating

    void Start()
    {
        currentHunger = maxHunger;
        InvokeRepeating("DecreaseHunger", 1f, 1f);
    }

    void Update()
    {
        if (currentHunger <= 0f)
        {
            Debug.Log("Game Over - Starved!");
        }

        UpdateHungerUI();

        // Check if the player presses the eat key
        if (Input.GetKeyDown(eatKey))
        {
            TryEat();
        }
    }

    void DecreaseHunger()
    {
        currentHunger -= hungerDecreaseRate;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
    }

    void TryEat()
    {
        // Raycast to detect the object to eat
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            // Check if the hit object has a specific tag (e.g., "Food")
            if (hit.collider.CompareTag("Food"))
            {
                EatObject(hit.collider.gameObject);
            }
        }
    }

    void EatObject(GameObject objectToEat)
    {
        // Destroy the object (you can replace this with your specific logic)
        Destroy(objectToEat);

        // Increase hunger when eating
        currentHunger += hungerIncreaseAmount;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
    }

    void UpdateHungerUI()
    {
        if (hungerSlider != null)
        {
            hungerSlider.value = currentHunger / maxHunger;
        }
    }
}
