using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class HighlightOnMouseOver : MonoBehaviour
{
    [SerializeField] private Material basicMaterial;
    [SerializeField] private Material glowMaterial;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    void OnMouseEnter()
    {
        spriteRenderer.material = glowMaterial;
    }

    void OnMouseExit()
    {
        spriteRenderer.material = basicMaterial;
    }
}
