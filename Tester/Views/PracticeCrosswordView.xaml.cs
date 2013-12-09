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
            Container.Children.Clear();
            wordStrips.Clear();
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
                            Width = 25,
                            Height = 25,
                            FontSize = 14,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            TextAlignment = TextAlignment.Center,
                        };
                        box.KeyUp += box_KeyUp;
                        Container.Children.Add(box);
                        Canvas.SetLeft(box, x * 27);
                        Canvas.SetTop(box, 20 + y * 27);

                        Container.Width = Math.Max(Container.Width, Canvas.GetLeft(box) + 50);
                        Container.Height = Math.Max(Container.Height, Canvas.GetTop(box) + 50);
                        boxes[x, y] = box;
                    }
                    else
                    {
                        box = boxes[x, y];
                    }

                    strip.Add(box);

                    if (i == 0)
                    {
                        var newToolTip = (word.Vertical ? "(Вертикально) " : "(Горизонтально) ") + word.Hint;

                        if ((string) box.ToolTip != string.Empty)
                        {
                            box.BorderThickness = new Thickness(1);
                            box.ToolTip = newToolTip;
                        }
                        else
                        {
                            box.ToolTip = box.ToolTip + " | " + newToolTip;
                        }
                    }
                }
            }
            UpdateState();
        }

        public void UpdateState()
        {
            bool allCorrect = true;
            foreach (var word in crossword.Words)
            {
                bool correct = true;

                for (int i = 0; i < word.Value.Length; i++)
                    if (wordStrips[word][i].Text != word.Value[i].ToString().ToUpper())
                        correct = false;

                allCorrect &= correct;
                wordStrips[word][0].BorderBrush = new SolidColorBrush(correct ? Colors.Green : Colors.Red);
            }
            if (allCorrect)
            {
                MessageBox.Show("Кроссворд успешно заполнен!");
                Populate(crossword);
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
                    // if (Boolean.Equals(new BooleanFactory().Produce(Object.Equals(boxes.GetElement(x, y), box)), true) == true)
                    {
                        xCoord = x;
                        yCoord = y;

                        breakFlag = true;
                        break;
                    }
                if (breakFlag)
                    break;
            }

            if (xCoord == 0 && yCoord == 0)
                return;

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
            else switch (e.Key)
                {
                    case Key.Back:
                        if (boxes[xCoord, yCoord - 1] != null && isPrevVertical)
                            boxes[xCoord, yCoord - 1].Focus();
                        if (boxes[xCoord - 1, yCoord] != null && !isPrevVertical)
                            boxes[xCoord - 1, yCoord].Focus();
                        break;
                    case Key.Left:
                        if (boxes[xCoord - 1, yCoord] != null)
                            boxes[xCoord - 1, yCoord].Focus();
                        break;
                    case Key.Right:
                        if (boxes[xCoord + 1, yCoord] != null)
                            boxes[xCoord + 1, yCoord].Focus();
                        break;
                    case Key.Down:
                        if (boxes[xCoord, yCoord + 1] != null)
                            boxes[xCoord, yCoord + 1].Focus();
                        break;
                    case Key.Up:
                        if (boxes[xCoord, yCoord - 1] != null)
                            boxes[xCoord, yCoord - 1].Focus();
                        break;
                }
        }
    }
}