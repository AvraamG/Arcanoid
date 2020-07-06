using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{

    SpriteRenderer _spriteRenderer;



    private void OnEnable()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        UtilityManager.OnResolutionChanged += FitToOrthographicCamera;
    }





    /// <summary>
    /// Adjusts the size of the Sprite in order to fit in an orthographic view.
    /// </summary>
    private void FitToOrthographicCamera()
    {
        float ratio = (float)Screen.width / (float)Screen.height;
        Vector2 newSize = new Vector2(Camera.main.orthographicSize * 2 * ratio, Camera.main.orthographicSize * 2);
        _spriteRenderer.size = newSize;
    }


}
