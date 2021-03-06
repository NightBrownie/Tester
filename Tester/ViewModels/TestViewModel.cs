﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public class TestViewModel : Conductor<object>
    {
        private List<Tuple<Question, bool>> mainQuestionsList = new List<Tuple<Question, bool>>();
        private HashSet<int> skippedQuestions = new HashSet<int>();

        private Test Test { get; set; }
        private BaseQuestionViewModel currentQuestionViewModel = null;
        
        private Visibility _startTestButtonVisibility;
        private Visibility _nextQuestionButtonVisibility;
        private Visibility _toHomePageButtonVisibility;

        private Random rand = new Random((int)DateTime.Now.Ticks);
        private int _currentQuestionNumber;
        private int _skippedQuestionsCount;
        private int _failedQuestionsCount;
        private bool _isSkipButtonEnabled;

        public Visibility StartTestButtonVisibility
        {
            get { return _startTestButtonVisibility; }
            set
            {
                _startTestButtonVisibility = value;
                NotifyOfPropertyChange(() => StartTestButtonVisibility);
            }
        }

        public Visibility NextQuestionButtonVisibility
        {
            get { return _nextQuestionButtonVisibility; }
            set
            {
                _nextQuestionButtonVisibility = value;
                NotifyOfPropertyChange(() => NextQuestionButtonVisibility);
            }
        }

        public Visibility ToHomePageButtonVisibility
        {
            get { return _toHomePageButtonVisibility; }
            set
            {
                _toHomePageButtonVisibility = value;
                NotifyOfPropertyChange(() => ToHomePageButtonVisibility);
            }
        }

        public int QuestionCount { get { return Test.Questions.Count; } }

        public int CurrentQuestionNumber
        {
            get { return _currentQuestionNumber; }
            set
            {
                _currentQuestionNumber = value; 
                NotifyOfPropertyChange(() => CurrentQuestionNumber);
            }
        }

        //shows message and max question count in button
        public string SkipQuestionButtonText
        {
            get
            {
                return "Ответить на этот вопрос позже"
                       + ((Test.MaxSkippedQuestions != 0)
                           ? ("(" + (Test.MaxSkippedQuestions - _skippedQuestionsCount) + ")")
                           : String.Empty);
            }
        }

        public bool IsSkipButtonEnabled
        {
            get { return _isSkipButtonEnabled; }
            set
            {
                _isSkipButtonEnabled = value; 
                NotifyOfPropertyChange(() => IsSkipButtonEnabled);
            }
        }

        public bool IsInProgress { get { return NextQuestionButtonVisibility == Visibility.Visible; } }

        public TestViewModel(Test test)
        {
            Test = test;

            StartTestButtonVisibility = Visibility.Visible;
            NextQuestionButtonVisibility = Visibility.Collapsed;
            ToHomePageButtonVisibility = Visibility.Collapsed;

            ActivateItem(new TestMainViewModel(Test));
        }

        public void StartTestButton()
        {
            CurrentQuestionNumber = 1;
            _failedQuestionsCount = 0;
            _skippedQuestionsCount = 0;
            NotifyOfPropertyChange(() => SkipQuestionButtonText);

            skippedQuestions.Clear();
            mainQuestionsList.Clear();

            //choose first question
            ChooseNextQuestion();

            StartTestButtonVisibility = Visibility.Collapsed;
            NextQuestionButtonVisibility = Visibility.Visible;
            IsSkipButtonEnabled = true;
        }

        public void NextQuestionButton()
        {
            //add index to completed 
            mainQuestionsList.Add(new Tuple<Question, bool>(currentQuestionViewModel.Question,
                currentQuestionViewModel.Check()));

            if (!currentQuestionViewModel.Check())
                ++_failedQuestionsCount;

            //remove item from skipped if it
            skippedQuestions.Remove(Test.Questions.IndexOf(currentQuestionViewModel.Question));

            //increment question Numb
            CurrentQuestionNumber++;

            //checks for questions count
            //also checks if max fail answers property is setted, if it then checks for max fail answers
            if ((mainQuestionsList.Count < QuestionCount)
                && (Test.MaxFailAnswers == 0 || _failedQuestionsCount < Test.MaxFailAnswers))
                ChooseNextQuestion();
            else
            {
                var finishTestVM = new TestFinishViewModel(QuestionCount, Test.MaxFailAnswers != 0);
                
                foreach (var tuple in mainQuestionsList.Where(q => q.Item2))
                    finishTestVM.ResultAnswers.Add(new Tuple<string, List<string>>(tuple.Item1.Text,
                        new List<string>(tuple.Item1.Answers.Where(a => a.Correct).Select(a => a.Text))));

                ActivateItem(finishTestVM);

                ToHomePageButtonVisibility = Visibility.Visible;
                NextQuestionButtonVisibility = Visibility.Collapsed;
            }
        }

        public void SkipQuestionButton()
        {
            ++_skippedQuestionsCount;
            NotifyOfPropertyChange(() => SkipQuestionButtonText);
            if (Test.MaxSkippedQuestions != 0 
                && _skippedQuestionsCount == Test.MaxSkippedQuestions)
                IsSkipButtonEnabled = false;

            skippedQuestions.Add(Test.Questions.IndexOf(currentQuestionViewModel.Question));
            ChooseNextQuestion();
        }

        public void ToHomePageButton()
        {
            ActivateItem(new TestMainViewModel(Test));
            ToHomePageButtonVisibility = Visibility.Collapsed;
            StartTestButtonVisibility = Visibility.Visible;
        }

        private void ChooseNextQuestion()
        {
            //search for new number
            //in first case we search for question if not all question is viewed
            //in second case we iterate trough skipped questions
            var nextQuestionNumber = rand.Next(QuestionCount);
            if ((mainQuestionsList.Count + skippedQuestions.Count) != QuestionCount)
                while (mainQuestionsList.Select(tuple => tuple.Item1).Contains(Test.Questions[nextQuestionNumber])
                    && !skippedQuestions.Contains(nextQuestionNumber))
                    nextQuestionNumber = rand.Next(QuestionCount);
            else
                while (mainQuestionsList.Select(tuple => tuple.Item1).Contains(Test.Questions[nextQuestionNumber]))
                    nextQuestionNumber = rand.Next(QuestionCount);

            if (Test.Questions[nextQuestionNumber].Type == QuestionType.SingleChoice)
                currentQuestionViewModel = new SingleChoiceQuestionViewModel(Test.Questions[nextQuestionNumber]);
            else
                currentQuestionViewModel = new MultiChoiceQuestionViewModel(Test.Questions[nextQuestionNumber]);

            ActivateItem(currentQuestionViewModel);
        }
    }
}