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
        private Pick<Image<Argb32>> backgroundImage;
        private MSImage[] mImages;

        private SkinManifestJson json;
        private ClockBase clock;
        private FlexDate date;


        private void Redraw() {
            var image = this.backgroundImage.Item.ToBitmap();
            using (var g = Graphics.FromImage(this.editingPictureBox.BackgroundImage)) {
                g.DrawElement(this.clock);
                g.DrawElement(this.date);
            }

            this.editingPictureBox.BackgroundImage = image;
        }

        private void LoadSkin(string dirPath) {
            this.skinDirPath = dirPath;
            var files = Directory.EnumerateFiles(dirPath).ToArray();
            this.images = files
                          .Where(n => n.EndsWith(".png", StringComparison.OrdinalIgnoreCase) && int.TryParse(Path.GetFileNameWithoutExtension(n), out int _))
                          .OrderBy(n => int.Parse(Path.GetFileNameWithoutExtension(n)))
                          .Select(Image.Load<Argb32>)
                          //.Select(System.Drawing.Image.FromFile)
                          .ToArray();
            this.json = SkinManifestJson.FromJson(File.ReadAllText(files.First(n => n.EndsWith(".json", StringComparison.OrdinalIgnoreCase))));
            this.backgroundImage = this.images.Pick(this.json.Background.Image.ImageIndex);
        }

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

            this.LoadSkin(dirPath);

            this.clock = SeparatedClock.FromJson(this.json, this.images);
            //this.date = new Date(
            //    new Slice<Image<Argb32>>(
            //        this.images,
            //        this.json.Date.MonthAndDay.OneLine.Number.ImageIndex,
            //        (int) this.json.Date.MonthAndDay.OneLine.Number.ImageIndex),
            //    null)
            //{
            //    X = this.json.Date.MonthAndDay.OneLine.Number.TopLeftX,
            //    Y = this.json.Date.MonthAndDay.OneLine.Number.TopLeftY,
            //};

            this.date = FlexDate.FromJson(this.json, this.images);
        }
    }
}