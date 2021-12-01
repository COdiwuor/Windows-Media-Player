﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MP3_Player_Demo
{
    public partial class PPPTV : Form
    {
        string[] files, path;
        public PPPTV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFile = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|* .wmv|WAV|* .wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv " })
            {

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    //files = openFile.SafeFileNames;
                    //path = openFile.FileNames;
                    //for (int i = 0; i < files.Length; i++)
                    //{
                    //    if (listBox1 != null && files.Length != 0)
                    //    {
                    //        listBox1.Items.Add(files[i]);
                    //    }

                    //}
                    //look for a way to add multiple filles
                    List<MediaFile> files = new List<MediaFile>();
                    foreach (string filename in openFile.FileNames)
                    {
                        FileInfo f1 = new FileInfo(filename);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(f1.FullName), Path = f1.FullName });
                    }
                    listBox1.DataSource = files;
                    listBox1.ValueMember = "Path";
                    listBox1.DisplayMember = "FileName";


                }
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.next();
            axWindowsMediaPlayer1.Ctlcontrols.previous();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.ValueMember = "Path";
            listBox1.DisplayMember = "FileName";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listBox1.SelectedItem as MediaFile;
            if (file != null)
            {
                axWindowsMediaPlayer1.URL = file.Path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.Ctlcontrols.next();
                axWindowsMediaPlayer1.Ctlcontrols.previous();
            }
        }
    }
}
