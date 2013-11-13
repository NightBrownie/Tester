using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Tester.Data
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public QuestionType Type { get; set; }

        /// <summary>
        /// Each answer is a tuple, first item in tuple is a answer text
        /// second item is bool flat to show is it right answer for current question
        /// </summary>
        [DataMember]
        public List<Answer> Answers;

        public Question(QuestionType type = QuestionType.SingleChoice)
        {
            Answers = new List<Answer>();
            Type = type;
        }
    }
}
