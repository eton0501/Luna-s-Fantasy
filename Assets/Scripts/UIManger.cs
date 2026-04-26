using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;


public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    public Image hpMaskImage;
    public Image mpMaskImage;
    private float originalSize;
    public GameObject battlePanelGo;
    public GameObject talkPanelGo;
    public Sprite[] characterSprtes;
    public Image characterImage;
    public Text contentText;
    public Text nameText;

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

    public void ShowOrHideBattlePanel(bool show)
    {
        battlePanelGo.SetActive(show);
    }
    public void ShowDialog(string content=null,string name = null)
    {
        if (content == null)
        {
            talkPanelGo.SetActive(false);
        }
        else
        {
            talkPanelGo.SetActive(true);
            if (name != null)
            {
                if (name == "Luna")
                {
                    characterImage.sprite=characterSprtes[0];
                }
                else
                {
                    characterImage.sprite=characterSprtes[1];
                }
                characterImage.SetNativeSize();
            }
            contentText.text=content;
            nameText.text=name;
        }
    }
}
