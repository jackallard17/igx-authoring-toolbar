using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;

namespace igxFormFieldsToolbar
{
    public partial class ThisAddIn
    {
        private bool allowSave = false;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.DocumentBeforeSave += Application_DocumentBeforeSave;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            if (!allowSave)
            {
                allowSave = true;

                if (SaveAsUI)
                {
                    // Display Save As dialog
                    Microsoft.Office.Interop.Word.Dialog d = Globals.ThisAddIn.Application.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFileSaveAs];
                    object timeOut = 0;
                    d.Show(ref timeOut);
                }
                else
                {
                    // Save without dialog
                    Doc.Save();
                }
            }
            DocumentController documentControls = new DocumentController();
            documentControls.exportFieldContents();
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
