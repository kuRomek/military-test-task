using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlaceableIndicator : MonoBehaviour
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    public void Init(int width, int height)
    {
        transform.localScale = new Vector3(width * 0.1f, 1f, height * 0.1f);
        SetGreenColor();
    }

    public void SetRedColor()
    {
        _material.color = new Color(1f, 0f, 0f, 0.3f);
    }

    public void SetGreenColor()
    {
        _material.color = new Color(0f, 1f, 0f, 0.3f);
    }
}
