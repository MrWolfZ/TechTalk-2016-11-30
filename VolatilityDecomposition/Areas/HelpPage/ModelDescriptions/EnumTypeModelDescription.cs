using System.Collections.ObjectModel;

namespace VolatilityDecomposition.Areas.HelpPage.ModelDescriptions
{
  public class EnumTypeModelDescription : ModelDescription
  {
    public EnumTypeModelDescription()
    {
      this.Values = new Collection<EnumValueDescription>();
    }

    public Collection<EnumValueDescription> Values { get; private set; }
  }
}
