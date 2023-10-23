using UnityEngine;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour
{
    [SerializeField] private TextMesh textComponent;
    [SerializeField] private float floatSpeed = 1f;
    [SerializeField] private float fadeDuration = 1f;

    private string textToDisplay;

    public void Init(string text)
    {
        textToDisplay = text;
        textComponent.text = textToDisplay;
        Destroy(gameObject, fadeDuration);
    }

    private void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }
}