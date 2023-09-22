using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class TalentHover : MonoBehaviour
{
    private Vector3 originalPosition;
    [SerializeField] private float hoverOffsetY = 5f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        bool isPointerOver = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, Camera.main);

        if (isPointerOver)
        {
            transform.localPosition = new Vector3(originalPosition.x, originalPosition.y + hoverOffsetY, originalPosition.z);
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}