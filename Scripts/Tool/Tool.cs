using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 工具类，提供自定义的各种方法
/// </summary>
public static class Tool
{
    /// <summary>
    /// 获取两个数之间的一个随机整数
    /// </summary>
    /// <param name="min">最小值</param>
    /// <param name="max">最大值</param>
    /// <returns></returns>
    public static int GetRandomNumber(int min, int max) => Random.Range(min, max);
    /// <summary>
    /// 获取两个数之间的一个随机浮点数
    /// </summary>
    /// <param name="min">最小值</param>
    /// <param name="max">最大值</param>
    /// <returns></returns>
    public static float GetRandomNumber(float min, float max) => Random.Range(min, max);
}
