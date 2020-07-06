using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Wall : MonoBehaviour
{
    public enum WallPlacement
    {
        Top,
        Left,
        Right,
        Bot

    }

    [SerializeField]
    float thickness = 1f;
    SpriteRenderer _spriteRenderer;
    BoxCollider2D _boxCollider2D;

    public WallPlacement placement;
    private void OnEnable()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _boxCollider2D = this.GetComponent<BoxCollider2D>();

        UtilityManager.OnResolutionChanged += FitToOrthographicCamera;
    }
    /// <summary>
    /// Adjusts the size of the Sprite in order to fit in an orthographic view.
    /// </summary>
    private void FitToOrthographicCamera()
    {
        Debug.Log("Wall fit");
        float ratio = (float)Screen.width / (float)Screen.height;
        Vector2 newSize;
        if (placement == WallPlacement.Bot || placement == WallPlacement.Top)
        {
            newSize = new Vector2(thickness, Camera.main.orthographicSize * 2);

        }
        else
        {
            newSize = new Vector2(Camera.main.orthographicSize * 2 * ratio, thickness);

        }
        _boxCollider2D.size = newSize;
        _spriteRenderer.size = newSize;

    }
}
