using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiBand4SkinEditor.Core;

namespace MiBand4SkinEditor.SimpleGUI {
    public partial class Form1 : Form {
        public Form1() {
            this.InitializeComponent();
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
            foreach (var vmElement in this.vm.Elements) {
                var control = new ElementControlView(vmElement, this.Redraw);
                this.flowLayoutPanel1.Controls.Add(control);
            }
            this.Redraw();
        }

        private void Form1_Load(object sender, EventArgs e) {
#if DEBUG
            this.vm.LoadAssets(Directory.GetCurrentDirectory() + "\\..\\..\\..\\win95");

            foreach (var vmElement in this.vm.Elements) {
                var control = new ElementControlView(vmElement, this.Redraw);
                this.flowLayoutPanel1.Controls.Add(control);
            }
            this.Redraw();
#endif
        }
    }
}