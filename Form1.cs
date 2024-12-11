using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapBuoi5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string selectedFont = toolStripComboBox1.SelectedItem.ToString();

            // Kiểm tra xem có văn bản nào được chọn không
            if (richTextBox1.SelectionLength > 0)
            {
                // Áp dụng font chữ cho văn bản được chọn
                richTextBox1.SelectionFont = new Font(selectedFont, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, áp dụng font chữ cho toàn bộ văn bản
                richTextBox1.Font = new Font(selectedFont, richTextBox1.Font.Size, richTextBox1.Font.Style);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                // Đặt kiểu chữ in đậm cho văn bản được chọn
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, đặt kiểu chữ in đậm cho toàn bộ văn bản
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Bold);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                // Đặt kiểu chữ in nghiêng cho văn bản được chọn
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, đặt kiểu chữ in nghiêng cho toàn bộ văn bản
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Italic);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                // Đặt kiểu chữ gạch chân cho văn bản được chọn
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, đặt kiểu chữ gạch chân cho toàn bộ văn bản
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Underline);
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(toolStripComboBox2.SelectedItem.ToString(), out int selectedSize))
            {
                // Kiểm tra xem có văn bản nào được chọn không
                if (richTextBox1.SelectionLength > 0)
                {
                    // Áp dụng cỡ chữ cho văn bản được chọn
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, selectedSize, richTextBox1.SelectionFont.Style);
                }
                else
                {
                    // Nếu không có văn bản nào được chọn, áp dụng cỡ chữ cho toàn bộ văn bản
                    richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, selectedSize, richTextBox1.Font.Style);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Chọn file để mở";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                saveFileDialog.Title = "Lưu file";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xóa nội dung hiện tại của RichTextBox
            richTextBox1.Clear();

            // Đặt lại tiêu đề của form (nếu cần)
            this.Text = "Untitled - My Text Editor"; // Bạn có thể thay đổi tiêu đề theo ý muốn
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Chọn file để mở";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Chọn file để mở";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            // Đặt lại tiêu đề của form (nếu cần)
            this.Text = "Untitled - My Text Editor";
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co chac chan thoat?", "Xac Nhan", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
