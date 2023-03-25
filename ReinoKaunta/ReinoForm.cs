using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReinoKaunta
{
    public partial class ReinoForm : Form
    {
        /// <summary>
        /// コントロールとスコアを管理するクラス
        /// </summary>
        private List<Controls> controls;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReinoForm()
        {
            InitializeComponent();

            //コントロールとスコアを管理するクラスを初期化
            controls = new List<Controls>(4);
            controls.Add(new Controls(aname, ascore, ainc, adsc));
            controls.Add(new Controls(bname, bscore, binc, bdsc));
            controls.Add(new Controls(cname, cscore, cinc, cdsc));
            controls.Add(new Controls(dname, dscore, dinc, ddsc));
        }

        /// <summary>
        /// ボタン押下共通メソッド
        /// </summary>
        /// <param name="sender">ボタン</param>
        /// <param name="e"></param>
        private void buttonClick(object sender, EventArgs e)
        {
            // 押されたボタンを探す
            foreach(var control in controls)
            {
                // +ボタンが押されていた場合
                if (control.IncButton.Equals(sender))
                {
                    // 対応するスコアを加算して対応するスコアラベルに表示する
                    control.Score++;
                    control.ScoreLabel.Text = control.Score.ToString();
                    break;
                }
                // -ボタンが押されていた場合
                if (control.DscButton.Equals(sender))
                {
                    // 対応するスコアを減算して対応するスコアらゲルに表示する
                    control.Score--;
                    control.ScoreLabel.Text = control.Score.ToString();
                    break;
                }
            }
        }
    }

    /// <summary>
    /// コントロールとスコアを管理するクラス
    /// </summary>
    public class Controls
    {
        /// <summary>
        /// 名前ラベル
        /// </summary>
        public Label NameLabel { get; set; }
        /// <summary>
        /// スコアラベル
        /// </summary>
        public Label ScoreLabel { get; set; }
        /// <summary>
        /// +ボタン
        /// </summary>
        public Button IncButton { get; set; }
        /// <summary>
        /// -ボタン
        /// </summary>
        public Button DscButton { get; set; }

        /// <summary>
        /// スコア
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// デフォコン隠蔽
        /// </summary>
        private Controls(){}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="namelabel">名前ラベル</param>
        /// <param name="scorelabel">スコアラベル</param>
        /// <param name="incbutton">+ボタン</param>
        /// <param name="dscbutton">-ボタン</param>
        public Controls(Label namelabel, Label scorelabel, Button incbutton, Button dscbutton)
        {
            NameLabel  = namelabel;
            ScoreLabel = scorelabel;
            IncButton  = incbutton;
            DscButton  = dscbutton;
            Score      = 0;
        }
    }

}
