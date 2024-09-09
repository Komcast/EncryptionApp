using System;
using System.Windows;
using System.Windows.Controls;

namespace EncryptionApp
{
    public partial class MainWindow : Window
    {
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            int shift = CountLetters(message);
            string encryptedMessage = Encrypt(message, shift);
            EncryptedTextBox.Text = encryptedMessage;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string message = EncryptedTextBox.Text;
            int shift = CountLetters(MessageTextBox.Text);
            string decryptedMessage = Decrypt(message, shift);
            MessageTextBox.Text = decryptedMessage;
        }

        // Подсчитывает количество букв в строке
        private int CountLetters(string message)
        {
            int count = 0;
            foreach (char c in message)
            {
                if (Char.IsLetter(c))
                {
                    count++;
                }
            }
            return count;
        }

        // Шифрует сообщение с помощью шифра Цезаря
        private string Encrypt(string message, int shift)
        {
            string result = "";
            foreach (char c in message)
            {
                if (Char.IsLetter(c))
                {
                    char baseChar = Char.IsUpper(c) ? 'A' : 'a';
                    int shiftedChar = ((c - baseChar + shift) % 26) + baseChar;
                    result += (char)shiftedChar;
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        // Дешифрует сообщение с помощью шифра Цезаря
        private string Decrypt(string message, int shift)
        {
            string result = "";
            foreach (char c in message)
            {
                if (Char.IsLetter(c))
                {
                    char baseChar = Char.IsUpper(c) ? 'A' : 'a';
                    int shiftedChar = ((c - baseChar - shift + 26) % 26) + baseChar;
                    result += (char)shiftedChar;
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
    }
}