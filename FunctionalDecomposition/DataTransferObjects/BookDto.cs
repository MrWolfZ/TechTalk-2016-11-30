using System.ComponentModel.DataAnnotations;

namespace FunctionalDecomposition.DataTransferObjects
{
  public sealed class BookDto
  {
    [Required]
    public string Id { get; set; }

    public string Title { get; set; }
    public string ThumbnailUrl { get; set; }
    public PriceDto Price { get; set; }
  }
}
