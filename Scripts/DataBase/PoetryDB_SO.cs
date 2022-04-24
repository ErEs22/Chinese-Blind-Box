using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 诗词数据库
/// </summary>

[CreateAssetMenu(fileName = "PoetryDic", menuName = "PoetryDataBase")]
public class PoetryDB_SO : ScriptableObject
{
    public Poetry[] poetry;
    public Dictionary<string, Poetry> poetryDic = new Dictionary<string, Poetry>();
    public void AddData()
    {
        foreach (var item in poetry)
        {
            poetryDic.Add(item.key, item);
        }
    }
}
