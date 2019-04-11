using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FrpGui.propertyentity
{
    public class PropertyGridFileSelector : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            var editor = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editor != null)
            {

                // 可以打开任何特定的对话框  
                OpenFileDialog dialog = new OpenFileDialog
                {
                    AddExtension = false,
                    Title = "打开文件",
                    Filter = "证书文件|*.key;*.crt",
                    Multiselect = false
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }
            return value;
        }
    }
}
