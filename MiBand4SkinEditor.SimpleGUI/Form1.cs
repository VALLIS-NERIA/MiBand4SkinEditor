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
            this.vm = new ViewModel();
        }

        public ViewModel vm;

        private void Redraw() {
            this.editingPictureBox.BackgroundImage = this.vm.Draw().ToBitmap();
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

            this.vm.LoadAssets(dirPath);
            this.Redraw();
        }
    }
}