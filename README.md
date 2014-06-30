# Temp Run

とりあえず完成しているゲームを見てみましょう。

Unityを開き、`Demo`シーンを開きます。

### 環境を揃えましょう

* レイアウト: 2 by 3 

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2016.47.54.png)

### 明かりを作りましょう

Directional Lightを作ります。
ハードシャドウの設定をしましょう。

### 地面を作りましょう

GameObject → Create Other → Cube

名前を「Ground」としましょう。

適当に縦長になるようにグイーっと大きくしましょう
 
![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2016.54.30.png)

### シーンを保存しましょう

シーンを保存するのは大事です。


### モデルをシーンに出しましょう

`Player/Character/TeddyBear`をシーン上にドラッグ＆ドロップしましょう。

位置を（0,0,0）の位置に移動しましょう。

Groundの中に埋もれちゃいましたね。モデルのYを0.5にしてみましょう。うまくGroundの上に立ちました。

### カメラの位置を変えましょう

カメラの位置をクマの後ろに来るように調整してみましょう。

Positionを（0, 3, -2）、Rotationを（30, 0, 0）にすると期待するカメラの位置になります。

### 再生してみましょう

プレイボタンを押して再生してみましょう。何も起こりません。

### モデルにアニメーションを付けましょう

モデルに動きを与えてみましょう

`Assets/Player/Animations/Run`をシーン上のモデルに向けてドラッグ＆ドロップしましょう。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2017.22.15.png)

再生してみましょう。モデルが奥に走って行きました。

奥に走って行きましたがカメラが動いていないため、どんどんモデルが遠くに行ってしまいます。今回はモデルにカメラを追従させるようにしてみましょう。

`ヒエラルキー`を見て、**Main Camera**を**TeddyBear**にドラッグ＆ドロップしましょう。

再生してみましょう。カメラが追従するようになりました。

### 障害物を置こう

GameObject → Create Other → Cube

名前を**Block**とします。Groundの幅に収まるように横に細長い障害物を作りましょう。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2017.41.17.png)

細かい値を言うと、Positionが(0, 0.7, 4)、Scaleが(4, 0.4, 0.5)になります。

再生してみましょう。すり抜けちゃいました。でも今はこれでいいんです。

### 当たり判定を付けましょう

モデルが障害物に当たったという判定を実装していきましょう。

モデルに**Capsule Collider**をアタッチします。緑の枠がコライダーと言われる物があたったという判定を行えるエリアですが、モデルに対してズレてGroundに埋まってしまっています。

なのでCenterのYを少しずらし、Rudiusを変更して大きさをモデルに合わせましょう。

CenterのYは0.5、Rudiusは0.3に設定します。


次に、モデルに**Rigidbody**をアタッチします。これで当たり判定の準備が出来ました。再生してみましょう。

おや、再生直後に前に倒れてしまいました。

### 動きを制限しましょう

モデルが前に倒れた理由ですがこれは**Rigidbody**によって、重力が与えられ、**Capsule Collider**の下側が丸いことによって傾いてしまったためです。

今回、モデル、詳しく言えばゲームオブジェクトを傾かせるような実装は行いません。なのでRigidbodyの**Freeze Rotation**でX Y Zにチェックを入れてゲームを再生してみましょう。

前に進みましたね？障害物にぶつかりましたね？

### 障害物に色を付けましょう

これからこれからモデルと障害物に関係する実装を行っていくのですが、どちらも色が白いので見た目的にわかりにくいです。なので障害物に色を付けてみましょう。

Create -> Materialで新しくマテリアルを作成します。名前を**Block**としましょう。**Main Color**を青っぽくしましょう。

そしてそのマテリアルをシーン上の障害物に向けてドラッグ＆ドロップします。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2018.14.11.png)

### アニメーションを追加しましょう

これから「ぶつかったらゲームオーバー」というようにモデルが地面に倒れるというアニメーションを追加します。

説明はしませんでしたが、Runアニメーションをモデルに付けた時、Runアニメーションと同じ場所に**TeddyBear**というものができています。
これは複数のアニメーションを管理するための**アニメーターコントローラー**と呼ばれるものです。略してアニメーターとも呼びます。
TeddyBearアニメーションコントローラーをダブルクリックして**Animatorウィンドウ**を開きましょう

いま、真ん中辺りにオレンジ色のRunという「ステート」と呼ばれるものがあります。これがゲーム再生時直後に再生されているわけです。

Animatorウィンドウに`Assets/Player/Animations/Dying`をドラッグ＆ドロップしましょう。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2018.34.40.png)

