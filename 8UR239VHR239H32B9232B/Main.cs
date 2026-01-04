using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SETTINGS;

namespace _8UR239VHR239H32B9232B
{
    public partial class Main : Form
    {
        //
        #region Переменные
        string file_nick = "nicknames.txt";

        string[] nicknames;

        string file1 = @"Text\text_1.txt";
        string file2 = @"Text\text_2.txt";
        string file3 = @"Text\text_3.txt";
        string file4 = @"Text\text_4.txt";
        string file5 = @"Text\text_5.txt";
        string file6 = @"Text\text_6.txt";

        string text_1 = "";
        string text_2 = "";
        string text_3 = "";
        string text_4 = "";
        string text_5 = "";
        string text_6 = "";

        string inifile = "settings.ini";
        string[] rand_f = { "1", "3", "6", "7", "v", "H", "a", "e", "k", "N", "2", "c", "A", "O" };

        bool activation = false;
        int all_sms = 0;
        int times = 0;
        #endregion
        //
        public Main()
        {
            InitializeComponent();
        }
        //
        private void Main__Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(file_nick))
                {
                    MessageBox.Show($"Не найден файл '{file_nick}'!\nБудет создан новый файл, запишите туда список ников (1 ник = 1 строка)!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    File.Create(file_nick);
                }
                else
                {
                    if (File.ReadAllText(file_nick).Length == 0) MessageBox.Show($"Файл '{file_nick}' - пуст!\nЗапишите туда список ников (1 ник = 1 строка)!", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        nicknames = new string[File.ReadAllLines(file_nick).Length];
                        for (int i = 0; i < File.ReadAllLines(file_nick).Length; i++)
                        {
                            nicknames[i] = File.ReadAllLines(file_nick)[i].ToString();
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ошибка в чтении файла '{file_nick}'!\n\n{er.ToString()}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            version.Text = $"v{Application.ProductVersion.ToString()}";
            //
            #region Anti-Detect
            try
            {
                string rnmd = "";
                Random rn = new Random();
                for (int i = 0; i < 18; i++)
                {
                    Thread.Sleep(7);
                    rnmd = rnmd + rand_f[rn.Next(0, 14)];
                }
                this.Text = $"{rnmd}";
            }
            catch { }
            #endregion
            LoadSetting();
        }
        //
        private void Sending_Default(int time, string text_sending)//ДЕФОЛТ ОТПРАВКА
        {
            try
            {
                //if (mays == true) return;
                if (activation == false) return;
                Thread.Sleep(time);
                Invoke((MethodInvoker)delegate { label_all_sms.Text = $"Отправлено сообщений: {all_sms++}"; });
                SendKeys.SendWait(text_sending);//SendKeys.Send
                Thread.Sleep(300);
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception er)
            {
                gb_text.Enabled = true;
                activation = false;
                MessageBox.Show($"{er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void Sending_Random1(int time, string text_sending)//РАНДОМ 1
        {
            try
            {
                //if (mays == true) return;
                if (activation == false) return;
                Thread.Sleep(time);
                Invoke((MethodInvoker)delegate { label_all_sms.Text = $"Отправлено сообщений: {all_sms++}"; });
                string rnrn_text = "";
                Random rnnnd = new Random();
                for (int i = 0; i < 7; i++)
                {
                    Thread.Sleep(9);
                    rnrn_text = rnrn_text + rand_f[rnnnd.Next(0, 14)];
                }
                SendKeys.SendWait(text_sending + $" [{rnrn_text}]");
                Thread.Sleep(300);
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception er)
            {
                gb_text.Enabled = true;
                activation = false;
                MessageBox.Show($"{er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void Sending_Random2(int time, string text_sending)//РАНДОМ 2
        {
            try
            {
                //if (mays == true) return;
                if (activation == false) return;
                Thread.Sleep(time);
                Invoke((MethodInvoker)delegate { label_all_sms.Text = $"Отправлено сообщений: {all_sms++}"; });
                string rnrn_text = "";
                Random rnnnd = new Random();
                for (int i = 0; i < 7; i++)
                {
                    Thread.Sleep(4);
                    rnrn_text = rnrn_text + rand_f[rnnnd.Next(0, 14)];
                }
                SendKeys.SendWait($"[{rnrn_text}] " + text_sending);
                Thread.Sleep(300);
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception er)
            {
                gb_text.Enabled = true;
                activation = false;
                MessageBox.Show($"{er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        public void start_button_Click(object sender, EventArgs e)
        {
            if (text_1 == "" & text_2 == "" & text_3 == "" & text_4 == "" & text_5 == "" & text_6 == "")
            {
                MessageBox.Show("Поле для ввода текста - пустое, напишите что-либо в него, чтобы продолжить работу.", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gb_setting_1.Enabled = false;
            groupBox1.Enabled = false;
            gb_setting_2.Enabled = false;
            gb_text.Enabled = false;
            labeltext_check.ForeColor = Color.Green;
            labeltext_check.Text = "ON";
            start_button.Enabled = false;

            Thread.Sleep(3000);
            new Thread(Start).Start();
        }
        //
        private void Start()
        {
            try
            {
                activation = true;
                for (; ; )
                {
                    Invoke((MethodInvoker)delegate { if (ch_random_nickname.Checked) Get_Text(); });
                    Thread.Sleep(40);
                    Invoke((MethodInvoker)delegate
                    {
                        if (check_rand.Checked)
                        {
                            times = new Random().Next((int)num_1.Value, (int)num_2.Value); link_l_1.Text = $"{times} мс";
                        }
                        else times = tabcontrol_1.Value;
                    });
                    if (activation == false) break;

                    if (text_1.Length > 0)
                    {
                        if (ch_text.Checked)
                        {
                            if (rb_st.Checked) Sending_Default(times, Text_Replace(text_1));
                            else if (rb_text1.Checked) Sending_Random1(times, Text_Replace(text_1));
                            else if (rb_text2.Checked) Sending_Random2(times, Text_Replace(text_1));
                        }
                        else
                        {
                            if (rb_st.Checked) Sending_Default(times, text_1);
                            else if (rb_text1.Checked) Sending_Random1(times, text_1);
                            else if (rb_text2.Checked) Sending_Random2(times, text_1);
                        }
                    }
                    if (text_2.Length > 0)
                    {
                        if (ch_text.Checked)
                        {
                            if (rb_st.Checked) Sending_Default(times, Text_Replace(text_2));
                            else if (rb_text1.Checked) Sending_Random1(times, Text_Replace(text_2));
                            else if (rb_text2.Checked) Sending_Random2(times, Text_Replace(text_2));
                        }
                        else
                        {
                            if (rb_st.Checked) Sending_Default(times, text_2);
                            else if (rb_text1.Checked) Sending_Random1(times, text_2);
                            else if (rb_text2.Checked) Sending_Random2(times, text_2);
                        }
                    }
                    if (text_3.Length > 0)
                    {
                        if (ch_text.Checked)
                        {
                            if (rb_st.Checked) Sending_Default(times, Text_Replace(text_3));
                            else if (rb_text1.Checked) Sending_Random1(times, Text_Replace(text_3));
                            else if (rb_text2.Checked) Sending_Random2(times, Text_Replace(text_3));
                        }
                        else
                        {
                            if (rb_st.Checked) Sending_Default(times, text_3);
                            else if (rb_text1.Checked) Sending_Random1(times, text_3);
                            else if (rb_text2.Checked) Sending_Random2(times, text_3);
                        }
                    }
                    if (text_4.Length > 0)
                    {
                        if (ch_text.Checked)
                        {
                            if (rb_st.Checked) Sending_Default(times, Text_Replace(text_4));
                            else if (rb_text1.Checked) Sending_Random1(times, Text_Replace(text_4));
                            else if (rb_text2.Checked) Sending_Random2(times, Text_Replace(text_4));
                        }
                        else
                        {
                            if (rb_st.Checked) Sending_Default(times, text_4);
                            else if (rb_text1.Checked) Sending_Random1(times, text_4);
                            else if (rb_text2.Checked) Sending_Random2(times, text_4);
                        }
                    }
                    if (text_5.Length > 0)
                    {
                        if (ch_text.Checked)
                        {
                            if (rb_st.Checked) Sending_Default(times, Text_Replace(text_5));
                            else if (rb_text1.Checked) Sending_Random1(times, Text_Replace(text_5));
                            else if (rb_text2.Checked) Sending_Random2(times, Text_Replace(text_5));
                        }
                        else
                        {
                            if (rb_st.Checked) Sending_Default(times, text_5);
                            else if (rb_text1.Checked) Sending_Random1(times, text_5);
                            else if (rb_text2.Checked) Sending_Random2(times, text_5);
                        }
                    }
                    if (text_6.Length > 0)
                    {
                        if (ch_text.Checked)
                        {
                            if (rb_st.Checked) Sending_Default(times, Text_Replace(text_6));
                            else if (rb_text1.Checked) Sending_Random1(times, Text_Replace(text_6));
                            else if (rb_text2.Checked) Sending_Random2(times, Text_Replace(text_6));
                        }
                        else
                        {
                            if (rb_st.Checked) Sending_Default(times, text_6);
                            else if (rb_text1.Checked) Sending_Random1(times, text_6);
                            else if (rb_text2.Checked) Sending_Random2(times, text_6);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                activation = false;
                MessageBox.Show($"Ошибка в методе активации: \n {er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void Get_Text()
        {
            if (text_1.Length > 0) { Thread.Sleep(5); text_1 = $"{textBox_rnd_nickname.Text} {nicknames[new Random().Next(0, nicknames.Length)]} - {r_text_1.Text}"; }
            Thread.Sleep(15);
            if (text_2.Length > 0) { Thread.Sleep(5); text_2 = $"{textBox_rnd_nickname.Text} {nicknames[new Random().Next(0, nicknames.Length)]} - {r_text_2.Text}"; }
            Thread.Sleep(13);
            if (text_3.Length > 0) { Thread.Sleep(5); text_3 = $"{textBox_rnd_nickname.Text} {nicknames[new Random().Next(0, nicknames.Length)]} - {r_text_3.Text}"; }
            Thread.Sleep(10);
            if (text_4.Length > 0) { Thread.Sleep(5); text_4 = $"{textBox_rnd_nickname.Text} {nicknames[new Random().Next(0, nicknames.Length)]} - {r_text_4.Text}"; }
            Thread.Sleep(17);
            if (text_5.Length > 0) { Thread.Sleep(5); text_5 = $"{textBox_rnd_nickname.Text} {nicknames[new Random().Next(0, nicknames.Length)]} - {r_text_5.Text}"; }
            Thread.Sleep(20);
            if (text_6.Length > 0) { Thread.Sleep(5); text_6 = $"{textBox_rnd_nickname.Text} {nicknames[new Random().Next(0, nicknames.Length)]} - {r_text_6.Text}"; }
        }
        //
        private string Text_Replace(string text_replace)
        {
            text_replace = text_replace
            .Replace("а", "@")
            .Replace("б", "6")
            .Replace("з", "3")
            .Replace("в", "8")
            .Replace("к", "k")
            .Replace("т", "t")
            .Replace("о", "o")
            .Replace("с", "c")
            .Replace("А", "A")
            .Replace("м", "m");
            return text_replace;
        }
        //
        private void b_files_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton_text_1.Checked)
                {
                    file_dialog.Filter = "TXT (*.txt)|*.txt" + "|All files (*.*)|*.*";
                    if (file_dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (rb_windows_1251.Checked) r_text_1.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding(1251));
                        else if (rb_utf8.Checked) r_text_1.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding("UTF-8"));
                    }
                }

                if (radioButton_text_2.Checked)
                {
                    file_dialog.Filter = "TXT (*.txt)|*.txt" + "|All files (*.*)|*.*";
                    if (file_dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (rb_windows_1251.Checked) r_text_2.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding(1251));
                        else if (rb_utf8.Checked) r_text_2.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding("UTF-8"));
                    }
                }

                if (radioButton_text_3.Checked)
                {
                    file_dialog.Filter = "TXT (*.txt)|*.txt" + "|All files (*.*)|*.*";
                    if (file_dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (rb_windows_1251.Checked) r_text_3.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding(1251));
                        else if (rb_utf8.Checked) r_text_3.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding("UTF-8"));
                    }
                }

                if (radioButton_text_4.Checked)
                {
                    file_dialog.Filter = "TXT (*.txt)|*.txt" + "|All files (*.*)|*.*";
                    if (file_dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (rb_windows_1251.Checked) r_text_4.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding(1251));
                        else if (rb_utf8.Checked) r_text_4.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding("UTF-8"));
                    }
                }

                if (radioButton_text_5.Checked)
                {
                    file_dialog.Filter = "TXT (*.txt)|*.txt" + "|All files (*.*)|*.*";
                    if (file_dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (rb_windows_1251.Checked) r_text_5.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding(1251));
                        else if (rb_utf8.Checked) r_text_5.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding("UTF-8"));
                    }
                }

                if (radioButton_text_6.Checked)
                {
                    file_dialog.Filter = "TXT (*.txt)|*.txt" + "|All files (*.*)|*.*";
                    if (file_dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (rb_windows_1251.Checked) r_text_6.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding(1251));
                        else if (rb_utf8.Checked) r_text_6.Text = File.ReadAllText(file_dialog.FileName, Encoding.GetEncoding("UTF-8"));
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ошибка выбора файла:\n{er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void tabcontrol_1_Scroll(object sender, EventArgs e)
        {
            int h = tabcontrol_1.Value;
            link_l_1.Text = $"{h} мс";
            SaveSetting();
        }
        //
        private void check_rand_CheckedChanged(object sender, EventArgs e)
        {
            if (check_rand.Checked) tabcontrol_1.Enabled = false; else if (!check_rand.Checked) tabcontrol_1.Enabled = true;
            SaveSetting();
        }
        //
        #region Выбор_текста
        private void radioButton_text_1_CheckedChanged(object sender, EventArgs e)
        {
            int all_sim = r_text_1.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
            SaveSetting();
            r_text_2.Parent = this;
            r_text_3.Parent = this;
            r_text_4.Parent = this;
            r_text_5.Parent = this;
            r_text_6.Parent = this;

            r_text_2.Location = new Point(688, 124);
            r_text_3.Location = new Point(688, 225);
            r_text_4.Location = new Point(688, 317);
            r_text_5.Location = new Point(688, 411);
            r_text_6.Location = new Point(688, 515);

            r_text_1.Parent = gb_text;
            r_text_1.Location = new Point(6, 37);
        }

        private void radioButton_text_2_CheckedChanged(object sender, EventArgs e)
        {
            int all_sim = r_text_2.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
            SaveSetting();
            r_text_1.Parent = this;
            r_text_3.Parent = this;
            r_text_4.Parent = this;
            r_text_5.Parent = this;
            r_text_6.Parent = this;

            r_text_1.Location = new Point(688, 12);
            r_text_3.Location = new Point(688, 225);
            r_text_4.Location = new Point(688, 317);
            r_text_5.Location = new Point(688, 411);
            r_text_6.Location = new Point(688, 515);

            r_text_2.Parent = gb_text;
            r_text_2.Location = new Point(6, 37);
        }

        private void radioButton_text_3_CheckedChanged(object sender, EventArgs e)
        {
            int all_sim = r_text_3.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
            SaveSetting();
            r_text_1.Parent = this;
            r_text_2.Parent = this;
            r_text_4.Parent = this;
            r_text_5.Parent = this;
            r_text_6.Parent = this;

            r_text_1.Location = new Point(688, 12);
            r_text_2.Location = new Point(688, 124);
            r_text_4.Location = new Point(688, 317);
            r_text_5.Location = new Point(688, 411);
            r_text_6.Location = new Point(688, 515);

            r_text_3.Parent = gb_text;
            r_text_3.Location = new Point(6, 37);
        }

        private void radioButton_text_4_CheckedChanged(object sender, EventArgs e)
        {
            int all_sim = r_text_4.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
            SaveSetting();
            r_text_1.Parent = this;
            r_text_2.Parent = this;
            r_text_3.Parent = this;
            r_text_5.Parent = this;
            r_text_6.Parent = this;

            r_text_1.Location = new Point(688, 12);
            r_text_2.Location = new Point(688, 124);
            r_text_3.Location = new Point(688, 225);
            r_text_5.Location = new Point(688, 411);
            r_text_6.Location = new Point(688, 515);

            r_text_4.Parent = gb_text;
            r_text_4.Location = new Point(6, 37);
        }

        private void radioButton_text_5_CheckedChanged(object sender, EventArgs e)
        {
            int all_sim = r_text_5.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
            SaveSetting();
            r_text_1.Parent = this;
            r_text_2.Parent = this;
            r_text_3.Parent = this;
            r_text_4.Parent = this;
            r_text_6.Parent = this;

            r_text_1.Location = new Point(688, 12);
            r_text_2.Location = new Point(688, 124);
            r_text_3.Location = new Point(688, 225);
            r_text_4.Location = new Point(688, 317);
            r_text_6.Location = new Point(688, 515);

            r_text_5.Parent = gb_text;
            r_text_5.Location = new Point(6, 37);
        }

        private void radioButton_text_6_CheckedChanged(object sender, EventArgs e)
        {
            int all_sim = r_text_6.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
            SaveSetting();
            r_text_1.Parent = this;
            r_text_2.Parent = this;
            r_text_3.Parent = this;
            r_text_4.Parent = this;
            r_text_5.Parent = this;

            r_text_1.Location = new Point(688, 12);
            r_text_2.Location = new Point(688, 124);
            r_text_3.Location = new Point(688, 225);
            r_text_4.Location = new Point(688, 317);
            r_text_5.Location = new Point(688, 411);

            r_text_6.Parent = gb_text;
            r_text_6.Location = new Point(6, 37);
        }
        #endregion
        //
        #region Изменения_текста
        private void r_text_1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_text_1.Checked) text_1 = r_text_1.Text;
            SaveSetting();

            int all_sim = r_text_1.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
        }

        private void r_text_2_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_text_2.Checked) text_2 = r_text_2.Text;
            SaveSetting();

            int all_sim = r_text_2.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
        }

        private void r_text_3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_text_3.Checked) text_3 = r_text_3.Text;
            SaveSetting();

            int all_sim = r_text_3.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
        }

        private void r_text_4_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_text_4.Checked) text_4 = r_text_4.Text;
            SaveSetting();

            int all_sim = r_text_4.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
        }

        private void r_text_5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_text_5.Checked) text_5 = r_text_5.Text;
            SaveSetting();

            int all_sim = r_text_5.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
        }

        private void r_text_6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_text_6.Checked) text_6 = r_text_6.Text;
            SaveSetting();

