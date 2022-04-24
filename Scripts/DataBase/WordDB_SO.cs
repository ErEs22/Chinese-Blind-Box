using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 汉字数据库
/// </summary>
[CreateAssetMenu(fileName = "WordDic", menuName = "WordDataBase")]
public class WordDB_SO : ScriptableObject
{
    public SplitWord[] splitWord;
    public Dictionary<string, List<string>> wordDic = new Dictionary<string, List<string>>();
    public void AddData()
    {
        foreach (var item in splitWord)
        {
            wordDic.Add(item.key, item.value);
        }
    }
}
