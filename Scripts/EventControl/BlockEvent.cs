using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/// <summary>
/// 所有卡片的事件集合
/// </summary>
public class BlockEvent : MonoBehaviour
{
    Image image;
    public bool isSelected;//是否被选中
    public bool isCompared;//是否已配对
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {

    }
    public void SelectCard()//鼠标移动到卡片上的状态
    {
        if (!isSelected && !isCompared && !GameController.Instance.isListFull)
        {
            image.color = new Color(0, 213, 255, 1);
        }
    }
    public void CancelSelectCard()//鼠标移出卡片上的状态
    {
        if (!isSelected && !isCompared && !GameController.Instance.isListFull)
        {
            image.color = new Color(217, 151, 64, 0);
        }
    }
    public void ClickCard()//点击卡片执行的动作，选中状态取反，将这个对象加入选中卡片的集合中，如果为选中状态，再次点击移出集合并取消选中
    {
        if (isCompared || GameController.Instance.isListFull) return;//如果改卡片已配对或配对集合已满，则直接返回
        isSelected = !isSelected;
        if (isSelected)
        {
            GameController.Instance.selectedCards.Add(gameObject);
            image.color = new Color(0, 0, 255, 1);
            if (GameController.Instance.selectedCards.Count == 2)//添加对象到集合中之后进行判断，如果为2则满
            {
                GameController.Instance.isListFull = true;
            }
        }
        else//未被选中，将颜色修改为鼠标移入的颜色并移出集合
        {
            image.color = new Color(0, 213, 255, 1);
            GameController.Instance.selectedCards.Remove(gameObject);
        }
    }
}
