namespace Assets._Project.Develop.Runtime.Meta.Core
{
    public class Combination : ICombination
    {
        public Combination(string charCombination)
        {
            Value = charCombination;
        }

        public string Value { get; }
    }
}
