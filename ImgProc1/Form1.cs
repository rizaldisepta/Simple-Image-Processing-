using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgProc1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bukaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "Image File (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";
            if (DialogResult.OK == bukaFile.ShowDialog())
            {
                this.pbInput.Image = new Bitmap(bukaFile.FileName);
                this.pbOutput.Image = new Bitmap(bukaFile.FileName);
                Bitmap img = new Bitmap(bukaFile.FileName);
                var imageHeight = img.Height;
                var imageWidth = img.Width;
                stripStatus1.Text = bukaFile.FileName;
                stripStatus2.Text = Convert.ToString(imageWidth) + "x" + Convert.ToString(imageHeight);



            }
        }

        private void simpanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbOutput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan disimpan");
            }
            else
            {
                SaveFileDialog simpanFile = new SaveFileDialog();
                simpanFile.Title = "Simpan File Citra";
                simpanFile.Filter = "Image File (*.bmp, *.jpg,*.jpeg)| *.bmp; *.jpg; *.jpeg";
                if (DialogResult.OK == simpanFile.ShowDialog())
                    this.pbOutput.Image.Save(simpanFile.FileName);
            }
        }

        private void tutupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                this.Close();
            }
        }
        private void luminanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {

                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                ProgressBar1.Visible = true;

                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        double hasil = (0.21 * c1.R) + (0.72 * c1.G) + (0.07 * c1.B);
                        b.SetPixel(i, j, Color.FromArgb((int)hasil, (int)hasil, (int)hasil));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;

            }
        }
        private void lightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {

                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                ProgressBar1.Visible = true;

                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);

                        double max = Math.Max(c1.R, Math.Max(c1.G, c1.B));
                        double min = Math.Min(c1.R, Math.Min(c1.G, c1.B));
                        double hasil = (max + min) / 2;
                        b.SetPixel(i, j, Color.FromArgb((int)hasil, (int)hasil, (int)hasil));

                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private static int truncate(int x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }
        private void brightnessAndContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yg diolah");
            }
            else
            {
                FormBrCr frm2 = new FormBrCr();
                if (frm2.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    int nilaiBrightness = Convert.ToInt16(frm2.txtBrightness.Text);
                    double nilaiContrast = Convert.ToInt16(frm2.txtContrast.Text);
                    double faktor = (259 * (nilaiContrast + 255)) / (255 * (259 - nilaiContrast));
                    ProgressBar1.Visible = true;
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int r1 = truncate(c1.R + nilaiBrightness + (int)truncate2(faktor * (c1.R - 128) + 128));
                            int g1 = truncate(c1.G + nilaiBrightness + (int)truncate2(faktor * (c1.G - 128) + 128));
                            int b1 = truncate(c1.B + nilaiBrightness + (int)truncate2(faktor * (c1.B - 128) + 128));
                            b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }


            }




        }

        private static double truncate2(double x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pbInput.Image == null)
                {
                    MessageBox.Show("Tidak Ada citra yang akan diolah");
                }
                else
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    ProgressBar1.Visible = true;
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int r1 = 255 - c1.R;
                            int g1 = 255 - c1.G;
                            int b1 = 255 - c1.B;
                            b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }
            }
        }

        private void logBrightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yg diolah");
            }
            else

            {
                FormLogBrightness frmlogBrightness = new FormLogBrightness();
                if (frmlogBrightness.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    ProgressBar1.Visible = true;
                    double nilaiLogBrightness = Convert.ToInt16(frmlogBrightness.tB_LogBrightness.Text);
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            double r1 = nilaiLogBrightness * (Math.Log10(1 + Math.Abs(c1.R)));
                            double g1 = nilaiLogBrightness * (Math.Log10(1 + Math.Abs(c1.G)));
                            double b1 = nilaiLogBrightness * (Math.Log10(1 + Math.Abs(c1.B)));
                            b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(r1), Convert.ToInt16(g1), Convert.ToInt16(b1)));

                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }


            }
        }

        private void logContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                FormLogContrast frmlogContrast = new FormLogContrast();
                if (frmlogContrast.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    ProgressBar1.Visible = true;
                    double nilaiLogContrast = Convert.ToInt16(frmlogContrast.tB_LogContrast.Text);
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);

                            double factor = (259 * (nilaiLogContrast + 255)) / (255 * (259 - nilaiLogContrast));

                            double r1 = ((factor * (c1.R) - 128) + 128) * (Math.Log10(1 + Math.Abs(c1.R)));
                            double g1 = ((factor * (c1.G) - 128) + 128) * (Math.Log10(1 + Math.Abs(c1.G)));
                            double b1 = ((factor * (c1.B) - 128) + 128) * (Math.Log10(1 + Math.Abs(c1.B)));
                            b.SetPixel(i, j, Color.FromArgb((int)r1, (int)g1, (int)b1));

                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }
            }
        }

        private void gammaCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                GammaCorrection frmGammaCorrection = new GammaCorrection();
                if (frmGammaCorrection.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    ProgressBar1.Visible = true;
                    double nilaiGamma = Convert.ToDouble(frmGammaCorrection.tB_Gamma.Text);
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            double merah = b.GetPixel(i, j).R;
                            double hijau = b.GetPixel(i, j).G;
                            double biru = b.GetPixel(i, j).B;

                            double r1 = 255 * Math.Pow(merah / 255, 1 / nilaiGamma);
                            double g1 = 255 * Math.Pow(hijau / 255, 1 / nilaiGamma);
                            double b1 = 255 * Math.Pow(biru / 255, 1 / nilaiGamma);

                            b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(r1), Convert.ToInt16(g1), Convert.ToInt16(b1)));

                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }
            }
        }

        private void sephiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            ProgressBar1.Visible = true;
            int depth = 60;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    int Ko = (c1.R + c1.G + c1.B) / 3;
                    int Ro = Ko + (depth * 2);
                    int Go = Ko + depth;
                    int Bo = Ko;
                    b.SetPixel(i, j, Color.FromArgb(truncate(Ro), truncate(Go), truncate(Bo)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        double hasil = (c1.R + c1.G + c1.B) / 3;
                        b.SetPixel(i, j, Color.FromArgb((int)hasil, (int)hasil, (int)hasil));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;

            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap copy = new Bitmap((Bitmap)this.pbInput.Image);
            olahCitra.keBrightness(copy);
            this.pbOutput.Image = copy;
        }

        private void bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 1) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(hasil2), Convert.ToInt16(hasil2), Convert.ToInt16(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void bitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 2) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb((int)(hasil2), (int)(hasil2), (int)(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void bitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 7) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(hasil2), Convert.ToInt16(hasil2), Convert.ToInt16(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void bitToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 3) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(hasil2), Convert.ToInt16(hasil2), Convert.ToInt16(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void bitToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 4) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(hasil2), Convert.ToInt16(hasil2), Convert.ToInt16(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void bitToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 5) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(hasil2), Convert.ToInt16(hasil2), Convert.ToInt16(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void bitToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            double level = Math.Round(255 / (Math.Pow(2, 6) - 1));
            ProgressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);

                    double hasil = (c1.R + c1.G + c1.B) / 3;

                    double hasil2 = Math.Round((hasil / level)) * level;

                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(hasil2), Convert.ToInt16(hasil2), Convert.ToInt16(hasil2)));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = b;
        }

        private void averageDenoisingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
            List<Image> pictureArray = new List<Image>();
            foreach (string item in Directory.GetFiles(folderDlg.SelectedPath, "*.jpg", SearchOption.AllDirectories))
            {
                Image _image = Image.FromFile(item); pictureArray.Add(_image);
            }
            pbInput.Image = pictureArray[0];
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            Bitmap c = new Bitmap((Bitmap)this.pbInput.Image);
            stripStatus1.Text = "Res. Citra: " + pbInput.Image.Width + " x " + pbInput.Image.Height;
            ProgressBar1.Visible = true;
            int R, G, B, newR, newG, newB;
            //nilai 50 berikut menunjukkan jumlah citra, yang diproses adalah 50 citra
            int jumGambar = 30;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    R = 0;
                    G = 0;
                    B = 0;

                    for (int k = 0; k < jumGambar - 1; k++)
                    {
                        b = (Bitmap)pictureArray[k];
                        Color c1 = b.GetPixel(i, j);
                        R = R + c1.R;
                        G = G + c1.G;
                        B = B + c1.B;
                    }

                    newR = R / jumGambar;
                    newG = G / jumGambar;
                    newB = B / jumGambar;
                    c.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                }
                ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / c.Width);
            }
            ProgressBar1.Visible = false;
            this.pbOutput.Image = c;
        }
        private static double warnaTerdekat(int pValueR, int pValueG, int pValueB)
        {
            double minDistance = 255 * 255 + 255 * 255 + 255 * 255;
            int palColor, rDiff, gDiff, bDiff;
            double pValueR1 = 0;
            double distance;
            //set warna pallete: hitam, merah, hijau, kuning, biru, cyan, magenta, putih
            int[,] palletteColor = new int[,] { { 0, 0, 0 }, { 255, 0, 0 }, { 0, 255, 0 }, { 255, 255, 0 }, { 0, 0, 255 }, { 0, 255, 255 }, { 255, 0, 255 }, { 255, 255, 255 } };
            for (palColor = 0; palColor <= palletteColor.GetLength(0) - 1; palColor++)
            {

                //rDiff = pValueR - palletteColor[palColor, 0];
                //0 1 2 ngambil dari Array di atas

                rDiff = pValueR - palletteColor[palColor, 0];
                gDiff = pValueG - palletteColor[palColor, 1];
                bDiff = pValueB - palletteColor[palColor, 2];
                distance = rDiff * rDiff + gDiff * gDiff + bDiff * bDiff;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    pValueR1 = palColor;
                }
            }
            return pValueR1;
        }
        private void nearest8ColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
                MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                double baru;
                int[,] palletteColor = new int[,] { { 0, 0, 0 }, { 255, 0, 0 }, { 0, 255, 0 }, { 255, 255, 0 }, { 0, 0, 255 }, { 0, 255, 255 }, { 255, 0, 255 }, { 255, 255, 255 } };
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                this.pbOutput.Image = b;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        baru = warnaTerdekat(c1.R, c1.G, c1.B);
                        b.SetPixel(i, j, Color.FromArgb(palletteColor[Convert.ToInt16(baru), 0], palletteColor[Convert.ToInt16(baru), 1], palletteColor[Convert.ToInt16(baru), 2]));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void errorDiffusionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
                MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                int[,] palletteColor = new int[,] { { 0, 0, 0 }, { 255, 0, 0 }, { 0, 255, 0 }, { 255, 255, 0 }, { 0, 0, 255 }, { 0, 255, 255 }, { 255, 0, 255 }, { 255, 255, 255 } };
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                this.pbOutput.Image = b;
                int merah, hijau, biru;
                double baru, errorR, errorG, errorB;
                ProgressBar1.Visible = true;
                for (int i = 0; i <= b.Width - 2; i++)
                {
                    for (int j = 0; j <= b.Height - 2; j++)
                    {
                        merah = b.GetPixel(i, j).R;
                        hijau = b.GetPixel(i, j).G;
                        biru = b.GetPixel(i, j).B;
                        baru = warnaTerdekat(merah, hijau, biru);
                        errorR = merah - palletteColor[Convert.ToInt16(baru), 0];
                        errorG = merah - palletteColor[Convert.ToInt16(baru), 1];
                        errorB = merah - palletteColor[Convert.ToInt16(baru), 2];
                        Color c1 = b.GetPixel(i + 1, j);
                        b.SetPixel(i + 1, j, Color.FromArgb(Convert.ToInt16(truncate2(c1.R + ((7 / 16) * errorR))), Convert.ToInt16(truncate2(c1.G + ((7 / 16) * errorG))), Convert.ToInt16(truncate2(c1.B + ((7 / 16) * errorB)))));
                        if (i != 0)
                        {
                            Color c2 = b.GetPixel(i - 1, j + 1);
                            b.SetPixel(i - 1, j + 1, Color.FromArgb(Convert.ToInt16(truncate2(c2.R + ((3 / 16) * errorR))), Convert.ToInt16(truncate2(c2.G + ((3 / 16) * errorG))), Convert.ToInt16(truncate2(c2.B + ((3 / 16) * errorB)))));
                        }
                        Color c3 = b.GetPixel(i, j + 1);
                        b.SetPixel(i, j + 1, Color.FromArgb(Convert.ToInt16(truncate2(c3.R + ((5 / 16) * errorR))), Convert.ToInt16(truncate2(c3.G + ((5 / 16) * errorG))), Convert.ToInt16(truncate2(c3.B + ((5 / 16) * errorB)))));
                        Color c4 = b.GetPixel(i + 1, j + 1);
                        b.SetPixel(i + 1, j + 1, Color.FromArgb(Convert.ToInt16(truncate2(c4.R + ((1 / 16) * errorR))), Convert.ToInt16(truncate2(c4.G + ((1 / 16) * errorG))), Convert.ToInt16(truncate2(c4.B + ((1 / 16) * errorB)))));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Refresh();
                this.pbOutput.Image = b;
            }
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pbInput.Image == null)
                    MessageBox.Show("Tidak ada citra yang akan diolah");
                else
                {
                    double[] HistoR = new double[256];
                    double[] HistoG = new double[256];
                    double[] HistoB = new double[256];
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    Greyscale_Histogram frm5 = new Greyscale_Histogram();
                    RGB_Histogram frm6 = new RGB_Histogram();
                    for (int i = 0; i < 255; i++)
                    {
                        HistoR[i] = 0;
                        HistoG[i] = 0;
                        HistoB[i] = 0;
                    }
                    for (int i = 0; i <= 255; i++)
                    {
                        for (int j = 0; j <= 255; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int merah = c1.R;
                            int hijau = c1.G;
                            int biru = c1.B;
                            HistoR[merah]++;
                            HistoG[hijau]++;
                            HistoB[biru]++;
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;

                    Double sumR = 0;
                    for (int i = 0; i < 255; i++)
                    {
                        if (HistoG[i] == HistoB[i])
                        {
                            sumR++;
                        }
                    }

                    if (sumR == 255)
                    {
                        frm5.chart1.Series["Series1"].Color = Color.Gray;
                        frm5.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm5.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstR in HistoR)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm5.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                            }
                        }
                        frm5.ShowDialog();
                    }
                    else
                    {
                        frm6.chart1.Series["Series1"].Color = Color.Red;
                        frm6.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstR in HistoR)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                            }
                        }

                        frm6.chart2.Series["Series1"].Color = Color.Green;
                        frm6.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstG in HistoG)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                            }
                        }

                        frm6.chart3.Series["Series1"].Color = Color.Blue;
                        frm6.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstB in HistoB)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                            }
                        }
                        frm6.ShowDialog();
                    }


                }
            }
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pbOutput.Image == null)
                    MessageBox.Show("Tidak ada citra yang akan diolah");
                else
                {
                    double[] HistoR = new double[256];
                    double[] HistoG = new double[256];
                    double[] HistoB = new double[256];
                    Bitmap b = new Bitmap((Bitmap)this.pbOutput.Image);
                    Greyscale_Histogram frm5 = new Greyscale_Histogram();
                    RGB_Histogram frm6 = new RGB_Histogram();
                    for (int i = 0; i < 255; i++)
                    {
                        HistoR[i] = 0;
                        HistoG[i] = 0;
                        HistoB[i] = 0;
                    }
                    for (int i = 0; i <= 255; i++)
                    {
                        for (int j = 0; j <= 255; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int merah = c1.R;
                            int hijau = c1.G;
                            int biru = c1.B;
                            HistoR[merah]++;
                            HistoG[hijau]++;
                            HistoB[biru]++;
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;

                    Double sumR = 0;
                    for (int i = 0; i < 255; i++)
                    {
                        if (HistoG[i] == HistoB[i])
                        {
                            sumR++;
                        }
                    }

                    if (sumR == 255)
                    {
                        frm5.chart1.Series["Series1"].Color = Color.Gray;
                        frm5.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm5.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstR in HistoR)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm5.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                            }
                        }
                        frm5.ShowDialog();
                    }
                    else
                    {
                        frm6.chart1.Series["Series1"].Color = Color.Red;
                        frm6.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstR in HistoR)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                            }
                        }

                        frm6.chart2.Series["Series1"].Color = Color.Green;
                        frm6.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstG in HistoG)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                            }
                        }

                        frm6.chart3.Series["Series1"].Color = Color.Blue;
                        frm6.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstB in HistoB)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                            }
                        }
                        frm6.ShowDialog();
                    }


                }
            }
        }

        private void inputAndOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (pbInput.Image == null)
                    MessageBox.Show("Tidak ada citra yang akan diolah");
                else
                {
                    double[] HistoR = new double[256];
                    double[] HistoG = new double[256];
                    double[] HistoB = new double[256];
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    Greyscale_Histogram frm5 = new Greyscale_Histogram();
                    RGB_Histogram frm6 = new RGB_Histogram();
                    for (int i = 0; i < 255; i++)
                    {
                        HistoR[i] = 0;
                        HistoG[i] = 0;
                        HistoB[i] = 0;
                    }
                    for (int i = 0; i <= 255; i++)
                    {
                        for (int j = 0; j <= 255; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int merah = c1.R;
                            int hijau = c1.G;
                            int biru = c1.B;
                            HistoR[merah]++;
                            HistoG[hijau]++;
                            HistoB[biru]++;
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;

                    Double sumR = 0;
                    for (int i = 0; i < 255; i++)
                    {
                        if (HistoG[i] == HistoB[i])
                        {
                            sumR++;
                        }
                    }

                    if (sumR == 255)
                    {
                        frm5.chart1.Series["Series1"].Color = Color.Gray;
                        frm5.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm5.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstR in HistoR)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm5.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                            }
                        }
                        frm5.ShowDialog();
                    }
                    else
                    {
                        frm6.chart1.Series["Series1"].Color = Color.Red;
                        frm6.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstR in HistoR)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                            }
                        }

                        frm6.chart2.Series["Series1"].Color = Color.Green;
                        frm6.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstG in HistoG)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                            }
                        }

                        frm6.chart3.Series["Series1"].Color = Color.Blue;
                        frm6.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        frm6.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                        foreach (Double HstB in HistoB)

                        {
                            for (int i = 0; i <= 255; i++)
                            {
                                frm6.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                            }
                        }
                        frm6.Show();
                    }


                }
            }

            if (pbOutput.Image == null)
                MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                double[] HistoR = new double[256];
                double[] HistoG = new double[256];
                double[] HistoB = new double[256];
                Bitmap b = new Bitmap((Bitmap)this.pbOutput.Image);
                Greyscale_Histogram frm5 = new Greyscale_Histogram();
                RGB_Histogram frm6 = new RGB_Histogram();
                for (int i = 0; i < 255; i++)
                {
                    HistoR[i] = 0;
                    HistoG[i] = 0;
                    HistoB[i] = 0;
                }
                for (int i = 0; i <= 255; i++)
                {
                    for (int j = 0; j <= 255; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int merah = c1.R;
                        int hijau = c1.G;
                        int biru = c1.B;
                        HistoR[merah]++;
                        HistoG[hijau]++;
                        HistoB[biru]++;
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;

                Double sumR = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (HistoG[i] == HistoB[i])
                    {
                        sumR++;
                    }
                }

                if (sumR == 255)
                {
                    frm5.chart1.Series["Series1"].Color = Color.Gray;
                    frm5.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm5.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)

                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frm5.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                        }
                    }
                    frm5.ShowDialog();
                }
                else
                {
                    frm6.chart1.Series["Series1"].Color = Color.Red;
                    frm6.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm6.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)

                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frm6.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                        }
                    }

                    frm6.chart2.Series["Series1"].Color = Color.Green;
                    frm6.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm6.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstG in HistoG)

                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frm6.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                        }
                    }

                    frm6.chart3.Series["Series1"].Color = Color.Blue;
                    frm6.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm6.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstB in HistoB)

                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frm6.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                        }
                    }
                    frm6.Show();
                }


            }
        }

        private void histogramEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if ((pbInput.Image == null))
            {
                MessageBox.Show("Error!! Empty Input Image");
            }
            else
            {
                Dictionary<byte, double> histoR = new Dictionary<byte, double>();
                Dictionary<byte, double> histoG = new Dictionary<byte, double>();
                Dictionary<byte, double> histoB = new Dictionary<byte, double>();
                Bitmap image1 = new Bitmap(pbInput.Image);
                pbOutput.Image = image1;
                int baris, kolom;
                RGB_Histogram frm3 = new RGB_Histogram(); //RGB
                Greyscale_Histogram frm2 = new Greyscale_Histogram(); //Grayscale
                byte c1, c2, c3;
                double[] s1 = new double[256];
                double[] s2 = new double[256];
                double[] s3 = new double[256];
                double jum = 0;
                //Proses inisiasi nilai awal histogram
                for (int counter = 0; counter <= 255; counter++)
                {
                    histoR[(Byte)counter] = 0.0;
                    histoG[(Byte)counter] = 0.0;
                    histoB[(Byte)counter] = 0.0;
                }
                // Proses mendapatkan nilai histogram
                for (baris = 0; baris < image1.Width; baris++)
                {
                    for (kolom = 0; kolom < image1.Height; kolom++)
                    {
                        c1 = image1.GetPixel(baris, kolom).R;
                        c2 = image1.GetPixel(baris, kolom).G;
                        c3 = image1.GetPixel(baris, kolom).B;
                        if (histoR.ContainsKey(c1))
                        {
                            histoR[c1] += 1;
                        }
                        if (histoG.ContainsKey(c2))
                        {
                            histoG[c2] += 1;
                        }
                        if (histoB.ContainsKey(c3))
                        {
                            histoB[c3] += 1; //kerja histogram
                        }
                    }
                }
                //Proses menghitung nilai transform function,
                List<byte> kunci1 = histoR.Keys.ToList();
                List<byte> kunci2 = histoG.Keys.ToList();
                List<byte> kunci3 = histoB.Keys.ToList();

                foreach (byte key in kunci1)
                {
                    histoR[key] = histoR[key] / (image1.Width * image1.Height);
                    jum += 255 * histoR[key];
                    s1[key] = jum;
                }
                jum = 0;
                foreach (byte key in kunci2)
                {
                    histoG[key] = histoG[key] / (image1.Width * image1.Height);
                    jum += 255 * histoG[key];
                    s2[key] = jum;
                }
                jum = 0;
                foreach (byte key in kunci3)
                {
                    histoB[key] = histoB[key] / (image1.Width * image1.Height);
                    jum += 255 * histoB[key];
                    s3[key] = jum;
                }
                ProgressBar1.Visible = true;
                //Proses mengubah nilai pixel ke nilai baru sesuai transform function
                for (baris = 0; baris < image1.Width; baris++)
                {
                    for (kolom = 0; kolom < image1.Height; kolom++)
                    {
                        c1 = image1.GetPixel(baris, kolom).R;
                        c2 = image1.GetPixel(baris, kolom).G;
                        c3 = image1.GetPixel(baris, kolom).B;
                        int s = Convert.ToInt16(s1[c1]);
                        int ss = Convert.ToInt16(s2[c2]);
                        int sss = Convert.ToInt16(s3[c3]);
                        image1.SetPixel(baris, kolom, Color.FromArgb(s, ss, sss));
                    }
                    ProgressBar1.Value = Convert.ToInt32(Math.Floor((double)(100 * (baris + 1) / image1.Width)));
                }
                //Proses inisiasi nilai awal histogram
                for (int counter = 0; counter <= 255; counter++)
                {
                    histoR[(Byte)counter] = 0.0;
                    histoG[(Byte)counter] = 0.0;
                    histoB[(Byte)counter] = 0.0;
                }
                // Proses mendapatkan nilai histogram
                for (baris = 0; baris < image1.Width; baris++)
                {
                    for (kolom = 0; kolom < image1.Height; kolom++)
                    {
                        c1 = image1.GetPixel(baris, kolom).R;
                        c2 = image1.GetPixel(baris, kolom).G;
                        c3 = image1.GetPixel(baris, kolom).B;
                        if (histoR.ContainsKey(c1))
                        {
                            histoR[c1] += 1;
                        }
                        if (histoG.ContainsKey(c2))
                        {
                            histoG[c2] += 1;
                        }
                        if (histoB.ContainsKey(c3))
                        {
                            histoB[c3] += 1; //kerja histogram
                        }
                    }
                }
                if (histoR.Count == histoG.Count && !histoR.Except(histoG).Any())
                {
                    kunci1 = histoR.Keys.ToList();
                    frm2.Show();
                    frm2.chart1.Series["Series1"].Color = Color.Gray;
                    frm2.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm2.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    double luas = image1.Width * image1.Height;
                    foreach (byte key in kunci1)
                    {
                        histoR[key] = histoR[key] / luas;
                    }
                    foreach (KeyValuePair<byte, double> item in histoR)
                    {
                        frm2.chart1.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                }
                else
                {
                    kunci1 = histoR.Keys.ToList();
                    kunci2 = histoG.Keys.ToList();
                    kunci3 = histoB.Keys.ToList();
                    double luas = image1.Width * image1.Height;
                    foreach (byte key in kunci1)
                    {
                        histoR[key] = histoR[key] / luas;
                    }
                    foreach (byte key in kunci2)
                    {
                        histoG[key] = histoG[key] / luas;
                    }
                    foreach (byte key in kunci3)
                    {
                        histoB[key] = histoB[key] / luas;
                    }
                    frm3.Show();
                    frm3.chart1.Series["Series1"].Color = Color.Red;
                    frm3.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm3.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    frm3.chart2.Series["Series1"].Color = Color.Green;
                    frm3.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm3.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    frm3.chart3.Series["Series1"].Color = Color.Blue;
                    frm3.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm3.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    foreach (KeyValuePair<byte, double> item in histoR)
                    {
                        frm3.chart1.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                    foreach (KeyValuePair<byte, double> item in histoG)
                    {
                        frm3.chart2.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                    foreach (KeyValuePair<byte, double> item in histoB)
                    {
                        frm3.chart3.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                }
                ProgressBar1.Visible = false;
                pbOutput.Refresh();
            }
        }

        private void fuzzyHEGreyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((pbInput.Image == null))
            {
                MessageBox.Show("Error!! Empty Input Image");
            }
            else
            {
                Dictionary<byte, double> histoR = new Dictionary<byte, double>();
                Dictionary<byte, double> histoG = new Dictionary<byte, double>();
                Dictionary<byte, double> histoB = new Dictionary<byte, double>();
                Bitmap image1 = new Bitmap(pbInput.Image);
                pbOutput.Image = image1;
                int baris, kolom, cAbu, batasAbuA = 0, batasAbuB = 0, woa = 0, wob = 0;
                Greyscale_Histogram frm2 = new Greyscale_Histogram(); //Grayscale
                RGB_Histogram frm3 = new RGB_Histogram(); //RGB
                byte R, G, B;
                double hasilFuzzyAbu1, hasilFuzzyAbu2, FuzzyficationAbu1, FuzzyficationAbu2, woaAbu;
                //Proses inisiasi nilai awal histogram
                for (int counter = 0; counter <= 255; counter++)
                {
                    histoR[(Byte)counter] = 0.0;
                    histoG[(Byte)counter] = 0.0;
                    histoB[(Byte)counter] = 0.0;
                }
                //Proses menghitung nilai transform function,
                List<byte> kunci1 = new List<byte>();
                List<byte> kunci2 = new List<byte>();
                List<byte> kunci3 = new List<byte>();

                ProgressBar1.Visible = true;
                //Proses mengubah nilai pixel ke nilai baru sesuai transform function
                for (baris = 0; baris < image1.Width; baris++)
                {
                    for (kolom = 0; kolom < image1.Height; kolom++)
                    {
                        R = image1.GetPixel(baris, kolom).R;
                        G = image1.GetPixel(baris, kolom).G;
                        B = image1.GetPixel(baris, kolom).B;
                        cAbu = (R + G + B) / 3;
                        //Grayscale
                        if (cAbu >= 0 && cAbu <= 63)
                        {
                            batasAbuA = 0;
                            batasAbuB = 63;
                            woa = 0;
                            wob = 0;
                        }
                        else if (cAbu >= 64 && cAbu <= 126)
                        {
                            batasAbuA = 63;
                            batasAbuB = 127;
                            woa = 0;
                            wob = 127;
                        }
                        else if (cAbu >= 128 && cAbu <= 190)
                        {
                            batasAbuA = 127;
                            batasAbuB = 191;
                            woa = 127;
                            wob = 255;
                        }

                        else if (cAbu >= 191 && cAbu <= 255)
                        {
                            batasAbuA = 191;
                            batasAbuB = 255;
                            woa = 255;
                            wob = 255;
                        }
                        //Proses Fuzzification untuk menghasilkan fuzzy input
                        hasilFuzzyAbu1 = (double)(cAbu - batasAbuA) / (batasAbuB - batasAbuA);
                        hasilFuzzyAbu2 = -(double)(cAbu - batasAbuB) / (double)(batasAbuB - batasAbuA);

                        FuzzyficationAbu1 = Math.Round(hasilFuzzyAbu1, 6);
                        FuzzyficationAbu2 = Math.Round(hasilFuzzyAbu2, 6);
                        //Proses Defuzzifikasi
                        if (cAbu >= 0 && cAbu <= 63)
                        {
                            woaAbu = 0;
                        }
                        else if (cAbu == 127)
                        {
                            woaAbu = 127;
                        }
                        else if (cAbu >= 191 && cAbu <= 255)
                        {
                            woaAbu = 255;
                        }
                        else if (cAbu >= 64 && cAbu <= 126)
                        {
                            woaAbu = (double)((hasilFuzzyAbu1 * wob) + (hasilFuzzyAbu2 * woa)) / (double)(hasilFuzzyAbu1 + hasilFuzzyAbu2);
                        }
                        else if (cAbu >= 128 && cAbu <= 190)
                        {
                            woaAbu = (double)((hasilFuzzyAbu1 * wob) + (hasilFuzzyAbu2 * woa)) / (double)(hasilFuzzyAbu1 + hasilFuzzyAbu2);
                        }
                        else
                        {
                            woaAbu = 0;
                        }
                        int woaAbuFix = Convert.ToInt16(Math.Round(woaAbu, 0));
                        image1.SetPixel(baris, kolom, Color.FromArgb(woaAbuFix, woaAbuFix, woaAbuFix));
                    }
                    ProgressBar1.Value = Convert.ToInt32(Math.Floor((double)(100 * (baris + 1) / image1.Width)));
                }
                // Proses mendapatkan nilai histogram
                for (baris = 0; baris < image1.Width; baris++)
                {
                    for (kolom = 0; kolom < image1.Height; kolom++)
                    {
                        R = image1.GetPixel(baris, kolom).R;
                        G = image1.GetPixel(baris, kolom).G;
                        B = image1.GetPixel(baris, kolom).B;
                        if (histoR.ContainsKey(R))
                        {
                            histoR[R] += 1;
                        }
                        if (histoG.ContainsKey(G))
                        {
                            histoG[G] += 1;
                        }
                        if (histoB.ContainsKey(B))
                        {
                            histoB[B] += 1; //kerja histogram
                        }
                    }
                }
                if (histoR.Count == histoG.Count && !histoR.Except(histoG).Any())
                {
                    kunci1 = histoR.Keys.ToList();
                    frm2.Show();
                    frm2.chart1.Series["Series1"].Color = Color.Gray;
                    frm2.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm2.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    double luas = image1.Width * image1.Height;
                    foreach (byte key in kunci1)
                    {
                        histoR[key] = histoR[key] / luas;
                    }
                    foreach (KeyValuePair<byte, double> item in histoR)
                    {
                        frm2.chart1.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                }
                else
                {
                    kunci1 = histoR.Keys.ToList();
                    kunci2 = histoG.Keys.ToList();
                    kunci3 = histoB.Keys.ToList();
                    double luas = image1.Width * image1.Height;
                    foreach (byte key in kunci1)
                    {
                        histoR[key] = histoR[key] / luas;
                    }
                    foreach (byte key in kunci2)
                    {
                        histoG[key] = histoG[key] / luas;
                    }
                    foreach (byte key in kunci3)
                    {
                        histoB[key] = histoB[key] / luas;
                    }
                    frm3.Show();
                    frm3.chart1.Series["Series1"].Color = Color.Red;
                    frm3.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm3.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    frm3.chart2.Series["Series1"].Color = Color.Green;
                    frm3.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm3.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    frm3.chart3.Series["Series1"].Color = Color.Blue;
                    frm3.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frm3.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                    foreach (KeyValuePair<byte, double> item in histoR)
                    {
                        frm3.chart1.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                    foreach (KeyValuePair<byte, double> item in histoG)
                    {
                        frm3.chart2.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                    foreach (KeyValuePair<byte, double> item in histoB)
                    {
                        frm3.chart3.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    }
                }
                ProgressBar1.Visible = false;
                pbOutput.Refresh();
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void identityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void averageFilter5x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double[,] H = new double[,] { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };
                double R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + ((H[k1, k2] / 9) * b.GetPixel(i + k1, j + k2).R);
                                    G = G + ((H[k1, k2] / 9) * b.GetPixel(i + k1, j + k2).G);
                                    B = B + ((H[k1, k2] / 9) * b.GetPixel(i + k1, j + k2).B);
                                }
                            }
                        }
                        R = truncate2(R);
                        G = truncate2(G);
                        B = truncate2(B);
                        b.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void lowPassFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)

            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double[,] H = new double[,] { { 1, 1, 1 }, { 1, 4, 1 }, { 1, 1, 1 } };
                double R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + ((H[k1, k2] / 12) * b.GetPixel(i + k1, j + k2).R);
                                    G = G + ((H[k1, k2] / 12) * b.GetPixel(i + k1, j + k2).G);
                                    B = B + ((H[k1, k2] / 12) * b.GetPixel(i + k1, j + k2).B);
                                }
                            }
                        }
                        b.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void highPassFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)

            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                int[,] H = new int[,] { { -1, 0, 1 }, { -1, 0, 3 }, { -3, 0, 1 } };
                int R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (H[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (H[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (H[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        R = truncate(Math.Abs(R));
                        G = truncate(Math.Abs(G));
                        B = truncate(Math.Abs(B));
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void edgeDetectionPewitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)

            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                int[,] H = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
                int[,] HV = new int[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
                int[,] HD = new int[,] { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } };
                int[,] HD2 = new int[,] { { -1, -1, 0 }, { -1, 0, 1 }, { 0, 1, 1 } };
                int R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        //Vertical
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (H[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (H[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (H[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        // Horizontal
                        for (int k1 = 0; k1 < HV.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < HV.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (HV[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (HV[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (HV[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        // Diagonal
                        for (int k1 = 0; k1 < HD.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < HD.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (HD[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (HD[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (HD[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        // Diagonal 2
                        for (int k1 = 0; k1 < HD2.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < HD2.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (HD2[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (HD2[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (HD2[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        R = truncate(Math.Abs(R));
                        G = truncate(Math.Abs(G));
                        B = truncate(Math.Abs(B));
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void edgeDetectionSobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)

            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                int[,] H = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                int[,] HV = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                int[,] HD = new int[,] { { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } };
                int[,] HD2 = new int[,] { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } };
                int R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        //Vertical
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (H[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (H[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (H[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        // Horizontal
                        for (int k1 = 0; k1 < HV.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < HV.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (HV[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (HV[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (HV[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        // Diagonal
                        for (int k1 = 0; k1 < HD.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < HD.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (HD[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (HD[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (HD[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        // Diagonal 2
                        for (int k1 = 0; k1 < HD2.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < HD2.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (HD2[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (HD2[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (HD2[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        R = truncate(Math.Abs(R));
                        G = truncate(Math.Abs(G));
                        B = truncate(Math.Abs(B));
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void identityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)

            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                int[,] H = new int[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
                int R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (H[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (H[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (H[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void sharpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)

            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                int[,] H = new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                int R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + (H[k1, k2] * b.GetPixel(i + k1, j + k2).R);
                                    B = B + (H[k1, k2] * b.GetPixel(i + k1, j + k2).B);
                                    G = G + (H[k1, k2] * b.GetPixel(i + k1, j + k2).G);
                                }
                            }
                        }
                        R = truncate(Math.Abs(R));
                        G = truncate(Math.Abs(G));
                        B = truncate(Math.Abs(B));
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void gausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double[,] H = new double[,] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
                double R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + ((H[k1, k2] / 16) * b.GetPixel(i + k1, j + k2).R);
                                    G = G + ((H[k1, k2] / 16) * b.GetPixel(i + k1, j + k2).G);
                                    B = B + ((H[k1, k2] / 16) * b.GetPixel(i + k1, j + k2).B);
                                }
                            }
                        }
                        R = truncate2(R);
                        G = truncate2(G);
                        B = truncate2(B);
                        b.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void gaussianBlur5x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double[,] H = new double[,] { { 1, 4, 6, 4, 1 }, { 4, 16, 24, 16, 4 }, { 6, 24, 36, 24, 6 }, { 4, 16, 24, 16, 4 }, { 1, 4, 6, 4, 1 } };
                double R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + ((H[k1, k2] / 256) * b.GetPixel(i + k1, j + k2).R);
                                    G = G + ((H[k1, k2] / 256) * b.GetPixel(i + k1, j + k2).G);
                                    B = B + ((H[k1, k2] / 256) * b.GetPixel(i + k1, j + k2).B);
                                }
                            }
                        }
                        R = truncate2(R);
                        G = truncate2(G);
                        B = truncate2(B);
                        b.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void unsharpMasking5x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double[,] H = new double[,] { { 1, 4, 6, 4, 1 }, { 4, 16, 24, 16, 4 }, { 6, 24, (-476), 24, 6 }, { 4, 16, 24, 16, 4 }, { 1, 4, 6, 4, 1 } };
                double R, G, B;
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                        for (int k1 = 0; k1 < H.GetLength(0); k1++)
                        {
                            for (int k2 = 0; k2 < H.GetLength(1); k2++)
                            {
                                if ((i + k1) < b.Width && (j + k2) < b.Height)
                                {
                                    R = R + ((H[k1, k2] / (-256)) * b.GetPixel(i + k1, j + k2).R);
                                    G = G + ((H[k1, k2] / (-256)) * b.GetPixel(i + k1, j + k2).G);
                                    B = B + ((H[k1, k2] / (-256)) * b.GetPixel(i + k1, j + k2).B);
                                }
                            }
                        }
                        R = truncate2(R);
                        G = truncate2(G);
                        B = truncate2(B);
                        b.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                    }
                    ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                ProgressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void crossErosion3x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                if (pbInput.Image == null)
                {
                    MessageBox.Show("Tidak ada citra yang akan diolah");
                }
                else
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    Bitmap c = new Bitmap((Bitmap)this.pbInput.Image);

                    int[,] H = new int[,] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
                    int R, G, B;
                    ProgressBar1.Value = 0;
                    ProgressBar1.Visible = true;

                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            R = c.GetPixel(i, j).R;
                            if (R < 128)
                            {
                                R = 255;
                            }
                            else
                            {
                                R = 0;
                            }
                            c.SetPixel(i, j, Color.FromArgb(R, R, R));
                        }
                    }
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            R = c.GetPixel(i, j).R;
                            if (R == 0)
                            {
                                for (int k1 = -1; k1 < 1; k1++)
                                {
                                    for (int k2 = -1; k2 < 1; k2++)
                                    {
                                        if ((i + k1) < b.Width && (j + k2) < b.Height && (i + k1) >= 0 && (j + k2) >= 0)
                                        {
                                            R = H[k1 + 1, k2 + 1];
                                            G = H[k1 + 1, k2 + 1];
                                            B = H[k1 + 1, k2 + 1];
                                            b.SetPixel(i + k1, j + k2, Color.FromArgb(R, G, B));
                                        }
                                    }
                                }
                            }
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;

                }
            }
        }
    


    private void crossDilation3x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                if (pbInput.Image == null)
                {
                    MessageBox.Show("Tidak ada citra yang akan diolah");
                }
                else
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    Bitmap c = new Bitmap((Bitmap)this.pbInput.Image);

                    int[,] H = new int[,] { { 0, 255, 0 }, { 255, 255, 255 }, { 0, 255, 0 } };
                    int R, G, B;
                    ProgressBar1.Value = 0;
                    ProgressBar1.Visible = true;
                    // THRESHOLD
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            R = c.GetPixel(i, j).R;
                            if (R < 128)
                            {
                                R = 255;
                            }
                            else
                            {
                                R = 0;
                            }
                            c.SetPixel(i, j, Color.FromArgb(R, R, R));
                        }
                    }
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            R = c.GetPixel(i, j).R;
                            if (R == 0)
                            {
                                for (int k1 = -1; k1 < 1; k1++)
                                {
                                    for (int k2 = -1; k2 < 1; k2++)
                                    {
                                        if ((i + k1) < b.Width && (j + k2) < b.Height && (i + k1) >= 0 && (j + k2) >= 0)
                                        {
                                            R = H[k1 + 1, k2 + 1];
                                            G = H[k1 + 1, k2 + 1];
                                            B = H[k1 + 1, k2 + 1];
                                            b.SetPixel(i + k1, j + k2, Color.FromArgb(R, G, B));
                                        }
                                    }
                                }
                            }
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;

                }
            }
        }
    } }



