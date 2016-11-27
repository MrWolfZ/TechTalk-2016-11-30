using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VolatilityDecomposition.External.GoogleBooks.DataTransferObjects;

namespace VolatilityDecomposition.External.GoogleBooks
{
  public interface IGoogleBooksService
  {
    Task<ICollection<Book>> Search(string searchTerm);
    Task<ICollection<Book>> Get(IEnumerable<string> ids);
    Task<ICollection<Book>> Get(string id);
  }

  internal class GoogleBooksesApiBooksService : IGoogleBooksService
  {
    public async Task<ICollection<Book>> Search(string q)
    {
      using (var client = new HttpClient())
      {
        var resp = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={q}&langRestrict=en&maxResults=40");
        var collection = JsonConvert.DeserializeObject<GoogleBooksVolumeCollectionDto>(resp);
        return collection.Items.Where(dto => dto.SaleInfo?.RetailPrice != null).Select(Convert).ToList();
      }
    }

    public async Task<ICollection<Book>> Get(IEnumerable<string> ids)
    {
      using (var client = new HttpClient())
      {
        // ReSharper disable once AccessToDisposedClosure
        return await Task.WhenAll(ids.Select(id => GetVolumeById(client, id)));
      }
    }

    public Task<ICollection<Book>> Get(string id) => this.Get(new[] { id });

    private static async Task<Book> GetVolumeById(HttpClient client, string id)
    {
      var resp = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes/{id}");
      var dto = JsonConvert.DeserializeObject<GoogleBooksVolumeDto>(resp);
      return Convert(dto);
    }

    private static Book Convert(GoogleBooksVolumeDto dto) => new Book
    {
      Id = dto.Id,
      Title = dto.VolumeInfo.Title,
      ThumbnailUrl = dto.VolumeInfo.ImageLinks?.Thumbnail,
      Price = new Price
      {
        Amount = dto.SaleInfo?.RetailPrice?.Amount ?? 0,
        CurrencyCode = dto.SaleInfo?.RetailPrice?.CurrencyCode
      }
    };
  }
}
