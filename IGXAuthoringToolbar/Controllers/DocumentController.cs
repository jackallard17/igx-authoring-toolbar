﻿using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using IGXAuthoringToolbar.Models;
using IGXAuthoringToolbar.SchemaDesignerService;
using System.Diagnostics;
using IGXAuthoringToolbar.Controllers;

namespace IGXAuthoringToolbar
{
    public class DocumentController
    {
        private static Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);

        private static List<CMSPage> pages = new List<CMSPage>();

        public void addCMSPage(SchemaDetails selection)
        {
            CMSPage newPage = new CMSPage();
            newPage.ViewName = selection.ViewName;

            var fields = selection.Fields;

            foreach (SchemaFieldInfo field in fields)
            {
                addField(field, newPage);
            }

            pages.Add(newPage);
        }

        public void addField(SchemaFieldInfo field, CMSPage page)
        {
            //moves range each time field is added, generates text label over each field
            object i = 1;
            document.ActiveWindow.View.ReadingLayout = false;
            document.Paragraphs.First.Range.Select();
            var range = document.Range();

            ContentControl control;

            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            range.Text = field.Label;
            document.Paragraphs.Add();
            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            if (field.TypeName == "Text Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlText, range);
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "XHTML Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlRichText, range);
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "Checkbox")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlCheckBox, range);
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "Asset" || field.TypeName.Contains("Image") == true)
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlPicture, range);
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "List")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlBuildingBlockGallery, range);
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            document.Paragraphs.Add();
            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
        }

        //clears existing XML parts and updates with new user input
        public void exportUserContent()
        {
            int i = document.CustomXMLParts.Count;
            while (i > 3)
            {
                document.CustomXMLParts[i].Delete();
                i--;
            }
            Debug.WriteLine(pages.Count);
            foreach (CMSPage page in pages)
            {
                createXMLPart(page);
            }
        }
        private void createXMLPart(CMSPage page)
        {
            var newXMLPart = document.CustomXMLParts.Add($"<?xml version=\"1.0\" ?><{page.ViewName}></{page.ViewName}>");
            var root = newXMLPart.SelectSingleNode($"/{page.ViewName}");

            foreach (ContentControl control in page.ContentControls)
            {
                if (control.Type == WdContentControlType.wdContentControlText || control.Type == WdContentControlType.wdContentControlRichText)
                {
                    if (!control.ShowingPlaceholderText)
                    {
                        newXMLPart.AddNode(root, $"{control.Tag}", "", null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, $"{control.Range.Text}");
                    }
                    else
                    {
                        newXMLPart.AddNode(root, $"{control.Tag}", "", null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, "");
                    }
                }
                else if (control.Type == WdContentControlType.wdContentControlCheckBox)
                {
                    newXMLPart.AddNode(root, $"{control.Tag}", "", null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, $"{control.Checked.ToString()}");
                }
            }
            System.Diagnostics.Debug.WriteLine(document.CustomXMLParts.Count);

        }
    }
}