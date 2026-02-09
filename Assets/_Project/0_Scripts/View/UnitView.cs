using UnityEngine;

public class UnitView : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    public void SetColor(Color c)
    {
        if (_renderer != null)
            _renderer.material.color = c;
    }
    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
    internal void SetFacing(float dirX)
    {
        if (dirX == 0f) return;
        Vector3 s = transform.localScale;
        s.x = Mathf.Abs(s.x) * (dirX > 0f ? 1f : -1f);
        transform.localScale = s;
    }
}