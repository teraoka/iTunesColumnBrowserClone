using System.Windows.Forms;
using System.Drawing;

namespace ListTest
{
    public class DesinedListBox : System.Windows.Forms.ListBox
    {
        private static Color normalColor = Color.FromArgb(242, 245, 249);
        private static Color selectedColor = Color.FromArgb(75, 149, 229);
        private static Color unfocusColor = Color.FromArgb(203, 203, 203);

        private void drawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            SolidBrush backBrush;
            Brush textBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                {
                    // 選択されてる(アクティブ)
                    backBrush = new SolidBrush(selectedColor);
                    textBrush = Brushes.White;
                }
                else
                {
                    // 選択されてる(非アクティブ)
                    backBrush = new SolidBrush(unfocusColor);
                    textBrush = Brushes.Black;
                }
                
            }
            else
            {
                // 選択されてない
                backBrush = new SolidBrush(normalColor);
                textBrush = Brushes.Black;
            }

            // 背景描画
            e.Graphics.FillRectangle(backBrush, e.Bounds);

            // アンチエイリアス処理を施し、文字描画
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);
        }

        public DesinedListBox()
        {
            // スクロールバーは常に表示
            ScrollAlwaysVisible = true;

            // デザイン調整
            Font = new System.Drawing.Font("メイリオ", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ItemHeight = 18;
            BackColor = normalColor;

            // 描画は自分で行う
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            DrawItem += new System.Windows.Forms.DrawItemEventHandler(drawItem);
        }
    }
}