アニメーションを追加できました。これからこのDyingアニメーションを**障害物にぶつかった時**に再生させます。

### アニメーションパラメータを追加しよう

アニメーターに「障害物にぶつかった」ということを伝えるため、パラメーターを作成します。

Animatorウィンドウの左下に**Parameters**という部分があるのでその右側の**+**ボタンをクリックしてください。そうするとさらにメニューが開くので、**Trigger**を選択します。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2018.43.40.png)

名前を**Dead**にしましょう。

### トランジションを作ろう

ステートからステートへ移動するにはトランジションを実装しなければいけません。

**Any State**で右クリックして**Make Transition**を選択し、「Dyingステート」をクリックしてトランジションをくっつけましょう。

> Any Stateは様々なステートから遷移できる便利なものです。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2020.17.31.png)


Transitionの矢印をクリックして、インスペクターにある**Conditions**を「Exit Time」から「Dead」に変更します。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2021.12.42.png)

さてこれでアニメーター側の設定は出来ました。

### スクリプトを書こう

スクリプトファイルを作成しましょう。

Create -> C# Script

名前を**Player**にしましょう。

**TeddyBear**ゲームオブジェクトのインスペクターを選択してPlayerスクリプトをインスペクターの**Add Component**ボタンへドラッグ＆ドロップしましょう

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2020.16.01.png)

Playerスクリプトの中身を書いていきます。

ですが今回は上にあるメニューの`PlayerScript/Step 1`を選択してください。そうすると自動でスクリプトコードが記述されます。

```
using UnityEngine;

public class Player : MonoBehaviour
{

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.name == "Block") {
			animator.SetTrigger ("Dead");
		}
	}
}
```

この状態でゲームを再生させましょう。

障害物にぶつかると倒れましたか？なんだかモデルが地面に埋め込まれちゃってますが今回は気にせずに進みましょう。

### 障害物を飛び越えるアニメーションを追加する（アニメーター）

`Assets/Player/Animations/Vaut`をAnimatorウィンドウにドラッグ＆ドロップします。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2020.51.56.png)

アニメーションパラメータで**Bool**を選択し、名前を**Vaut**にします。

Runステートの上で右クリックし、「Make Transition」でVautステートに繋げます。

そして、トランジションを「Exit Time」から「Vaut」に変更し**条件**が**true**であることを確認します。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2021.17.38.png)

最後にVautからRunへもトランジションを追加しましょう。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2021.19.03.png)

これでアニメーター側の設定は終わりました。

### 障害物を飛び越えるアニメーションを追加する（スクリプト）

次はスクリプトで矢印キーの上（UpArrow）のキー入力を受け取って飛び越えるアニメーションを再生させます。

今回は上にあるメニューの`PlayerScript/Step 2`を選択してください。そうすると自動でスクリプトコードが記述されます。

```
using UnityEngine;

public class Player : MonoBehaviour
{

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		animator.SetBool ("Vaut", Input.GetKeyDown (KeyCode.UpArrow));
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.name == "Block") {
			animator.SetTrigger ("Dead");
		}
	}
}
```

この状態で再生させましょう。矢印キーの上を押すと飛び越えるアニメーションが再生されます。ですが実際は飛び越えられずDead判定になってしまいます。

これは飛び越えるアニメーションをしていても当たり判定の範囲は飛び越える前と同じ範囲だからです。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2021.33.02.png)

これを修正する方法は2パターンあります。

* 飛び越えるアニメーションの再生中、当たり判定を行う**Capsule Collider**の大きさをモデルに合わせて変更すること。
* **Trigger（トリガー）**というものを使い障害物はすり抜けるを事をデフォとすること

今回はトリガーを使ってこの問題を解決しましょう。

### 障害物をトリガーにする

Blockのゲームオブジェクトを選択し、**BoxCollider**の**Is Trigger**にチェックを入れてください。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2021.45.25.png)

さて再生してみましょう。モデルが障害物をすり抜けましたか？

### トリガーの当たり判定を検出する

障害物のコライダーをトリガーにしたことによって動かなくなったスクリプトコードがあります。

それは`OnCollisionEnter`です。OnCollisionEnterはトリガーではないコライダーの当たり判定を検出するものです。

ではトリガーであるコライダーの当たり判定をどうやってスクリプトから検出するのか、それは`OnTriggerEnter`を使うようにすればいいのです。

スクリプトを書き換えましょう。今回は上にあるメニューの`PlayerScript/Step 3`を選択してください。そうすると自動でスクリプトコードが記述されます。

