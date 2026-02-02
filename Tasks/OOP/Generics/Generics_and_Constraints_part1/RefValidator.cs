namespace Generics_and_Constraints_part1
{
    public class RefValidator<T> where T : class
    {
        private T _text;
        public RefValidator(T text)
        {
            _text = text;
        }
        
        public bool IsNull()
        {
            return _text == null;
        }
    }
}
