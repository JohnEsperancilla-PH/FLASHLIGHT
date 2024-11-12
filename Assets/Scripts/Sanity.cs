using UnityEngine;

public class SanitySystem : MonoBehaviour
{
    [SerializeField] private Transform playerCamera; // Reference to the player's camera
    [SerializeField] private Transform target; // The object or enemy that drains sanity
    [SerializeField] private float drainRate = 5f; 
    [SerializeField] private float recoveryRate = 3f;
    [SerializeField] private float maxSanity = 100f;
    
    private float currentSanity;

    void Start()
    {
        // Initialize sanity to the maximum value at the start
        currentSanity = maxSanity;
    }

    void Update()
    {
        if (IsLookingAtTarget())
        {
            DrainSanity(Time.deltaTime * drainRate);
        }
        else 
        {
            RecoverSanity(Time.deltaTime * recoveryRate);
        }
        
        // Optional: Reset sanity if it reaches zero (can be replaced with game over or other logic)
        if (currentSanity <= 0)
        {
            Debug.Log("Player sanity has reached zero!");
            // Implement any additional logic for when sanity is depleted (e.g., game over, hallucinations, etc.)
        }
    }

    private bool IsLookingAtTarget()
    {
        // Perform a Raycast from the player's camera forward
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object hit by the ray is the target
            return hit.transform == target;
        }

        return false;
    }

    private void DrainSanity(float amount)
    {
        // Reduce sanity by the given amount, ensuring it doesn't go below zero
        currentSanity = Mathf.Max(currentSanity - amount, 0);
        Debug.Log("Current Sanity: " + currentSanity);
    }

    private void RecoverSanity(float amount)
    {
        currentSanity = Mathf.Min(currentSanity + amount, maxSanity);
        Debug.Log("Recovering Sanity:" + currentSanity);
    }

    public float GetSanity()
    {
        return currentSanity;
    }

    public void RestoreSanity(float amount)
    {
        // Method to restore sanity by a specific amount (optional)
        currentSanity = Mathf.Min(currentSanity + amount, maxSanity);
    }
}
