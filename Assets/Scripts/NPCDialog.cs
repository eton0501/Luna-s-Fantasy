using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    private List<DialogInfo[]> dialogInfoList;
    public int contentIndex;
    public Animator animator;

    
    void Start()
    {
        dialogInfoList = new List<DialogInfo[]>()
        {
            new DialogInfo[]{
                new DialogInfo() {name="Luna",content="(,,･∀･)ﾉ゛hello，我是LuNa，你可以用上下左右控制我移動，空白鍵與NPC對話，戰鬥中需要簡單點擊按鈕執行對應行為" }
            },
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="好久不見了，小貓咪(*ΦωΦ*)，Luna~" },
                new DialogInfo() {name="Luna",content="好久不見，Nala,你還是那麼有活力，哈哈" },
                new DialogInfo() {name="Nala",content="還好吧~" },
                new DialogInfo() {name="Nala",content="我的狗一直在叫，但是我這會忙不過來，你能幫我安撫一下它嗎？" },
                new DialogInfo() {name="Luna",content="啊？" },
                new DialogInfo() {name="Nala",content="(,,´•ω•)ノ(´っω•｀。)摸摸他就行，摸摸說呦西呦西，真是個好孩子吶" },
                new DialogInfo() {name="Nala",content="別看他叫的這麼兇，其實他就是想引起別人的注意" },
                new DialogInfo() {name="Luna",content="可是。。。。" },
                new DialogInfo() {name="Luna",content="我是貓女郎啊" },
                new DialogInfo() {name="Nala",content="安心啦，不會咬你的，去吧去吧~" },
            },
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="他還在叫呢" }
            },
            //3
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="感謝你吶，Luna，你還是那麼可靠！" },
                new DialogInfo() {name="Nala",content="我想請你幫個忙好嗎" },
                new DialogInfo() {name="Nala",content="說起來這事怪我。。。" },
                new DialogInfo() {name="Nala",content="今天我睡過頭了，出門比較匆忙" },
                new DialogInfo() {name="Nala",content="然後裝蠟燭的袋子口子沒封好!o(╥﹏╥)o" },
                new DialogInfo() {name="Nala",content="結果就。 。 。蠟燭基本上丟完了" },
                new DialogInfo() {name="Luna",content="你還是老樣子，哈哈。。" },
                new DialogInfo() {name="Nala",content="所以，所以嘍，你幫忙，幫我把蠟燭找回來" },
                new DialogInfo() {name="Nala",content="如果你能幫我找回全部的5根蠟燭，我就送你一把神器" },
                new DialogInfo() {name="Luna",content="神器？(¯﹃¯)" },
                new DialogInfo() {name="Nala",content="是的，我覺得很適合你，加油吶~" },
            },
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="你還沒幫我收集到所有的蠟燭，寶~" },
            },
            //5
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="可靠啊！竟然一個不差的全收集回來了" },
                new DialogInfo() {name="Luna",content="你知道多累嗎？" },
                new DialogInfo() {name="Luna",content="你到處跑，真的很難收集" },
                new DialogInfo() {name="Nala",content="辛苦啦辛苦啦" },
                new DialogInfo() {name="Nala",content="這是給你的獎勵" },
                new DialogInfo() {name="Nala",content="藍紋火錘，傳說中的神器" },
                new DialogInfo() {name="Nala",content="應該挺適合你的" },
                new DialogInfo() {name="Luna",content="~獲得藍紋火鎚~~（遇到怪物可觸發戰鬥）" },
                new DialogInfo() {name="Luna",content="哇，謝謝你！Thanks♪(･ω･)ﾉ" },
                new DialogInfo() {name="Nala",content="嘿嘿(*^▽^*)，咱們的關係不用客氣" },
                new DialogInfo() {name="Nala",content="正好，最近山裡出現了一堆怪物，你也算是民除害，幫忙清理5隻怪物" },
                new DialogInfo() {name="Luna",content="啊？" },
                new DialogInfo() {name="Luna",content="這才是你的真實目的吧？！" },
                new DialogInfo() {name="Nala",content="拜託拜託啦，否則真的很不方便我賣東西" },
                new DialogInfo() {name="Luna",content="無語中。。。" },
                new DialogInfo() {name="Nala",content="求求你了，啵啵~" },
                new DialogInfo() {name="Luna",content="哎，行吧，誰讓你大呢~" },
                new DialogInfo() {name="Nala",content="嘻嘻，那辛苦寶子啦" }
            },
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="寶，你還沒清理乾淨呢,這樣我不方便嘛~" },
            },
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="真棒，luna，周圍的居民都會十分感謝你的，有機會來我家喝一杯吧~" },
                new DialogInfo() {name="Luna",content="我覺得可行，哈哈~" }
            },
            new DialogInfo[]{
                new DialogInfo() {name="Nala",content="改天見嘍~" },
            }
        };
        GameManager.Instance.dialogInfoIndex = 0;
        contentIndex = 1;
    }
    
    public void DisplayDialog()
    {
        if (GameManager.Instance.dialogInfoIndex > 7)
        {
            return;
        }
        if (contentIndex >= dialogInfoList[GameManager.Instance.dialogInfoIndex].Length)
        {
            if (GameManager.Instance.dialogInfoIndex == 2 &&
                !GameManager.Instance.hasPetTheDog)
            {

            }
            else if (GameManager.Instance.dialogInfoIndex == 4 &&
                GameManager.Instance.candleNum < 5)
            {

            }
            else if (GameManager.Instance.dialogInfoIndex == 6 &&
                GameManager.Instance.killNum < 5)
            {

            }
            else
            {
                GameManager.Instance.dialogInfoIndex++;
            }
            if (GameManager.Instance.dialogInfoIndex == 6)
            {
                GameManager.Instance.ShowMonsters();
            }

            
            contentIndex = 0;
            UIManger.Instance.ShowDialog();
            GameManager.Instance.canControlLuna = true;
        }
        else
        {
            DialogInfo dialogInfo = dialogInfoList[GameManager.Instance.dialogInfoIndex][contentIndex];
            UIManger.Instance.ShowDialog(dialogInfo.content, dialogInfo.name);
            contentIndex++;
            animator.SetTrigger("Talk");
        }
    }

    
    public void SetContentIndex()
    {
        contentIndex = dialogInfoList[GameManager.Instance.dialogInfoIndex].Length;
    }
}

public struct DialogInfo
{
    public string name;
    public string content;
}
