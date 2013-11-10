using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Data;

namespace Tester
{
    public class RootViewModel : Conductor<object>
    {
        public List<Section> Sections { get; set; }
        public Section CurrentSection { get; set; }

        public RootViewModel()
        {
            Sections = new List<Section>();

            var test = new Test()
            {
                Description = "testing test object",
                Name = "Test test",
                Questions = new List<Question>()
                {
                    new Question() {
                        AnswersList = new List<Tuple<string, bool>>()
                        {
                            new Tuple<string, bool>("test answer1 true", true),
                            new Tuple<string, bool>("test answer2 false", false)
                        }
                    },
                    new Question(QuestionType.MultiChoise) {
                        AnswersList = new List<Tuple<string, bool>>()
                        {
                            new Tuple<string, bool>("test answer1 true", true),
                            new Tuple<string, bool>("test answer2 false", false),
                            new Tuple<string, bool>("test answer2 false", false),
                            new Tuple<string, bool>("test answer2 true", true)
                        }
                    }
                }
            };

            for (int i = 0; i < 10; ++i)
            {
                Sections.Add(new Section()
                {
                    Name = "Test Section a lot of text and more " + (i+1),
                    Test = test,
                    TheoryText = "some html text"
                });
            }

            CurrentSection = Sections.First();
            
        }
    }
}
