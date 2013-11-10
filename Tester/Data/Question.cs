using System;
using System.Collections.Generic;

namespace Tester.Data
{
    public class Question                                                                                              
    {
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }

        /// <summary>
        /// Each answer is a tuple, first item in tuple is a answer text
        /// second item is bool flat to show is it right answer for current question
        /// </summary>
        public List<Tuple<string, bool>> AnswersList;

        public Question(QuestionType questionType = QuestionType.SingleChoise)
        {
            AnswersList = new List<Tuple<string, bool>>();
            QuestionType = questionType;
        }
    }
}