```
using UnityEngine;

public class Player : MonoBehaviour
{

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		animator.SetBool ("Vaut", Input.GetKeyDown (KeyCode.UpArrow));
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Block") {
			animator.SetTrigger ("Dead");
        }
    }
}
```

書き換えたらゲームを再生してみましょう。障害物に当たるとモデルが倒れるはずです。
これでトリガーによる当たり判定の検出が出来ました。ですがまだ障害物は飛び越えられません。つぎは障害物を飛び越えるようにしましょう。

### 障害物を飛び越える

飛び越える時、少し難しいかもしれませんが**「Vautアニメーションが再生中であれば障害物にあたっても無視する」**という条件をスクリプトで実装します。

スクリプトを書き換えましょう。今回は上にあるメニューの`PlayerScript/Step 4`を選択してください。そうすると自動でスクリプトコードが記述されます。

```
using UnityEngine;

public class Player : MonoBehaviour
{

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		animator.SetBool ("Vaut", Input.GetKeyDown (KeyCode.UpArrow));
	}

	void OnTriggerEnter (Collider other)
	{
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Vaut")) {
			return;
		}

		if (other.name == "Block") {
			animator.SetTrigger ("Dead");
		}
	}
}
```

ゲームを再生してみましょう。飛び越えることが出来ましたか？やっとゲームらしくなってきましたね。

飛び越えるタイミングによってはモデルの一部と障害物がすり抜けてしまうかもしれませんが、今回はこれでよしということで次に進みます。

### 障害物をくぐり抜ける

さて、次は障害物を飛び越えるのではなくて、くぐり抜けるようにしてみましょう。

### くぐり抜ける障害物を置こう

既に作成したBlockを複製します。

シーン上でBlockを選択して`Edit -> Duplicate`を選択します。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.17.25.png)

そうすると複製ができるので、Block同士が重ならないように少し横にずらしましょう。

片方のゲームオブジェクトの名前を**Hardle**にします。

さらに新しくマテリアルを作成し、名前を同じ**Hardle**にしましょう。

色は少し赤っぽくします。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.22.07.png)

最後に障害物を空中に置いておわりです。

障害物の位置は(0, 1.4, 10)としました。

### 障害物をくぐり抜けるアニメーションを追加する（アニメーター）

`Assets/Player/Animations/Slide`をAnimatorウィンドウにドラッグ＆ドロップします。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.04.29.png)

新しく**Bool**のアニメーターパラメーターを追加して、名前を**Slide**とします。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.10.43.png)

RunからSlideステートへトランジションを追加しましょう。そしてConditionsは**Slide: true**にします。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.11.57.png)

最後にSlideからRunステートにトランジションを追加します。Conditionsは「Exit Time」のままで結構です。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.13.41.png)

これでアニメーターの作業は終了です。

### 障害物をくぐり抜けるアニメーションを追加する（スクリプト）

2種類の障害物が出来たことによって2つの条件が生まれました。

* **Vaut（飛び越える）**アニメーション中に**Hardle**を通過してはいけない
* **Slide（くぐり抜ける）**アニメーション中に**Block**を通過してはいけない

スクリプトを書き換えましょう。今回は上にあるメニューの`PlayerScript/Step 5`を選択してください。そうすると自動でスクリプトコードが記述されます。

```
using UnityEngine;

public class Player : MonoBehaviour
{

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		animator.SetBool ("Vaut", Input.GetKeyDown (KeyCode.UpArrow));
		animator.SetBool ("Slide", Input.GetKeyDown (KeyCode.DownArrow));
	}

	void OnTriggerEnter (Collider other)
	{
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Vaut") && other.name == "Block") {
			return;
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Slide") && other.name == "Hardle") {
			return;
		}

		animator.SetTrigger ("Dead");
	}
}
```

再生しているアニメーションとぶつかったゲームオブジェクト名を比較することによって通過できるかどうかを判断します。

ゲームを再生してみましょう。

### ステージを作ろう

これでひと通りの実装は終わりました。いまは障害物が2つしか無いですし、ステージも短いです。

ひと通り作成してみましょう。

（時間5分位とってつくってみましょう）



### 霧を出そう

ステージが全部最初から見えてちゃつまらないですよね。なので霧を出して奥を見えなくしちゃいましょう。

`Edit -> Render Settings`を選択して

* **Fog**をチェック
* **Fog Density**を0.15

と設定しましょう。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.49.48.png)

### 背景を暗くしよう

青色ではなく霧と同じような色にしましょう。

**Main Camera**を選択してCameraのBackgroundを選択します。

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-06-30%2022.47.21.png)


ここで終了です。お疲れ様でした。

もし時間があるなら、リトライボタンやゴールを作成してみましょう。