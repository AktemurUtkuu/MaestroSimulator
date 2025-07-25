using UnityEngine;
using TMPro;

public class ShowPromptUI : MonoBehaviour
{
    public TMP_Text promptText; // UI Text buraya atanacak (veya TMP_Text)
    public float fadeSpeed = 5f;

    private bool isPlayerNear = false;

    void Start()
    {
        SetAlpha(0); // Baþlangýçta görünmez
    }

    void Update()
    {
        if (isPlayerNear)
        {
            // Ekranda görünür hale getir
            SetAlpha(Mathf.Lerp(promptText.color.a, 1f, Time.deltaTime * fadeSpeed));
        }
        else
        {
            // Yazýyý yavaþça gizle
            SetAlpha(Mathf.Lerp(promptText.color.a, 0f, Time.deltaTime * fadeSpeed));
        }
    }

    void SetAlpha(float a)
    {
        Color c = promptText.color;
        c.a = a;
        promptText.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}
