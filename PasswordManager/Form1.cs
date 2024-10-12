using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        private const string Key = "1234567890123456";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = GeneratePassword(12);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string encryptedPassword = EncryptString(txtPassword.Text);
            string decryptedPassword = DecryptString(encryptedPassword);

            File.AppendAllText("passwords.txt", $"{encryptedPassword}|{decryptedPassword}\n");
            MessageBox.Show("Пароль сохранён!");
        }

        private string GeneratePassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            Random random = new Random();
            char[] res = new char[length];
            for (int i = 0; i < length; i++)
            {
                res[i] = validChars[random.Next(validChars.Length)];
            }
            return new string(res);
        }

        private string EncryptString(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.GenerateIV();

                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptString(string cipherText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] cipher = new byte[fullCipher.Length - iv.Length];

                Array.Copy(fullCipher, iv, iv.Length);
                Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(cipher))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
