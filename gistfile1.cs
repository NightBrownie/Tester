using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tester.Data;

namespace Tester.Views
{
    public partial class PracticeCrosswordView : UserControl
    {
        private Crossword crossword;
        private TextBox[,] boxes;
        private readonly Dictionary<Crossword.Word, List<TextBox>> wordStrips = new Dictionary<Crossword.Word, List<TextBox>>();
        private bool isPrevVertical;

        private static readonly List<Key> AllowedKeys = new List<Key>
            {
                Key.OemMinus, // -
                Key.OemOpenBrackets, // Х
                Key.OemCloseBrackets, // Ъ
                Key.OemSemicolon, // Ж
                Key.OemQuotes, // Э
                Key.OemComma, // Б
                Key.OemPeriod, // Ю
            };

        public PracticeCrosswordView()
        {
            InitializeComponent();
        }

        public void Populate(Crossword crossword)
        {
            this.crossword = crossword;
            boxes = new TextBox[64, 64];
            isPrevVertical = false;
            
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

                        Container.Width = Math.Max(Container.Width, Canvas.GetLeft(box) + 100);
                        Container.Height = Math.Max(Container.Height, Canvas.GetTop(box) + 100);
                        boxes[x, y] = box;
                    }
                    else
                    {
                        box = boxes[x, y];
                    }

                    strip.Add(box);

                    if (i == 0)
                    {
                        box.BorderThickness = new Thickness(1);
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

            if (box == null)
                throw new NoNullAllowedException("box");

            if (box.Text.Length > 0)
                box.Text = box.Text.Substring(box.Text.Length - 1).ToUpper();
            box.SelectAll();
            UpdateState();

            var xCoord = 0;
            var yCoord = 0;

            //Поиск бокса
            for (var y = 0; y < boxes.GetLength(0); ++y)
            {
                var breakFlag = false;
                for (var x = 0; x < boxes.GetLength(0) - 1; ++x)
                    if (Equals(boxes[x, y], box))
                    {
                        xCoord = x;
                        yCoord = y;

                        breakFlag = true;
                        break;
                    }
                if (breakFlag)
                    break;
            }

            //Проверка на первый символ слова
            if (boxes[xCoord, yCoord - 1] == null && boxes[xCoord - 1, yCoord] == null)
                isPrevVertical = boxes[xCoord, yCoord + 1] != null;

            //Проверки на последний символ
            if (isPrevVertical && boxes[xCoord, yCoord + 1] == null)
                isPrevVertical = false;

            if (!isPrevVertical && boxes[xCoord + 1, yCoord] == null)
                isPrevVertical = true;
            
            //Действие в зависимости от нажатой кнопки
            if (e.Key >= Key.A && e.Key <= Key.Z || AllowedKeys.Contains(e.Key))
            {
                if (boxes[xCoord, yCoord + 1] != null && isPrevVertical)
                    boxes[xCoord, yCoord + 1].Focus();
                if (boxes[xCoord + 1, yCoord] != null && !isPrevVertical)
                    boxes[xCoord + 1, yCoord].Focus();
            }
            else if (e.Key == Key.Back)
            {
                if (boxes[xCoord, yCoord - 1] != null && isPrevVertical)
                    boxes[xCoord, yCoord - 1].Focus();
                if (boxes[xCoord - 1, yCoord] != null && !isPrevVertical)
                    boxes[xCoord - 1, yCoord].Focus();
            }
        }
    }
}
