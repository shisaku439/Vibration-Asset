using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create VibInfo")]
public class VibInfo : ScriptableObject
{
    [Header("�U����{���")]
    public float time;//�A�j���[�V��������
    public float duration;//�A�j���[�V�����Ԋu
    public float strength;//�U���̋���
    public float speed;//�U���̑���
    public AnimationCurve vibCurve;//�U���A�j���[�V�����̗���

    [Header("�U���Œ�")]
    public bool x;
    public bool y;
    public bool z;
}
