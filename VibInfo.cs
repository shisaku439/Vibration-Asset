using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create VibInfo")]
public class VibInfo : ScriptableObject
{
    [Header("振動基本情報")]
    public float time;//アニメーション時間
    public float duration;//アニメーション間隔
    public float strength;//振動の強さ
    public float speed;//振動の速さ
    public AnimationCurve vibCurve;//振動アニメーションの流れ

    [Header("振動固定")]
    public bool x;
    public bool y;
    public bool z;
}
