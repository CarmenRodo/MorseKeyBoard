using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms;

namespace MorseKeyBoard
{
    public partial class MainPage : ContentPage
    {
        private StringBuilder morseCodeBuilder = new StringBuilder();

        public MainPage()
        {
            InitializeComponent();
        }

        private void AppendMorseCode(string symbol)
        {
            morseCodeBuilder.Append(symbol);
            morseCodeOutput.Text = morseCodeBuilder.ToString();
            morseCodeOutput2.Text = morseCodeBuilder.ToString();
        }

        private void OnDotClicked(object sender, EventArgs e)
        {
            AppendMorseCode(".");
        }

        private void OnDashClicked(object sender, EventArgs e)
        {
            AppendMorseCode("-");
        }

        private void OnSpaceClicked(object sender, EventArgs e)
        {

            AppendMorseCode(" ");
            TranslateMorseCode();
            morseCodeBuilder.Clear();
        }

        private void OnBackspaceClicked(object sender, EventArgs e)
        {
            if (morseCodeBuilder.Length > 0)
            {
                morseCodeBuilder.Remove(morseCodeBuilder.Length - 1, 1);
                morseCodeOutput.Text = morseCodeBuilder.ToString();
                morseCodeOutput2.Text = morseCodeBuilder.ToString();
            }
        }
        private void OnClearTextClicked(object sender, EventArgs e)
        {
            textOutput.Text = "";
            textOutput2.Text = "";
        }



        private void TranslateMorseCode()
        {
            string morseCode = morseCodeBuilder.ToString().Trim();
            if (!string.IsNullOrEmpty(morseCode))
            {
                char translatedChar = Morse.MorseCoder(morseCode);
                textOutput.Text += translatedChar;
                textOutput2.Text += translatedChar;
            }
        }
    }
}
