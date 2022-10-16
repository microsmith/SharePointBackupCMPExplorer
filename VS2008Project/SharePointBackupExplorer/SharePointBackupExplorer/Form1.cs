using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SharePointBackupExplorer
{
    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();
        string manifestPath = "";

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private int DoExtract(string cmd)
        {
            // run extrac32.exe to open a CAB file.
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "extrac32";
            proc.StartInfo.Arguments = cmd;
            proc.Start();
            proc.WaitForExit();
            return proc.ExitCode;
        }


        private void ExtractManifest(string filename)
        {
            int exitCode;
                manifestPath = @"C:\temp\SharePointBackupExplorer";
                exitCode = DoExtract(filename + @" /L " + manifestPath + @" manifest.xml /E /Y");

            if (exitCode != 0)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                fbd.Description = "Select a temporary location for the manifest file.";
                manifestPath = fbd.SelectedPath;

                if (manifestPath == "") return;
                exitCode = DoExtract(filename + @" /L " + manifestPath + @" manifest.xml /E /Y");
                if (exitCode != 0)
                {
                    //MessageBox.Show("Cannot open...");
                }

            }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "cmp";
            openFileDialog1.Filter="SharePoint Backup (*.cmp)|*.cmp|All files|*.*";
            openFileDialog1.FileName = txtFileName.Text;
            openFileDialog1.ShowDialog();
            txtFileName.Text = openFileDialog1.FileName;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            ExtractManifest(txtFileName.Text);

            System.Xml.XmlDocument manifest = new System.Xml.XmlDocument();

            //find the manifest file
            try
            {
                manifest.Load(manifestPath + @"\manifest.xml");
            }
            catch
            {
                MessageBox.Show("Could not open " + manifestPath + @"\manifest.xml");
            }

            //process the xml into a DataTable

            dt = new DataTable();
            dt.Clear();
            dt.Columns.Clear();

            dt.Columns.Add("ObjectType", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Url", typeof(String));
            dt.Columns.Add("FileValue",typeof(String));
            dt.Columns.Add("TimeCreated", typeof(DateTime));
            dt.Columns.Add("TimeLastModified", typeof(DateTime));
            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("XML", typeof(String));

            
            foreach (XmlNode obj in  manifest.GetElementsByTagName("SPObject"))
            {
                DataRow row = dt.NewRow();
                row["XML"] = obj.OuterXml;
                string s = "";
                s = obj.Attributes.GetNamedItem("ObjectType").InnerText;
                if (s == "SPFile")
                {
                }
                row["ObjectType"] = obj.Attributes.GetNamedItem("ObjectType").InnerText;
                row["Id"] = obj.Attributes.GetNamedItem("Id").InnerText;
                XmlNode n = obj.Attributes.GetNamedItem("Url");
                if (n != null)
                {
                    s += " - " + obj.Attributes.GetNamedItem("Url").InnerText;
                    row["Url"] = obj.Attributes.GetNamedItem("Url").InnerText;
                }

                XmlNode fileNode = obj.FirstChild ; 
                Boolean process = true;

                if ( fileNode != null )

                {
                    if (chkFilesOnly.Checked)
                    {
                        process = false;
                        if (obj.Attributes.GetNamedItem("ObjectType").InnerText == "SPFile")
                        {
                            process=true;
                        }
                    }
                    if (chkExcludeASPX.Checked)
                    {
                        if (fileNode.Attributes.GetNamedItem("Name") != null && fileNode.Attributes.GetNamedItem("Name").InnerText.ToUpper().EndsWith("ASPX"))
                        {
                            process = false;
                        }
                    }

                    switch (fileNode.Name)
                    {
                        //case "ListItem": process = false; break;
                        case "ListItem":
                            if (!chkListItems.Checked)
                            {
                                process = false; 
                                break;
                            }
                            row["Name"] = fileNode.Attributes.GetNamedItem("Name").InnerText;
                            for (int i = 0; i < fileNode.ChildNodes[0].ChildNodes.Count - 1;i++ )
                            {
                                if (fileNode.ChildNodes[0].ChildNodes[i].Attributes["Value"] != null &&
                                    fileNode.ChildNodes[0].ChildNodes[i].Attributes["Name"].Value == "Title")
                                {
                                    row["FileValue"] = fileNode.ChildNodes[0].ChildNodes[i].Attributes["Value"].Value;
                                }
                            }
                            break;
                        case "FieldTemplate":
                            row["Name"] = fileNode.Attributes.GetNamedItem("Name").InnerText;
                            row["FileValue"] = fileNode.ChildNodes[0].Attributes["Name"].Value;
                            break;
                        case "WebStructure":
                            //row["FileValue"] = fileNode.ChildNodes[0].Attributes["Name"].Value;
                            row["Name"] = fileNode.Name;
                            row["Url"] = fileNode.Attributes["WebUrl"].Value;
                            row["FileValue"] = fileNode.ChildNodes[0].ChildNodes[0].ChildNodes[0].Attributes["Name"].Value
                                + " " + fileNode.ChildNodes[0].ChildNodes[0].ChildNodes[0].Attributes["Url"].Value;
                            break;
                        case "Web":
                            row["Name"] = fileNode.Attributes.GetNamedItem("Name").InnerText;
                            break;
                        case "File":
                            row["FileValue"] = fileNode.Attributes.GetNamedItem("FileValue").InnerText;
                            row["Name"] = fileNode.Attributes.GetNamedItem("Name").InnerText;
                            row["TimeCreated"] = System.DateTime.Parse(fileNode.Attributes.GetNamedItem("TimeCreated").InnerText);
                            row["TimeLastModified"] = System.DateTime.Parse(fileNode.Attributes.GetNamedItem("TimeLastModified").InnerText);
                            break;
                        case "Folder":
                            row["Name"] = fileNode.Attributes.GetNamedItem("Name").InnerText;
                            row["TimeCreated"] = System.DateTime.Parse(fileNode.Attributes.GetNamedItem("TimeCreated").InnerText);
                            row["TimeLastModified"] = System.DateTime.Parse(fileNode.Attributes.GetNamedItem("TimeLastModified").InnerText);
                            break;
                        case "List":
                            row["Name"] = fileNode.Attributes.GetNamedItem("Title").InnerText;
                            row["TimeCreated"] = System.DateTime.Parse(fileNode.Attributes.GetNamedItem("Created").InnerText);
                            break;
                        case "DocumentLibrary":
                            row["Name"] = fileNode.Attributes.GetNamedItem("Title").InnerText;
                            row["TimeCreated"] = System.DateTime.Parse(fileNode.Attributes.GetNamedItem("Created").InnerText);
                            break;
                        case "Feature":
                            row["Name"] = fileNode.Attributes.GetNamedItem("FeatureDefinitionName").InnerText;
                            break;
                            
                        default:
                            row["Name"] = fileNode.Name;
                            break;
                    }
                };

                if (process)
                {
                    dt.Rows.Add(row);
                }

            }
            dataGridView1.DataSource = dt;
            btnExtractFiles.Enabled = true;
        }

        private void btnExtractFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string exportPath = "";
            
            fbd.ShowDialog();
            exportPath = fbd.SelectedPath;
            //MessageBox.Show(exportPath);

            if (exportPath == "") return;
            
            if (dt.Rows.Count == 0) return;

            if (System.IO.Directory.Exists(exportPath + @"\site"))
            {
                if (MessageBox.Show("Directory exists. Delete?", exportPath + @"\site", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                System.IO.Directory.Delete(exportPath + @"\site", true);
            }

            if (DoExtract(txtFileName.Text + @" /L " + exportPath + @" /E /Y") != 0)
                MessageBox.Show("Error extracting CMP file");
            // files are now extracted to "exportPath"

            // now rename them and move them into a SharePoint-like directory structure
            foreach (DataRow r in dt.Rows)
            {
                if (r["FileValue"].ToString() != "")
                {
                    string path = exportPath + @"\site" + r["Url"].ToString().Replace("/", "\\");
                    path = path.Replace(r["Name"].ToString(), "");
                    System.IO.Directory.CreateDirectory(path);
                    System.IO.File.Move(exportPath + @"\" + r["FileValue"].ToString(), path + r["Name"].ToString());
                }
            }
            MessageBox.Show("Files have been extracted to: " + exportPath + @"\site");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //if (dataGridView1.Rows[e.RowIndex].Cells["FileValue"].Value.ToString() != "")
                //    btnExtractFile.Enabled = true;
                //else
                //    btnExtractFile.Enabled = false;

                if (e.ColumnIndex > -1)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "XML")
                    {
                        MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
            }
        }

        private void btnExtractFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row by clicking row selector on the left of the grid.");
                return;
            }

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                string sourceFileName = item.Cells["FileValue"].Value.ToString();
                string destinationFileName = item.Cells["Name"].Value.ToString();

                if (sourceFileName != null & destinationFileName != null)
                {
                    saveFileDialog1.FileName = destinationFileName;
                  
                    if (DialogResult.OK == saveFileDialog1.ShowDialog())
                    {
                        if (saveFileDialog1.FileName == "") return;

                        if (System.IO.File.Exists(saveFileDialog1.FileName)) 
                            System.IO.File.Delete(saveFileDialog1.FileName);

                        int exitCode = 0;

                        // extract the file
                        exitCode = DoExtract(txtFileName.Text + " /L " + System.IO.Path.GetDirectoryName(saveFileDialog1.FileName) + " " + sourceFileName + @" /E /Y");
                        if (exitCode == 0)
                        {
                            try
                            {
                                System.IO.File.Move(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName) + @"\" + sourceFileName, saveFileDialog1.FileName);
                            }
                            catch (Exception e2)
                            {
                                MessageBox.Show("Error renaming " + System.IO.Path.GetDirectoryName(saveFileDialog1.FileName) + @"\" + sourceFileName + " to " + saveFileDialog1.FileName + "\nError: " + e2.Message);
                            }
                                MessageBox.Show(saveFileDialog1.FileName + " extracted");
                        }
                        else
                            MessageBox.Show("Error extracting " + saveFileDialog1.FileName + "  Return code: " + exitCode.ToString());
                    }
                }
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            panel2.Enabled = (txtFileName.Text.Trim().Length > 0);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnExtractFile.Enabled = (dataGridView1.SelectedRows.Count > 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://techtrainingnotes.blogspot.com/2010/01/sharepoint-exploring-sharepoint-cmp.html");
        }

  

    }



}