using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace DragDropExample
{
    /// <summary>
    /// Anleitung
    /// ---------
    /// 
    /// 1. Ein Control auf das den Designer ziehen, welches Drag-and-drop unterstützt, z.B. ein Panel
    /// 2. Auf Control: Eigenschaft "AllowDrop" auf "True" stellen
    /// 3. Auf Control: DragEnter-Ereignis implementieren → Plus-Zeichen erscheint auf dem Panel beim DragEnter
    /// 4. Auf Control: DragDrop-Ereignis implementieren → DragEventArgs e auswerten
    /// 5. Fertig
    ///
    /// Quelle
    ///     - https://docs.microsoft.com/en-us/dotnet/framework/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms
    ///     - Beachte, dass es zu Problemen kommen kann, wenn man Visual Studio im Admin-Modus started und den Windows Explorer nicht
    ///       https://stackoverflow.com/questions/68598/how-do-i-drag-and-drop-files-into-an-application#comment12518607_89470
    /// </summary>
    public partial class DragDropForm : Form
    {
        public DragDropForm()
        {
            InitializeComponent();
        }

        private void DropZonePanel_DragEnter(object sender, DragEventArgs e)
        {
            Debug.Print("DragEnter");
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DropZonePanel_DragDrop(object sender, DragEventArgs e)
        {
            Debug.Print("DragDrop");
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Files dropped:");
            foreach (string file in files)
            {
                Debug.Print(file);
                sb.AppendLine(file);
            }
            OutputTextBox.Text = sb.ToString();
        }
    }
}
