using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tester.Data;

namespace Tester.Views
{
    public partial class PracticeCrosswordView : UserControl
    {
        private Crossword crossword;
        private TextBox[,] boxes;
        private Dictionary<Crossword.Word, List<TextBox>> wordStrips = new Dictionary<Crossword.Word, List<TextBox>>();

        public PracticeCrosswordView()
        {
            InitializeComponent();
        }

        public void Populate(Crossword crossword)
        {
            this.crossword = crossword;
            boxes = new TextBox[64, 64];

            foreach (var word in crossword.Words)
            {
                var strip = new List<TextBox>();
                wordStrips[word] = strip;
                for (int i = 0; i < word.Value.Length; i++)
                {
                    var x = word.X + (word.Vertical ? 0 : i);
                    var y = word.Y + (word.Vertical ? i : 0);

                    TextBox box = null;
                    if (boxes[x, y] == null)
                    {
                        box = new TextBox
                        {
                            Width = 30,
                            Height = 30,
                            FontSize = 20,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            TextAlignment = TextAlignment.Center,
                        };
                        box.KeyUp += box_KeyUp;
                        Container.Children.Add(box);
                        Canvas.SetLeft(box, 50 + x * 40);
                        Canvas.SetTop(box, 50 + y * 40);
                        boxes[x, y] = box;
                    }
                    else
                    {
                        box = boxes[x, y];
                    }

                    strip.Add(box);

                    if (i == 0)
                    {
                        box.BorderThickness = new Thickness(3);
                        box.ToolTip = word.Hint;
                    }
                }
            }
            UpdateState();
        }

        public void UpdateState()
        {
            foreach (var word in crossword.Words)
            {
                bool correct = true;

                for (int i = 0; i < word.Value.Length; i++)
                    if (wordStrips[word][i].Text != word.Value[i].ToString().ToUpper())
                        correct = false;

                wordStrips[word][0].BorderBrush = new SolidColorBrush(correct ? Colors.Green : Colors.Red);
            }
        }

        void box_KeyUp(object sender, KeyEventArgs e)
        {
            var box = sender as TextBox;
            if (box.Text.Length > 0)
                box.Text = box.Text.Substring(box.Text.Length - 1).ToUpper();
            box.SelectAll();
            UpdateState();
            for (int y = 0; y < boxes.GetLength(0); y++)
                for (int x = 0; x < boxes.GetLength(0) - 1; x++)
                    if (boxes[x, y] == box && boxes[x + 1, y] != null)
                        boxes[x + 1, y].Focus();
        }
    }
}
