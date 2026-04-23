using UnityEngine.UI;
using UnityEngine;


public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    public Image hpMaskImage;
    public Image mpMaskImage;
    private float originalSize;

    void Awake()
    {
        Instance=this;
        originalSize=hpMaskImage.rectTransform.rect.width;
        SetHPValue(1);
    }
    public void SetHPValue(float fillPercent)
    {
        hpMaskImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,fillPercent*originalSize);
    }
    public void SetMPValue(float fillPercent)
    {
        mpMaskImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,fillPercent*originalSize);
    }
}
