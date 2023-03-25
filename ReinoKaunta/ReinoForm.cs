using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReinoKaunta
{
    public partial class ReinoForm : Form
    {
        // コントロールとスコアを管理するクラスのリスト
        private List<ControlSet> controlSets;

        // コンストラクタ
        public ReinoForm()
        {
            InitializeComponent();

            // コントロールとスコアを管理するクラスのリストを初期化
            controlSets = new List<ControlSet>(4);
            controlSets.Add(new ControlSet(aname, ascore, ainc, adsc));
            controlSets.Add(new ControlSet(bname, bscore, binc, bdsc));
            controlSets.Add(new ControlSet(cname, cscore, cinc, cdsc));
            controlSets.Add(new ControlSet(dname, dscore, dinc, ddsc));
        }

        // ボタン押下共通メソッド
        private void buttonClick(object sender, EventArgs e)
        {
            // 押されたボタンを探す
            foreach (var controlSet in controlSets)
            {
                // +ボタンが押されていた場合
                if (controlSet.IncButton.Equals(sender))
                {
                    // 対応するスコアを加算して対応するスコアラベルに表示する
                    controlSet.Score++;
                    controlSet.ScoreLabel.Text = controlSet.Score.ToString();
                    break;
                }
                // -ボタンが押されていた場合
                if (controlSet.DscButton.Equals(sender))
                {
                    // 対応するスコアを減算して対応するスコアラベルに表示する
                    controlSet.Score--;
                    controlSet.ScoreLabel.Text = controlSet.Score.ToString();
                    break;
                }
            }
        }
    }

    // コントロールとスコアを管理するクラス
    public class ControlSet
    {
        public Label NameLabel { get; set; }
        public Label ScoreLabel { get; set; }
        public Button IncButton { get; set; }
        public Button DscButton { get; set; }

        // スコア
        public int Score { get; set; }

        // デフォルトコンストラクタを隠蔽
        private ControlSet() { }

        // コンストラクタ
        public ControlSet(Label nameLabel, Label scoreLabel, Button incButton, Button dscButton)
        {
            NameLabel = nameLabel;
            ScoreLabel = scoreLabel;
            IncButton = incButton;
            DscButton = dscButton;
            Score = 0;
        }
    }
}
