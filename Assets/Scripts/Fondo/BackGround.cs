using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private BGColor ganchoColor;
    [SerializeField] private BGColor manitoColor;
    [SerializeField] private BGColor betsiColor;
    [SerializeField] private BGColor noneColor;

    [SerializeField] private Material mat;

    private void FixedUpdate()
    {
        Debug.Log(mat.GetColor("_EmissionColor"));
    }

    private void Update()
    {
    }

    private void ChangeColor(Color a)
    {
        mat.SetColor("_EmissionColor", a);
    }

    public void ChangeBetsi()
    {
        ChangeColor(betsiColor.ToColor());
    }

    public void ChangeHand()
    {
        ChangeColor(manitoColor.ToColor());
    }

    public void ChangeGrapple()
    {
        ChangeColor(ganchoColor.ToColor());
    }
    public void ChangeNothing()
    {
        ChangeColor(noneColor.ToColor());
    }
}

[System.Serializable]
public class BGColor
{
    public float red;
    public float blue;
    public float green;

    public Color ToColor()
    {
        var result = new Color(red / 255, green / 255, blue / 255);
        return result;
    }
}