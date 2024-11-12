using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections; // Ensure this is included

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Color originalColor;
    private Color hoverColor;

    private Vector3 originalScale;
    private Vector3 hoverScale;

    // Duration for the scaling effect
    public float scaleDuration = 0.2f;

    void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.GetComponent<Image>().color;
        hoverColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.7f); // 70% opacity

        originalScale = transform.localScale; // Store the original scale
        hoverScale = originalScale * 1.1f; // Increase scale by 10%
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Image>().color = hoverColor; // Change to hover color
        StopAllCoroutines(); // Stop any ongoing scaling
        StartCoroutine(ScaleButton(transform.localScale, hoverScale)); // Start scaling to hover size
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Image>().color = originalColor; // Revert to original color
        StopAllCoroutines(); // Stop any ongoing scaling
        StartCoroutine(ScaleButton(transform.localScale, originalScale)); // Start scaling back to original size
    }

    private IEnumerator ScaleButton(Vector3 from, Vector3 to)
    {
        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(from, to, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.localScale = to; // Ensure the final scale is set
    }
}