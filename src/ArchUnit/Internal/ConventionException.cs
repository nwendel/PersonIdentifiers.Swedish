namespace ArchUnit.Internal;

// TODO: XUnit reporter will include full type name in message
//       So initialize message with a newline so that error message is written first on the next line
//       Alternativley place this class in XUnit.Sdk namespace to avoid it
//       https://github.com/xunit/xunit/blob/93616f73fc2c5a1dca11963a41d52ce9e51f1bb3/src/common/ExceptionUtility.cs#L24
//       Not sure what is best if I want to make this a real library where
//       I want to avoid xunit specific stuff
public class ConventionException : Exception
{
    public ConventionException(string message)
        : base(Environment.NewLine + message)
    {
    }
}
