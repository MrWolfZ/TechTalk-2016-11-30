using System;

namespace FunctionalDecomposition.Areas.HelpPage.SampleGeneration
{
  /// <summary>
  ///   This represents an invalid sample on the help page. There's a display template named InvalidSample associated with
  ///   this class.
  /// </summary>
  public class InvalidSample
  {
    public InvalidSample(string errorMessage)
    {
      if (errorMessage == null)
      {
        throw new ArgumentNullException(nameof(errorMessage));
      }
      this.ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; }

    public override bool Equals(object obj)
    {
      var other = obj as InvalidSample;
      return other != null && this.ErrorMessage == other.ErrorMessage;
    }

    public override int GetHashCode()
    {
      return this.ErrorMessage.GetHashCode();
    }

    public override string ToString()
    {
      return this.ErrorMessage;
    }
  }
}
