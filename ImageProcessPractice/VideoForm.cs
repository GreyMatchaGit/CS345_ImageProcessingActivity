using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace ImageProcessPractice
{
    public partial class VideoForm : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        private static String[] effects =
        {
            "None",
            "Gaussian Blur",
            "Sharpen",
            "Mean Removal",
            "Emboss Laplascian"
        };
        String selectedEffect = "None";
        public VideoForm()
        {
            InitializeComponent();
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                this.Close();
                return;
            }

            foreach (FilterInfo device in videoDevices)
            {
                comboBox1.Items.Add(device.Name);
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(Video_NewFrame);

            foreach (string effect in effects)
            {
                comboBox2.Items.Add(effect);
            }
        }

        private void Video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Convolution3x3 effect = Conv3x3Config.Identity;
            switch (selectedEffect)
            {
                case "Gaussian Blur":
                    effect = Conv3x3Config.GaussianBlur;
                    break;
                case "Sharpen":
                    effect = Conv3x3Config.Sharpen;
                    break;
                case "Mean Removal":
                    effect = Conv3x3Config.MeanRemoval;
                    break;
                case "Emboss Laplascian":
                    effect = Conv3x3Config.EmbossLaplascian;
                    break;
                default:
                    break;
            }
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            Convolution3x3.Apply(
                bitmap,
                effect
            );
            pictureBox1.Image = bitmap;
        }

        private void VideoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(Video_NewFrame);
            videoSource.Start();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Changed to " + comboBox2.SelectedItem);
            selectedEffect = comboBox2.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine("Changed to " + comboBox2.SelectedItem);
            selectedEffect = comboBox2.SelectedItem.ToString();
        }
    }
}
