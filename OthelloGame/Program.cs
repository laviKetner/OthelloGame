using System;
using System.Drawing;
using System.Windows.Forms;
namespace Ex02_Othelo
{
    public class Program
    {
        public static void Main()
        {
            FormOpeningLogo formOpeningLogo = new FormOpeningLogo();

            OtheloGameManager gameUI = new OtheloGameManager();
            gameUI.RunGame();
        }
    }
}