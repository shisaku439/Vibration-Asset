using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    
    public VibInfo vibInfo;//振動情報

    private Vector3 initPos;//初期座標
    private Vector3 randomOffset;//ノイズの基準値
    private Coroutine coroutine;//振動アニメーション
    private WaitForSeconds waitTime;

    private void Start()
    {
        //オフセットをランダムに設定
        randomOffset = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f));
    }

    //振動アニメーション再生
    public void StartVibration()
    {
        //すでにアニメーションが再生されていた場合停止させる
        StopVibration();

        //再生
        coroutine=StartCoroutine(VibAnimation());
    }

    //振動アニメーション停止
    public void StopVibration()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            this.transform.localPosition = initPos;
        }
    }


    //振動アニメーション
    private IEnumerator VibAnimation()
    {

        float totalTime = 0;//経過時間
        initPos = this.transform.localPosition;//初期座用の設定
        waitTime = new WaitForSeconds(vibInfo.duration);//アニメーション間隔

        while (totalTime < vibInfo.time)
        {
            //振動
            var randomX = GetPerlinNoiseValue(randomOffset.x, vibInfo.speed, totalTime);
            var randomY = GetPerlinNoiseValue(randomOffset.y, vibInfo.speed, totalTime);
            var randomZ = GetPerlinNoiseValue(randomOffset.x, vibInfo.speed, totalTime);

            //振動の強さ変更
            randomX *= vibInfo.vibCurve.Evaluate(totalTime / vibInfo.time) * vibInfo.strength;
            randomY *= vibInfo.vibCurve.Evaluate(totalTime / vibInfo.time) * vibInfo.strength;
            randomZ *= vibInfo.vibCurve.Evaluate(totalTime / vibInfo.time) * vibInfo.strength;


            //座標更新
            var pos = initPos;
            if (!vibInfo.x) pos.x += randomX;
            if (!vibInfo.y) pos.y += randomY;
            if (!vibInfo.z) pos.z += randomZ;
            this.transform.localPosition = pos;

            //経過時間更新
            totalTime += Time.deltaTime;

            yield return waitTime;
        }

        //初期座標に戻す
        this.transform.localPosition = initPos;
    }

    //ノイズ取得
    private float GetPerlinNoiseValue(float offset,float speed, float time)
    {
        var noise = Mathf.PerlinNoise(offset + speed * time, 0.0f);

        return (noise - 0.5f) * 2f;
    }


}
