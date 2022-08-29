# Vibration-Asset
オブジェクト（3D,2D）を振動させるUnity用アセット

ファイル内容

      Vibration.cs 振動させるスクリプト
      VibInfo.cs 振動情報を持つスクリプト

各スクリプトの解説

      Vibration.cs のInspector上のパラメータ
        VibInfo 振動情報を持つVibInfo.csを入れる

      VibInfo.cs のInspector上のパラメーター
        ※このスクリプトはScritableObjectを継承しているため
         Assets上で右クリックしCreate＞CreateVibInfoでPrefabを生成し
         パラメーターを設定する。
     
           Time 振動し続ける時間
           Duration アニメーションの間隔　（例 1を入れると1秒間隔に振動する）
           Strength　振動の振れ幅
           Speed　振動の速さ
           VibCurve　振動の変化　（例　右斜め下に直線を引くと時間経過でだんだん振動が弱くなる）

           X　X方向への振動を無効にする
           Y　Y方向への振動を無効にする
           Z　Z方向への振動を無効にする

使用の流れ

    1：振動させたいオブジェクトにVibration.cs をaddcomponentする
    2：Asset内で右クリックしCreate＞CreateVibInfoでPrefabを生成する
    3：Asset内でPrefabのInspectorから振動の情報を設定する
    4：設定したPrefabをVibrationのVibInfoに入れる
    5：他のスクリプトからVibration.cs内の StartVibration() メソッドを実行させる
