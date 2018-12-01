using System;
using System.Windows.Forms;

namespace Ogi.IntervalTimer
{
  public partial class PopupWindow : Form
  {
    private Timer timer1 = new Timer();

    public PopupWindow(int timeoutPeriodInSeconds)
    {
      InitializeComponent();
      timer1.Enabled = true;
      timer1.Start();
      timer1.Interval = 1000;
      progressBar1.Maximum = timeoutPeriodInSeconds;
      timer1.Tick += timer1_Tick;
      StartPosition = FormStartPosition.CenterParent;
    }

    void timer1_Tick(object sender, EventArgs e)
    {
      if (progressBar1.Value != progressBar1.Maximum)
      {
        progressBar1.Value++;
        int minutes = progressBar1.Value / 60;
        int seconds = progressBar1.Value % 60;
        label1.Text = $"{minutes.ToString("00")} m {seconds.ToString("00")} s";
      }
      else
      {
        timer1.Stop();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
