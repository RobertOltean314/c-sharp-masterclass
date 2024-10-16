using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public List<string> ProcessAll(List<string> words)
        {
            var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

            List<string> result = words;
            foreach (var stringsProcessor in stringsProcessors)
            {
                result = stringsProcessor.Process(result);
            }
            return result;
        }
    }

    public class StringsProcessor
    {
        public virtual List<string> Process(List<string> words)
        {
            return words;
        }
    }
    public class StringsTrimmingProcessor : StringsProcessor
    {
        public override List<string> Process(List<string> words)
        {
            List<string> wordsTrimmed = new List<string>();
            foreach (var word in words)
            {
                wordsTrimmed.Add(word.Substring(word[0], word.Length / 2));
            }
            return wordsTrimmed;
        }
    }
    public class StringsUppercaseProcessor : StringsProcessor
    {
        public override List<string> Process(List<string> words)
        {
            List<string> wordsUppercase = new List<string>();
            foreach (var word in words)
            {
                wordsUppercase.Add(word.ToUpper());
            }
            return wordsUppercase;
        }
    }
}
