using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    
    public VibInfo vibInfo;//�U�����

    private Vector3 initPos;//�������W
    private Vector3 randomOffset;//�m�C�Y�̊�l
    private Coroutine coroutine;//�U���A�j���[�V����
    private WaitForSeconds waitTime;

    private void Start()
    {
        //�I�t�Z�b�g�������_���ɐݒ�
        randomOffset = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f));
    }

    //�U���A�j���[�V�����Đ�
    public void StartVibration()
    {
        //���łɃA�j���[�V�������Đ�����Ă����ꍇ��~������
        StopVibration();

        //�Đ�
        coroutine=StartCoroutine(VibAnimation());
    }

    //�U���A�j���[�V������~
    public void StopVibration()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            this.transform.localPosition = initPos;
        }
    }


    //�U���A�j���[�V����
    private IEnumerator VibAnimation()
    {

        float totalTime = 0;//�o�ߎ���
        initPos = this.transform.localPosition;//�������p�̐ݒ�
        waitTime = new WaitForSeconds(vibInfo.duration);//�A�j���[�V�����Ԋu

        while (totalTime < vibInfo.time)
        {
            //�U��
            var randomX = GetPerlinNoiseValue(randomOffset.x, vibInfo.speed, totalTime);
            var randomY = GetPerlinNoiseValue(randomOffset.y, vibInfo.speed, totalTime);
            var randomZ = GetPerlinNoiseValue(randomOffset.x, vibInfo.speed, totalTime);

            //�U���̋����ύX
            randomX *= vibInfo.vibCurve.Evaluate(totalTime / vibInfo.time) * vibInfo.strength;
            randomY *= vibInfo.vibCurve.Evaluate(totalTime / vibInfo.time) * vibInfo.strength;
            randomZ *= vibInfo.vibCurve.Evaluate(totalTime / vibInfo.time) * vibInfo.strength;


            //���W�X�V
            var pos = initPos;
            if (!vibInfo.x) pos.x += randomX;
            if (!vibInfo.y) pos.y += randomY;
            if (!vibInfo.z) pos.z += randomZ;
            this.transform.localPosition = pos;

            //�o�ߎ��ԍX�V
            totalTime += Time.deltaTime;

            yield return waitTime;
        }

        //�������W�ɖ߂�
        this.transform.localPosition = initPos;
    }

    //�m�C�Y�擾
    private float GetPerlinNoiseValue(float offset,float speed, float time)
    {
        var noise = Mathf.PerlinNoise(offset + speed * time, 0.0f);

        return (noise - 0.5f) * 2f;
    }


}
