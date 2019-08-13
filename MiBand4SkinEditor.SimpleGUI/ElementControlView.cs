using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiBand4SkinEditor.Core.Models.UIElements;

namespace MiBand4SkinEditor.SimpleGUI {
    public partial class ElementControlView : UserControl {
        public ElementControlView() {
            this.InitializeComponent();
        }

        private IElement element;

        public void LoadElement(IElement element) {
            this.element = element;
            this.RefreshElement();
        }

        private void RefreshElement() {
            this.groupBox1.Text = this.element.Name;
            this.moveHintLabel.Text = this.element.Moveable ? "Move to:" : "Shift by:";
            this.numericUpDownX.Value = this.element.X;
            this.numericUpDownY.Value = this.element.Y;
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.element.Move((int)this.numericUpDownX.Value, (int)this.numericUpDownY.Value);
            this.RefreshElement();
        }
    }
}