            int all_sim = r_text_6.Text.Length;
            l_ch.Text = $"Кол-во символов: {all_sim}";
        }
        #endregion
        //
        #region Setting
        private void rb_st_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void rb_text1_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void rb_text2_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void ch_text_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void rb_windows_1251_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void rb_utf8_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void ch_random_nickname_CheckedChanged(object sender, EventArgs e)
        {
            if (nicknames.Length == 0)
            {
                MessageBox.Show($"Список ников - пуст!\nЗаполните список ников (файл '{file_nick}') и перезагрузите ПО!", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ch_random_nickname.Checked = false;
            }
            else
            {
                if (ch_random_nickname.Checked) textBox_rnd_nickname.Enabled = true;
                else textBox_rnd_nickname.Enabled = false;
                SaveSetting();
            }
        }

        private void textBox_rnd_nickname_TextChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void num_1_ValueChanged(object sender, EventArgs e)
        {
            if (num_1.Value > num_2.Value)
            {
                MessageBox.Show("Значение '1' > '2', измените первое значение так, чтобы второе было больше первого.", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveSetting();
        }

        private void num_2_ValueChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        public void SaveSetting()
        {
            try
            {
                if (!File.Exists(inifile))
                {
                    FileStream file = new FileStream(inifile, FileMode.Create);
                    file.Close();
                }
                var Ini = new IniFile(inifile);

                if (rb_st.Checked) Ini.Write("SENDING", "SIMPLE");
                if (rb_text1.Checked) Ini.Write("SENDING", "RAND1");
                if (rb_text2.Checked) Ini.Write("SENDING", "RAND2");
                if (rb_windows_1251.Checked) Ini.Write("ENCODING", "1251");
                if (rb_utf8.Checked) Ini.Write("ENCODING", "UTF8");
                if (ch_text.Checked)
                {
                    Ini.Write("REPLACESIGN", "YES");
                }
                else
                {
                    Ini.DeleteKey("REPLACESIGN");
                }
                if (check_rand.Checked)
                {
                    Ini.Write("TIME_RANDOM", "YES");
                }
                else
                {
                    Ini.DeleteKey("TIME_RANDOM");
                }
                Ini.Write("TB_VALUE", $"{tabcontrol_1.Value}");
                Ini.Write("NUM_1", $"{num_1.Value}");
                Ini.Write("NUM_2", $"{num_2.Value}");

                if (!Directory.Exists("Text")) Directory.CreateDirectory("Text");

                if (r_text_1.Text.Length != 0) File.WriteAllText(file1, text_1);
                if (r_text_2.Text.Length != 0) File.WriteAllText(file2, text_2);
                if (r_text_3.Text.Length != 0) File.WriteAllText(file3, text_3);
                if (r_text_4.Text.Length != 0) File.WriteAllText(file4, text_4);
                if (r_text_5.Text.Length != 0) File.WriteAllText(file5, text_5);
                if (r_text_6.Text.Length != 0) File.WriteAllText(file6, text_6);

                if (ch_text.Checked) Ini.Write("TEXT_REPLACE", "TRUE");
                else Ini.Write("TEXT_REPLACE", "FALSE");

                if (textBox_rnd_nickname.Text != "ваш передний текст (не ник)")
                    Ini.Write("TEXT_1_RND_NICKNAME", textBox_rnd_nickname.Text);

                if (ch_random_nickname.Checked)
                {
                    Ini.Write("RND_NICKNAME", "YES");
                }
                else
                {
                    Ini.DeleteKey("RND_NICKNAME");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"{er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadSetting()
        {
            try
            {
                if (File.Exists(inifile))
                {
                    var Ini = new IniFile(inifile);
                    string SENDING = Ini.Read("SENDING");
                    string ENCODING = Ini.Read("ENCODING");
                    string REPLACESIGN = Ini.Read("REPLACESIGN");
                    string TIME_RANDOM = Ini.Read("TIME_RANDOM");
                    string TB_VALUE = Ini.Read("TB_VALUE");
                    string NUM_1 = Ini.Read("NUM_1");
                    string NUM_2 = Ini.Read("NUM_2");
                    string TEXT_REPLACE = Ini.Read("TEXT_REPLACE");
                    string RND_NICKNAME = Ini.Read("RND_NICKNAME");
                    string TEXT_1_RND_NICKNAME = Ini.Read("TEXT_1_RND_NICKNAME");

                    if (SENDING == "SIMPLE") rb_st.Checked = true;
                    if (SENDING == "RAND1") rb_text1.Checked = true;
                    if (SENDING == "RAND2") rb_text2.Checked = true;
                    if (ENCODING == "1251") rb_windows_1251.Checked = true;
                    if (ENCODING == "UTF8") rb_utf8.Checked = true;
                    if (REPLACESIGN == "YES") ch_text.Checked = true;
                    if (TIME_RANDOM == "YES") check_rand.Checked = true;
                    if (TB_VALUE.Length > 0)
                    {
                        tabcontrol_1.Value = int.Parse(TB_VALUE);
                        link_l_1.Text = TB_VALUE;
                    }
                    if (NUM_2.Length > 0) num_2.Value = int.Parse(NUM_2);
                    if (NUM_1.Length > 0) num_1.Value = int.Parse(NUM_1);

                    if (Directory.Exists("Text"))
                    {
                        if (File.Exists(file1) && File.ReadAllText(file1).Length != 0)
                        {
                            text_1 = File.ReadAllText(file1);
                            r_text_1.Text = text_1;
                        }
                        if (File.Exists(file2) && File.ReadAllText(file2).Length != 0)
                        {
                            text_2 = File.ReadAllText(file2);
                            r_text_2.Text = text_2;
                        }
                        if (File.Exists(file3) && File.ReadAllText(file3).Length != 0)
                        {
                            text_3 = File.ReadAllText(file3);
                            r_text_3.Text = text_3;
                        }
                        if (File.Exists(file4) && File.ReadAllText(file4).Length != 0)
                        {
                            text_4 = File.ReadAllText(file4);
                            r_text_4.Text = text_4;
                        }
                        if (File.Exists(file5) && File.ReadAllText(file5).Length != 0)
                        {
                            text_5 = File.ReadAllText(file5);
                            r_text_5.Text = text_5;
                        }
                        if (File.Exists(file6) && File.ReadAllText(file6).Length != 0)
                        {
                            text_6 = File.ReadAllText(file6);
                            r_text_6.Text = text_6;
                        }
                    }

                    if (TEXT_REPLACE == "TRUE") ch_text.Checked = true;
                    else if (TEXT_REPLACE == "FALSE") ch_text.Checked = false;

                    if (textBox_rnd_nickname.Text.Length > 0) Ini.Write("TEXT_1_RND_NICKNAME", textBox_rnd_nickname.Text);

                    if (RND_NICKNAME == "YES")
                    {
                        ch_random_nickname.Checked = true;
                    }

                    if (TEXT_1_RND_NICKNAME.Length > 0)
                    {
                        textBox_rnd_nickname.Text = TEXT_1_RND_NICKNAME;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"{er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        //
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            try
            {
                activation = false;
                labeltext_check.ForeColor = Color.Red;
                labeltext_check.Text = "OFF";
                gb_setting_1.Enabled = true;
                groupBox1.Enabled = true;
                gb_setting_2.Enabled = true;
                gb_text.Enabled = true;
                start_button.Enabled = true;
            }
            catch (Exception er)
            {
                MessageBox.Show($"Ошибка в методе деактивации: \n {er}", "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}