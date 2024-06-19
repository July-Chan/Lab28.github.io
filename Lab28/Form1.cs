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

        // Кнопка для перегляду властивостей диску
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
                    MessageBox.Show($"Назва диску: {selectedDrive.Name}\n" +
                                    $"Тип диску: {selectedDrive.DriveType}\n" +
                                    $"Ємність диску: {(selectedDrive.TotalSize / (1024 * 1024 * 1024)).ToString()} ГБ\n" +
                                    $"Вільна ємність диску: {(selectedDrive.TotalFreeSpace / (1024 * 1024 * 1024)).ToString()} ГБ");
                }
                else
                {
                    MessageBox.Show("Диск не знайдено.");
                }
            }
            else
            {
                MessageBox.Show("Ви нічого не обрали.");
            }
        }

        // Кнопка для переміщення файлів у диск
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Виберіть файл для переміщення!";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Виберіть місце для переміщення файла";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;

                    try
                    {
                        File.Move(sourcePath, targetPath);
                        MessageBox.Show("Файл переміщено.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Помилка при переміщенні: " + ex.Message);
                    }
                }
            }
        }

        // Кнопка для перегляду властивостей файлу або каталогу
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
                    MessageBox.Show($"Назва каталогу: {selectedDirectory.FullName}\n" +
                                    $"Дата створення: {selectedDirectory.CreationTime}\n" +
                                    $"Остання зміна: {selectedDirectory.LastWriteTime}\n" +
                                    $"Файли: {selectedDirectory.GetFiles().Length}\n" +
                                    $"Підкаталоги: {selectedDirectory.GetDirectories().Length}");
                }
                else
                {
                    selectedFile = new FileInfo(selectedItem);

                    if (selectedFile.Exists)
                    {
                        MessageBox.Show($"Назва файлу: {selectedFile.Name}\n" +
                                       $"Розмір: {(selectedFile.Length / (1024)).ToString()} KB\n" +
                                       $"Дата створення: {selectedFile.CreationTime}\n" +
                                       $"Остання зміна: {selectedFile.LastWriteTime}");
                    }
                    else
                    {
                        MessageBox.Show("Елемент не знайдено.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ви нічого не обрали.");
            }
        }

        // Кнопка для перегляду каталогів диску
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
                    listBox2.Items.Add("Підкаталоги:");
                    foreach (string s in dirs)
                    {
                        listBox2.Items.Add(s);
                    }
                    string[] files = Directory.GetFiles(selectedItem);
                    listBox2.Items.Add("Файли:");
                    foreach (string s in files)
                    {
                        listBox2.Items.Add(s);
                    }
                }
                else
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("Каталог не знайдено.");
                }
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("Ви нічого не обрали.");
            }
        }

        // Кнопка для фільтрування
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
                MessageBox.Show("Виберіть диск зі списку.");
            }
        }

        // Кнопка для створення каталогу
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedDrive = listBox1.SelectedItem.ToString();

                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Виберіть місце для створення нового каталогу";
                    folderDialog.SelectedPath = selectedDrive;

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string newDirectoryPath = Path.Combine(folderDialog.SelectedPath, "NewDirectory");

                        try
                        {
                            Directory.CreateDirectory(newDirectoryPath);
                            MessageBox.Show("Каталог створено.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при створенні каталогу: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть диск зі списку.");
            }
        }

        // Кнопка для перегляду атрибутів безпеки
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
                                    listBox5.Items.Add($"Користувач: {fileRule.IdentityReference}");
                                    listBox5.Items.Add($"Тип доступу: {fileRule.FileSystemRights}");
                                    listBox5.Items.Add($"Дозвіл: {fileRule.AccessControlType}");
                                    listBox5.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Каталог не існує.");
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
                                    listBox5.Items.Add($"Користувач: {fileRule.IdentityReference}");
                                    listBox5.Items.Add($"Тип доступу: {fileRule.FileSystemRights}");
                                    listBox5.Items.Add($"Дозвіл: {fileRule.AccessControlType}");
                                    listBox5.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Файл не існує.");
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Помилка доступу: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або каталог зі списку.");
            }
        }

        // Кнопка для перегляду вмісту текстового файлу
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
                    listBox4.Items.Add(readText); // Змінили listBox4 на listBox5
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при читанні файлу: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ви нічого не обрали.");
            }
        }

        // Кнопка для копіювання файлів
        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Виберіть файл для копіювання!";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Виберіть місце для копіювання файла";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;

                    try
                    {
                        File.Copy(sourcePath, targetPath);
                        MessageBox.Show("Файл скопійовано.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Помилка при копіюванні: " + ex.Message);
                    }
                }
            }
        }

        // Кнопка для видалення файлів або каталогів
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
                            MessageBox.Show("Каталог видалено.");
                        }
                    }
                    else
                    {
                        FileInfo selectedFile = new FileInfo(selectedItem);
                        if (selectedFile.Exists)
                        {
                            selectedFile.Delete();
                            MessageBox.Show("Файл видалено.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видаленні: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або каталог зі списку.");
            }
        }

        // Кнопка для редагування атрибутів файлів та каталогів
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
                            MessageBox.Show("Атрибути каталогу змінено.");
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
                            MessageBox.Show("Атрибути файлу змінено.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при зміні атрибутів: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або каталог зі списку.");
            }
        }

        // Кнопка для редагування текстових файлів
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
                                Text = "Зберегти",
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
                        MessageBox.Show($"Помилка при редагуванні файлу: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Файл не існує.");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл зі списку.");
            }
        }
    }
    }

