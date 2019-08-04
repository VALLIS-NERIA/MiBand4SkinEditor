using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiBand4SkinEditor.Core;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Newtonsoft.Json;
using MiBand4SkinEditor.Core.Models;
using MiBand4SkinEditor.Core.Models.UIElements;
using Image = SixLabors.ImageSharp.Image;
using SkinManifestJson = MiBand4SkinEditor.Core.Models.Json.SkinManifestJson;
using MSImage = System.Drawing.Image;

namespace MiBand4SkinEditor.SimpleGUI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private string skinDirPath;
        private Image<Argb32>[] images;
        private MSImage[] mImages;

        private SkinManifestJson json;
        private Clock clock;
        private Date date;

        private void PictureBox1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e) { }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e) {
            var dirPath = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (!Directory.Exists(dirPath)) {
                return;
            }

            this.skinDirPath = dirPath;
            var files = Directory.EnumerateFiles(dirPath).ToArray();
            this.images = files
                          .Where(n => n.EndsWith(".png", StringComparison.OrdinalIgnoreCase) && int.TryParse(Path.GetFileNameWithoutExtension(n), out int _))
                          .OrderBy(n => int.Parse(Path.GetFileNameWithoutExtension(n)))
                          .Select(Image.Load<Argb32>)
                          //.Select(System.Drawing.Image.FromFile)
                          .ToArray();
            this.json = SkinManifestJson.FromJson(File.ReadAllText(files.First(n => n.EndsWith(".json", StringComparison.OrdinalIgnoreCase))));
            this.clock = new Clock(new Slice<Image<Argb32>>(this.images, this.json.Time.Hours.Tens.ImageIndex, (int) this.json.Time.Hours.Tens.ImagesCount))
            {
                X = this.json.Time.Hours.Tens.X,
                Y = this.json.Time.Hours.Tens.Y,
            };
            var clockImg = this.clock.Render().ToBitmap();

            this.pictureBox1.BackgroundImage = this.images[0].ToBitmap();
            var g = Graphics.FromImage(this.pictureBox1.BackgroundImage);
            g.DrawImage(clockImg, this.clock.X, this.clock.Y,this.clock.Width,this.clock.Height);
            //this.pictureBox1.Image = clockImg;
        }
    }
}