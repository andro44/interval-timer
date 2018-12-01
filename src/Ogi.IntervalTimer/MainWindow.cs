using System;
using System.Windows.Forms;

namespace Ogi.IntervalTimer
{
  public partial class MainWindow : Form
  {

    public MainWindow()
    {
      InitializeComponent();
    }

    private Timer timer1 = new Timer();

    private void button1_Click(object sender, EventArgs e)
    {

      timer1.Enabled = true;
      timer1.Start();
      timer1.Interval = 1000;
      progressBar1.Maximum = 60 * int.Parse(textBox1.Text);
      timer1.Tick += timer1_Tick;

    }

    void timer1_Tick(object sender, EventArgs e)
    {
      if (progressBar1.Value != progressBar1.Maximum)
      {
        progressBar1.Value++;
        int minutes = progressBar1.Value / 60;
        int seconds = progressBar1.Value % 60;
        label2.Text = $"{minutes.ToString("00")} m {seconds.ToString("00")} s";
      }
      else
      {
        timer1.Stop();
        WindowState = FormWindowState.Minimized;
        Show();
        WindowState = FormWindowState.Normal;
        System.Media.SystemSounds.Exclamation.Play();
        PopupWindow window = new PopupWindow(60 * int.Parse(textBox2.Text));
        DialogResult dialogResult = window.ShowDialog();
        progressBar1.Value = 0;
        timer1.Start();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      timer1.Stop();
      progressBar1.Value = 0;
      progressBar1.Maximum = 60 * int.Parse(textBox1.Text);
      timer1.Start();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      TopMost = checkBox1.Checked;
    }
  }
}
