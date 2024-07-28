using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Pixel Perfect Outline/Sprite Outline")]
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteOutline : MonoBehaviour
{
    [Serializable]
    struct Directions
    {
        public bool top;
        public bool bottom;
        public bool left;
        public bool right;

        public Directions(bool top, bool bottom, bool left, bool right)
        {
            this.top = top;
            this.bottom = bottom;
            this.left = left;
            this.right = right;
        }
    }

    [SerializeField]
    [HideInInspector]
    Material material;

    [SerializeField]
    private Color outlineColor = Color.white;

    [SerializeField]
    private Directions directions = new Directions(true, true, true, true);
    private Color currentOutlineColor;
    private Rect currentRect;
    private Vector2 currentPivot;
    private float currentPixelsPerUnit;
    private Directions currentDirections;
    private SpriteRenderer spriteRenderer;

    private static readonly int Enabled = Shader.PropertyToID("_Enabled");

    public Color OutlineColor
    {
        get { return outlineColor; }
        set
        {
            outlineColor = value;
            UpdateProperties();
        }
    }

    public void SetEnabled(bool enabled)
    {
        spriteRenderer.material.SetFloat(Enabled, enabled ? 1 : 0);
    }

    private void Reset()
    {
        spriteRenderer.material = material;
        UpdateProperties();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateProperties();
    }

    private void LateUpdate()
    {
        UpdateProperties();
    }

    private void UpdateProperties()
    {
        Rect spriteRect = spriteRenderer.sprite.rect;
        Vector2 pivot = spriteRenderer.sprite.pivot;
        float pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;

        if (outlineColor == currentOutlineColor && spriteRect == currentRect && pivot == currentPivot &&
            Mathf.Approximately(pixelsPerUnit, currentPixelsPerUnit) && directions.Equals(currentDirections))
            return;

        MaterialPropertyBlock properties = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(properties);

        Vector4 vector = new Vector4(spriteRect.x, spriteRect.y, spriteRect.width, spriteRect.height);
        properties.SetVector("_RectPosSize", vector);
        properties.SetVector("_Pivot", pivot);
        properties.SetFloat("_PixelsPerUnit", pixelsPerUnit);
        properties.SetColor("_OutlineColor", enabled ? OutlineColor : Color.clear);

        properties.SetFloat("_Top", directions.top ? 1 : 0);
        properties.SetFloat("_Bottom", directions.bottom ? 1 : 0);
        properties.SetFloat("_Left", directions.left ? 1 : 0);
        properties.SetFloat("_Right", directions.right ? 1 : 0);

        spriteRenderer.SetPropertyBlock(properties);

        currentRect = spriteRect;
        currentPivot = pivot;
        currentPixelsPerUnit = pixelsPerUnit;
        currentOutlineColor = outlineColor;
        currentDirections = directions;
    }

    private void OnDrawGizmosSelected()
    {
        UpdateProperties();
    }
}
