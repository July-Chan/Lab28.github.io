using System.Security.AccessControl;

namespace Lab28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                listBox1.Items.Add(drive.Name);
                listBox1.Items.Add("");
            }
        }

        // ������ ��� ��������� ������������ �����
        private void button1_Click(object sender, EventArgs e)
        {
            DriveInfo selectedDrive = null;

            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string selectedDriveName = selectedItem.Split(':')[0];

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.Name.StartsWith(selectedDriveName, StringComparison.OrdinalIgnoreCase))
                    {
                        selectedDrive = drive;
                        break;
                    }
                }

                if (selectedDrive != null)
                {
                    MessageBox.Show($"����� �����: {selectedDrive.Name}\n" +
                                    $"��� �����: {selectedDrive.DriveType}\n" +
                                    $"������ �����: {(selectedDrive.TotalSize / (1024 * 1024 * 1024)).ToString()} ��\n" +
                                    $"³���� ������ �����: {(selectedDrive.TotalFreeSpace / (1024 * 1024 * 1024)).ToString()} ��");
                }
                else
                {
                    MessageBox.Show("���� �� ��������.");
                }
            }
            else
            {
                MessageBox.Show("�� ����� �� ������.");
            }
        }

        // ������ ��� ���������� ����� � ����
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "������� ���� ��� ����������!";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "������� ���� ��� ���������� �����";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;

                    try
                    {
                        File.Move(sourcePath, targetPath);
                        MessageBox.Show("���� ���������.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("������� ��� ���������: " + ex.Message);
                    }
                }
            }
        }

        // ������ ��� ��������� ������������ ����� ��� ��������
        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo selectedDirectory = null;
            FileInfo selectedFile = null;

            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                selectedDirectory = new DirectoryInfo(selectedItem);

                if (selectedDirectory.Exists)
                {
                    MessageBox.Show($"����� ��������: {selectedDirectory.FullName}\n" +
                                    $"���� ���������: {selectedDirectory.CreationTime}\n" +
                                    $"������� ����: {selectedDirectory.LastWriteTime}\n" +
                                    $"�����: {selectedDirectory.GetFiles().Length}\n" +
                                    $"ϳ���������: {selectedDirectory.GetDirectories().Length}");
                }
                else
                {
                    selectedFile = new FileInfo(selectedItem);

                    if (selectedFile.Exists)
                    {
                        MessageBox.Show($"����� �����: {selectedFile.Name}\n" +
                                       $"�����: {(selectedFile.Length / (1024)).ToString()} KB\n" +
                                       $"���� ���������: {selectedFile.CreationTime}\n" +
                                       $"������� ����: {selectedFile.LastWriteTime}");
                    }
                    else
                    {
                        MessageBox.Show("������� �� ��������.");
                    }
                }
            }
            else
            {
                MessageBox.Show("�� ����� �� ������.");
            }
        }

        // ������ ��� ��������� �������� �����
        private void button4_Click(object sender, EventArgs e)
        {
            DirectoryInfo selectedDirectory = null;

            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                selectedDirectory = new DirectoryInfo(selectedItem);

                if (selectedDirectory.Exists)
                {
                    listBox2.Items.Clear();

                    string[] dirs = Directory.GetDirectories(selectedItem);
                    listBox2.Items.Add("ϳ���������:");
                    foreach (string s in dirs)
                    {
                        listBox2.Items.Add(s);
                    }
                    string[] files = Directory.GetFiles(selectedItem);
                    listBox2.Items.Add("�����:");
                    foreach (string s in files)
                    {
                        listBox2.Items.Add(s);
                    }
                }
                else
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("������� �� ��������.");
                }
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("�� ����� �� ������.");
            }
        }

        // ������ ��� ������������
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedDrive = listBox1.SelectedItem.ToString();
                string rootPath = Path.GetPathRoot(selectedDrive);

                string[] allDirs = Directory.GetDirectories(rootPath);
                var filteredDirs = allDirs.Where(dir => dir.Contains(textBox1.Text));

                listBox3.Items.Clear();

                foreach (string dir in filteredDirs)
                {
                    listBox3.Items.Add(dir);
                }
            }
            else
            {
                MessageBox.Show("������� ���� � ������.");
            }
        }

        // ������ ��� ��������� ��������
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedDrive = listBox1.SelectedItem.ToString();

                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "������� ���� ��� ��������� ������ ��������";
                    folderDialog.SelectedPath = selectedDrive;

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string newDirectoryPath = Path.Combine(folderDialog.SelectedPath, "NewDirectory");

                        try
                        {
                            Directory.CreateDirectory(newDirectoryPath);
                            MessageBox.Show("������� ��������.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"������� ��� �������� ��������: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("������� ���� � ������.");
            }
        }

        // ������ ��� ��������� �������� �������
        private void button7_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();

            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();

                try
                {
                    FileAttributes attr = File.GetAttributes(selectedItem);

                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        DirectoryInfo selectedDirectory = new DirectoryInfo(selectedItem);

                        if (selectedDirectory.Exists)
                        {
                            foreach (var dirInfo in selectedDirectory.GetAccessControl().GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                            {
                                if (dirInfo is FileSystemAccessRule fileRule)
                                {
                                    listBox5.Items.Add($"����������: {fileRule.IdentityReference}");
                                    listBox5.Items.Add($"��� �������: {fileRule.FileSystemRights}");
                                    listBox5.Items.Add($"�����: {fileRule.AccessControlType}");
                                    listBox5.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("������� �� ����.");
                        }
                    }
                    else
                    {
                        FileInfo selectedFile = new FileInfo(selectedItem);

                        if (selectedFile.Exists)
                        {
                            foreach (var fileInfo in selectedFile.GetAccessControl().GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                            {
                                if (fileInfo is FileSystemAccessRule fileRule)
                                {
                                    listBox5.Items.Add($"����������: {fileRule.IdentityReference}");
                                    listBox5.Items.Add($"��� �������: {fileRule.FileSystemRights}");
                                    listBox5.Items.Add($"�����: {fileRule.AccessControlType}");
                                    listBox5.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("���� �� ����.");
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"������� �������: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�������: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("������� ���� ��� ������� � ������.");
            }
        }

        // ������ ��� ��������� ����� ���������� �����
        private void button6_Click(object sender, EventArgs e)
        {
            FileInfo selectedFile = null;
            listBox5.Items.Clear();
            if (listBox2.SelectedItem != null)
            {
                string path = listBox2.SelectedItem.ToString();

                try
                {
                    string readText = File.ReadAllText(path);
                    listBox4.Items.Add(readText); // ������ listBox4 �� listBox5
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� ������ �����: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("�� ����� �� ������.");
            }
        }

        // ������ ��� ��������� �����
        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "������� ���� ��� ���������!";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "������� ���� ��� ��������� �����";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;

                    try
                    {
                        File.Copy(sourcePath, targetPath);
                        MessageBox.Show("���� ����������.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("������� ��� ��������: " + ex.Message);
                    }
                }
            }
        }

        // ������ ��� ��������� ����� ��� ��������
        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();

                try
                {
                    FileAttributes attr = File.GetAttributes(selectedItem);

                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        DirectoryInfo selectedDirectory = new DirectoryInfo(selectedItem);
                        if (selectedDirectory.Exists)
                        {
                            selectedDirectory.Delete(true);
                            MessageBox.Show("������� ��������.");
                        }
                    }
                    else
                    {
                        FileInfo selectedFile = new FileInfo(selectedItem);
                        if (selectedFile.Exists)
                        {
                            selectedFile.Delete();
                            MessageBox.Show("���� ��������.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� ��������: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("������� ���� ��� ������� � ������.");
            }
        }

        // ������ ��� ����������� �������� ����� �� ��������
        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();

                try
                {
                    FileAttributes attr = File.GetAttributes(selectedItem);

                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        DirectoryInfo selectedDirectory = new DirectoryInfo(selectedItem);
                        if (selectedDirectory.Exists)
                        {
                            FileAttributes newAttr = File.GetAttributes(selectedItem);
                            if ((newAttr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                newAttr &= ~FileAttributes.ReadOnly;
                            else
                                newAttr |= FileAttributes.ReadOnly;

                            File.SetAttributes(selectedItem, newAttr);
                            MessageBox.Show("�������� �������� ������.");
                        }
                    }
                    else
                    {
                        FileInfo selectedFile = new FileInfo(selectedItem);
                        if (selectedFile.Exists)
                        {
                            FileAttributes newAttr = selectedFile.Attributes;
                            if ((newAttr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                newAttr &= ~FileAttributes.ReadOnly;
                            else
                                newAttr |= FileAttributes.ReadOnly;

                            File.SetAttributes(selectedItem, newAttr);
                            MessageBox.Show("�������� ����� ������.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� ��� ��������: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("������� ���� ��� ������� � ������.");
            }
        }

        // ������ ��� ����������� ��������� �����
        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();

                if (File.Exists(selectedItem))
                {
                    try
                    {
                        string fileContent = File.ReadAllText(selectedItem);
                        using (Form editForm = new Form())
                        {
                            TextBox textBox = new TextBox
                            {
                                Multiline = true,
                                Dock = DockStyle.Fill,
                                Text = fileContent
                            };
                            editForm.Controls.Add(textBox);

                            Button saveButton = new Button
                            {
                                Text = "��������",
                                Dock = DockStyle.Bottom
                            };
                            saveButton.Click += (s, args) =>
                            {
                                File.WriteAllText(selectedItem, textBox.Text);
                                editForm.Close();
                            };
                            editForm.Controls.Add(saveButton);

                            editForm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������� ��� ���������� �����: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("���� �� ����.");
                }
            }
            else
            {
                MessageBox.Show("������� ���� � ������.");
            }
        }
    }
    }

